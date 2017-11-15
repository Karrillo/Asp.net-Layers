using SantaMarta.Data.Models.Categories;
using SantaMarta.DataAccess.CategoryAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.CategoriesBussines
{
    public class CategoriesB : ICategoriesB
    {
        private CategoryAccess categoryAccess = new CategoryAccess();

        public int Create(Categories input)
        {
            return categoryAccess.Create(input);
        }

        public int Delete(int id)
        {
            return categoryAccess.Delete(id);
        }

        public int Restore(int id)
        {
            return categoryAccess.Restore(id);
        }

        public List<Categories> GetAll()
        {
            return categoryAccess.GetAll();
        }
        public List<Categories> GetAllDelete()
        {
            return categoryAccess.GetAllDelete();
        }


        public Categories GetById(int id)
        {
            return categoryAccess.GetById(id);
        }

        public int Update(Categories input)
        {
            return categoryAccess.Update(input);
        }
    }
}
