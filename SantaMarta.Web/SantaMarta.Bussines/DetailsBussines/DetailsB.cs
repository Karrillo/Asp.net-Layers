using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.DetailAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public class DetailsB : IDetailsB
    {
        private DetailAccess detailAccess = new DetailAccess();

        public Int64 Create(Int64 id)
        {
            return detailAccess.Create(id);
        }

        public int Delete(Int64 id)
        {
            return detailAccess.Delete(id);
        }

        public List<Details> GetAll()
        {
            return detailAccess.GetAll();
        }

        public Details GetById(Int64 id)
        {
            return detailAccess.GetById(id);
        }

        public int Update(Details input)
        {
            return detailAccess.Update(input);
        }
    }
}
