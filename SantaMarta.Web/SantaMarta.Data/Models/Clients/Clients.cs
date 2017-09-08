using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Clients
{
    public class Clients : Entity
    {
        public bool State { get; set; }
        public int? IdPerson { get; set; }
    }
}
