using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Enumerated.Kleren; //para mostrar selects con enums
using KlerenGen.ApplicationCore.Helpers; //para mostrar selects con enums
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.Infraestructure.CP;
using KlerenGen.Infraestructure.EN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate;
using NHibernate.SqlCommand;
using System.Linq;
using System.Security.Cryptography;
using web_kleren.Assemblers;
using web_kleren.Models;

namespace web_kleren.Controllers
{
    public class LinPedController : BasicController
    {
        // GET: LinpedController
        public ActionResult Index()
        {
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            SessionInitialize();
            //Esto es lo que va a salir por pantalla 
            if(usuarioId != 0)
            {
                PedidoRepository pedRepository = new PedidoRepository(session);
                PedidoCEN pedCEN = new PedidoCEN(pedRepository);

                IList<PedidoEN> pedidos = pedCEN.DamePedidosPorUsuario(usuarioId);
                //PedidoCEN pedidoEst = new PedidoCEN(pedRepository);
                PedidoEN pedidoEst = null;
                foreach (var pedido in pedidos)
                {
                    if ((int)pedido.Estado == 5)
                    {
                        pedidoEst = pedido;
                       // break; // Termina la búsqueda una vez encontrado
                    }
                }

                //LinPedRepository linRepository = new LinPedRepository(session);
                //LinPedCEN linCEN = new LinPedCEN(linRepository);
                //IList<LinPedViewModel> lineas = new List<LinPedViewModel>();

                if (pedidoEst != null)
                {
                    IList<LinPedEN> listEN = pedidoEst.LinPed;
                    IEnumerable<LinPedViewModel> listLins = new LinPedAssembler().ConvertirListENToViewModel(listEN).ToList();
                    SessionClose();
                    return View(listLins);

                }

            }
            
            SessionClose();
            return View(null); ;

        }

        public ActionResult Cesta()
        {
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            SessionInitialize();
            //Esto es lo que va a salir por pantalla 
            if (usuarioId != 0)
            {
                PedidoRepository pedRepository = new PedidoRepository(session);
                PedidoCEN pedCEN = new PedidoCEN(pedRepository);

                IList<PedidoEN> pedidos = pedCEN.DamePedidosPorUsuario(usuarioId);
                //PedidoCEN pedidoEst = new PedidoCEN(pedRepository);
                PedidoEN pedidoEst = null;
                foreach (var pedido in pedidos)
                {
                    if ((int)pedido.Estado == 5)
                    {
                        pedidoEst = pedido;
                        // break; // Termina la búsqueda una vez encontrado
                    }
                }

                //LinPedRepository linRepository = new LinPedRepository(session);
                //LinPedCEN linCEN = new LinPedCEN(linRepository);
                //IList<LinPedViewModel> lineas = new List<LinPedViewModel>();

                if (pedidoEst != null)
                {
                    IList<LinPedEN> listEN = pedidoEst.LinPed;
                    IEnumerable<LinPedViewModel> listLins = new LinPedAssembler().ConvertirListENToViewModel(listEN).ToList();
                    SessionClose();

                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new
                        {
                            lineas = listLins,
                            totalArticulos = listLins.Sum(item => item.Cantidad),
                            precioTotal = listLins.Sum(item => item.Precio)
                        });
                    }
                    return View(listLins);
                }

                SessionClose();
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { lineas = new List<LinPedViewModel>(), totalArticulos = 0, precioTotal = 0 });
                }
                return View(null);

            }

            SessionClose();
            return View(null); ;

        }

        [HttpPost]
        public JsonResult IncrementarCantidad(int lineaId)
        {
            JsonResult result = null;
            try
            {
                SessionInitialize();
                LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());

                if (linCP != null)
                {
                    linCP.Modificar(lineaId, 1, 0);
                    LinPedRepository linRepository = new LinPedRepository();
                    LinPedCEN linCEN = new LinPedCEN(linRepository);
                    LinPedEN linEN = linCEN.DamePorId(lineaId);
                    int cantidad = linEN.Cantidad;

                    result = Json(new { nuevaCantidad = cantidad });
                }
                else
                {
                    result = Json(new { error = "No se pudo incrementar la cantidad." });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { error = ex.Message });
            }
            finally
            {
                SessionClose();
            }

            return result;
        }


        [HttpPost]
        public JsonResult DecrementarCantidad(int lineaId)
        {
            JsonResult result = null;
            try
            {
                SessionInitialize();
                LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());
                LinPedRepository linRepository = new LinPedRepository();
                LinPedCEN linCEN = new LinPedCEN(linRepository);
                LinPedEN linEN = linCEN.DamePorId(lineaId);

                if (linCP != null && linEN.Cantidad > 1)
                {
                    linCP.Modificar(lineaId, -1,0);
                    // Obtenemos la cantidad actualizada
                    LinPedEN linENActualizado = linCEN.DamePorId(lineaId);
                    int cantidad = linENActualizado.Cantidad;

                    result = Json(new { nuevaCantidad = cantidad });
                }
                else
                {
                    result = Json(new { error = "La cantidad no puede ser menor que 1." });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { error = ex.Message });
            }
            finally
            {
                SessionClose();
            }

            return result;
        }


        public ActionResult ObtenerVistaEditarLinPed(int lineaId)
        {   /*
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
            ArticuloEN artEN = artCEN.DamePorId(id);
            DetalleArticuloViewModel artVM = new ArticuloAssembler().ConvertirENToDetalleViewModel(artEN, favorito, colores, tallas);
            */
            SessionInitialize();
            LinPedRepository linPedRepository = new LinPedRepository(session); 
            LinPedCEN linp = new LinPedCEN(linPedRepository);
            LinPedEN lin = linp.DamePorId(lineaId);
            VarianteEN variante = lin.Variante;
            ArticuloEN artEN = variante.Articulo;
            int ArtId = artEN.ArticuloId;
            ArticuloCP articulocp = new ArticuloCP(new SessionCPNHibernate());
            IList<ColorEN> colores = articulocp.DameColoresDelArticulo(ArtId);
            IList<TallaEN> tallas = articulocp.DameTallasDelArticulo(ArtId);

            LinpedEditarViewModel linE = new LinPedAssembler().ConvertirLinpedEditarENToViewModel(lin,colores,tallas);
            SessionClose();
            return PartialView("_EditarLinPed", linE);

        }

        [HttpPost]
        public IActionResult Editar(int lineaId, int ArtId, int ColorSel, int TallaSel)
          
        {
           
            SessionInitialize();
            LinPedRepository linPedRepository = new LinPedRepository();
            LinPedCEN linp = new LinPedCEN(linPedRepository);
            LinPedEN lin = linp.DamePorId(lineaId);
            if (lin != null)
            {
                
                LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());
                VarianteRepository varRepo = new VarianteRepository();
                VarianteCEN varianteCEN = new VarianteCEN(varRepo);
                VarianteEN var = varianteCEN.DamePorTallaYColorYArticulo(TallaSel, ColorSel, ArtId);
                //int varID = var.VarianteId;
                if (var != null)
                {
                    int varID = var.VarianteId;
                    linCP.Modificar(lineaId, 0, varID);
                    SessionClose();
                    return Json(new { success = true, message = "Línea de pedido actualizada con éxito" });
                }
                else
                {
                    // No se encontró la variante
                    SessionClose();
                    return Json(new { success = false, error = "No se encontró la variante especificada" });
                }
                //linCP.Modificar(lineaId, 0, varID);
                //SessionClose();

               // return Json(new { success = true }); // Devuelve un JSON indicando éxito
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SubirCantidad(int linId, int num)
        {

        }
        */
        // GET: LinpedController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LinpedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinpedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LinpedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LinpedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LinpedController/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: LinpedController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EliminarDeCesta(int lineaId)
        {
            try
            {
                SessionInitialize();
                LinPedRepository linRepository = new LinPedRepository();
                LinPedCEN linCEN = new LinPedCEN(linRepository);


                linCEN.Borrar(lineaId);
               
                SessionClose();
                // Redirigir a la vista de detalles del pedido o a la lista de artículos
                return RedirectToAction("Cesta"); // O la acción correspondiente
            }
            catch
            {
                // Si ocurre un error, vuelve a mostrar la vista con un mensaje de error
                return View();
            }
        }

    }
}
