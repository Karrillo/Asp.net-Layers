using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.InvoiceAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.InvoicesBussines
{
    public class InvoicesB : IInvoicesB
    {
        private InvoiceAccess invoiceAccess = new InvoiceAccess();
        public int Create(Invoices input)
        {
            return invoiceAccess.Create(input);
        }

        public int Delete(Int64 id)
        {
            return invoiceAccess.Delete(id);
        }

        public View_Invoice_Details GetById(Int64 id)
        {
            return invoiceAccess.GetById(id);
        }

        public int Update(Invoices input)
        {
            return invoiceAccess.Update(input);
        }

        public List<Views_Invoices> GetAllSales()
        {
            return invoiceAccess.GetAllSales();
        }

        public List<Views_Invoices> GetAllPurchases()
        {
            return invoiceAccess.GetAllPurchases();
        }

        public decimal? GetSumInvoices(Int64 id) {
            return invoiceAccess.GetSumInvoices(id);
        }
        public List<Views_Sales_Purchase_Product> GetSalesProduct(Int64 id)
        {
            return invoiceAccess.GetSalesProduct(id);
        }
        public List<Views_Sales_Purchase_Product> GetPurchasesProduct(Int64 id)
        {
            return invoiceAccess.GetPurchasesProduct(id);
        }
    }
}
