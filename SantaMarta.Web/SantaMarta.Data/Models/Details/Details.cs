using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Details
{
    public class Details
    {
        [Key]
        public Int64 IDDetail { get; set; }
        public DateTime CurrentDate { get; set; }
        public Int64? IDUser { get; set; }
    }
}
