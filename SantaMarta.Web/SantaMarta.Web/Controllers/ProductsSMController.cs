using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Data.Models.Products;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class ProductsSMController : Controller
    {
        private ProductsB productsB;

        public ProductsSMController()
        {
            productsB = new ProductsB();
        }

        // GET: ProductsSM
        public ActionResult Index()
        {
            return View(productsB.GetAll().ToList());
        }

        // GET: ProductsSM/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = productsB.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView(product);
        }

        // GET: ProductsSM/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: ProductsSM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Products product = new Products();

                product.Code = collection["Code"];
                product.Name = collection["Name"];
                product.Price = Decimal.Parse(collection["Price"]);
                product.Description = collection["Description"];
                product.Tax = Decimal.Parse(collection["Tax"]);

                productsB.Create(product);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        // GET: ProductsSM/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = productsB.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return PartialView(product);
        }

        // POST: ProductsSM/Edit/5
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

                    productsB.Update(product, id);
                }

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
        }

        // GET: ProductsSM/Delete/5
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
                productsB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public JsonResult GetProduct(string name)
        {
            String product = productsB.CheckName(name);
            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}
