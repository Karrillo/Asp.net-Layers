using SantaMarta.Data.Models.Invoices;
using System.Collections.Generic;

namespace SantaMarta.Bussines.InvoicesBussines
{
    public interface IInvoicesB
    {
        bool Create(Invoices input);
        bool Update(Invoices input);
        bool Delete(int id);
        Invoices GetById(int id);
        List<Invoices> GetAll();
    }
}
