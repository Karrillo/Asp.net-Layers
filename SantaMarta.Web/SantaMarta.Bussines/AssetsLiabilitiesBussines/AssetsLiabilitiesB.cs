using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.AssetLiabilityAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AssetsLiabilitiesBussines
{
    public class AssetsLiabilitiesB : IAssetsLiabilitiesB
    {
        private AssetsLiabilityAccess assetsLiabilityAccess = new AssetsLiabilityAccess();

        public int Create(AssetsLiabilities input)
        {
            return assetsLiabilityAccess.Create(input);
        }
        public int CreateCredit(AssetsLiabilities input)
        {
            return assetsLiabilityAccess.CreateCredit(input);
        }
        public Decimal? TotalSum(String dateStart, String dateEnd, Boolean type)
        {
            return assetsLiabilityAccess.TotalSum(dateStart, dateEnd, type);
        }
        public int Delete(int id)
        {
            return assetsLiabilityAccess.Delete(id);
        }
        public List<AssetsLiabilities> GetAll()
        {
            return assetsLiabilityAccess.GetAll();
        }
        public List<AssetsLiabilities> GetAllDate(String dateStart, String dateEnd)
        {
            return assetsLiabilityAccess.GetAllDate(dateStart, dateEnd);
        }
        public AssetsLiabilities GetById(int id)
        {
            return assetsLiabilityAccess.GetById(id);
        }
        public int Update(AssetsLiabilities input)
        {
            return assetsLiabilityAccess.Update(input);
        }
        public List<AssetsLiabilities> GetByIdInvoinces(Int64 id)
        {
            return assetsLiabilityAccess.GetByIdInvoinces(id);
        }
    }
}
