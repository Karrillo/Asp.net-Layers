using SantaMarta.Data.Models.Categories;
using System.Collections.Generic;

namespace SantaMarta.Bussines.CategoriesBussines
{
    public interface ICategoriesB
    {
        bool Create(Categories input);
        bool Update(Categories input);
        bool Delete(int id);
        Categories GetById(int id);
        List<Categories> GetAll();
    }
}
