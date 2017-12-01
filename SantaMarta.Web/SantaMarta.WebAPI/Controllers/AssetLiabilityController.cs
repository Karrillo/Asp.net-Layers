using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Data.Models.AssetsLiabilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    public class AssetLiabilityController : ApiController
    {
        // GET: api/AssetLiability
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AssetLiability/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AssetLiability
        [HttpPost]
        public IHttpActionResult Post(AssetsLiabilities assetsLiabilities)
        {
            int assetsLiabilitie;

            AssetsLiabilitiesB assetsLiabilitiesB = new AssetsLiabilitiesB();

            assetsLiabilitie = assetsLiabilitiesB.CreateCredit(assetsLiabilities);

            switch (assetsLiabilitie)
            {
                case 200:
                    return Ok(200);
                    break;
                case 500:
                    return Ok(500);
                    break;
                default:
                    return Ok(false);
                    break;
            }
        }

        // PUT: api/AssetLiability/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AssetLiability/5
        public void Delete(int id)
        {
        }
    }
}
