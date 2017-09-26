using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class Views_Invoices
    {
        public Int64 IDInvoice { get; set; }
        public Decimal Total { get; set; }
        public Boolean State { get; set; }
        public String CurrentDate { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String NameCompany { get; set; }
    }
}
