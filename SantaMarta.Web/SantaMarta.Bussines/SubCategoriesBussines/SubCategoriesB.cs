using SantaMarta.Data.Models.SubCategories;
using SantaMarta.DataAccess.SubCategoryAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.SubCategoriesBussines
{
    public class SubCategoriesB : ISubCategoriesB
    {
        private SubCategoryAccess subCategoryAccess = new SubCategoryAccess();

        public bool Create(SubCategories input)
        {
            return subCategoryAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return subCategoryAccess.Delete(id);
        }

        public List<SubCategories> GetAll()
        {
            return subCategoryAccess.GetAll();
        }

        public SubCategories GetById(int id)
        {
            return subCategoryAccess.GetById(id);
        }

        public bool Update(SubCategories input)
        {
            return subCategoryAccess.Update(input);
        }
    }
}
