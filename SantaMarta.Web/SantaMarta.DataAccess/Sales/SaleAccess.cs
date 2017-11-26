using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Sales;
using System;
using SantaMarta.Data.Store_Procedures;
using System.Linq;

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
            List<Views_Invoinces_Products> products = new List<Views_Invoinces_Products>();

            try
            {
                products = db.Views_Invoice_Product_Sale(id).ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        public int Update(Sales user)
        {
            return 0;
        }

        public int Create(Sales sales)
        {
            try
            {
                db.Insert_Sale(sales);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Delete(Int64 id)
        {
            try
            {
                db.Delete_Sale(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
