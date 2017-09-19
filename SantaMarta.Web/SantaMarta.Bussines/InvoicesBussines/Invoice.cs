using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.InvoiceAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.InvoicesBussines
{
    public class InvoicesB : IInvoicesB
    {
        private InvoiceAccess invoiceAccess = new InvoiceAccess();
        public bool Create(Invoices input)
        {
            return invoiceAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return invoiceAccess.Delete(id);
        }

        public List<Invoices> GetAll()
        {
            return invoiceAccess.GetAll();
        }

        public Invoices GetById(int id)
        {
            return invoiceAccess.GetById(id);
        }

        public bool Update(Invoices input)
        {
            return invoiceAccess.Update(input);
        }
    }
}
