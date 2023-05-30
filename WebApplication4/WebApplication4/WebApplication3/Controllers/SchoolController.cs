using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Repositories;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class SchoolController : Controller
    {
        readonly ISchoolRepository schoolRepository;
        public SchoolController(ISchoolRepository SchoollRepository)
        {
            schoolRepository = SchoollRepository;
        }

        [AllowAnonymous]
        // GET: SchoolController
        public ActionResult Index()
        {
            var Schools = schoolRepository.GetAll();
            return View(Schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var Schools = schoolRepository.FindByID(id);
            return View(Schools);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
        {
            schoolRepository.Add(s);
            return View();
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var Schools = schoolRepository.FindByID(id);
            return View(Schools);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, School newSchool)
        {
            schoolRepository.Update(id, newSchool);
            return View();
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var Schools = schoolRepository.FindByID(id);
            return View(Schools);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, School s)
        {
            schoolRepository.Delete(id);
            return View();
        }
    }
}
