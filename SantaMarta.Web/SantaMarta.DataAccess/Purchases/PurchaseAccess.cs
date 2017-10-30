using System.Collections.Generic;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.DataAccess.Entity;
using System;

namespace SantaMarta.DataAccess.PurchaseAccess
{
    public class PurchaseAccess
    {
        ContextDb db = new ContextDb();

        public List<Purchases> GetAll()
        {
            return null;
        }

        public List<Purchases> GetById(Int64 id)
        {
            return null;
        }

        public int Update(Purchases user)
        {
            return 0;
        }

        public int Create(Purchases purchase)
        {
            return db.Insert_Purchase(purchase);
        }

        public int Delete(Int64 id)
        {
            return 0;
        }
    }
}
