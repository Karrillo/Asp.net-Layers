using SantaMarta.Data.Models.Purchases;
using SantaMarta.DataAccess.PurchaseAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.PurchasesBussines
{
    public class PurchasesB : IPurchasesB
    {
        private PurchaseAccess purchaseAccess = new PurchaseAccess();
        public bool Create(Purchases input)
        {
            return purchaseAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return purchaseAccess.Delete(id);
        }

        public List<Purchases> GetAll()
        {
            return purchaseAccess.GetAll();
        }

        public Purchases GetById(int id)
        {
            return purchaseAccess.GetById(id);
        }

        public bool Update(Purchases input)
        {
            return purchaseAccess.Update(input);
        }
    }
}
