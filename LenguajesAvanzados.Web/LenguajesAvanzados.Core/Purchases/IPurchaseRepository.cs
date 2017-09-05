using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Purchases
{
    public interface IPurchaseRepository
    {
        void Create(Purchase input);
        void Update(Purchase input);
        void Delete(int id);
        Purchase Get(int id);
        Purchase GetById(int id);
        List<Purchase> GetAll();
    }
}
