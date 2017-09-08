using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Products
{
    public class Products : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? IdProvider { get; set; }
    }
}
