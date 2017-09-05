using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IRepository _repository;
        private const string InvoiceNoExists = "Invoice does not exist!";

        public InvoiceRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Invoice input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Invoice>(id);
        }

        public Invoice GetById(int id)
        {
            var invoice = _repository.GetById<Invoice>(id);

            if (invoice == null)
            {
                throw new Exception(InvoiceNoExists);
            }

            return invoice;
        }

        public List<Invoice> GetAll()
        {
            var reservation = _repository.GetAll<Invoice>().ToList();

            return reservation;
        }

        public void Update(Invoice input)
        {
            var invoice = _repository.GetById<Invoice>(input.Id);
            if (invoice == null)
            {
                throw new Exception(InvoiceNoExists);
            }
            _repository.Update(input);
        }

        public Invoice Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
