using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Persons;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.Providers
{
    public class Provider : Entity
    {
        public bool State { get; set; }
        public string NameCompany { get; set; } 
        public int? IdPerson { get; set; }
        //foreignkey 
        [ForeignKey("IdPerson")]
        public Person person { get; set; }
    }
}