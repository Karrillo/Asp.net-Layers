using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Sales
{
    public class Sales : Entity
    {
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public int? IdProduct { get; set; }
        public int? IdInvoices { get; set; }
    }
}
