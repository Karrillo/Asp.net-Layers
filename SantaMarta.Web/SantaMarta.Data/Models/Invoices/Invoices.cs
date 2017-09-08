using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Invoices
{
    public class Invoices : Entity
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
