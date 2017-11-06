﻿using SantaMarta.Data.Models.SubCategories;
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

        public String CheckName(string name, int id)
        {
            return subCategoryAccess.CheckName(name, id);
        }

        public int Delete(int id)
        {
            return subCategoryAccess.Delete(id);
        }

        public List<SubCategories> GetAll()
        {
            return subCategoryAccess.GetAll();
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
