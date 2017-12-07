using System.Collections.Generic;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using System;
using SantaMarta.DataAccess.Emails;

namespace SantaMarta.DataAccess.InvoiceAccess
{
    public class InvoiceAccess
    {
        private ContextDb db;
        private EmailsAccess emails;
        private ClientAccess.ClientAccess clients;

        public InvoiceAccess()
        {
            db = new ContextDb();
            emails = new EmailsAccess();
            clients = new ClientAccess.ClientAccess();
        }

        //Get All Sales Invoices
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

        //Get All Purchases Invoices
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

        //Get All Sales Invoices Expired
        public List<Views_Invoices> GetAllSalesExpired()
        {
            List<Views_Invoices> invoice = new List<Views_Invoices>();
            try
            {
                invoice = db.Views_Invoices_All_Sales_Expired();
                return invoice;
            }
            catch (Exception)
            {
                return invoice;
            }
        }

        //Get All Purchases Invoices Expired
        public List<Views_Invoices> GetAllPurchasesExpired()
        {
            List<Views_Invoices> invoice = new List<Views_Invoices>();
            try
            {
                invoice = db.Views_Invoices_All_Purchase_Expired();
                return invoice;
            }
            catch (Exception)
            {
                return invoice;
            }
        }

        //Get Invoices
        public Views_Invoinces_Details GetById(Int64 id, Boolean type)
        {
            Views_Invoinces_Details invoice = new Views_Invoinces_Details();
            try
            {
                if (type == true)
                {
                    return db.View_Invoice_Clients(id);
                }
                else
                {
                    return db.View_Invoice_Providers(id);
                }
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

        //Create Invoices
        public int Create(Invoices invoices)
        {
            try
            {
                db.Insert_Invoice(invoices);
                int state = sendEmail(invoices);
                if (state == 200 || state == 400)
                {
                    return 200;
                }
                return 501;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Delete Invoices
        public int Delete(Int64 id)
        {
            try
            {
                Boolean? assetsLiabilities = db.Check_AssestLiabilities(id) ?? false;
                if (assetsLiabilities == false)
                {
                    db.Delete_Invoice(id);
                    return 200;
                }
                return 400;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Get Last Code Inovoices
        public Int64 GetCode()
        {
            try
            {
                String code = db.Code_Invoice();
                Int64 number = 0;

                if (code == null)
                {
                    return 1;
                }
                number = Int64.Parse(code);
                return number + 1;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Send Email Invoices
        private int sendEmail(Invoices invoices)
        {
            All_Clients client = clients.GetById(Convert.ToInt32(invoices.IdClient));

            if (client.Email != null)
            {
                String credit;

                if (Convert.ToDateTime(invoices.LimitDate).Date == DateTime.Now.Date)
                {
                    credit = "contado,";
                }
                else
                {
                    credit = "credito, con fecha a cancelar el " + Convert.ToDateTime(invoices.LimitDate).ToShortDateString();
                }
                String subject = "Productos Alimenticios Santa Marta Factura: " + invoices.Code;
                String body = "Factura a " + credit + " realizada el " + DateTime.Now.ToShortDateString() + " con el numero " + invoices.Code + " por un monto de ₡" + invoices.Total;
                int state = emails.SendEmail(client.Email, subject, body);
                return state;
            }
            return 400;
        }
    }
}
