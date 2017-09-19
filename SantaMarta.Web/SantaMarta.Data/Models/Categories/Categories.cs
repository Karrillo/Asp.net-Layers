using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Categories
{
    public class Categories
    {
        [Key]
        public Int64 IDCategory { get; set; }
        public String Name { get; set; }
    }
}
