using System.Collections.Generic;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.InvoiceAccess
{
    public class InvoiceAccess
    {
        ContextDb db = new ContextDb();

        public List<Invoices> GetAll()
        {
            return null;
        }

        public Invoices GetById(int id)
        {
            return null;
        }

        public bool Update(Invoices user)
        {
            return true;
        }

        public bool Create(Invoices user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
