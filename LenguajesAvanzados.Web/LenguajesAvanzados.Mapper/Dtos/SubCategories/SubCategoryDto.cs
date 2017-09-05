using LenguajesAvanzados.Mapper.Dtos.ConfigInterface;

namespace LenguajesAvanzados.Mapper.Dtos.SubCategories
{
    public class SubCategoryDto : Entity
    {
        public string Name { get; set; }
        public int? IdCategory { get; set; }
    }
}
