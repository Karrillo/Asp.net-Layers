using System.Collections.Generic;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Linq;

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
            List<Views_Invoices> invoice = new List<Views_Invoices>();
            try
            {
                invoice = db.Views_Invoices_All_Sales();
                return invoice;
            }
            catch (Exception)
            {
                return invoice;
            }
        }

        public List<Views_Invoices> GetAllPurchases()
        {
            List<Views_Invoices> invoice = new List<Views_Invoices>();
            try
            {
                invoice = db.Views_Invoices_All_Purchase();
                return invoice;
            }
            catch (Exception)
            {
                return invoice;
            }
        }

        public Views_Invoinces_Details GetById(Int64 id)
        {
            Views_Invoinces_Details invoice = new Views_Invoinces_Details();
            try
            {
                return db.View_Invoice_Clients(id);
            }
            catch (Exception)
            {
                return invoice;
            }
        }

        public int Update(Invoices user)
        {
            return 0;
        }

        public int Create(Invoices invoices)
        {
            try
            {
                db.Insert_Invoice(invoices);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Delete(Int64 id)
        {
            try
            {
                //db.delete(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
