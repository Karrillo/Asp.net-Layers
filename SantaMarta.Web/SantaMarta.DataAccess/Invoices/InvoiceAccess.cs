using System.Collections.Generic;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using System;

namespace SantaMarta.DataAccess.InvoiceAccess
{
    public class InvoiceAccess
    {
        ContextDb db = new ContextDb();

        public List<Views_Invoices> GetAllSales()
        {
            return db.Views_Invoices_All_Sales();
        }
        public List<Views_Invoices> GetAllPurchases()
        {
            return db.Views_Invoices_All_Purchase();
        }
        public Decimal? GetSumInvoices(Int64 id)
        {
            return db.Sum_Invoices(id);
        }
        public List<Views_Sales_Purchase_Product> GetSalesProduct(Int64 id)
        {
            return db.Views_Sales_Product(id);
        }
        public List<Views_Sales_Purchase_Product> GetPurchasesProduct(Int64 id)
        {
            return db.Views_Purchase_Product(id);
        }
        public View_Invoice_Details GetById(Int64 id)
        {
            return db.View_Invoice_Details(id);
        }
        public int Update(Invoices user)
        {
            return 0;
        }
        public int Create(Invoices invoices)
        {
            return db.Insert_Invoice(invoices);
        }
        public int Delete(Int64 id)
        {
            return 0;
        }
    }
}
