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
        // GET: api/Invoice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Invoice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invoice
        [HttpPost]
        public IHttpActionResult Post(Invoices invoices)
        {
            int invoice;

            InvoicesB invoicesB = new InvoicesB();

            invoice = invoicesB.Create(invoices);

            if (invoice != -1)
            {
                return BadRequest();
            }

            return Ok();
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
                return NotFound();
            }

            return Ok(invoice);
        }

        [Route("api/Invoice/GetInvoicesDetails")]
        [HttpGet]
        public IHttpActionResult GetInvoicesDetails(Int64 id)
        {
            View_Invoice_Details invoice = null;

            InvoicesB invoiceB = new InvoicesB();

            invoice = invoiceB.GetById(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [Route("api/Invoice/GetSumInvoicesSale")]
        [HttpGet]
        public IHttpActionResult GetSumInvoicesSale(Int64 id)
        {
            Decimal? invoice;

            InvoicesB invoiceB = new InvoicesB();

            invoice = invoiceB.GetSumInvoices(id);

            return Ok(invoice);
        }

        [Route("api/Invoice/GetSalesProduct")]
        [HttpGet]
        public IHttpActionResult GetSalesProduct(Int64 id)
        {
            InvoicesB invoiceB = new InvoicesB();

            var invoice = invoiceB.GetSalesProduct(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }
        // PUT: api/Invoice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invoice/5
        public void Delete(int id)
        {
        }
    }
}
