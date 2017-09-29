using SantaMarta.Bussines.SalesBussines;
using SantaMarta.Data.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        // POST: api/Sale
        [HttpPost]
        public IHttpActionResult Post(Sales sales)
        {
            int sale;

            SalesB salesB = new SalesB();

            sale = salesB.Create(sales);

            if (sale != -1)
            {
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Sale/5
        public IHttpActionResult Delete(int id)
        {
            int sale;

            SalesB salesB = new SalesB();

            sale = salesB.Delete(id);

            if (sale != -1)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
