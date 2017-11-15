using SantaMarta.Data.Models.Categories;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.CategoriesBussines
{
    public interface ICategoriesB
    {
        int Create(Categories input);
        int Update(Categories input);
        int Delete(int id);
        int Restore(int id);
        Categories GetById(int id);
        List<Categories> GetAll();
        List<Categories> GetAllDelete();
    }
}
