using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Products
{
    public class Products
    {
        [Key]
        public Int64 IDAccount { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Boolean State { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public Int64 IdProvider { get; set; }
    }
}
