using LenguajesAvanzados.Core.Clients;
using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Providers;
using LenguajesAvanzados.Core.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.Invoices
{
    public class Invoice : Entity
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
        [ForeignKey("IdClient")]
        public Client client { get; set; }
        [ForeignKey("IdProvider")]
        public Provider provider { get; set; }
        [ForeignKey("IdUser")]
        public User user { get; set; }
    }
}