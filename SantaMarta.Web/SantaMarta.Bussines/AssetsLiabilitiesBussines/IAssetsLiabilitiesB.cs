using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AssetsLiabilitiesBussines
{
    public interface IAssetsLiabilitiesB
    {
        int Create(AssetsLiabilities input);
        int Update(AssetsLiabilities input);
        int Delete(int id);
        AssetsLiabilities GetById(int id);
        List<AssetsLiabilities> GetAll();
        List<AssetsLiabilities> GetAllDate(String dateStart, String dateEnd);
        Decimal? TotalSum(String dateStart, String dateEnd, Boolean type);

    }
}
