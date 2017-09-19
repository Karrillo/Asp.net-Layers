using SantaMarta.Data.Models.Categories;
using SantaMarta.DataAccess.CategoryAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.CategoriesBussines
{
    public class CategoriesB : ICategoriesB
    {
        private CategoryAccess categoryAccess = new CategoryAccess();

        public bool Create(Categories input)
        {
            return categoryAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return categoryAccess.Delete(id);
        }

        public List<Categories> GetAll()
        {
            return categoryAccess.GetAll();
        }

        public Categories GetById(int id)
        {
            return categoryAccess.GetById(id);
        }

        public bool Update(Categories input)
        {
            return categoryAccess.Update(input);
        }
    }
}
