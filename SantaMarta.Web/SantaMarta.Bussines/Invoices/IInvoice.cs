using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Invoices
{
    public interface IInvoiceCore
    {
        void Create(Invoice input);
        void Update(Invoice input);
        void Delete(int id);
        Invoice Get(int id);
        Invoice GetById(int id);
        List<Invoice> GetAll();
    }
}
