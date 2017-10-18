using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Bussines.DetailsBussines;
using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Bussines.SalesBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class SalesController : Controller
    {
        SalesB saleB = new SalesB();
        AssetsLiabilitiesB assetsLiabilitiesB = new AssetsLiabilitiesB();
        ClientsB clientsB = new ClientsB();
        ProductsB productsB = new ProductsB();
        DetailsB details = new DetailsB();

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
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

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sales/Edit/5
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

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
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

        public ActionResult Assets(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Assets(int id, FormCollection collection)
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
