using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppPelda.Models;
using WebAppPelda.Services;

namespace WebAppPelda.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Sajat()
        {
            List<Vasarlo> vasarlok = new VasarloService().GetAllVasarlo();
            return View(vasarlok);
        }

        public IActionResult Vasarlo(int id)
        {
            Vasarlo kivalasztott = new VasarloService().GetById(id);
            return View(kivalasztott);
        }

        //Üres vásárló létrehozása a GET kérésre, majd a POST kérés feldolgozása
        [HttpGet]
        public IActionResult UjVasarlo()
        {
            var model = new Vasarlo();
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF elleni védelem
        public IActionResult UjVasarlo(Vasarlo vasarlo)
        {
            // Ha a szerveroldali validáció megbukik
            if (!ModelState.IsValid)
            {
                return View(vasarlo);
            }

            // Adatbázisba mentés logikája
            string result = new VasarloService().PostVasarlo(vasarlo);
             

            TempData["SuccessMessage"] = result;

            // Átirányítás a siker jelzésére (PRG pattern)
            return RedirectToAction(nameof(UjVasarlo));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
