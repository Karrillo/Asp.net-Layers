using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Clients
{
    public class Clients 
    {
        [Key]
        public Int64 IDClient { get; set; }
        public Boolean State { get; set; }
        public Int64? IdPerson { get; set; }
    }
}
