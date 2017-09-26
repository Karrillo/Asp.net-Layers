using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class All_Clients
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
        public Int64 IDClient { get; set; }
    }
}
