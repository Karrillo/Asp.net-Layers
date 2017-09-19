using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Accounts
{
    public class Accounts
    {
        [Key]
        public Int64 IDAccount { get; set; }
        public String Name { get; set; }
    }
}
