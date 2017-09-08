using System;
using System.Collections.Generic;

namespace LenguajesAvanzados.Core.AssetsLiabilities
{
    public class AssetLiabilityCore : IAssetLiabilityCore
    {
        private readonly IAssetLiabilityRepository _assetLiabilityRepo;
        public AssetLiabilityCore(IAssetLiabilityRepository assetLiabilityRepo)
        {
            _assetLiabilityRepo = assetLiabilityRepo;
        }
        public AssetLiability GetById(int id)
        {
            return _assetLiabilityRepo.GetById(id);
        }

        public List<AssetLiability> GetAll()
        {
            return _assetLiabilityRepo.GetAll();
        }

        public void Create(AssetLiability input)
        {
            _assetLiabilityRepo.Create(input);
        }

        public void Update(AssetLiability input)
        {
            _assetLiabilityRepo.Update(input);
        }

        public void Delete(int id)
        {
            _assetLiabilityRepo.Delete(id);
        }

        public AssetLiability Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
