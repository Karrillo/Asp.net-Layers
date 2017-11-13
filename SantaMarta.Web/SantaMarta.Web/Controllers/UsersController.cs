using SantaMarta.Bussines.UsersBussines;
using System.Web.Mvc;
using System.Linq;
using SantaMarta.Data.Models.Users;
using System.Net;

namespace SantaMarta.Web.Controllers
{
    public class UsersController : Controller
    {
        private UsersB userB;

        public UsersController()
        {
            userB = new UsersB();
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(userB.GetAll().ToList());
        }

        public ActionResult Index2()
        {
            return View(userB.GetAllDelete().ToList());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            int status = userB.Create(users);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("NickName", "El NickName se esta usando actualmente");
                return View(users);
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(userB.GetById(id));
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            int status = userB.Update(users);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("NickName", "El NickName se esta usando actualmente");
                return View(users);
            }
            return View(users);
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
            int status = userB.Delete(id);

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

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = userB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
