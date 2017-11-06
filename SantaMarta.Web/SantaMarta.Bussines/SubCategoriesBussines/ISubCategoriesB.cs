using System.Collections.Generic;
using SantaMarta.Data.Models.SubCategories;
using System;

namespace SantaMarta.Bussines.SubCategoriesBussines
{
    public interface ISubCategoriesB
    {
        int Create(SubCategories input);
        int Update(SubCategories input);
        int Delete(int id);
        SubCategories GetById(int id);
        List<SubCategories> GetAll();
        List<SubCategories> GetByIdAll(int id);
        string GetByIdName(int id);
        String CheckName(string name, int id);
    }
}
