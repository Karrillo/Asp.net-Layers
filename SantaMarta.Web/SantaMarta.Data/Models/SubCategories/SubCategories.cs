using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.SubCategories
{
    public class SubCategories
    {
        [Key]
        public Int64 IDSubCategory { get; set; }
        public String Name { get; set; }
        public Int64? IdCategory { get; set; }
    }
}
