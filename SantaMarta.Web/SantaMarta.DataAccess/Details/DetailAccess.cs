using System.Collections.Generic;
using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.DetailAccess
{
    public class DetailAccess
    {
        ContextDb db = new ContextDb();

        public List<Details> GetAll()
        {
            return null;
        }

        public Details GetById(int id)
        {
            return null;
        }

        public bool Update(Details user)
        {
            return true;
        }

        public bool Create(Details user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
