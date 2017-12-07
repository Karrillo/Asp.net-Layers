using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Data.Models.Categories;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
    public class CategoriesController : Controller
    {
        private CategoriesB categoriesB;
        private SubCategoriesB subCategoriesB;

        public CategoriesController()
        {
            categoriesB = new CategoriesB();
            subCategoriesB = new SubCategoriesB();
        }

        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.Categories = categoriesB.GetAll().ToList();
            ViewBag.SubCategories = subCategoriesB.GetAll().ToList();
            return View();
        }

        // GET: Categories Deleted
        public ActionResult Index2()
        {
            return View(categoriesB.GetAllDelete().ToList());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            int status = categoriesB.Create(categories);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se está usando actualmente");
                return View(categories);
            }
            return View(categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(categoriesB.GetById(id));
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categories categories)
        {
            categories.IDCategory = id;
            int status = categoriesB.Update(categories);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se está usando actualmente");
                return View(categories);
            }
            return View(categories);
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
            int status = categoriesB.Delete(id);

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

        // POST: Restore
        public ActionResult Restore(int id)
        {
            return PartialView();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = categoriesB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
