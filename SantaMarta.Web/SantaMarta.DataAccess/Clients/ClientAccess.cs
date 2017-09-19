using System.Collections.Generic;
using SantaMarta.Data.Models.Clients;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.ClientAccess
{
    public class ClientAccess
    {
        ContextDb db = new ContextDb();

        public List<Clients> GetAll()
        {
            return null;
        }

        public Clients GetById(int id)
        {
            return null;
        }

        public bool Update(Clients user)
        {
            return true;
        }

        public bool Create(Clients user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
