using SantaMarta.Bussines.UsersBussines;
using System.Web.Mvc;
using System.Linq;
using SantaMarta.Data.Models.Users;
using System;
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

        // GET: Users/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUser, Nickname, Password, Type")] Users users)
        {
            if (ModelState.IsValid)
            {
                userB.Create(users);
                return Json(new { success = true });
            }

            return PartialView(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var users = userB.GetById(id);

            if (users == null)
            {
                return HttpNotFound();
            }
            return PartialView(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUser, Nickname, Password, Type")] Users users)
        {
            if (ModelState.IsValid)
            {
                userB.Update(users);
                return Json(new { success = true });
            }

            return PartialView(users);
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
            try
            {
                userB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public JsonResult GetName(string name)
        {
            String nickName = userB.CheckNickname(name);
            return Json(nickName, JsonRequestBehavior.AllowGet);
        }
    }
}
