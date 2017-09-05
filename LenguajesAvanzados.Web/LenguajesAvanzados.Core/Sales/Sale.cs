using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Invoices;
using LenguajesAvanzados.Core.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.Sales
{
    public class Sale : Entity
    {
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public int? IdProduct { get; set; }
        public int? IdInvoices { get; set; }
        [ForeignKey("IdProduct")]
        public Product product { get; set; }
        [ForeignKey("IdInvoices")]
        public Invoice invoice { get; set; }
    }
}