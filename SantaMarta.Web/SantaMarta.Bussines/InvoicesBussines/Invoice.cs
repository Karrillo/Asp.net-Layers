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

        public int Delete(int id)
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

        public int Update(Invoices input)
        {
            return invoiceAccess.Update(input);
        }

        public List<Views_Invoices> GetAllSales()
        {
            return invoiceAccess.GetAllSales();
        }

        public List<View_Invoice_Details> GetAllDetails(Int64 id)
        {
            return invoiceAccess.GetAllDetails(id);
        }

        public Decimal GetSumInvoicesSale(Int64 id)
        {
            return invoiceAccess.GetSumInvoicesSale(id);
        }

        public Views_Sales_Purchase_Product GetSalesProduct(Int64 id)
        {
            return invoiceAccess.GetSalesProduct(id);
        }
    }
}
