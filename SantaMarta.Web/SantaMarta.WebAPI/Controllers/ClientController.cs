using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Data.Models.Clients;
using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IHttpActionResult Get()
        {
            IList<All_Clients> clients = null;

            ClientsB clientB = new ClientsB();

            clients = clientB.GetAll();

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // GET: api/Client/5
        public IHttpActionResult Get(int id)
        {
            All_Clients clients = null;

            ClientsB clientB = new ClientsB();

            clients = clientB.GetById(id);

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpGet]
        [ActionName("GetName")]
        public IHttpActionResult GetName(String name)
        {
            IList<All_Clients> clients = null;

            ClientsB clientB = new ClientsB();

            clients = clientB.GetByName(name);

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // POST: api/Client
        [HttpPost]
        public IHttpActionResult Post(Persons persons)
        {
            int clients;

            ClientsB clientB = new ClientsB();

            clients = clientB.Create(persons);

            if (clients != -1)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
