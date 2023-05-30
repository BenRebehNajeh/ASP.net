using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Models.Help;
using WebApplication5.Models.Repositories;

namespace WebApplication5.Controllers
{
	public class PanierController : Controller

	{
		readonly ProduitsRepository produitRepository;
		public PanierController(ProduitsRepository produitRepository)
		{
			this.produitRepository = produitRepository;
		}

		// GET: PanierController
		public ActionResult Index()
		{
			ViewBag.Liste = ListeCart.Instance.Items;
			ViewBag.total = ListeCart.Instance.GetSubTotal();
			return View();
		}

		// GET: PanierController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PanierController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PanierController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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

		// GET: PanierController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PanierController/Edit/5
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

		// GET: PanierController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PanierController/Delete/5
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

		public ActionResult AjouterProduit(int id)
		{
			Produit pp = produitRepository.GetById(id);
			ListeCart.Instance.AddItem(pp);
			ViewBag.Liste = ListeCart.Instance.Items;
			ViewBag.total = ListeCart.Instance.GetSubTotal();
			return View();
		}
		[HttpPost]
		public ActionResult PlusProduit(int id)
		{
			Produit pp = produitRepository.GetById(id);
			ListeCart.Instance.AddItem(pp);
			Item trouve = null;
			foreach (Item a in ListeCart.Instance.Items)
			{
				if (a.Prod.ProduitId == pp.ProduitId)
					trouve = a;
			}
			var results = new
			{
				ct = 1,
				Total = ListeCart.Instance.GetSubTotal(),
				Quatite = trouve.quantite,
				TotalRow = trouve.TotalPrice
			};
			return Json(results);
		}
		[HttpPost]
		public ActionResult MoinsProduit(int id)
		{
			Produit pp = produitRepository.GetById(id);
			ListeCart.Instance.SetLessOneItem(pp);
			Item trouve = null;
			foreach (Item a in ListeCart.Instance.Items)
			{
				if (a.Prod.ProduitId == pp.ProduitId)
					trouve = a;
			}
			if (trouve != null)
			{
				var results = new
				{
					Total = ListeCart.Instance.GetSubTotal(),
					Quatite = trouve.quantite,
					TotalRow = trouve.TotalPrice,
					ct = 1
				};
				return Json(results);
			}
			else
			{
				var results = new
				{
					ct = 0
				};
				return Json(results);
			}
			return null;
		}
		public ActionResult CheckOut()
		{
			return View();
		}
		[HttpPost]
		public ActionResult CheckOut(FormCollection collection)
		{
			ListeCart.Instance.Items.Clear();
			ViewBag.Message = "Commande effectuée zvec succès";
			return View();
		}
		[HttpPost]
		public ActionResult SupprimerProduit(int id)
		{
			Produit pp = produitRepository.GetById(id);
			ListeCart.Instance.RemoveItem(pp);
			var results = new
			{
				Total = ListeCart.Instance.GetSubTotal(),
			};
			return Json(results);
		}
	}

}
