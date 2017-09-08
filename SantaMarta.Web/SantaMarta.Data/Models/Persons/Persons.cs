using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.Persons
{
    public class Persons : Entity
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string identification { get; set; }
    }
}
