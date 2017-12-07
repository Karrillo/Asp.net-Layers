using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Bussines.PersonsBussines;
using SantaMarta.Bussines.ProvidersBussines;
using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
    public class ProvidersController : Controller
    {
        private ProvidersB providersB;
        private ClientsB clientsB;
        private PersonsB personsB;

        public ProvidersController()
        {
            providersB = new ProvidersB();
            clientsB = new ClientsB();
            personsB = new PersonsB();
        }

        // GET: Clients
        public ActionResult Index()
        {
            List<Int64> clients = clientsB.ClientsAll().ToList();
            List<All_Providers> providers = providersB.GetAll().ToList();

            foreach (var y in providers)
            {
                foreach (var x in clients)
                {
                    if (y.IDPerson == x)
                    {
                        y.IsClient = true;
                    }
                }
            }
            return View(providers);
        }

        // Get: Providers deleted
        public ActionResult Index2()
        {
            return View(providersB.GetAllDelete().ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(providersB.GetById(id));
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persons providers)
        {
            int status = providersB.Create(providers);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se está usando actualmente");
                return View(providers);
            }
            return View(providers);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(providersB.GetById(id));
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, All_Providers providers)
        {
            Persons provider = new Persons();

            provider.Code = providers.Code;
            provider.Name = providers.Name;
            provider.FirstName = providers.FirstName;
            provider.SecondName = providers.SecondName;
            provider.NameCompany = providers.NameCompany;
            provider.CellPhone = providers.CellPhone;
            provider.Phone = providers.Phone;
            provider.Email = providers.Email;
            provider.Address = providers.Address;

            int status = providersB.Update(provider, id);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se está usando actualmente");
                return View(providers);
            }
            return View(providers);
        }

        // POST: Restore
        public ActionResult Restore(int id)
        {
            return PartialView();
        }

        // POST: Clients/Restore/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = providersB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            return PartialView();
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = providersB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            return PartialView();
        }

        public ActionResult CreatePC(int id)
        {
            return PartialView();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult CreatePC(int id, FormCollection collection)
        {
            int status = providersB.CreatePC(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
