using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Mapper.Dtos.Invoices
{
    public class InvoiceDto : Entity
    {
        public string Date { get; set; }
        public string State { get; set; }
        public string LimitDate { get; set; }
        public string Code { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int? IdClient { get; set; }
        public int? IdProvider { get; set; }
        public int? IdUser { get; set; }
    }
}
