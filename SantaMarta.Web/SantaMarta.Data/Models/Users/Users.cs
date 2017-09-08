using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Users
{
    public class Users : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }
        public bool State { get; set; }
    }
}
