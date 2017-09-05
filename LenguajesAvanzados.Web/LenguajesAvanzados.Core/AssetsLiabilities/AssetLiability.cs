using LenguajesAvanzados.Core.Accounts;
using LenguajesAvanzados.Core.Categories;
using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Invoices;
using LenguajesAvanzados.Core.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.AssetsLiabilities
{
    public class AssetLiability : Entity
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
        [ForeignKey("IdUser")]
        public User user { get; set; }
        [ForeignKey("IdAccount")]
        public Account account { get; set; }
        [ForeignKey("IdCategory")]
        public Category category { get; set; }
        [ForeignKey("IdInvoice")]
        public Invoice invoice { get; set; }
    }

}
