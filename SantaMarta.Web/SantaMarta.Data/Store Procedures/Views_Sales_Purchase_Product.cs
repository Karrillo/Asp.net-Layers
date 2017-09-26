using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class Views_Sales_Purchase_Product
    {
        public Int64 IDPurchase { get; set; }
        public String Code { get; set; }
        public Int16 Quantity { get; set; }
        public Decimal Total { get; set; }
    }
}
