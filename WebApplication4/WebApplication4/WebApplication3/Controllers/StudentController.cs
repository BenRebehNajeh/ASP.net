using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Repositories;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class StudentController : Controller
    {

        readonly IStudentRepository StudentRepository;
        readonly ISchoolRepository schoolRepository;
        public StudentController(IStudentRepository studRepository, ISchoolRepository schlRepository)
        {
            StudentRepository = studRepository;
            schoolRepository = schlRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var Students = StudentRepository.GetAll();
            return View(Students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var Students = StudentRepository.FindByID(id);
            return View(Students);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            StudentRepository.Add(s);
            return View();
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            var Students = StudentRepository.FindByID(id);
            return View(Students);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student newStudent)
        {
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            StudentRepository.Update(id, newStudent);
            return View();
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var Students = StudentRepository.FindByID(id);
            return View(Students);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student s)
        {
            StudentRepository.Delete(id);
            return View();
        }

        //SEARCH
        public ActionResult Search(string name, int? schoolid)
        {
            var result = StudentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = StudentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = StudentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}
