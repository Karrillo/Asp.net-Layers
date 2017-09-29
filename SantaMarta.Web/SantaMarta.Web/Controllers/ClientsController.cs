using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Data.Models.Persons;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class ClientsController : Controller
    {
        ClientsB clientsB = new ClientsB();

        // GET: Clients
        public ActionResult Index()
        {
            return View(clientsB.GetAll().ToList());
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
                client.identification = collection["Identification"];
                client.NameCompany = collection["NameCompany"];

                clientsB.Create(client);

                return Json(new { success = true });
            }
            catch(InvalidCastException e)
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
                    client.identification = collection["Identification"];
                    client.NameCompany = collection["NameCompany"];

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
    }
}
