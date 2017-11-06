using System;

namespace SantaMarta.Data.Store_Procedures
{
    public class InvoicesTable
    {
        public Int64 IDInvoice { get; set; }
        public String Date { get; set; }
        public Decimal Rode { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String NameCompany { get; set; }
        public Int16 Type { get; set; }
    }
}
