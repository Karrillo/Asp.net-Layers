using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.Users
{
    public class UserDto : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }
        public bool State { get; set; }
    }
}
