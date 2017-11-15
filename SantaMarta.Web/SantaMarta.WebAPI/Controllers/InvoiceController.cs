using SantaMarta.Bussines.InvoicesBussines;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        // POST: api/Invoice
        [HttpPost]
        public IHttpActionResult Post(Invoices invoices)
        {
            int invoice;

            InvoicesB invoicesB = new InvoicesB();

            invoice = invoicesB.Create(invoices);

            switch (invoice)
            {
                case 200:
                    return Ok(200);
                    break;
                case 500:
                    return Ok(500);
                    break;
                default:
                    return Ok(false);
                    break;
            }
        }

        [Route("api/Invoice/GetInvoicesAllSales")]
        [HttpGet]
        public IHttpActionResult GetInvoicesAllSales()
        {
            IList<Views_Invoices> invoice = null;

            InvoicesB invoiceB = new InvoicesB();

            invoice = invoiceB.GetAllSales();

            if (invoice == null)
            {
                Ok(false);
            }

            return Ok(invoice);
        }

        [Route("api/Invoice/GetInvoicesDetails")]
        [HttpGet]
        public IHttpActionResult GetInvoicesDetails(Int64 id)
        {
            Views_Invoinces_Details invoice = null;

            InvoicesB invoiceB = new InvoicesB();

            invoice = invoiceB.GetById(id);

            if (invoice == null)
            {
                Ok(false);
            }

            return Ok(invoice);
        }
    }
}
