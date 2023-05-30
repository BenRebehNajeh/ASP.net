using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.Models.Repositories;

namespace projet.Controllers
{
    public class DepartementController : Controller
    {
        readonly IDepartementRepository DepartementRepository;
        public DepartementController(IDepartementRepository DepRepository)
        {
            DepartementRepository = DepRepository;
        }
        // GET: DepartementController
        public ActionResult Index()
        {
            var departements = DepartementRepository.GetAll();
            return View(departements);
        }

        // GET: DepartementController/Details/5
        public ActionResult Details(int id)
        {
            var departements = DepartementRepository.FindByID(id);
            return View(departements);
        }

        // GET: DepartementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement d)
        {
            DepartementRepository.Add(d);
            return View();
        }

        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            var Departements = DepartementRepository.FindByID(id);
            return View(Departements);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departement newDepartement)
        {

            DepartementRepository.Update(id, newDepartement);
            return View();
        }

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int id)
        {
            var Departements = DepartementRepository.FindByID(id);
            return View(Departements);
        }

        // POST: DepartementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departement d)
        {
            DepartementRepository.Delete(id);
            return View();
        }
    }
}
