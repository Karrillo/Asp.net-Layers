using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Sales
{
    public class SaleCore : ISaleCore
    {
        private readonly ISaleRepository _saleRepo;
        public SaleCore(ISaleRepository saleRepo)
        {
            _saleRepo = saleRepo;
        }
        public Sale GetById(int id)
        {
            return _saleRepo.GetById(id);
        }

        public List<Sale> GetAll()
        {
            return _saleRepo.GetAll();
        }

        public void Create(Sale input)
        {
            _saleRepo.Create(input);
        }

        public void Update(Sale input)
        {
            _saleRepo.Update(input);
        }

        public void Delete(int id)
        {
            _saleRepo.Delete(id);
        }

        public Sale Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

