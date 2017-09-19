using System.Collections.Generic;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.AssetLiabilityAccess
{
    public class AssetsLiabilityAccess
    {
        ContextDb db = new ContextDb();

        public List<AssetsLiabilities> GetAll()
        {
            return null;
        }

        public AssetsLiabilities GetById(int id)
        {
            return null;
        }

        public bool Update(AssetsLiabilities user)
        {
            return true;
        }

        public bool Create(AssetsLiabilities user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
