using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.Purchases
{
    public class PurchaseDto : Entity
    {
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public int? IdProduct { get; set; }
        public int? IdInvoices { get; set; }
    }
}
