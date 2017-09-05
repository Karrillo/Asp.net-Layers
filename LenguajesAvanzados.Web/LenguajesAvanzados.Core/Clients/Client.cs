using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Persons;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.Clients
{
    public class Client : Entity
    {
        public bool State { get; set; }
        public int? IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public Person person { get; set; }
    }
}