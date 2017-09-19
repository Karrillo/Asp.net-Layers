using System.Collections.Generic;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.PurchaseAccess
{
    public class PurchaseAccess
    {
        ContextDb db = new ContextDb();

        public List<Purchases> GetAll()
        {
            return null;
        }

        public Purchases GetById(int id)
        {
            return null;
        }

        public bool Update(Purchases user)
        {
            return true;
        }

        public bool Create(Purchases user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
