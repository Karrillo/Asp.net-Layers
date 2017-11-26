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
                return Ok(false);
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
                return Ok(false);
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
                return Ok(false);
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

            switch (clients)
            {
                case 200:
                    return Ok(200);
                    break;
                case 401:
                    return Ok(401);
                    break;
                case 400:
                    return Ok(400);
                    break;
                case 500:
                    return Ok(500);
                    break;
                default:
                    return Ok(false);
                    break;
            }
        }
    }
}
