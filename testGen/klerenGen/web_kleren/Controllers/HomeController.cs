using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web_kleren.Models;

namespace web_kleren.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()

        {
            ArticuloRepository articuloRepo = new ArticuloRepository();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloRepo);
            IList<ArticuloEN> listaArt = articuloCEN.DameTodos(0, -1);

            return View(listaArt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // hola
    }
}
