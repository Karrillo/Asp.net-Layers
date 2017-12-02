using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Data.Models.SubCategories;
using System.Collections.Generic;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    public class SubCategoriesController : ApiController
    {
        // GET: api/SubCategories
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SubCategories/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            IList <SubCategories> subCategories = null;

            SubCategoriesB subCategoriesB = new SubCategoriesB();

            subCategories = subCategoriesB.GetByIdAll(id);

            if (subCategories == null)
            {
                Ok(false);
            }

            return Ok(subCategories);
        }

        // POST: api/SubCategories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SubCategories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SubCategories/5
        public void Delete(int id)
        {
        }
    }
}
