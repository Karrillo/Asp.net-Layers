using System;

namespace SantaMarta.Data.Store_Procedures
{
    public class Check_Payment
    {
        public Int64 IDInvoice { get; set; }
        public Decimal? Total { get; set; }
        public Decimal? Rode { get; set; }
    }
}
