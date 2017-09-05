using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IRepository _repository;
        private const string SaleNoExists = "Sale does not exist!";

        public SaleRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Sale input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Sale>(id);
        }

        public Sale GetById(int id)
        {
            var sale = _repository.GetById<Sale>(id);

            if (sale == null)
            {
                throw new Exception(SaleNoExists);
            }

            return sale;
        }

        public List<Sale> GetAll()
        {
            var sale = _repository.GetAll<Sale>().ToList();

            return sale;
        }

        public void Update(Sale input)
        {
            var sale = _repository.GetById<Sale>(input.Id);
            if (sale == null)
            {
                throw new Exception(SaleNoExists);
            }
            _repository.Update(input);
        }

        public Sale Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
