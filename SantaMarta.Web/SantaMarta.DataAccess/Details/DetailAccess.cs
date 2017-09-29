using System.Collections.Generic;
using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.Entity;
using System;

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

        public bool Update(Details details)
        {
            return true;
        }

        public int Create(Int64 id)
        {
            return db.Insert_Detail(id);
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
