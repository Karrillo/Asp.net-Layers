using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Products;
using System.Linq;
using System;

namespace SantaMarta.DataAccess.ProductAccess
{
    public class ProductAccess
    {
        ContextDb db = new ContextDb();

        public List<Products> GetAll()
        {
            List<Products> products = db.List_Products_SM().ToList();
            return products;
        }

        public Products GetById(int id)
        {
            return db.View_Product(id);
        }

        public int Update(Products products, Int64 id)
        {
            return db.Update_Product(products, id);
        }

        public int Create(Products products)
        {
            return db.Insert_Product_SM(products);
        }

        public int Delete(int id)
        {
            return db.Delete_Product(id);
        }
    }
}
