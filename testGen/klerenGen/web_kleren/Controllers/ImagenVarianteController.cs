using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.Infraestructure.CP;
using KlerenGen.Infraestructure.EN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Linq;
using System.Security.Cryptography;
using web_kleren.Assemblers;
using web_kleren.Models;
using KlerenGen.ApplicationCore.Enumerated.Kleren; //para mostrar selects con enums
using KlerenGen.ApplicationCore.Helpers; //para mostrar selects con enums

namespace web_kleren.Controllers
{
    public class ImagenVarianteController : BasicController
    {
        public readonly IWebHostEnvironment _webHost;

        public ImagenVarianteController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        
            // GET: ImagenVarianteController
        public ActionResult Index(int id)
        {
            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
            ArticuloEN artEN = artCEN.DamePorId(id);
            IList<VarianteEN> variantes = artCEN.DameVariantes(id);

            IList<ImagenVarianteEN> imagenesVariante = new List<ImagenVarianteEN>();

            foreach (var variante in variantes)
            {
                NHibernateUtil.Initialize(variante.ImagenVariante);

                if (variante.ImagenVariante != null)
                {
                    if (!imagenesVariante.Any(img => img.ImagenVarianteId == variante.ImagenVariante.ImagenVarianteId))
                    {
                        imagenesVariante.Add(variante.ImagenVariante);
                        Console.WriteLine($"Variante {variante.VarianteId} tiene una imagen: {variante.ImagenVariante.RutaArchivo}");
                    }
                    else
                    {
                        Console.WriteLine($"Imagen repetida encontrada: {variante.ImagenVariante.RutaArchivo}");
                    }
                }
                else
                {
                    Console.WriteLine($"Variante {variante.VarianteId} no tiene imagen.");
                }
            }

            IList<ImagenVarianteViewModel> imagenes = new ImagenVarianteAssembler().ConvertirListENToViewModel(imagenesVariante);
            SessionClose();
            ViewData["ArticuloId"] = id;
            ViewData["ArticuloNombre"] = artEN.Nombre;

            return View(imagenes);
        }

        // GET: ImagenVarianteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImagenVarianteController/Create
        public ActionResult Create(int id)
        {
            ImagenVarianteViewModel imagenVariante = new ImagenVarianteViewModel();

            SessionInitialize();
            ArticuloRepository articuloRepo = new ArticuloRepository(session);
            ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
            ArticuloEN artEN = artCEN.DamePorId(id);

            ArticuloCP articulocp = new ArticuloCP(new SessionCPNHibernate());
            IList<ColorEN> coloresEN = articulocp.DameColoresDelArticulo(id);
            IList<ColorViewModel> colores = new ColorAssembler().ConvertirListENToViewModel(coloresEN);

            CreateImagenVarianteViewModel createImagen = new CreateImagenVarianteAssembler().ConvertirToViewModel(imagenVariante, colores);

            ViewData["ArticuloNombre"] = artEN.Nombre;
            ViewData["ArticuloId"] = id;
            //ViewData["ColorOptions"] = EnumHelper.GetEnumSelectList<ColorEnum>();

            SessionClose();
            return View(createImagen);
        }

        // POST: ImagenVarianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateImagenVarianteViewModel img, int articuloId, int ColorSel)
        {
            string fileName = "", path = "";
            KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum colorSeleccionado = (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum)ColorSel;

            if (img.ImagenVariante.RutaArchivo != null && img.ImagenVariante.RutaArchivo.Length > 0)
            {
                fileName = Path.GetFileName(img.ImagenVariante.RutaArchivo.FileName).Trim();
                string directory = _webHost.WebRootPath + "/Images";
                path = Path.Combine(directory, fileName);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var stream = System.IO.File.Create(path))
                {
                    await img.ImagenVariante.RutaArchivo.CopyToAsync(stream);
                }
            }
            try
            {
                SessionInitialize();
                ImagenVarianteRepository imagenVarianteRepo = new ImagenVarianteRepository();
                ImagenVarianteCEN imgCEN = new ImagenVarianteCEN(imagenVarianteRepo);
                ArticuloRepository articuloRepo = new ArticuloRepository();
                ArticuloCEN artCEN = new ArticuloCEN(articuloRepo);
                IList<VarianteEN> variantes = artCEN.DameVariantesPorColor(articuloId, colorSeleccionado);
                foreach (var var in variantes)
                {
                    Console.WriteLine("Stock variante: " + var.Stock);
                }
                IList<int> variantesIds = variantes.Select(v => v.VarianteId).ToList();

                foreach (var id in variantesIds)
                {
                    Console.WriteLine("Id variante: " + id);
                }

                fileName = "/Images/" + fileName; 
                int oid = imgCEN.Nueva(fileName, img.ImagenVariante.TextoAlternativo);
                imgCEN.AsociarAVariante(oid, variantesIds);        
                SessionClose();

                return RedirectToAction(nameof(Index), new { id = articuloId });

                //return RedirectToAction(nameof(ArticuloController.Index), "Articulo");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al crear la imagen: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un error al crear la imagen.");
                return View(img);
                //return View();
            }
        }

        // GET: ImagenVarianteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImagenVarianteController/Edit/5
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

        // GET: ImagenVarianteController/Delete/5
        public ActionResult Delete(int idVariante, int idArt)
        {
            Console.WriteLine("Oye que borroooo");
            ImagenVarianteRepository imgRepo = new ImagenVarianteRepository();
            ImagenVarianteCEN imgCEN = new ImagenVarianteCEN(imgRepo);
            imgCEN.Borrar(idVariante);
            return RedirectToAction(nameof (Index), new { id = idArt });
        }

        // POST: ImagenVarianteController/Delete/5
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
