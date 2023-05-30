using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication5.Models.Repositories;
using WebApplication5.Models;
using WebApplication5.Models.ViewModel;

namespace WebApplication5.Controllers
{
    public class ProduitController : Controller

    {

        readonly IProduitsRepository ProduitsRepository;
        readonly ICategorieRepository CategorieRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ProduitController(IProduitsRepository ProdRepository, ICategorieRepository CatRepository, IWebHostEnvironment hostingEnvironment)
        {
            ProduitsRepository = ProdRepository;
            CategorieRepository = CatRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            ViewBag.CategorieId = new SelectList(CategorieRepository.GetAll(), "CategorieId", "Nom");
            var Produits = ProduitsRepository.GetAll();
            return View(Produits);
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            var Produits = ProduitsRepository.GetById(id);
            return View(Produits);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(CategorieRepository.GetAll(), "CategorieId", "Nom");
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProduitViewModel model)
        {
            ViewBag.CategorieId = new SelectList(CategorieRepository.GetAll(), "CategorieId", "Nom");

            if (ModelState.IsValid)
            {
                string? uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.ImagePath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder

                    model.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Produit newProduit = new Produit
                {
                    Nom = model.Nom,
                    Prix = model.Prix,
                    CategorieId = model.CategorieId,
                    Quantite = model.Quantite,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Image = uniqueFileName
                };
                ProduitsRepository.Add(newProduit);
                return RedirectToAction("details", new { id = newProduit.ProduitId });
            }
            return View();
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategorieId = new SelectList(CategorieRepository.GetAll(), "CategorieId", "Nom");

            Produit produit = ProduitsRepository.GetById(id);
            EditProduitViewModel produitEditViewModel = new EditProduitViewModel
            {
                ProduitId = produit.ProduitId,
                Nom = produit.Nom,
                Prix = produit.Prix,
                CategorieId = produit.CategorieId,
                Quantite = produit.Quantite,
                ExistingImagePath = produit.Image
            };
            return View(produitEditViewModel);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProduitViewModel model)
        {
            ViewBag.CategorieId = new SelectList(CategorieRepository.GetAll(), "CategorieId", "Nom");

            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the product being edited from the database
                Produit produit = ProduitsRepository.GetById(model.ProduitId);
                // Update the product object with the data in the model object
                produit.Nom = model.Nom;
                produit.Prix = model.Prix;
                produit.CategorieId = model.CategorieId;
                produit.Quantite = model.Quantite;

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.ImagePath != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", (string)model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the product object which will be
                    // eventually saved in the database
                    produit.Image = ProcessUploadedFile(model);

                }
                // Call update method on the repository service passing it the
                // product object to update the data in the database table
                Produit updatedProduit = ProduitsRepository.Update(produit);

                if (updatedProduit != null)
                    return RedirectToAction("Index");
                else
                    return NotFound();

            }
            return View(model);
        }
        [NonAction]
        private string ProcessUploadedFile(CreateProduitViewModel model)
        {
            string uniqueFileName = null;

            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            var Produits = ProduitsRepository.FindByID(id);
            return View(Produits);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produit p)
        {
            ProduitsRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
     }

