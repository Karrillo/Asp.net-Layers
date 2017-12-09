using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Data.Models.Products;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
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

            return PartialView(productsB.GetById(id));
        }

        // GET: ProductsSM/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: ProductsSM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            int status = productsB.Create(products);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se está usando actualmente");
                return View(products);
            }
            return View(products);
        }

        // GET: ProductsSM/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(productsB.GetById(id));
        }

        // POST: ProductsSM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products products)
        {
            int status = productsB.Update(products, id);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se está usando actualmente");
                return View(products);
            }
            return View(products);
        }

        // GET: ProductsSM/Delete/?
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: ProductsSM/Delete/?
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = productsB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
