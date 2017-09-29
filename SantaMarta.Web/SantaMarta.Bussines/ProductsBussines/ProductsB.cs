using SantaMarta.Data.Models.Products;
using SantaMarta.DataAccess.ProductAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsBussines
{
    public class ProductsB : IProductsB
    {
        private ProductAccess productAccess = new ProductAccess();
        public int Create(Products input)
        {
            return productAccess.Create(input);
        }

        public int Delete(int id)
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

        public int Update(Products input, int id)
        {
            return productAccess.Update(input, id);
        }
    }
}
