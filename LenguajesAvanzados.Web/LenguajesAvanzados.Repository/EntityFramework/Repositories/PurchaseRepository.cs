using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IRepository _repository;
        private const string PurchaseNoExists = "Purchase does not exist!";

        public PurchaseRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Purchase input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Purchase>(id);
        }

        public Purchase GetById(int id)
        {
            var purchase = _repository.GetById<Purchase>(id);

            if (purchase == null)
            {
                throw new Exception(PurchaseNoExists);
            }

            return purchase;
        }

        public List<Purchase> GetAll()
        {
            var purchase = _repository.GetAll<Purchase>().ToList();

            return purchase;
        }

        public void Update(Purchase input)
        {
            var purchase = _repository.GetById<Purchase>(input.Id);
            if (purchase == null)
            {
                throw new Exception(PurchaseNoExists);
            }
            _repository.Update(input);
        }

        public Purchase Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
