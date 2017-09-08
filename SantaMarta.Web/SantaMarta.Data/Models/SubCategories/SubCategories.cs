using SantaMarta.Data.Models.ConfigInterface;

namespace SantaMarta.Data.Models.SubCategories
{
    public class SubCategories : Entity
    {
        public string Name { get; set; }
        public int? IdCategory { get; set; }
    }
}
