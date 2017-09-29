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

        public List<Invoices> GetAll()
        {
            return null;
        }
        public List<Views_Invoices> GetAllSales()
        {
            return db.Views_Invoices_All_Sales();
        }

        public List<View_Invoice_Details> GetAllDetails(Int64 IDInvoice)
        {
            return db.View_Invoice_Details(IDInvoice);
        }

        public Decimal GetSumInvoicesSale(Int64 id)
        {
            return db.Sum_Invoices_Sale(id);
        }

        public Views_Sales_Purchase_Product GetSalesProduct(Int64 id)
        {
            return db.Views_Sales_Product(id);
        }

        public Invoices GetById(int id)
        {
            return null;
        }
        public int Update(Invoices user)
        {
            return 0;
        }

        public int Create(Invoices invoices)
        {
            return db.Insert_Invoice(invoices);
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}
