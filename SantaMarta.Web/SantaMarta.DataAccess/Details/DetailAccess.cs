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

        public Details GetById(Int64 id)
        {
            return null;
        }

        public int Update(Details details)
        {
            return 0;
        }

        public Int64 Create(Int64 id)
        {
            return db.Insert_Detail(id);
        }

        public int Delete(Int64 id)
        {
            return 0;
        }
    }
}
