using SantaMarta.Bussines.SalesBussines;
using SantaMarta.Data.Models.Sales;
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

            switch (sale)
            {
                case 200:
                    return Ok(200);
                case 500:
                    return Ok(500);
                default:
                    return Ok(false);
            }
        }
        // DELETE: api/Sale/5
        public IHttpActionResult Delete(int id)
        {
            int sale;

            SalesB salesB = new SalesB();

            sale = salesB.Delete(id);

            switch (sale)
            {
                case 200:
                    return Ok(200);
                case 500:
                    return Ok(500);
                default:
                    return Ok(false);
            }
        }
    }
}
