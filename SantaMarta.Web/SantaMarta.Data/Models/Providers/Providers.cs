using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Providers
{
    public class Providers : Entity
    {
        public bool State { get; set; }
        public string NameCompany { get; set; }
        public int? IdPerson { get; set; }
    }
}
