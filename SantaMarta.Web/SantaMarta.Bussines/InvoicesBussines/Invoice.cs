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

        public Views_Invoinces_Details GetById(Int64 id, Boolean type)
        {
            return invoiceAccess.GetById(id, type);
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

        public List<Views_Invoices> GetAllSalesExpired()
        {
            return invoiceAccess.GetAllSalesExpired();
        }

        public List<Views_Invoices> GetAllPurchasesExpired()
        {
            return invoiceAccess.GetAllPurchasesExpired();
        }

        public Int64 GetCode()
        {
            return invoiceAccess.GetCode();
        }
    }
}
