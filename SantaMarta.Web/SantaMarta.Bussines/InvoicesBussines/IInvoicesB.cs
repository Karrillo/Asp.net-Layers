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
        View_Invoice_Details GetById(Int64 id);
        List<Views_Invoices> GetAllSales();
        List<Views_Invoices> GetAllPurchases();
        decimal? GetSumInvoices(Int64 id);
        List<Views_Sales_Purchase_Product> GetSalesProduct(Int64 id);
        List<Views_Sales_Purchase_Product> GetPurchasesProduct(Int64 id);

    }
}
