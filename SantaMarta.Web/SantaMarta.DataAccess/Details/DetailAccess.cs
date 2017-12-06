using System.Collections.Generic;
using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.Entity;
using System;

namespace SantaMarta.DataAccess.DetailAccess
{
    public class DetailAccess
    {
        private ContextDb db;

        public DetailAccess()
        {
            db = new ContextDb();
        }

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

        //Create Details
        public Int64 Create(Int64 id)
        {
            try
            {
                return db.Insert_Detail(id);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(Int64 id)
        {
            return 0;
        }
    }
}
