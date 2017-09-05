using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Sales
{
    public interface ISaleRepository
    {
        void Create(Sale input);
        void Update(Sale input);
        void Delete(int id);
        Sale Get(int id);
        Sale GetById(int id);
        List<Sale> GetAll();
    }
}
