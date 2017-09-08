using System;
using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Invoices
{
    public class InvoiceCore : IInvoiceCore
    {
        private readonly IInvoiceRepository _invoiceRepo;
        public InvoiceCore(IInvoiceRepository invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }
        public Invoice GetById(int id)
        {
            return _invoiceRepo.GetById(id);
        }

        public List<Invoice> GetAll()
        {
            return _invoiceRepo.GetAll();
        }

        public void Create(Invoice input)
        {
            _invoiceRepo.Create(input);
        }

        public void Update(Invoice input)
        {
            _invoiceRepo.Update(input);
        }

        public void Delete(int id)
        {
            _invoiceRepo.Delete(id);
        }

        public Invoice Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
