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
using KlerenGen.ApplicationCore.IRepository.Kleren;
using System.Collections.Generic;

namespace web_kleren.Controllers
{
    public class AdministradorController : BasicController
    {
        // GET: AdministradorController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdministradorController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            try
            {
                AdministradorRepository adminRepo = new AdministradorRepository();
                AdministradorCEN adminCEN = new AdministradorCEN(adminRepo);

                // Verificar credenciales del administrador
                AdministradorEN adminEN = adminCEN.DamePorCorreo(login.Correo);
                if (adminEN != null && adminEN.Pass == Util.GetEncondeMD5(login.Pass))
                {
                    // Guardar los datos del administrador en la sesión
                    AdministradorViewModel adminVM = new AdministradorAssembler().ConvertirENToViewModel(adminEN);
                    HttpContext.Session.Set<AdministradorViewModel>("admin", adminVM);
                    HttpContext.Session.SetString("UsuarioId", adminEN.AdminId.ToString());

                    return RedirectToAction("Perfil", "Administrador");
                }

                ModelState.AddModelError("", "Error al introducir el correo o la contraseña.");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ocurrió un error: {ex.Message}");
                return View();
            }
        }

        // GET: AdministradorController/CerrarSesion
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Administrador");
        }

        // Métodos para gestionar productos (Crear, Editar, Eliminar)
        public ActionResult GestionProductos()
        {
            return RedirectToAction("Index", "Articulo");
        }

        // Métodos para gestionar pedidos
        public IActionResult _Pedidos()
        {
            try
            {
                // Lógica para obtener los pedidos
                SessionInitialize();
                IPedidoRepository pedidoRepository = new PedidoRepository(session);
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);
                IList<PedidoEN> pedidos = pedidoCEN.DameTodos(0,-1); // Método que obtiene todos los pedidos

                IList<PedidoViewModel> peds = new List<PedidoViewModel>();
                foreach (var pedido in pedidos)
                {
                    PedidoViewModel PedVM = new PedidoAssembler().ConvertirENToViewModel(pedido);
                    peds.Add(PedVM);
                }
                SessionClose();
                return PartialView("_Pedidos", peds); // Devuelve la vista parcial con los pedidos
            }
            catch (Exception ex)
            {
                // Manejo de errores
                TempData["ErrorMessage"] = $"Ocurrió un error al cargar los pedidos: {ex.Message}";
                return PartialView("_Pedidos", new List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>());
            }
        }

        [HttpPost]
        public IActionResult ActualizarEstadoPedido(int pedidoId)
        {
            try
            {
                // Crear instancia del repositorio
                IPedidoRepository pedidoRepository = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);

                // Obtener el pedido desde la base de datos
                PedidoEN pedidoEN = pedidoCEN.DamePorId(pedidoId);

                if (pedidoEN == null)
                {
                    return NotFound("Pedido no encontrado.");
                }

                // Ciclo de estados
                var estados = Enum.GetValues(typeof(EstadoPedidoEnum)).Cast<EstadoPedidoEnum>().ToList();
                var estadoActual = pedidoEN.Estado;
                var indiceActual = estados.IndexOf(estadoActual);
                var siguienteEstado = estados[(indiceActual + 1) % estados.Count]; // Ciclo al siguiente estado

                // Actualizar el estado del pedido
                pedidoCEN.Modificar(pedidoId, siguienteEstado);

                // Redirigir o devolver un mensaje de éxito
                TempData["SuccessMessage"] = "Estado del pedido actualizado correctamente.";
                return RedirectToAction("Perfil");
                //return RedirectToAction("Perfil"); // Redirigir a la página de pedidos
            }
            catch (Exception ex)
            {
                // Manejar errores
                TempData["ErrorMessage"] = $"Ocurrió un error al actualizar el estado del pedido: {ex.Message}";
                return RedirectToAction("Perfil"); // Redirigir de nuevo a la página de pedidos
            }
        }



        // Métodos para gestionar devoluciones
        public IActionResult _Devoluciones()
        {
            try
            {
                // Lógica para obtener los pedidos
                SessionInitialize();
                IDevolucionRepository devRepository = new DevolucionRepository(session);
                DevolucionCEN devCEN = new DevolucionCEN(devRepository);
                IList<DevolucionEN> devoluciones = devCEN.DameTodos(0, -1); // Método que obtiene todos las devoluciones

                IList<DevolucionViewModel> devs = new List<DevolucionViewModel>();
                foreach (var dev in devoluciones)
                {
                    DevolucionViewModel DevVM = new DevolucionAssembler().ConvertirENToViewModel(dev);
                    devs.Add(DevVM);
                }
                SessionClose();
                return PartialView("_Devoluciones", devs); // Devuelve la vista parcial con las devoluciones
            }
            catch (Exception ex)
            {
                // Manejo de errores
                TempData["ErrorMessage"] = $"Ocurrió un error al cargar los pedidos: {ex.Message}";
                return PartialView("_Devoluciones", new List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>());
            }
        }

        [HttpPost]
        public IActionResult ActualizarEstadoDevolucion(int devId)
        {
            try
            {
                // Crear instancia del repositorio
                IDevolucionRepository devRepository = new DevolucionRepository();
                DevolucionCEN devCEN = new DevolucionCEN(devRepository);

                // Obtener el pedido desde la base de datos
                DevolucionEN devEN = devCEN.DamePorId(devId);

                if (devEN == null)
                {
                    return NotFound("Devolucion no encontrada.");
                }

                // Ciclo de estados
                var estados = Enum.GetValues(typeof(EstadoDevolucionEnum)).Cast<EstadoDevolucionEnum>().ToList();
                var estadoActual = devEN.Estado;
                var indiceActual = estados.IndexOf(estadoActual);
                var siguienteEstado = estados[(indiceActual + 1) % estados.Count]; // Ciclo al siguiente estado
                var motivo = devEN.MotivoRechazo;

                // Actualizar el estado del pedido
                devCEN.Modificar(devId, siguienteEstado, motivo);

                // Redirigir o devolver un mensaje de éxito
                TempData["SuccessMessage"] = "Estado de la devolucion actualizado correctamente.";
                return RedirectToAction("Perfil"); // Redirigir a la página de pedidos
            }
            catch (Exception ex)
            {
                // Manejar errores
                TempData["ErrorMessage"] = $"Ocurrió un error al actualizar el estado de la devolucion: {ex.Message}";
                return RedirectToAction("Perfil"); // Redirigir de nuevo a la página de pedidos
            }
        }




        // Métodos para gestionar datos personales
        public ActionResult Perfil()
        {
            var admin = HttpContext.Session.Get<AdministradorViewModel>("admin");
            if (admin == null)
            {
                return RedirectToAction("Login");
            }

            return View(admin);
        }

        [HttpPost]
        public ActionResult Perfil(AdministradorViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
                var adminId = HttpContext.Session.GetString("UsuarioId");
                if (string.IsNullOrEmpty(adminId))
                {
                    return RedirectToAction("Login", "Administrador");
                }

                AdministradorRepository adminRepo = new AdministradorRepository();
                AdministradorCEN adminCEN = new AdministradorCEN(adminRepo);

                adminCEN.Modificar(
                    int.Parse(adminId),
                    adminVM.Nombre,
                    adminVM.Apellidos,
                    adminVM.Correo,
                    adminVM.Telefono,
                    adminVM.FNac,
                    adminVM.Dni, 
                    adminVM.Pass
                );

                return RedirectToAction("Perfil");
            }

            return View(adminVM);
        }

        // GET: AdministradorController/MisDatosPartial
        public ActionResult MisDatosPartial()
        {
            // Obtener el id del usuario de la sesión
            var adminId = GetUsuarioIdFromSession();
            if (!adminId.HasValue)
            {
                adminId = 0;
            }

            // Recuperar el usuario desde la base de datos
            AdministradorRepository adminRepo = new AdministradorRepository();
            AdministradorCEN adminCEN = new AdministradorCEN(adminRepo);
            AdministradorEN adminEN = adminCEN.DamePorId((int)adminId);
            AdministradorViewModel adminVM = new AdministradorAssembler().ConvertirENToViewModel(adminEN);

            // Pasa el usuario a la vista parcial
            return PartialView("MisDatosPartial", adminVM);
        }

        // GET: AdministradorController/ModificarDatosPartial
        public ActionResult ModificarDatosPartial()
        {
            var admin = HttpContext.Session.Get<AdministradorViewModel>("admin");
            if (admin == null)
            {
                return RedirectToAction("Login");
            }

            return PartialView("ModificarDatosPartial",admin);
        }

        // POST: AdministradorController/ModificarDatosPartial
        [HttpPost]
        public ActionResult ModificarDatosPartial(AdministradorViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
                var adminId = HttpContext.Session.GetString("UsuarioId");
                if (string.IsNullOrEmpty(adminId))
                {
                    return RedirectToAction("Login", "Administrador");
                }

                AdministradorRepository adminRepo = new AdministradorRepository();
                AdministradorCEN adminCEN = new AdministradorCEN(adminRepo);

                adminCEN.Modificar(
                    int.Parse(adminId),
                    adminVM.Nombre,
                    adminVM.Apellidos,
                    adminVM.Correo,
                    adminVM.Telefono,
                    adminVM.FNac,
                    adminVM.Dni,
                    adminVM.Pass
                );

                return RedirectToAction("Perfil");
            }

            return RedirectToAction("Perfil");
        }

        // GET: AdministradorController/_ModificarContra
        public ActionResult _ModificarContra()
        {
            var admin = HttpContext.Session.Get<AdministradorViewModel>("admin");
            if (admin == null)
            {
                return RedirectToAction("Login");
            }

            return PartialView();
        }

        // POST: AdministradorController/_ModificarContra
        [HttpPost]
        public ActionResult _ModificarContra(string nuevaContra, string confirmacionContra)
        {
            var adminId = HttpContext.Session.GetString("UsuarioId");
            if (string.IsNullOrEmpty(adminId))
            {
                return RedirectToAction("Login", "Administrador");
            }

            if (nuevaContra == confirmacionContra)
            {
                AdministradorRepository adminRepo = new AdministradorRepository();
                AdministradorCEN adminCEN = new AdministradorCEN(adminRepo);

                adminCEN.ModificarContra(int.Parse(adminId), Util.GetEncondeMD5(nuevaContra));
                return RedirectToAction("Perfil");
            }

            ModelState.AddModelError("", "Las contraseñas no coinciden.");
            return PartialView();
        }




    }
}
