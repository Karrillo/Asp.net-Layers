using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Providers
{
    public class Providers 
    {
        [Key]
        public Int64 IDProvider { get; set; }
        public Boolean State { get; set; }
        public Int64? IdPerson { get; set; }
    }
}
