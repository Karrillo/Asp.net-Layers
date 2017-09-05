using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.AssetsLiabilities
{
    public class AssetLiabilityDto : Entity
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
        public decimal Rode { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? IdUser { get; set; }
        public int? IdAccount { get; set; }
        public int? IdCategory { get; set; }
        public int? IdInvoice { get; set; }
    }
}
