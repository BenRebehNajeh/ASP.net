using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.Repositories;

namespace WebApplication5.Controllers
{
    public class CategorieController : Controller
    {
        readonly ICategorieRepository CategorieRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CategorieController(ICategorieRepository CatRepository, IWebHostEnvironment hostingEnvironment)
        {
            CategorieRepository = CatRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            var Categories = CategorieRepository.GetAll();
            return View(Categories);
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategorieController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie c)
        {
            CategorieRepository.Add(c);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            var categorie = CategorieRepository.FindByID(id);
            return View(categorie);
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categorie newCategorie)
        {
            CategorieRepository.Update(id, newCategorie);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            var Categories = CategorieRepository.FindByID(id);
            return View(Categories);
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categorie c)
        {
            CategorieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
