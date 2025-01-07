using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using NHibernate;
using NHibernate.Criterion;
using NuGet.Packaging.Signing;
using System.Text;
using web_kleren.Assemblers;
using web_kleren.Models;

namespace web_kleren.Controllers
{
    public class ListaDeseosController : BasicController
    {
        // GET: ListaDeseosController
        public ActionResult Index()
        {
            var usuarioId = GetUsuarioIdFromSession();
            if (usuarioId.HasValue)
            {
                SessionInitialize();

                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository(session);
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                IList<ArticuloEN> artsFavs = usuCEN.DameArticulosEnListaDeseos((int)usuarioId);

                IList<ArticuloViewModel> artsFavsVM = new List<ArticuloViewModel>();

                bool favorito = true;

                foreach (var articulo in artsFavs)
                {
                    ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);
                    artsFavsVM.Add(art);
                }

                SessionClose();
                return View(artsFavsVM);
            } else
            {
                return RedirectToAction("Home", "Articulo");
            }
            return View();
        }

        public ActionResult AvisoLogin()
        {
            return View();
        }

        // GET: ListaDeseosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaDeseosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaDeseosController/Create
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

        // GET: ListaDeseosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaDeseosController/Edit/5
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

        // GET: ListaDeseosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaDeseosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        // Para Agregar y Eliminar de favoritos
        [HttpPost]
        public JsonResult ToggleFavorito(int idArticulo, bool favorito)
        {
            var usuarioId = GetUsuarioIdFromSession();
            bool nuevoEstado;

            if (usuarioId.HasValue) 
            {
                // Obtener si el articulo esta o no actualmente en favoritos
                SessionInitialize();
                ListaDeseosRepository listaDeseosRepo = new ListaDeseosRepository();
                ListaDeseosCEN listaDeseosCEN = new ListaDeseosCEN(listaDeseosRepo);


                if (favorito)
                {
                    // Lógica para eliminar de favoritos
                    IList<ListaDeseosEN> listasEliminar = listaDeseosCEN.DameListaDeseosPorUsuarioYArticulo((int)usuarioId, idArticulo);
                    foreach(ListaDeseosEN item in listasEliminar)
                    {
                        listaDeseosCEN.Borrar(item.ListaDeseosID);
                    }
                    nuevoEstado = false;
                }
                else
                {
                    // Lógica para agregar a favoritos
                    int idLista = listaDeseosCEN.Nuevo((int)usuarioId, idArticulo);

                    nuevoEstado = true;
                }
               
                SessionClose();

                return Json(new { success = true, favorito = nuevoEstado });
            }

            return Json(new { success = false, message = "El usuario no ha iniciado sesion." });
        }

        // Compartir lista de deseos
        [HttpGet]
        public JsonResult Compartir()
        {
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                return Json(new { success = false, mensaje = "El usuario no ha iniciado sesion." });
            }

            // Generacion del toke
            var claveUnica = Guid.NewGuid().ToString();
            var rawToken = $"{usuarioId}-{claveUnica}";
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawToken));

            SessionInitialize();

            UsuarioRegistradoRepository usuarioRegistradoRepo = new UsuarioRegistradoRepository();
            UsuarioRegistradoCEN usuarioRegistradoCEN = new UsuarioRegistradoCEN(usuarioRegistradoRepo);

            usuarioRegistradoCEN.GuardarToken((int)usuarioId, token);

            string enlace = Url.Action("VerListaDeseos", "ListaDeseos", new { token = token }, protocol: Request.Scheme);

            SessionClose();

            return Json(new { success = true, enlace });
        }


        // Ver lista de deseos compartida
        [HttpGet]
        public ActionResult VerListaDeseos(string token)
        {
            var usuarioId = GetUsuarioIdFromSession();
 
            if (string.IsNullOrEmpty(token))
            {
                return View("ErrorKleren", "El enlace no es válido.");
            }

            string decodedToken;
            try
            {
                decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            }
            catch
            {
                return View("ErrorKleren", "El enlace no es válido.");
            }

            var partes = decodedToken.Split('-');
            if (partes.Length < 2)
            {
                return View("ErrorKleren", "El enlace no es válido.");
            }

            int propietarioId;
            string identificadorUnico;

            if (!int.TryParse(partes[0], out propietarioId) || string.IsNullOrEmpty(partes[1]))
            {
                return View("ErrorKleren", "El enlace no es válido.");
            }

            identificadorUnico = partes[1];

            SessionInitialize();


            // Validamos que el identificador único coincide con el generado
            UsuarioRegistradoRepository usuarioRegistradoRepo = new UsuarioRegistradoRepository();
            UsuarioRegistradoCEN usuarioRegistradoCEN = new UsuarioRegistradoCEN(usuarioRegistradoRepo);

            //var hashEsperado = usuarioRegistradoCEN.DameTokenPorUsuario(propietarioId); 
            UsuarioRegistradoEN remitenteEN = usuarioRegistradoCEN.DamePorId(propietarioId);
            var hashEsperado = remitenteEN.TokenCompartido;
            string nombreRemitente = remitenteEN.Nombre;

            if (hashEsperado != token)
            {
                SessionClose();
                return View("ErrorKleren", "El enlace no es válido o ha expirado.");
            }

            // Obtenemos la lista de deseos del usuario si todo ha ido bien
            IList<ArticuloEN> artsFavsRemitente = usuarioRegistradoCEN.DameArticulosEnListaDeseos(propietarioId);

            IList<ArticuloViewModel> artsFavsVM = new List<ArticuloViewModel>();

            bool favorito = false;

            if(!usuarioId.HasValue)
            {
                foreach (var articulo in artsFavsRemitente)
                {
                    ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);
                    artsFavsVM.Add(art);
                }
            }else
            {
                IList<ArticuloEN> artsFavsDestinatario = usuarioRegistradoCEN.DameArticulosEnListaDeseos((int)usuarioId);

                foreach (var articulo in artsFavsRemitente)
                {
                    if (artsFavsDestinatario.Any(a => a.ArticuloId == articulo.ArticuloId))
                    {
                        favorito = true;
                    }

                    ArticuloViewModel art = new ArticuloAssembler().ConvertirENToViewModel(articulo, favorito);
                    artsFavsVM.Add(art);
                    favorito = false;
                }
            }

            ListaDeseosViewModel listaDeseosVM = new ListaDeseosAssembler().ConvertirToViewModel(nombreRemitente, artsFavsVM);

            SessionClose();
            return View(listaDeseosVM);
        }
    }
}
