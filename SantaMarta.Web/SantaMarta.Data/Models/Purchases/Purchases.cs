using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Purchases
{
    public class Purchases 
    {
        [Key]
        public Int64 IDPurchase { get; set; }
        public String Code { get; set; }
        public Int16 Quantity { get; set; }
        public Decimal Total { get; set; }
        public Int64? IdProduct { get; set; }
        public Int64? IdDetails { get; set; }
    }
}
