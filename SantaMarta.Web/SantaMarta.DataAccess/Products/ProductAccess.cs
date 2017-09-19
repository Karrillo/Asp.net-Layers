using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Products;


namespace SantaMarta.DataAccess.ProductAccess
{
    public class ProductAccess
    {
        ContextDb db = new ContextDb();

        public List<Products> GetAll()
        {
            return null;
        }

        public Products GetById(int id)
        {
            return null;
        }

        public bool Update(Products user)
        {
            return true;
        }

        public bool Create(Products user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
