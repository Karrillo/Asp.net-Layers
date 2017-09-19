using SantaMarta.Data.Models.Providers;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProvidersBussines
{
    public interface IProvidersB
    {
        bool Create(Providers input);
        bool Update(Providers input);
        bool Delete(int id);
        Providers GetById(int id);
        List<Providers> GetAll();
    }
}
