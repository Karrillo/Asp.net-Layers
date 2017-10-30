using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Invoices
{
    public class Invoices 
    {
        [Key]
        public Int64 IDInvoice { get; set; }
        public DateTime? LimitDate { get; set; }
        public String Code { get; set; }
        public Decimal? Discount { get; set; }
        public Decimal Total { get; set; }
        public Boolean? State { get; set; }
        public Int64? IdClient { get; set; }
        public Int64? IdProvider { get; set; }
        public Int64? IdDetail { get; set; }
    }
}
