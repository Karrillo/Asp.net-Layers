using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IHttpActionResult Get()
        {
            IList<Products> product = null;

            ProductsB productB = new ProductsB();

            product = productB.GetAll();

            if (product == null)
            {
                return Ok(false);
            }

            return Ok(product);
        }

        // GET: api/Product/5
        public IHttpActionResult Get(int id)
        {
            Products product = null;

            ProductsB productB = new ProductsB();

            product = productB.GetById(id);

            if (product == null)
            {
                return Ok(false);
            }

            return Ok(product);
        }
    }
}
