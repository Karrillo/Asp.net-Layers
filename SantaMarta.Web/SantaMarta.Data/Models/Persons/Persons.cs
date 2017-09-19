using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Persons
{
    public class Persons
    {
        [Key]
        public Int64 IDPerson { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String CellPhone { get; set; }
        public String Address { get; set; }
        public String identification { get; set; }
        public String NameCompany { get; set; }
    }
}
