using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Data.Models.SubCategories;
using System;
using System.Linq;
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

        // GET: SubCategories Deleted
        public ActionResult Index2()
        {
            return View(subCategoriesB.GetAllDelete().ToList());
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
        public ActionResult Create(int id, SubCategories subCategory)
        {
            subCategory.IdCategory = id;
            int status = subCategoriesB.Create(subCategory);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se esta usando actualmente");
                return View(subCategory);
            }
            return View(subCategory);
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
        public ActionResult Edit(int id, SubCategories subcategory)
        {
            subcategory.IDSubCategory = id;
            int status = subCategoriesB.Update(subcategory);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se esta usando actualmente");
                return View(subcategory);
            }
            return View(subcategory);
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
            int status = subCategoriesB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                TempData["message"] = "Exists";
                return Json(new { success = true });
            }
            return PartialView();
        }

        // View Restore
        public ActionResult Restore(int id)
        {
            return PartialView();
        }

        // POST: SubCategories/Restore/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = subCategoriesB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
