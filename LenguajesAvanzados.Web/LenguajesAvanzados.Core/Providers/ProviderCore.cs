using System;
using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Providers
{
    public class ProviderCore : IProviderCore
    {
        private readonly IProviderRepository _providerRepo;
        public ProviderCore(IProviderRepository providerRepo)
        {
            _providerRepo = providerRepo;
        }
        public Provider GetById(int id)
        {
            return _providerRepo.GetById(id);
        }

        public List<Provider> GetAll()
        {
            return _providerRepo.GetAll();
        }

        public void Create(Provider input)
        {
            _providerRepo.Create(input);
        }

        public void Update(Provider input)
        {
            _providerRepo.Update(input);
        }

        public void Delete(int id)
        {
            _providerRepo.Delete(id);
        }

        public Provider Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
