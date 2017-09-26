using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class List_Providers
    {
        [Key]
        public Int64 IDProvider { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String NameCompany { get; set; }       
    }
}
