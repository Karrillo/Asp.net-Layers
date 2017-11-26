using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SantaMarta.Data.Store_Procedures
{
    public class Views_Invoinces_Details
    {
        public Int64 IDInvoice { get; set; }
        public DateTime? LimitDate { get; set; }
        public String Code { get; set; }
        public Decimal? Discount { get; set; }
        public Decimal Total { get; set; }
        public Boolean State { get; set; }
        public Int64 IdProvider { get; set; }
        public Int64 IdClient { get; set; }
        public Int64 IdDetail { get; set; }
        public DateTime CurrentDate { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String NameCompany { get; set; }
        public Decimal Residue { get; set; }
        public Decimal Payments { get; set; }
        public String Date { get; set; }
        public List<Views_Invoinces_Products> Products { get; set; }
        public List<AssetsLiabilities> AssetsLiabilities { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
