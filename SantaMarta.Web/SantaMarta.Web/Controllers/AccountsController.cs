using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Data.Models.Accounts;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class AccountsController : Controller
    {
        private AccountsB accountB;

        public AccountsController()
        {
            accountB = new AccountsB();
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(accountB.GetAll().ToList());
        }

        public ActionResult Index2()
        {
            return View(accountB.GetAllDelete().ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Accounts accounts)
        {
            int status = accountB.Create(accounts);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se esta usando actualmente");
                return View(accounts);
            }
            return View(accounts);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(accountB.GetById(id));
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Accounts account)
        {
            int status = accountB.Update(account);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Name", "El nombre se esta usando actualmente");
                return View(account);
            }
            return View(account);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = accountB.Delete(id);

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

        public ActionResult Restore(int id)
        {
            return PartialView();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = accountB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
