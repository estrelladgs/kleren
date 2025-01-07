using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Enumerated.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_kleren.Controllers
{
    public class AvisoStockController : BasicController
    {
        // GET: AvisoStockController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvisoStockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvisoStockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvisoStockController/Create
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

        // GET: AvisoStockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvisoStockController/Edit/5
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

        // GET: AvisoStockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvisoStockController/Delete/5
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

    
        public ActionResult SolicitarAviso(int tallaId, int colorId, int articuloId)
        {

            VarianteRepository varRepo = new VarianteRepository();
            VarianteCEN var = new VarianteCEN(varRepo);
            VarianteEN varEN = var.DamePorTallaYColorYArticulo(tallaId, colorId, articuloId);

            var usuarioId = GetUsuarioIdFromSession();
            if (!usuarioId.HasValue)
            {
                return View("IngresarCorreo");
            } else
            {
                UsuarioRegistradoRepository usuRepo = new UsuarioRegistradoRepository();
                UsuarioRegistradoCEN usuCEN = new UsuarioRegistradoCEN(usuRepo);

                UsuarioRegistradoEN usuEN = usuCEN.DamePorId((int)usuarioId);

                AvisoStockRepository avisoRepo = new AvisoStockRepository();
                AvisoStockCEN avisoCEN = new AvisoStockCEN(avisoRepo);

                EstadoAvisoStockEnum estadoAvisoEnum = EstadoAvisoStockEnum.sinEnviar;

                int avisoId = 0;

                if (varEN != null)
                {
                    avisoId = avisoCEN.Nuevo(varEN.VarianteId, usuEN.Correo);
                }

                return View("AvisoRegistrado", avisoId);
            }

        }

      
        [HttpPost]
        public IActionResult SolicitarAvisoNoRegistrado(string correo, int tallaId, int colorId, int articuloId)
        {
            VarianteRepository varRepo = new VarianteRepository();
            VarianteCEN var = new VarianteCEN(varRepo);
            VarianteEN varEN = var.DamePorTallaYColorYArticulo(tallaId, colorId, articuloId);

            AvisoStockRepository avisoRepo = new AvisoStockRepository();
            AvisoStockCEN avisoCEN = new AvisoStockCEN(avisoRepo);

            EstadoAvisoStockEnum estadoAvisoEnum = EstadoAvisoStockEnum.sinEnviar;

            int avisoId = 0;
            
            if(varEN != null)
            {
                avisoId = avisoCEN.Nuevo(varEN.VarianteId, correo);
            } 
            

            return View("AvisoRegistrado", avisoId);

        }
    }
}
