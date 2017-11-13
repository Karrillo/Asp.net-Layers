using System.Collections.Generic;
using SantaMarta.Data.Models.SubCategories;
using SantaMarta.Data.Store_Procedures;

namespace SantaMarta.Bussines.SubCategoriesBussines
{
    public interface ISubCategoriesB
    {
        int Create(SubCategories input);
        int Update(SubCategories input);
        int Delete(int id);
        int Restore(int id);
        SubCategories GetById(int id);
        List<SubCategories> GetAll();
        List<View_SubCategories_Deleted> GetAllDelete();
        List<SubCategories> GetByIdAll(int id);
        string GetByIdName(int id);
    }
}
