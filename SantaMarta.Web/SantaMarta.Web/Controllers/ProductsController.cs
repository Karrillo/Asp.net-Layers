using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Bussines.ProductsProvidersBussines;
using SantaMarta.Data.Models.Products;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsProvidersB productsProvidersB;
        private ProductsB productsB;

        public ProductsController()
        {
            productsProvidersB = new ProductsProvidersB();
            productsB = new ProductsB();
        }

        // GET: Products
        public ActionResult Index(String id)
        {

            if (id != null && id != "")
            {
                Session["IDProvider"] = id;
            }
            else
            {
                Session["IDProvider"] = null;
            }

            var providers = productsProvidersB.GetAllProviders().ToList();

            ViewBag.id = new SelectList(providers, "IDProvider", "NameCompany");


            return View(productsProvidersB.GetAll(Convert.ToInt32(id)).ToList());

        }

        // Get: Products Deleted
        public ActionResult Index2()
        {
            return View(productsB.GetAllDelete().ToList());
        }

        // Get Details Product
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(productsProvidersB.GetById(id));
        }

        // POST: Create View
        public ActionResult Create(int? id)
        {
            return PartialView();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products, int id)
        {
            products.IdProvider = id;

            int status = productsProvidersB.Create(products);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se esta usando actualmente");
                return View(products);
            }
            return View(products);
        }

        // GET: Client View
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(productsProvidersB.GetById(id));
        }

        // POST: Edit 
        [HttpPost]
        public ActionResult Edit(int id, Products products)
        {
            int status = productsProvidersB.Update(products, id);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se esta usando actualmente");
                return View(products);
            }
            return View(products);
        }

        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: ProductsSM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = productsProvidersB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            return PartialView();
        }

        public ActionResult Restore(int id)
        {
            return PartialView();
        }

        // POST: ProductsSM/Delete/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = productsB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
