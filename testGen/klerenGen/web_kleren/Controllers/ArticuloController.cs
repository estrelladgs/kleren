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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using web_kleren.Assemblers;
using web_kleren.Models;
using static log4net.Appender.ColoredConsoleAppender;


namespace web_kleren.Controllers
{

    public class ArticuloController : BasicController
    {
        //GET: ArticuloController
        public object Index()
        {
            Console.WriteLine("Muestro el index...");


            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }


          //usuarioId = 294912; //BORRAR!!!

            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            IList<ArticuloEN> listEN = artCEN.DameTodos(0, -1);
            NHibernateUtil.Initialize(listEN);


            bool favorito;
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();

            foreach (var articulo in listEN)
            {
                 favorito = false;
                if (usuarioId != 0)
                {
                    int articuloId = articulo.ArticuloId;
                    ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, articuloId);
                    if (lista != null)
                    {
                        favorito = true;
                    }
                }

                ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito); 

                arts.Add(art);

            }
              
            SessionClose();

            return View(arts);
        }


        public object Home()
        {

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            IList<ArticuloEN> listEN = artCEN.DameTodos(0, -1);
            NHibernateUtil.Initialize(listEN);


            bool favorito;
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();

            foreach (var articulo in listEN)
            {
                favorito = false;
                if (usuarioId != 0)
                {
                    int articuloId = articulo.ArticuloId;
 
                    ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, articuloId);
     
                    if (lista != null)
                    {
                        favorito = true;
                    }
                }

                ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);

                arts.Add(art);

            }

            SessionClose();

            return View(arts);
        }

        //GET: Articulo por id Articulo/Detalles/oid
        public ActionResult Details(int id)
        {
            string tallaIdeal = string.Empty;

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            SessionInitialize();

            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
            ArticuloCP artCP = new ArticuloCP(session);

            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            ArticuloEN artEN = artCEN.DamePorId(id);
 
            bool favorito = false;
            if (usuarioId != 0)
            {
                ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, id);

                if (lista != null)
                {
                    favorito = true;
                }

                MedidasUsuarioRepository medidasUsuarioRepo = new MedidasUsuarioRepository(session);
                MedidasUsuarioCEN usuCEN = new MedidasUsuarioCEN(medidasUsuarioRepo);
                MedidasUsuarioCP medidasUsuarioCP = new MedidasUsuarioCP(new SessionCPNHibernate());

                MedidasUsuarioEN medidasUsu = usuCEN.DameMedidasUsuario((int)usuarioId);
                if(medidasUsu != null)
                {
                    tallaIdeal = medidasUsuarioCP.MostrarTallaIdeal(medidasUsu.MedidasUsuarioId, id);
                }
            }

            ArticuloCP articulocp = new ArticuloCP(new SessionCPNHibernate());
            IList<ColorEN> colores = articulocp.DameColoresDelArticulo(id);
            IList<TallaEN> tallas = articulocp.DameTallasDelArticulo(id);

            /*
            /// IList<ArticuloEN> articulosSimilares = arti
            /// 

            //ResenaRepository resenaRepo = new ResenaRepository(session);
            //ResenaCEN resenaCEN = new ResenaCEN(resenaRepo);

            //ImagenResenaRepository imgresenaRepo = new ImagenResenaRepository(session);
            //ImagenResenaCEN imgresenaCEN = new ImagenResenaCEN(imgresenaRepo);

            //IList<ResenaEN> resenas = resenaCEN.DameResenasPorArticulo(id);
            //IList<ImagenResenaEN> imgsResenas = new List<ImagenResenaEN>();
            //IList<ResenaVM> resenasVM = new List<ResenaVM>();

   

            //foreach (var resena in resenas)
            //{
            //    IList<ImagenResenaEN> imgsEN = imgresenaCEN.DameImagenesPorResena(resena.ResenaId);

            //    ResenaVM resenaVM = new ResenaAssembler().ConvertirENToViewModel(resena, imgsEN);
            //    resenasVM.Add(resenaVM);
            //}



            DetalleArticuloViewModel artVM = new ArticuloAssembler().ConvertirENToDetalleViewModel(artEN, favorito, colores, tallas, tallaIdeal);
            */

            // Seleccionar imagen inicial
            ImagenVarianteEN imgInicial = artEN.Variante
                .Select(v => v.ImagenVariante)
                .FirstOrDefault() ?? new ImagenVarianteEN
                {
                    RutaArchivo = "/images/no-image.png",
                    TextoAlternativo = "Sin imagen disponible"
                };


            DetalleArticuloViewModel artVM = new ArticuloAssembler()
                .ConvertirENToDetalleViewModel(artEN, favorito, colores, tallas, tallaIdeal);

            // Pasar la imagen inicial al modelo
            artVM.ImagenPrincipal = new ImagenVarianteViewModel
            {
                RutaArchivoString = imgInicial.RutaArchivo,
                TextoAlternativo = imgInicial.TextoAlternativo
            };

            SessionClose();

            return View(artVM);
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            // Obtener los valores de los enums y pasarlos a la vista
            ViewData["CategoriaOptions"] = EnumHelper.GetEnumSelectList<TipoPrendaEnum>();
            ViewData["SexoOptions"] = EnumHelper.GetEnumSelectList<SexoEnum>(); 
            ViewData["ParteOptions"] = EnumHelper.GetEnumSelectList<PartesEnum>();

            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloViewModel art)
        {
            try
            {
                ArticuloCP articulocp = new ArticuloCP(new SessionCPNHibernate());
                articulocp.Nuevo(art.Precio, art.Categoria, art.Sexo, art.Promocion, art.PrecioOferta, art.Nombre, art.Trazabilidad, art.Parte, art.StockInicial);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Filtrado por categoria y sexo
        public ActionResult FiltrarPorSexoYCategoria(string sexo, string categoria)
        {
            SessionInitialize();

            SexoEnum sexoEnum = (SexoEnum)Enum.Parse(typeof(SexoEnum), sexo, true);
            TipoPrendaEnum prendaEnum = (TipoPrendaEnum)Enum.Parse(typeof(TipoPrendaEnum), categoria, true);

            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            IList<ArticuloEN> articulosFiltradosEN = artCEN.DameArticulosPorSexoYTipoPrenda(sexoEnum, prendaEnum);

            bool favorito;
            IList<ArticuloViewModel> articulosFiltradosVM = new List<ArticuloViewModel>();

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            foreach (var articulo in articulosFiltradosEN)
            {
                favorito = false;
                if (usuarioId != 0)
                {
                    int articuloId = articulo.ArticuloId;

                    ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, articuloId);

                    if (lista != null)
                    {
                        favorito = true;
                    }
                }

                ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);

                articulosFiltradosVM.Add(art);

            }

            SessionClose();

            return View(articulosFiltradosVM);
        }


        // GET: Filtrado por promocion y sexo
        public ActionResult FiltrarPorPromocion(string sexo)
        {
            SessionInitialize();

            SexoEnum sexoEnum = (SexoEnum)Enum.Parse(typeof(SexoEnum), sexo, true);

            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            IList<ArticuloEN> articulosFiltradosEN = artCEN.DameArticulosEnPromocionPorSexo(sexoEnum);

            bool favorito;
            IList<ArticuloViewModel> articulosFiltradosVM = new List<ArticuloViewModel>();

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            foreach (var articulo in articulosFiltradosEN)
            {
                favorito = false;
                if (usuarioId != 0)
                {
                    int articuloId = articulo.ArticuloId;

                    ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, articuloId);

                    if (lista != null)
                    {
                        favorito = true;
                    }
                }

                ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);

                articulosFiltradosVM.Add(art);

            }

            SessionClose();

            return View(articulosFiltradosVM);
        }

        // GET: Filtrado por nombre
        public ActionResult FiltrarPorNombre(string nombre)
        {
            SessionInitialize();

            ViewBag.NombreBuscado = nombre;

            nombre = $"%{nombre}%";

            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);


            ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository(session);
            ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);

            IList<ArticuloEN> articulosFiltradosEN = artCEN.DameArticulosPorNombre(nombre);

            bool favorito;
            IList<ArticuloViewModel> articulosFiltradosVM = new List<ArticuloViewModel>();

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            foreach (var articulo in articulosFiltradosEN)
            {
                favorito = false;
                if (usuarioId != 0)
                {
                    int articuloId = articulo.ArticuloId;

                    ListaDeseosEN lista = listaDeseosCEN.DameListaDeDeseos((int)usuarioId, articuloId);

                    if (lista != null)
                    {
                        favorito = true;
                    }
                }

                ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);

                articulosFiltradosVM.Add(art);

            }

            SessionClose();

            return View(articulosFiltradosVM);
        }

        // GET: ArticuloController/Edit
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
            ArticuloEN artEN = artCEN.DamePorId(id);
            ArticuloViewModel artView = new ArticuloAssembler().ConvertirENToViewModel(artEN, true); //quitar el true
            SessionClose();

            // Obtener los valores de los enums y pasarlos a la vista
            ViewData["CategoriaOptions"] = EnumHelper.GetEnumSelectList<TipoPrendaEnum>();
            ViewData["SexoOptions"] = EnumHelper.GetEnumSelectList<SexoEnum>();
            ViewData["ParteOptions"] = EnumHelper.GetEnumSelectList<PartesEnum>();

            return View(artView);
        }

        // POST: ArticuloController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticuloViewModel art)
        {
            try
            {
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
                artCEN.Modificar(id, art.Precio, art.Categoria, art.Sexo, art.Promocion, art.PrecioOferta, art.Nombre, art.Trazabilidad, art.Parte);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            ArticuloRepository imgRepo = new ArticuloRepository();
            ArticuloCEN imgCEN = new ArticuloCEN(imgRepo);
            imgCEN.Borrar(id);
            return RedirectToAction(nameof(Index), new { id = id });
        }


        [HttpPost]
        public JsonResult MeterEnCesta(int ArtId, int ColorSel, int TallaSel)
        {
            if (ColorSel == 0 || TallaSel == 0)
            {
               
                return Json(new { success = false, message = "Por favor, selecciona tanto el color como la talla." });
            }
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
                return Json(new { success = false, message = "Por favor, regístrate o inicia sesión para añadir artículos a la cesta" });
            }


            SessionInitialize();
            //Esto es lo que va a salir por pantalla 
            if (usuarioId != 0)
            {
                int usuId = usuarioId.Value;
                PedidoRepository pedRepository = new PedidoRepository();
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
                VarianteRepository varRepo = new VarianteRepository();
                VarianteCEN var = new VarianteCEN(varRepo);
                VarianteEN vari = var.DamePorTallaYColorYArticulo(TallaSel, ColorSel, ArtId);
                LinPedRepository linRepository = new LinPedRepository();
                LinPedCEN lin = new LinPedCEN(linRepository);
                int varid = vari.VarianteId;
                

                if(pedidoEst == null)
                {
                    string a = "A";
                    DirEnvioRepository dirEnvioRepository = new DirEnvioRepository();
                    DirEnvioCEN dirEnv = new DirEnvioCEN(dirEnvioRepository);
                    int dirId = dirEnv.Nueva(a, 0, 0, 0, a, 0, a, a, usuId);
                    MetodoPagoRepository metodoPagoRepository = new MetodoPagoRepository();
                    MetodoPagoCEN met = new MetodoPagoCEN(metodoPagoRepository);
                    int metoId = met.Nuevo();
                    int pedidoId = pedCEN.Nuevo(dirId, metoId, usuId);
                    LinPedEN linea = lin.DamePorPedidoYVariante(varid, pedidoId);
                    if (linea == null)
                    {
                        if (vari.Stock >= 1)
                        {
                            LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());
                            linCP.Nueva(1, pedidoId, varid);
                            SessionClose();
                           
                            return Json(new { success = true, message = "Artículo añadido a la cesta" });

                        }


                    }


                } else
                {
                    int pedId = pedidoEst.PedidoId;
                    LinPedEN linea = lin.DamePorPedidoYVariante(varid, pedId);
                    if (linea == null)
                    {
                        if (vari.Stock >= 1)
                        {
                            LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());
                            linCP.Nueva(1, pedId, varid);
                            SessionClose();
                            return Json(new { success = true, message = "Artículo añadido a la cesta" });

                        }


                    } else
                    {
                        if (vari.Stock >= 1)
                        {
                            int linId = linea.LineaId;
                            LinPedCP linCP = new LinPedCP(new SessionCPNHibernate());
                            linCP.Modificar(linId, 1, varid);
                            SessionClose();
                            return Json(new { success = true, message = "Artículo añadido a la cesta" });

                        }
                    }

                }
                

            }else
            {
                SessionClose();
                
                return Json(new { success = false, message = "No se pudo añadir el artículo a la cesta" });

            }
            SessionClose();
            return Json(new { success = false, message = "No se pudo añadir el artículo a la cesta" });

        }
        public IActionResult GuiaTallas(int id)
        {
            return View(id);
        }

        [HttpGet]
        public JsonResult ComprobarStock(int tallaId, int colorId, int articuloId)
        {  
            bool tieneStock = false;

            VarianteRepository varRepo = new VarianteRepository();
            VarianteCEN var = new VarianteCEN(varRepo);
            VarianteEN varEN = var.DamePorTallaYColorYArticulo(tallaId, colorId, articuloId);

            if (varEN != null && varEN.Stock > 0)
            {
                tieneStock = true;
            }

            return Json(new { tieneStock });
        }

        /*
        [HttpGet]
        public JsonResult ObtenerImagenPorColor(int ColorSel, int articuloId)
        {
            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum colorSeleccionado = (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum)ColorSel;
            IList<VarianteEN> variantes = artCEN.DameVariantesPorColor(articuloId, colorSeleccionado);

            ImagenVarianteEN imgEN = variantes[0].ImagenVariante;

            ImagenVarianteViewModel imagen = new ImagenVarianteAssembler().ConvertirENToViewModel(imgEN);
            
            SessionClose();

            return Json(imagen);
        }
        */

        [HttpGet]
        public JsonResult ObtenerImagenPorColor(int ColorSel, int articuloId)
        {
            SessionInitialize();

            System.Console.WriteLine("ColorSel: " + ColorSel);
            System.Console.WriteLine("articuloId: " + articuloId);


            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);

            // Obtener las variantes por el color seleccionado
            KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum colorSeleccionado = (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum)ColorSel;
            IList<VarianteEN> variantes = artCEN.DameVariantesPorColor(articuloId, colorSeleccionado);

            // Validar si hay variantes disponibles
            ImagenVarianteViewModel imagen = null;
            if (variantes != null && variantes.Any())
            {
                ImagenVarianteEN imgEN = variantes.First().ImagenVariante; // Obtener la primera variante
                imagen = new ImagenVarianteAssembler().ConvertirENToViewModel(imgEN);
            }
            else
            {
                // Retornar una imagen genérica si no hay variantes disponibles
                imagen = new ImagenVarianteViewModel
                {
                    RutaArchivoString = "/images/no-image.png",
                    TextoAlternativo = "Sin imagen disponible"
                };
            }

            SessionClose();
            return Json(imagen);
        }


    }

}
