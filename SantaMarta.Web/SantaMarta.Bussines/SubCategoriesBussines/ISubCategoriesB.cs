using System.Collections.Generic;
using SantaMarta.Data.Models.SubCategories;


namespace SantaMarta.Bussines.SubCategoriesBussines
{
    public interface ISubCategoriesB
    {
        bool Create(SubCategories input);
        bool Update(SubCategories input);
        bool Delete(int id);
        SubCategories GetById(int id);
        List<SubCategories> GetAll();
    }
}
