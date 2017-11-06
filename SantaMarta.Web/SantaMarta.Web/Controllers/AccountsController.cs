using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Data.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Accounts account = new Accounts();
                account.Name = collection["Name"];

                accountB.Create(account);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var users = accountB.GetById(id);

            if (users == null)
            {
                return HttpNotFound();
            }
            return PartialView(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Accounts account = new Accounts();
                account.Name = collection["Name"];
                account.IDAccount = id;

                accountB.Update(account);

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
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
                accountB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public JsonResult GetName(string name)
        {
            String nameAccount = accountB.CheckName(name);
            return Json(nameAccount, JsonRequestBehavior.AllowGet);
        }
    }
}
