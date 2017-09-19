using SantaMarta.Data.Models.Details;
using SantaMarta.DataAccess.DetailAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.DetailsBussines
{
    public class DetailsB : IDetailsB
    {
        private DetailAccess detailAccess = new DetailAccess();

        public bool Create(Details input)
        {
            return detailAccess.Create(input);
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
