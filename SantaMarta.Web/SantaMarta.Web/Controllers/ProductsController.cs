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
        private ProductsProvidersB productsProvidersB = new ProductsProvidersB();

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

            ViewBag.id = new SelectList(productsProvidersB.GetAllProviders().ToList(), "IDProvider", "NameCompany");

            try
            {
                return View(productsProvidersB.GetAll(Convert.ToInt32(id)).ToList());
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = productsProvidersB.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView(product);
        }

        public ActionResult Create(int? id)
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, int id)
        {
            try
            {
                Products product = new Products();

                product.Code = collection["Code"];
                product.Name = collection["Name"];
                product.Price = Decimal.Parse(collection["Price"]);
                product.Description = collection["Description"];
                product.Tax = Decimal.Parse(collection["Tax"]);
                product.IdProvider = Convert.ToInt32(id);

                productsProvidersB.Create(product);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = productsProvidersB.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Products product = new Products();

                    product.Code = collection["Code"];
                    product.Name = collection["Name"];
                    product.Price = Decimal.Parse(collection["Price"]);
                    product.Description = collection["Description"];
                    product.Tax = Decimal.Parse(collection["Tax"]);

                    productsProvidersB.Update(product, id);
                }

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: ProductsSM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                productsProvidersB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
