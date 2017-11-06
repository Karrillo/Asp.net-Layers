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

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = clientsB.GetById(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return PartialView(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Persons client = new Persons();

                client.Name = collection["Name"];
                client.FirstName = collection["FirstName"];
                client.SecondName = collection["SecondName"];
                client.Phone = collection["Phone"];
                client.CellPhone = collection["CellPhone"];
                client.Email = collection["Email"];
                client.Address = collection["Address"];
                client.Identification = collection["Identification"];
                client.NameCompany = collection["NameCompany"];
                client.Code = collection["Code"];
                clientsB.Create(client);

                return Json(new { success = true });
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);

                return PartialView(collection);
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = clientsB.GetById(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            return PartialView(client);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Persons client = new Persons();

                    client.Name = collection["Name"];
                    client.FirstName = collection["FirstName"];
                    client.SecondName = collection["SecondName"];
                    client.Phone = collection["Phone"];
                    client.CellPhone = collection["CellPhone"];
                    client.Email = collection["Email"];
                    client.Address = collection["Address"];
                    client.Identification = collection["Identification"];
                    client.NameCompany = collection["NameCompany"];
                    client.Code = collection["Code"];

                    clientsB.Update(client, id);

                }

                return Json(new { success = true });
            }
            catch
            {
                return PartialView(collection);
            }
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
            try
            {
                clientsB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public ActionResult CreateCP(int id)
        {
            return PartialView();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult CreateCP(int id, FormCollection collection)
        {
            try
            {
                clientsB.CreateCP(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public JsonResult GetCode(string code)
        {
            String codePersons = personsB.CheckCode(code);
            return Json(codePersons, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIdentification(string identification)
        {
            String identificationPersons = personsB.CheckIdentification(identification);
            return Json(identificationPersons, JsonRequestBehavior.AllowGet);
        }
    }
}
