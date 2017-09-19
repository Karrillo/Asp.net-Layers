using System.Collections.Generic;
using SantaMarta.Data.Models.Providers;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.ProviderAccess
{
    public class ProviderAccess
    {
        ContextDb db = new ContextDb();

        public List<Providers> GetAll()
        {
            return null;
        }

        public Providers GetById(int id)
        {
            return null;
        }

        public bool Update(Providers user)
        {
            return true;
        }

        public bool Create(Providers user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
