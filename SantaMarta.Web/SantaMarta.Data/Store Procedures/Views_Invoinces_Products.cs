using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class Views_Invoinces_Products
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public Decimal? Tax { get; set; }
        public Int32 Quantity { get; set; }
        public Decimal Total { get; set; }

        [NotMapped]
        public int ConfirmStatus { get; set; }
    }
}
