using System;
using System.ComponentModel.DataAnnotations;

namespace SantaMarta.Data.Models.Users
{
    public class Users
    {
        [Key]
        public Int64 IDUser { get; set; }
        public String Nickname { get; set; }
        public String Password { get; set; }
        public Boolean Type { get; set; }
        public Boolean State { get; set; }
    }
}
