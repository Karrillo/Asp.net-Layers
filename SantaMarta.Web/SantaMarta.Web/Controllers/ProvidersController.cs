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
            List<All_Clients> clients = clientsB.GetAll().ToList();
            List<All_Providers> providers = providersB.GetAll().ToList();
            foreach (var y in providers)
            {
                foreach (var x in clients)
                {
                    if (y.IDPerson == x.IDPerson)
                    {
                        y.IsClient = true;
                    }
                }
            }
            return View(providers);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var provider = providersB.GetById(id);

            if (provider == null)
            {
                return HttpNotFound();
            }

            return PartialView(provider);
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
                Persons provider = new Persons();

                provider.Name = collection["Name"];
                provider.FirstName = collection["FirstName"];
                provider.SecondName = collection["SecondName"];
                provider.Phone = collection["Phone"];
                provider.CellPhone = collection["CellPhone"];
                provider.Email = collection["Email"];
                provider.Address = collection["Address"];
                provider.Identification = collection["Identification"];
                provider.NameCompany = collection["NameCompany"];
                provider.Code = collection["Code"];

                providersB.Create(provider);

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

            var provider = providersB.GetById(id);

            if (provider == null)
            {
                return HttpNotFound();
            }

            return PartialView(provider);
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

                    Persons provider = new Persons();

                    provider.Name = collection["Name"];
                    provider.FirstName = collection["FirstName"];
                    provider.SecondName = collection["SecondName"];
                    provider.Phone = collection["Phone"];
                    provider.CellPhone = collection["CellPhone"];
                    provider.Email = collection["Email"];
                    provider.Address = collection["Address"];
                    provider.Identification = collection["Identification"];
                    provider.NameCompany = collection["NameCompany"];
                    provider.Code = collection["Code"];

                    providersB.Update(provider, id);

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
                providersB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public ActionResult CreatePC(int id)
        {
            return PartialView();
        }

        // POST: Clients/Delete/5
        [HttpPost]
        public ActionResult CreatePC(int id, FormCollection collection)
        {
            try
            {
                providersB.CreatePC(id);
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
