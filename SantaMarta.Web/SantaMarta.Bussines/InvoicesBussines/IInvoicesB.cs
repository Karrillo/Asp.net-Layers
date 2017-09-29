using SantaMarta.Data.Models.Invoices;
using System.Collections.Generic;

namespace SantaMarta.Bussines.InvoicesBussines
{
    public interface IInvoicesB
    {
        int Create(Invoices input);
        int Update(Invoices input);
        int Delete(int id);
        Invoices GetById(int id);
        List<Invoices> GetAll();
    }
}
