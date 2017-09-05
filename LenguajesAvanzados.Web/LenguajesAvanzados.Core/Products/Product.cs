using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Providers;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.Products
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? IdProvider { get; set; }
        [ForeignKey("IdProvider")]
        public Provider provider { get; set; }
    }
}