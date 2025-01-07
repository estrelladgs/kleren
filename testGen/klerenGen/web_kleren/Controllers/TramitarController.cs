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
using System;
using System.Linq;
using System.Security.Cryptography;
using web_kleren.Assemblers;
using web_kleren.Models;

namespace web_kleren.Controllers
{
    public class TramitarController : BasicController
    {
        // GET: TramitarController
        public ActionResult Index()
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
                    TramitarViewModel tramPed = new TramitarAssembler().ConvertirENToViewModel(pedidoEst);
                    SessionClose();
                    return View("TramitarPedido",tramPed);

                }

            }

            SessionClose();
            return View(null); ;
        }

        // GET: TramitarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: TramitarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TramitarController/Create
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

        // GET: TramitarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TramitarController/Edit/5
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

        // GET: TramitarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public ActionResult TramitarP(string nombre, string apellidos, string correo, string telefono, string calle, int numero, int escalera, int piso, string puerta, int codpos, string ciudad, string provincia, string metodoPago, bool canjearPuntos, string numeroTarjeta, string fechaExpiracion, string cvv, int PedidoId, int DirEnvioId)
        {
            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                usuarioId = 0;
            }

            SessionInitialize();
            PedidoRepository pedRepository = new PedidoRepository();
            PedidoCEN pedCEN = new PedidoCEN(pedRepository);
            PedidoEN ped = pedCEN.DamePorId(PedidoId);
            DirEnvioEN dir = ped.DirEnvio;


            if(ped != null)
            {
                if ((int)ped.Estado == 5)
                {
                    if (canjearPuntos)
                    {
                        int Id = ped.PedidoId;
                        PedidoCP pedCP = new PedidoCP(new SessionCPNHibernate());
                        pedCP.CalcularDescuento(PedidoId);
                        PedidoEN pedi = pedCEN.DamePorId(PedidoId);
                        if(pedi.TotalDescuento != 0)
                        {
                            int pediId = pedi.PedidoId;
                            int dirId = dir.DirEnvioId;
                            DirEnvioRepository dirRepository = new DirEnvioRepository();
                            DirEnvioCEN dire = new DirEnvioCEN(dirRepository);
                            dire.Modificar(dirId, calle, numero, escalera, piso, puerta, codpos, ciudad, provincia);
                            EstadoPedidoEnum estado = (EstadoPedidoEnum)Enum.Parse(typeof(EstadoPedidoEnum), "pagado", true);
                            pedCEN.Modificar(pediId, estado);
                            FacturaRepository facRepo = new FacturaRepository();
                            FacturaCEN fac = new FacturaCEN(facRepo);
                            double tot = pedi.TotalDescuento;
                            double des = pedi.Total - pedi.TotalDescuento;
                            double sub = tot - (tot * 0.21);
                            float sub1 = (float)sub;
                            float tot1 = (float)tot;
                            float iva = (float)(tot * 0.21);
                            float des1 = (float)des;
                            UsuarioRegistradoRepository us = new UsuarioRegistradoRepository();
                            UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(us);
                            int usuID = pedi.UsuarioRegistrado.UsuarioRegistradoId;
                            UsuarioRegistradoEN usuEN = usuCEN.DamePorId(usuID);
                            int p = usuEN.Puntos;
                            bool res = usuCEN.RestarPuntos(usuID,p);
                            double cal = pedi.TotalDescuento;
                            int puntosPor15Euros = 100;
                            // Calcular los puntos
                            int puntosASumar = (int)(cal / 5) * puntosPor15Euros;
                            usuCEN.SumarPuntos(usuID,puntosASumar);
                            int idfac = fac.Nueva(sub1, tot1, DateTime.Now.Date, pediId, iva, des1, nombre, apellidos, correo, telefono);
                            FacturaEN face = fac.DamePorId(idfac);
                            FacturaViewModel Fact = new TramitarAssembler().ConvertirENFactToViewModel(face);
                            if (metodoPago == "paypal")
                            {
                                TempData["Mensaje"] = "PayPal";
                            }
                            else
                            {
                                TempData["Mensaje"] = "Tarjeta";
                            }
                            TempData["Puntos"] = puntosASumar;
                            SessionClose();
                            return View("Factura", Fact);


                        }
                        else
                        {
                            int pediId = pedi.PedidoId;
                            int dirId = dir.DirEnvioId;
                            DirEnvioRepository dirRepository = new DirEnvioRepository();
                            DirEnvioCEN dire = new DirEnvioCEN(dirRepository);
                            dire.Modificar(dirId, calle, numero, escalera, piso, puerta, codpos, ciudad, provincia);
                            EstadoPedidoEnum estado = (EstadoPedidoEnum)Enum.Parse(typeof(EstadoPedidoEnum), "pagado", true);
                            pedCEN.Modificar(pediId, estado);
                            FacturaRepository facRepo = new FacturaRepository();
                            FacturaCEN fac = new FacturaCEN(facRepo);

                            double tot = ped.Total;
                            double sub = tot - (tot * 0.21);
                            float sub1 = (float)sub;
                            float tot1 = (float)tot;
                            float iva = (float)(tot * 0.21);
                            UsuarioRegistradoRepository us = new UsuarioRegistradoRepository();
                            UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(us);
                            int usuID = ped.UsuarioRegistrado.UsuarioRegistradoId;
                            UsuarioRegistradoEN usuEN = usuCEN.DamePorId(usuID);
                            

                            double cal = ped.Total;
                            int puntosPor15Euros = 100;
                            int puntosASumar = (int)(cal / 5) * puntosPor15Euros;
                            usuCEN.SumarPuntos(usuID, puntosASumar);

                            int idfac = fac.Nueva(sub1, tot1, DateTime.Now.Date, Id, iva, 0, nombre, apellidos, correo, telefono);
                            FacturaEN face = fac.DamePorId(idfac);
                            FacturaViewModel Fact = new TramitarAssembler().ConvertirENFactToViewModel(face);
                            if (metodoPago == "paypal")
                            {
                                TempData["Mensaje"] = "PayPal";
                            }
                            else
                            {
                                TempData["Mensaje"] = "Tarjeta";
                            }
                            TempData["Puntos"] = puntosASumar;
                            SessionClose();
                            return View("Factura", Fact);
                        }
                       


                    } else
                    {

                        int Id = ped.PedidoId;
                        int dirId = dir.DirEnvioId;
                        DirEnvioRepository dirRepository = new DirEnvioRepository();
                        DirEnvioCEN dire = new DirEnvioCEN(dirRepository);
                        dire.Modificar(dirId, calle, numero, escalera, piso, puerta, codpos, ciudad, provincia);
                        EstadoPedidoEnum estado = (EstadoPedidoEnum)Enum.Parse(typeof(EstadoPedidoEnum), "pagado", true);
                        pedCEN.Modificar(Id, estado);
                        FacturaRepository facRepo = new FacturaRepository();
                        FacturaCEN fac = new FacturaCEN(facRepo);

                        double tot = ped.Total;
                        double sub = tot - (tot * 0.21);
                        float sub1 = (float)sub;
                        float tot1 = (float)tot;
                        float iva = (float)(tot * 0.21);
                        UsuarioRegistradoRepository us = new UsuarioRegistradoRepository();
                        UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(us);
                        int usuID = ped.UsuarioRegistrado.UsuarioRegistradoId;
                        UsuarioRegistradoEN usuEN = usuCEN.DamePorId(usuID);
                        
                        
                        double cal = ped.Total;
                        int puntosPor15Euros = 100;
                        int puntosASumar = (int)(cal / 5) * puntosPor15Euros;
                        usuCEN.SumarPuntos(usuID, puntosASumar);

                        int idfac = fac.Nueva(sub1, tot1, DateTime.Now.Date, Id, iva, 0, nombre, apellidos, correo, telefono);
                        FacturaEN face = fac.DamePorId(idfac);
                        FacturaViewModel Fact = new TramitarAssembler().ConvertirENFactToViewModel(face);
                        if (metodoPago == "paypal")
                        {
                            TempData["Mensaje"] = "PayPal";
                        }
                        else
                        {
                            TempData["Mensaje"] = "Tarjeta";
                        }
                        TempData["Puntos"] = puntosASumar;
                        SessionClose();
                        return View("Factura", Fact);

                    }
                }


            }
            SessionClose();
            return View();
           // return RedirectToAction("Confirmacion"); // Redirige a una página de confirmación, por ejemplo
        }



        // POST: TramitarController/Delete/5
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
