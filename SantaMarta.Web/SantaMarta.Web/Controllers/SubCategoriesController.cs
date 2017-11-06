using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Data.Models.SubCategories;
using System;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class SubCategoriesController : Controller
    {
        private SubCategoriesB subCategoriesB;

        public SubCategoriesController()
        {
            subCategoriesB = new SubCategoriesB();
        }

        // GET: SubCategories
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubCategories/Create
        public ActionResult Create(int id)
        {
            return PartialView();
        }

        // POST: SubCategories/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                SubCategories subCategory = new SubCategories();

                subCategory.Name = collection["Name"];
                subCategory.IdCategory = id;

                subCategoriesB.Create(subCategory);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subcategory = subCategoriesB.GetById(id);

            if (subcategory == null)
            {
                return HttpNotFound();
            }

            return PartialView(subcategory);
        }

        // POST: SubCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    SubCategories subcategory = new SubCategories();

                    subcategory.Name = collection["Name"];
                    subcategory.IDSubCategory = id;

                    subCategoriesB.Update(subcategory);

                }

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: SubCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                subCategoriesB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public JsonResult GetName(string name, int id)
        {
            String nameSubCategory = subCategoriesB.CheckName(name, id);
            return Json(nameSubCategory, JsonRequestBehavior.AllowGet);
        }
    }
}
