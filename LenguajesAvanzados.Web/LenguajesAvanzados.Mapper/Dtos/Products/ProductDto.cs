using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.Products
{
    public class ProductDto : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? IdProvider { get; set; }
    }
}
