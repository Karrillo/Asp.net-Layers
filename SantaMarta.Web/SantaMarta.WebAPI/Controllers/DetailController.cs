using SantaMarta.Bussines.DetailsBussines;
using System;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class DetailController : ApiController
    {
        // GET: api/Detail/5
        public IHttpActionResult Get(Int64 id)
        {
            Int64 detail;

            DetailsB detailsB = new DetailsB();

            detail = detailsB.Create(id);

            if (detail == -1)
            {
                return Ok(false);
            }

            return Ok(detail);
        }
    }
}
