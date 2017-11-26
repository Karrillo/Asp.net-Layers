using SantaMarta.Data.Models.Purchases;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.PurchaseAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PurchasesBussines
{
    public class PurchasesB : IPurchasesB
    {
        private PurchaseAccess purchaseAccess = new PurchaseAccess();
        public int Create(Purchases input)
        {
            return purchaseAccess.Create(input);
        }

        public int Delete(Int64 id)
        {
            return purchaseAccess.Delete(id);
        }

        public List<Purchases> GetAll()
        {
            return purchaseAccess.GetAll();
        }

        public List<Views_Invoinces_Products> GetById(Int64 id)
        {
            return purchaseAccess.GetById(id);
        }

        public int Update(Purchases input)
        {
            return purchaseAccess.Update(input);
        }
    }
}
