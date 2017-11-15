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
    public class ClientsController : Controller
    {
        private ClientsB clientsB;
        private ProvidersB providersB;
        private PersonsB personsB;

        public ClientsController()
        {
            clientsB = new ClientsB();
            providersB = new ProvidersB();
            personsB = new PersonsB();
        }

        // GET: Clients
        public ActionResult Index()
        {
            List<All_Clients> clients = clientsB.GetAll().ToList();
            List<All_Providers> providers = providersB.GetAll().ToList();

            foreach (var y in clients)
            {
                foreach (var x in providers)
                {
                    if (y.IDPerson == x.IDPerson)
                    {
                        y.IsProvider = true;
                    }
                }
            }
            return View(clients);
        }

        public ActionResult Index2()
        {
            return View(clientsB.GetAllDelete().ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(clientsB.GetById(id));
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persons clients)
        {
            int status = clientsB.Create(clients);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se esta usando actualmente");
                return View(clients);
            }
            else if (status == 401)
            {
                ModelState.AddModelError("Identification", "La identificacion se esta usando actualmente");
                return View(clients);
            }
            return View(clients);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView(clientsB.GetById(id));
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(All_Clients clients, int id)
        {
            Persons client = new Persons();

            client.Code = clients.Code;
            client.Identification = clients.Identification;
            client.Name = clients.Name;
            client.FirstName = clients.FirstName;
            client.SecondName = clients.SecondName;
            client.NameCompany = clients.NameCompany;
            client.CellPhone = clients.CellPhone;
            client.Phone = clients.Phone;
            client.Email = clients.Email;
            client.Address = clients.Address;

            int status = clientsB.Update(client, id);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Code", "El codigo se esta usando actualmente");
                return View(clients);
            }
            else if (status == 401)
            {
                ModelState.AddModelError("Identification", "La identificacion se esta usando actualmente");
                return View(clients);
            }
            return View(clients);
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
            int status = clientsB.Delete(id);

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

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult Restore(int id, FormCollection collection)
        {
            int status = clientsB.Restore(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }

        public ActionResult CreateCP(int id)
        {
            return PartialView();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult CreateCP(int id, FormCollection collection)
        {
            int status = clientsB.CreateCP(id);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return PartialView();
        }
    }
}
