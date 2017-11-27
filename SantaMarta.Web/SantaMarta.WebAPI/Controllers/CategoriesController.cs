using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Data.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        [HttpGet]
        public IHttpActionResult Get()
        {
            IList<Categories> categories = null;

            CategoriesB categoriesB = new CategoriesB();

            categories = categoriesB.GetAll();

            if (categories == null)
            {
                Ok(false);
            }

            return Ok(categories);
        }

        // GET: api/Categories/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categories
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
