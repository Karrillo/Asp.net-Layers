using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.InvoicesBussines
{
    public interface IInvoicesB
    {
        int Create(Invoices input);
        int Update(Invoices input);
        int Delete(Int64 id);
        Views_Invoinces_Details GetById(Int64 id, Boolean type);
        List<Views_Invoices> GetAllSales();
        List<Views_Invoices> GetAllPurchases();
        List<Views_Invoices> GetAllSalesExpired();
        List<Views_Invoices> GetAllPurchasesExpired();
        Int64 GetCode();
    }
}
