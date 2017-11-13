using SantaMarta.Data.Models.SubCategories;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.SubCategoryAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.SubCategoriesBussines
{
    public class SubCategoriesB : ISubCategoriesB
    {
        private SubCategoryAccess subCategoryAccess = new SubCategoryAccess();

        public int Create(SubCategories input)
        {
            return subCategoryAccess.Create(input);
        }

        public int Delete(int id)
        {
            return subCategoryAccess.Delete(id);
        }

        public int Restore(int id)
        {
            return subCategoryAccess.Restore(id);
        }

        public List<SubCategories> GetAll()
        {
            return subCategoryAccess.GetAll();
        }

        public List<View_SubCategories_Deleted> GetAllDelete()
        {
            return subCategoryAccess.GetAllDelete();
        }

        public List<SubCategories> GetByIdAll(int id)
        {
            return subCategoryAccess.GetByIdAll(id);
        }

        public SubCategories GetById(int id)
        {
            return subCategoryAccess.GetById(id);
        }
        public string GetByIdName(int id)
        {
            return subCategoryAccess.GetByIdName(id);
        }

        public int Update(SubCategories input)
        {
            return subCategoryAccess.Update(input);
        }
    }
}
