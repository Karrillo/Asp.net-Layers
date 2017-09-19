using SantaMarta.Data.Models.Providers;
using SantaMarta.DataAccess.ProviderAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProvidersBussines
{
    public class ProvidersB : IProvidersB
    {
        private ProviderAccess providerAccess = new ProviderAccess();

        public bool Create(Providers input)
        {
            return providerAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return providerAccess.Delete(id);
        }

        public List<Providers> GetAll()
        {
            return providerAccess.GetAll();
        }

        public Providers GetById(int id)
        {
            return providerAccess.GetById(id);
        }

        public bool Update(Providers input)
        {
            return providerAccess.Update(input);
        }
    }
}
