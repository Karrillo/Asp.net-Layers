using SantaMarta.Data.Models.Products;
using SantaMarta.DataAccess.ProductAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsBussines
{
    public class ProductsB : IProductsB
    {
        private ProductAccess productAccess = new ProductAccess();
        public bool Create(Products input)
        {
            return productAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return productAccess.Delete(id);
        }

        public List<Products> GetAll()
        {
            return productAccess.GetAll();
        }

        public Products GetById(int id)
        {
            return productAccess.GetById(id);
        }

        public bool Update(Products input)
        {
            return productAccess.Update(input);
        }
    }
}
