using System;
using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Purchases
{
    public class PurchaseCore : IPurchaseCore
    {
        private readonly IPurchaseRepository _purchaseRepo;
        public PurchaseCore(IPurchaseRepository purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }
        public Purchase GetById(int id)
        {
            return _purchaseRepo.GetById(id);
        }

        public List<Purchase> GetAll()
        {
            return _purchaseRepo.GetAll();
        }

        public void Create(Purchase input)
        {
            _purchaseRepo.Create(input);
        }

        public void Update(Purchase input)
        {
            _purchaseRepo.Update(input);
        }

        public void Delete(int id)
        {
            _purchaseRepo.Delete(id);
        }

        public Purchase Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
