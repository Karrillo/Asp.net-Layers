using System;

namespace SantaMarta.Data.Store_Procedures
{
    public class List_Products_Deleted
    {
        public Int64 IdProduct { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public Decimal? Tax { get; set; }
        public Boolean State { get; set; }
        public Int64 IdProvider { get; set; }
        public String NameCompany { get; set; }
        public String CodeProvider { get; set; }
        public String FullName { get; set; }
    }
}
