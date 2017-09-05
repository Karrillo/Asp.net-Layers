using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Providers
{
    public interface IProviderRepository
    {
        void Create(Provider input);
        void Update(Provider input);
        void Delete(int id);
        Provider Get(int id);
        Provider GetById(int id);
        List<Provider> GetAll();
    }
}
