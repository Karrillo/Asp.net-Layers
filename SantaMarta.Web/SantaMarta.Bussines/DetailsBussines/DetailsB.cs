using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.DetailAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public class DetailsB : IDetailsB
    {
        private DetailAccess detailAccess = new DetailAccess();

        public int Create(Int64 id)
        {
            return detailAccess.Create(id);
        }

        public bool Delete(int id)
        {
            return detailAccess.Delete(id);
        }

        public List<Details> GetAll()
        {
            return detailAccess.GetAll();
        }

        public Details GetById(int id)
        {
            return detailAccess.GetById(id);
        }

        public bool Update(Details input)
        {
            return detailAccess.Update(input);
        }
    }
}
