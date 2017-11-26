using System.Collections.Generic;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.DataAccess.Entity;
using System;
using SantaMarta.Data.Store_Procedures;
using System.Linq;

namespace SantaMarta.DataAccess.PurchaseAccess
{
    public class PurchaseAccess
    {
        private ContextDb db;

        public PurchaseAccess()
        {
            db = new ContextDb();
        }

        public List<Purchases> GetAll()
        {
            return null;
        }

        public List<Views_Invoinces_Products> GetById(Int64 id)
        {
            List<Views_Invoinces_Products> products = new List<Views_Invoinces_Products>();

            try
            {
                products = db.Views_Invoice_Product_Purcase(id).ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        public int Update(Purchases user)
        {
            return 0;
        }

        public int Create(Purchases purchase)
        {
            try
            {
                db.Insert_Purchase(purchase);
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
                db.Delete_Purchase(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
