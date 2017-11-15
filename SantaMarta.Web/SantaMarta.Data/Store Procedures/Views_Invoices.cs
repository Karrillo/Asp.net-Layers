using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime? LimitDate { get; set; }
        public String Code { get; set; }
        public DateTime CurrentDate { get; set; }
        public String Name { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String NameCompany { get; set; }
        public Decimal? Rode { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
