using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet.Models;
using projet.Models.Repositories;

namespace projet.Controllers
{
    public class EnseignantController : Controller
                
    {
        readonly IEnseignantRepository EnseignantRepository;
        readonly IDepartementRepository DepartementRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public EnseignantController(IEnseignantRepository EnsgRepository, IDepartementRepository DepRepository, IWebHostEnvironment hostingEnvironment)
        {
            EnseignantRepository = EnsgRepository;
            DepartementRepository = DepRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: EnseignantController
        public ActionResult Index()
        {
            ViewBag.ID = new SelectList(DepartementRepository.GetAll(), "ID", "Nom","Responsable");
            var Enseignants = EnseignantRepository.GetAll();
            return View(Enseignants);
        }

        // GET: EnseignantController/Details/5

        public ActionResult Details(int id)
        {
            var Enseignants = EnseignantRepository.GetById(id);
            return View(Enseignants);
        }

        // GET: EnseignantController/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(DepartementRepository.GetAll(), "ID", "Nom", "Responsable");
            return View();
        }

        // POST: EnseignantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enseignant e)
        {
            ViewBag.ID = new SelectList(DepartementRepository.GetAll(), "ID", "Nom", "Responsable");
            EnseignantRepository.Add(e);
            return View();
            
        }

        // GET: EnseignantController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ID = new SelectList(DepartementRepository.GetAll(), "ID", "Nom", "Responsable");
            var Enseignants = EnseignantRepository.FindByID(id);
            return View(Enseignants);
        }

        // POST: EnseignantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Enseignant newEnseignant)
        {
            ViewBag.ID = new SelectList(DepartementRepository.GetAll(), "ID", "Nom","Responsable");
            EnseignantRepository.Update(id, newEnseignant);
            return View();
        }

        // GET: EnseignantController/Delete/5
        public ActionResult Delete(int id)
        {
            var Enseignants = EnseignantRepository.FindByID(id);
            return View(Enseignants);
        }

        // POST: EnseignantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Enseignant e)
        {
            EnseignantRepository.Delete(id);
            return View();
        }
        
    }
}
