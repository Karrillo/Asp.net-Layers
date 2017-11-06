using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;
using System;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Products;

namespace SantaMarta.DataAccess.SaleAccess
{
    public class SaleAccess
    {
        private ContextDb db;

        public SaleAccess() {
            db = new ContextDb();
        }

        public List<Sales> GetAll()
        {
            return null;
        }

        public List<Views_Invoinces_Products> GetById(Int64 id)
        {
            return db.Views_Invoice_Product(id);
        }

        public int Update(Sales user)
        {
            return 0;
        }

        public int Create(Sales sales)
        {
            return db.Insert_Sale(sales);
        }

        public int Delete(Int64 id)
        {
            return db.Delete_Sale(id);
        }
    }
}
