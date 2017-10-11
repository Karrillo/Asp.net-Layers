using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Data.Models.Categories;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesB categoriesB = new CategoriesB();
        SubCategoriesB subCategoriesB = new SubCategoriesB();

        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.Categories = categoriesB.GetAll().ToList();
            ViewBag.SubCategories = subCategoriesB.GetAll().ToList();
            return View();
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Categories category = new Categories();

                category.Name = collection["Name"];

                categoriesB.Create(category);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = categoriesB.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return PartialView(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Categories category = new Categories();

                    category.Name = collection["Name"];
                    category.IDCategory = id;

                    categoriesB.Update(category);

                }

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                categoriesB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
