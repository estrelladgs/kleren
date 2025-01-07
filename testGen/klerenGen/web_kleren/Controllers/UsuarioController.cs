using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Utils;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using web_kleren.Assemblers;
using web_kleren.Models;
using KlerenGen.ApplicationCore.Utils;
using KlerenGen.ApplicationCore.Enumerated.Kleren;
using KlerenGen.Infraestructure.EN.Kleren;
using System.Diagnostics;


namespace web_kleren.Controllers
{
    public class UsuarioController : BasicController
    {

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            try
            {
                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                // Primero, verificar si es un usuario registrado
                UsuarioRegistradoEN usuEN = usuCEN.DamePorCorreo(login.Correo);
                if (usuEN != null && usuEN.Pass == Util.GetEncondeMD5(login.Pass))
                {
                    // Guardar los datos del usuario en la sesión
                    UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                    HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                    HttpContext.Session.SetString("UsuarioId", usuEN.UsuarioRegistradoId.ToString());

                    return RedirectToAction("Home", "Articulo");
                }

                // Si no encuentra el correo en ninguno de los repositorios
                ModelState.AddModelError("", "Error al introducir el correo o la contraseña.");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ocurrió un error: {ex.Message}");
                return View();
            }
        }


        // GET: UsuarioController/Registro
        public ActionResult Registro()
        {
            return View();
        }

        // POST: UsuarioController/Registro
        [HttpPost]
        public ActionResult Registro(RegistroUsuarioViewModel registro)
        {
            // Verificar que el modelo es válido
            //if (!ModelState.IsValid)
            //{
            //    // Si hay errores en el modelo, regresar a la vista con los errores
            //    return View(registro);
            //}

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Clave: {error.Key}");
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($"Error: {err.ErrorMessage}");
                    }
                }
                return View(registro);
            }


            try
            {
                // Validar si el correo ya existe
                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                if (usuRepo.DamePorCorreo(registro.Correo) != null)
                {
                    ModelState.AddModelError("Correo", "El correo electrónico ya está registrado.");
                    return View(registro);
                }

                var hoy = DateTime.Today;
                var edad = hoy.Year - registro.FNac.Year;

                if (registro.FNac > hoy.AddYears(-edad))
                {
                    edad--;
                }

                if (edad < 18)
                {

                    ModelState.AddModelError("FNac", "Debes ser mayor de 18 años para registrarte.");
                    return View(registro);
                }

                int nuevoUsu = usuCEN.Nuevo(
                    registro.Nombre,
                    registro.Apellidos,
                    registro.Correo,
                    registro.Telefono,
                    registro.FNac,
                    registro.Pass,
                    0
                );

                if (nuevoUsu > 0)
                {
                    SessionInitialize();
                    UsuarioRegistradoEN usuEN = usuCEN.DamePorCorreo(registro.Correo);
                    UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                    HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                    HttpContext.Session.SetString("UsuarioId", usuEN.UsuarioRegistradoId.ToString());
                    SessionClose();
                    return RedirectToAction("Home", "Articulo");

                }
                else
                {
                    ModelState.AddModelError("", "No se pudo registrar el usuario. Inténtelo de nuevo.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ocurrió un error: {ex.Message}");
            }

            return View(registro);
        }



        // GET: UsuarioController/Perfil
        public ActionResult Perfil()
        {
            // Recupera el usuario actual de la sesión
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                // Si no hay usuario en sesión, redirige a la página de login
                return RedirectToAction("Login");
            }

            // Devuelve los datos del usuario a la vista
            return View(usuario);
        }


        // GET: UsuarioController/MisDatos
        public ActionResult MisDatosPartial()
        {
            // Obtener el id del usuario de la sesión
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            // Recuperar el usuario desde la base de datos
            UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
            UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);
            UsuarioRegistradoEN usuEN = usuCEN.DamePorId((int)usuarioId);
            UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

            // Pasa el usuario a la vista parcial
            return PartialView("MisDatosPartial", usuVM);
        }

        // GET: UsuarioController/ModificarDatos
        public ActionResult ModificarDatosPartial()
        {
            // Obtener el id del usuario de la sesión
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
            UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);
            UsuarioRegistradoEN usuEN = usuCEN.DamePorId((int)usuarioId);
            DatosViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel2(usuEN);

            return PartialView("ModificarDatosPartial", usuVM);
        }

        // POST: UsuarioController/ModificarDatos
        [HttpPost]
        public ActionResult ModificarDatosPartial(DatosViewModel usuarioVM)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario desde la sesión
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                    return RedirectToAction("Login", "Usuario");
                }

                // Convertir el ID de usuario a un entero
                int id = int.Parse(usuarioId);

                // Crear la instancia de los repositorios y CEN (lógica de negocio)
                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                // Llamar a la función DamePorId para obtener los datos del usuario
                UsuarioRegistradoEN usuEN = usuCEN.DamePorId(id);

                if (usuEN == null)
                {
                    // Si el usuario no existe, redirigir al login o página de error
                    return RedirectToAction("Login", "Usuario");
                }
                // Usar el método Modificar de la CEN para actualizar los datos del usuario

                string fechaString = "2024-12-19"; // Una fecha en formato string
                DateTime fecha = DateTime.Parse(fechaString); // Convertir el string a DateT
                usuCEN.Modificar(
           
                    usuarioVM.Nombre,
                    usuarioVM.Apellidos,
                    usuarioVM.Correo,
                    usuarioVM.Telefono,
                    fecha,
                    id
                );


                // Obtener los datos actualizados del usuario
                UsuarioRegistradoEN usuarioActualizado = usuCEN.DamePorId(id);

                // Convertir el UsuarioRegistradoEN a UsuarioViewModel para mostrar los datos actualizados
                DatosViewModel usuarioActualizadoVM = new UsuarioAssembler().ConvertirENToViewModel2(usuarioActualizado);


                // Devolver la vista con los datos actualizados en la vista parcial
                return PartialView("MisDatosPartial", usuarioActualizadoVM);
            }

            // Si los datos no son válidos, volver al formulario de modificación
            return PartialView("ModificarDatosPartial", usuarioVM);
        }




        // GET: UsuarioController/ModificarContra
        public ActionResult _ModificarContra()
        {
            // Lógica para la vista de cambio de contraseña
            return PartialView("_ModificarContra");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _ModificarContra(ContraViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario desde la sesión
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                    return RedirectToAction("Login", "Usuario");
                }

                int id = int.Parse(usuarioId);

                // Crear la instancia de los repositorios y la lógica de negocio
                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                // Obtener los datos del usuario actual
                UsuarioRegistradoEN usuEN = usuCEN.DamePorId(id);


                if (usuEN == null)
                {
                    // Si el usuario no existe, redirigir al login o página de error
                    return RedirectToAction("Login", "Usuario");
                }

                // Verificar si la contraseña actual es correcta
                if (usuEN.Pass != KlerenGen.ApplicationCore.Utils.Util.GetEncondeMD5(model.Pass))
                {
                    return PartialView("_ModificarContra", model); 
                }


                usuCEN.ModificarContra(id,model.NuevaContra);

      
                return PartialView("_ExitoContra", model); 
            }

            // Si el modelo no es válido, volver a mostrar la vista parcial con los errores
            return PartialView("_ModificarContra", model);
        }



        // GET: UsuarioController/BorrarCuenta
        public ActionResult _BorrarCuenta()
        {
            // Recupera el usuario actual de la sesión
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                // Si no hay usuario en sesión, redirige a la página de login
                return RedirectToAction("Login");
            }

            // Devuelve los datos del usuario a la vista
            return PartialView("_BorrarCuenta");
        }


        // POST: UsuarioController/BorrarCuenta

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _BorrarCuenta(BorrarViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario desde la sesión
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    
                    return RedirectToAction("Login", "Usuario");
                }

                int id = int.Parse(usuarioId);

                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                try
                {
          
                    usuCEN.SolicitarBorrarCuenta(id, model.Pass);


                    return RedirectToAction("Login", "Usuario");
                }
                catch (Exception ex)
                {
                
                    ModelState.AddModelError("", ex.Message);
                    return PartialView("_BorrarCuenta", model); 
                }
            }

            // Si el modelo no es válido, volver a mostrar la vista parcial con los errores
            return PartialView("_BorrarCuenta", model);
        }


        // GET: UsuarioController/PedidosYDevoluciones
        public ActionResult _ComprasYDevoluciones()
        {
            return PartialView("_ComprasYDevoluciones");
        }

        public ActionResult _Compras()
        {
            // Obtener el ID del usuario desde la sesión
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                return RedirectToAction("Login", "Usuario");
            }

            int id = int.Parse(usuarioId);

            SessionInitialize();

            PedidoRepository pedidoRepo = new PedidoRepository(session);
            PedidoCEN pedCEN = new PedidoCEN(pedidoRepo);

            // Obtener los pedidos del usuario
            IList<PedidoEN> pedidosPorUsuEN = pedCEN.DamePedidosPorUsuario(id);

            // Depuración: Verificar si la lista de pedidos tiene elementos
            Debug.WriteLine($"Cantidad de pedidos: {pedidosPorUsuEN.Count}");

            IList<PedidoViewModel> pedidosPorUsuVM = new List<PedidoViewModel>();

            foreach (var pedido in pedidosPorUsuEN)
            {
                PedidoViewModel ped = new PedidoAssembler().ConvertirENToViewModel(pedido);
                pedidosPorUsuVM.Add(ped);
            }

            // Verificar si la lista de ViewModels tiene elementos
            Debug.WriteLine($"Cantidad de pedidos (ViewModel): {pedidosPorUsuVM.Count}");

            SessionClose();

            return PartialView("_Compras", pedidosPorUsuVM);
        }

        public ActionResult _Devoluciones()
        {
            // Obtener el ID del usuario desde la sesión
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                return RedirectToAction("Login", "Usuario");
            }

            int id = int.Parse(usuarioId);

            SessionInitialize();

            DevolucionRepository devRepo = new DevolucionRepository(session);
            DevolucionCEN devCEN = new DevolucionCEN(devRepo);

            // Obtener los pedidos del usuario
            IList<DevolucionEN> devolucionENs = devCEN.DameTodos(0, -1);

            IList<DevolucionViewModel> devsPorUsuVM = new List<DevolucionViewModel>();

            foreach (var devEN in devolucionENs)
            {
                DevolucionViewModel devVM = new DevolucionAssembler().ConvertirENToViewModel(devEN);
                /*if (devVM. == id) {
                    devsPorUsuVM.Add(devVM);
                }*/

                devsPorUsuVM.Add(devVM);
                
            }

            SessionClose();

            return PartialView("_Devoluciones", devsPorUsuVM);
        }

        public ActionResult _VerDetalleDev(int id)
        {
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                return RedirectToAction("Login", "Usuario");
            }

            int idUsu = int.Parse(usuarioId);

            SessionInitialize();

            DevolucionRepository devRepo = new DevolucionRepository(session);
            DevolucionCEN devCEN = new DevolucionCEN(devRepo);


            DevolucionEN devEN = devCEN.DamePorId(id);
            DevolucionViewModel devVM = new DevolucionAssembler().ConvertirENToViewModel(devEN);

            SessionClose();

            return PartialView("_VerDetalleDev", devVM);
        }

        public ActionResult _VerDetallePedido(int id)
        {
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                return RedirectToAction("Login", "Usuario");
            }

            int idUsu = int.Parse(usuarioId);

            SessionInitialize();

            PedidoRepository pedidoRepo = new PedidoRepository(session);
            PedidoCEN pedCEN = new PedidoCEN(pedidoRepo);

           
            PedidoEN pedEN = pedCEN.DamePorId(id);
            PedidoViewModel pedVM = new PedidoAssembler().ConvertirENToViewModel(pedEN);
  
            SessionClose();

            return PartialView("_VerDetallePedido", pedVM);
        }

        public ActionResult _TramitarDevolucion(int id)
        {

            SessionInitialize();

            PedidoRepository pedidoRepo = new PedidoRepository(session);
            PedidoCEN pedCEN = new PedidoCEN(pedidoRepo);


            PedidoEN pedEN = pedCEN.DamePorId(id);
            PedidoViewModel pedVM = new PedidoAssembler().ConvertirENToViewModel(pedEN);

            SessionClose();

            return PartialView("_TramitarDevolucion", pedVM);
        }

        [HttpPost]
        public ActionResult _TramitarDevolucion(PedidoViewModel pedido)
        {

            SessionInitialize();

            DevolucionRepository dev = new DevolucionRepository(session);
            DevolucionCEN devCEN = new DevolucionCEN(dev);
            devCEN.Nueva(pedido.PedidoId, "Quiero devolverlo");

            SessionClose();

            return PartialView("_ExitoDevolucion");
        }




        // GET: UsuarioController/MisMedidas
        public ActionResult _MisMedidas()
        {
            // Obtener el ID del usuario desde la sesión
            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            if (string.IsNullOrEmpty(usuarioId))
            {
                // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                return RedirectToAction("Login", "Usuario");
            }

            // Convertir el ID de usuario a un entero
            int id = int.Parse(usuarioId);

            SessionInitialize();

            MedidasUsuarioRepository medidasRepo = new MedidasUsuarioRepository();
            MedidasUsuarioCEN medidasCEN = new MedidasUsuarioCEN(medidasRepo);

            // Obtener las medidas del usuario
            MedidasUsuarioEN medidasEN = medidasCEN.DameMedidasUsuario(id);
            MedidasViewModel medidasVM;
            if (medidasEN == null)
            {
                // Si no se encuentran medidas, devolver un modelo vacío
                medidasVM = new MedidasViewModel
                {
                    Pecho = 0,
                    LargoBrazo = 0,
                    Cintura = 0,
                    Caderas = 0,
                    LargoPierna = 0
                };
            }
            else
            {
                // Convertir el modelo EN a ViewModel
                medidasVM = new UsuarioAssembler().ConvertirENToViewModel(medidasEN);
            }

            SessionClose();

            // Pasar el modelo a la vista parcial
            return PartialView("_MisMedidas", medidasVM);

        }

        // GET: UsuarioController/ModificarMedidas
         public ActionResult _ModificarMedidas()
         {
             // Obtener el ID del usuario desde la sesión
             var usuarioId = HttpContext.Session.GetString("UsuarioId");

             if (string.IsNullOrEmpty(usuarioId))
             {
                 // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                 return RedirectToAction("Login", "Usuario");
             }

             // Convertir el ID de usuario a un entero
             int id = int.Parse(usuarioId);

             MedidasUsuarioRepository medidasRepo = new MedidasUsuarioRepository();
             MedidasUsuarioCEN medidasCEN = new MedidasUsuarioCEN(medidasRepo);

             // Obtener las medidas del usuario
             MedidasUsuarioEN medidasEN = medidasCEN.DameMedidasUsuario(id);

             MedidasViewModel medidasVM = new UsuarioAssembler().ConvertirENToViewModel(medidasEN);


             // Pasar el modelo a la vista parcial
             return PartialView("_ModificarMedidas", medidasVM);

         }

         // POST: UsuarioController/ModificarMedidas
         [HttpPost]
         public ActionResult _ModificarMedidas(MedidasViewModel modelo)
         {
             if (ModelState.IsValid)
             {
                 // Obtener el ID del usuario desde la sesión
                 var usuarioId = HttpContext.Session.GetString("UsuarioId");

                 if (string.IsNullOrEmpty(usuarioId))
                 {
                     // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                     return RedirectToAction("Login", "Usuario");
                 }

                 // Convertir el ID de usuario a un entero
                 int id = int.Parse(usuarioId);

                 MedidasUsuarioRepository medidasRepo = new MedidasUsuarioRepository();
                 MedidasUsuarioCEN medidasCEN = new MedidasUsuarioCEN(medidasRepo);
                 MedidasUsuarioEN medidasEN = medidasCEN.DameMedidasUsuario(id);


                medidasCEN.Modificar(medidasEN.MedidasUsuarioId, modelo.Cintura, modelo.Pecho, modelo.AnchoEspalda, modelo.Caderas, modelo.LargoBrazo, modelo.LargoPierna);
  
                 MedidasUsuarioEN medidasAcutalizadas = medidasCEN.DameMedidasUsuario(id);

                 // Convertir el UsuarioRegistradoEN a UsuarioViewModel para mostrar los datos actualizados
                 MedidasViewModel medidasActualizadasVM = new UsuarioAssembler().ConvertirENToViewModel(medidasAcutalizadas);


                 // Devolver la vista con los datos actualizados en la vista parcial
                 return PartialView("_MisMedidas", medidasActualizadasVM);
             }

             // Si los datos no son válidos, volver al formulario de modificación
             return PartialView("_ModificarMedidas", modelo);
         }
        

        // GET: UsuarioController/IntroducirMedidas
        public ActionResult _IntroducirMedidas()
        {
            //var model = new MedidasViewModel();

            return PartialView("_IntroducirMedidas");

        }

        // POST: UsuarioController/IntroducirMedidas
        [HttpPost]
        public ActionResult _IntroducirMedidas(MedidasViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario desde la sesión
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    // Si no se encuentra el ID del usuario en la sesión, redirigir al login
                    return RedirectToAction("Login", "Usuario");
                }

                // Convertir el ID de usuario a un entero
                int id = int.Parse(usuarioId);

                MedidasUsuarioRepository medidasRepo = new MedidasUsuarioRepository();
                MedidasUsuarioCEN medidasCEN = new MedidasUsuarioCEN(medidasRepo);

                int idMedidas = medidasCEN.Nuevo(modelo.Cintura, modelo.Pecho, modelo.AnchoEspalda, modelo.Caderas, modelo.LargoBrazo, modelo.LargoPierna, id);

                MedidasUsuarioEN medidasEN = medidasCEN.DamePorId(idMedidas);

                // Convertir a ViewModel
                MedidasViewModel medidasVM = new UsuarioAssembler().ConvertirENToViewModel(medidasEN);

                // Devolver la vista parcial con los datos actualizados
                return PartialView("_MisMedidas", medidasVM);
            }

            // Si los datos no son válidos, volver al formulario de modificación
            return PartialView("_IntroducirMedidas", modelo);
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
    }
}