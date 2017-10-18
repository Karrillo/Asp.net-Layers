using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class PurchasesController : Controller
    {
        // GET: Purchases
        public ActionResult Index()
        {
            return View();
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchases/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purchases/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purchases/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
