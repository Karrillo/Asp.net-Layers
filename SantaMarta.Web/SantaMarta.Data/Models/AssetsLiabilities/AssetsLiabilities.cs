using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.AssetsLiabilities
{
    public class AssetsLiabilities
    {
        [Key]
        public Int64 IDAssetLiability { get; set; }
        public DateTime CurrentDate { get; set; }
        public Int64 Code { get; set; }
        public Decimal Rode { get; set; }
        public Boolean Type { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public Boolean State { get; set; }
        public Int64? IdInvoice { get; set; }
        public Int64? IdAccount { get; set; }
        public Int64? IdSubCategory { get; set; }
        public Int64? IdUser { get; set; }
    }
}
