using SantaMarta.Bussines.DetailsBussines;
using SantaMarta.Data.Models.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class DetailController : ApiController
    {
        // POST: api/Detail
        [HttpPost]
        public IHttpActionResult Post(Int64 id)
        {
            Int64 clients;

            DetailsB detailsB = new DetailsB();

            clients = detailsB.Create(id);

            if (clients != -1)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
