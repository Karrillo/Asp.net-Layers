using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.DataAccess.AssetLiabilityAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AssetsLiabilitiesBussines
{
    public class AssetsLiabilitiesB : IAssetsLiabilitiesB
    {
        private AssetsLiabilityAccess assetsLiabilityAccess = new AssetsLiabilityAccess();

        public bool Create(AssetsLiabilities input)
        {
            return assetsLiabilityAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return assetsLiabilityAccess.Delete(id);
        }

        public List<AssetsLiabilities> GetAll()
        {
            return assetsLiabilityAccess.GetAll();
        }

        public AssetsLiabilities GetById(int id)
        {
            return assetsLiabilityAccess.GetById(id);
        }

        public bool Update(AssetsLiabilities input)
        {
            return assetsLiabilityAccess.Update(input);
        }
    }
}
