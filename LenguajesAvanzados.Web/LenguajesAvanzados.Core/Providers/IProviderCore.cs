using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Providers
{
    public interface IProviderCore
    {
        void Create(Provider input);
        void Update(Provider input);
        void Delete(int id);
        Provider Get(int id);
        Provider GetById(int id);
        List<Provider> GetAll();
    }
}
