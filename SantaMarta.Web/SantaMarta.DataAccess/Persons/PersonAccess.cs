using System.Collections.Generic;
using SantaMarta.Data.Models.Persons;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.PersonAccess
{
    public class PersonAccess
    {
        ContextDb db = new ContextDb();

        public List<Persons> GetAll()
        {
            return null;
        }

        public Persons GetById(int id)
        {
            return null;
        }

        public bool Update(Persons user)
        {
            return true;
        }

        public bool Create(Persons user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
