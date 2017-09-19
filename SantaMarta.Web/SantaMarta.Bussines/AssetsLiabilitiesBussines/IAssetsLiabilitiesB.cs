using SantaMarta.Data.Models.AssetsLiabilities;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AssetsLiabilitiesBussines
{
    public interface IAssetsLiabilitiesB
    {
        bool Create(AssetsLiabilities input);
        bool Update(AssetsLiabilities input);
        bool Delete(int id);
        AssetsLiabilities GetById(int id);
        List<AssetsLiabilities> GetAll();
    }
}
