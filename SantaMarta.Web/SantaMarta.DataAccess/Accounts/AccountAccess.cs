using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Accounts;


namespace SantaMarta.DataAccess.AccountAccess
{
    public class AccountAccess
    {
        ContextDb db = new ContextDb();

        public List<Accounts> GetAll()
        {
            return null;
        }

        public Accounts GetById(int id)
        {
            return null;
        }

        public bool Update(Accounts user)
        {
            return true;
        }

        public bool Create(Accounts user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
