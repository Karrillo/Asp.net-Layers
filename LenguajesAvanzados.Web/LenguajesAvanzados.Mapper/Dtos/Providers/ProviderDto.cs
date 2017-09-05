using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.Providers
{
    public class ProviderDto : Entity
    {
        public bool State { get; set; }
        public string NameCompany { get; set; }
        public int? IdPerson { get; set; }
    }
}
