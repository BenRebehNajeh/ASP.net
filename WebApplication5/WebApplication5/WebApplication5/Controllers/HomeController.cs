using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;
using WebApplication5.Models.Repositories;

namespace WebApplication5.Controllers
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
        
           public ActionResult DetailsCategorie (string cat, CategorieRepository c)
            {
                        var produitListe = c.GetProduitsByCateg(cat);
            return View(produitListe);
            }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}