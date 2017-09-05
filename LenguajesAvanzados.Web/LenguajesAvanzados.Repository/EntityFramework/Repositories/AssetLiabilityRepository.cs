using LenguajesAvanzados.Core.AssetsLiabilities;
using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class AssetLiabilityRepository : IAssetLiabilityRepository
    {
        private readonly IRepository _repository;
        private const string AssetLiabilityNoExists = "Asset Liability does not exist!";

        public AssetLiabilityRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(AssetLiability input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<AssetLiability>(id);
        }

        public AssetLiability GetById(int id)
        {
            var assetLiability = _repository.GetById<AssetLiability>(id);

            if (assetLiability == null)
            {
                throw new Exception(AssetLiabilityNoExists);
            }

            return assetLiability;
        }

        public List<AssetLiability> GetAll()
        {
            var assetLiability = _repository.GetAll<AssetLiability>().ToList();

            return assetLiability;
        }

        public void Update(AssetLiability input)
        {
            var assetLiability = _repository.GetById<AssetLiability>(input.Id);
            if (assetLiability == null)
            {
                throw new Exception(AssetLiabilityNoExists);
            }
            _repository.Update(input);
        }

        public AssetLiability Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
