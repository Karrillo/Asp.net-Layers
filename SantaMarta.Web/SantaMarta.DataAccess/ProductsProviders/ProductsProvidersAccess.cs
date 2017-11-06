using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.ProductsProviders
{
    public class ProductsProvidersAccess
    {
        private ContextDb db;

        public ProductsProvidersAccess()
        {
            db = new ContextDb();
        }

        public List<Products> GetAll(Int64 id)
        {
            List<Products> products = db.Provider_Products(id).ToList();
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
            return db.Insert_Product(products);
        }

        public int Delete(int id)
        {
            return db.Delete_Product(id);
        }

        public List<List_Providers> GetAllProviders()
        {
            List<List_Providers> providers = db.List_Providers().ToList();
            return providers;
        }
    }
}
