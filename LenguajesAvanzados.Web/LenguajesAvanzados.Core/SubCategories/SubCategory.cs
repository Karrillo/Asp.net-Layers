using LenguajesAvanzados.Core.Categories;
using LenguajesAvanzados.Core.ConfigInterface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LenguajesAvanzados.Core.SubCategories
{
    public class SubCategory : Entity
    {
        public string Name { get; set; }
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category category { get; set; }
    }
}