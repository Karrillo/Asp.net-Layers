using System.Collections.Generic;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using System;

namespace SantaMarta.DataAccess.InvoiceAccess
{
    public class InvoiceAccess
    {
        private ContextDb db;

        public InvoiceAccess()
        {
            db = new ContextDb();
        }

        public List<Views_Invoices> GetAllSales()
        {
            return db.Views_Invoices_All_Sales();
        }
        public List<Views_Invoices> GetAllPurchases()
        {
            return db.Views_Invoices_All_Purchase();
        }
        public Views_Invoinces_Details GetById(Int64 id)
        {
            return db.View_Invoice_Clients(id);
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
