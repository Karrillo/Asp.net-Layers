using System.Collections.Generic;

namespace LenguajesAvanzados.Core.AssetsLiabilities
{
    public interface IAssetLiabilityRepository
    {
        void Create(AssetLiability input);
        void Update(AssetLiability input);
        void Delete(int id);
        AssetLiability Get(int id);
        AssetLiability GetById(int id);
        List<AssetLiability> GetAll();
    }
}
