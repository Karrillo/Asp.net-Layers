using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly IRepository _repository;
        private const string ProviderNoExists = "Provider does not exist!";

        public ProviderRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Provider input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Provider>(id);
        }

        public Provider GetById(int id)
        {
            var provider = _repository.GetById<Provider>(id);

            if (provider == null)
            {
                throw new Exception(ProviderNoExists);
            }

            return provider;
        }

        public List<Provider> GetAll()
        {
            var provider = _repository.GetAll<Provider>().ToList();

            return provider;
        }

        public void Update(Provider input)
        {
            var provider = _repository.GetById<Provider>(input.Id);
            if (provider == null)
            {
                throw new Exception(ProviderNoExists);
            }
            _repository.Update(input);
        }

        public Provider Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
