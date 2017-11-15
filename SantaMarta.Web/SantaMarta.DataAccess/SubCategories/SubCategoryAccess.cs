using SantaMarta.Data.Models.SubCategories;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.SubCategoryAccess
{
    public class SubCategoryAccess
    {
        private ContextDb db;

        public SubCategoryAccess()
        {
            db = new ContextDb();
        }

        public List<SubCategories> GetAll()
        {
            List<SubCategories> subCategories = db.View_SubCategories().ToList();
            return subCategories;
        }

        public List<View_SubCategories_Deleted> GetAllDelete()
        {
            List<View_SubCategories_Deleted> subCategories = db.View_SubCategories_Deleted().ToList();
            return subCategories;
        }

        public String CheckName(string name, int id)
        {
            String subCategories = db.Check_NameSubCategory(name, id);
            return subCategories;
        }

        public List<SubCategories> GetByIdAll(int id)
        {
            List<SubCategories> subCategories = db.View_SubCategoryByCategory(id).ToList();
            return subCategories;
        }

        public SubCategories GetById(int id)
        {
            return db.View_SubCategory(id);
        }

        public String GetByIdName(int id)
        {
            return db.View_CategoryName(id);
        }

        public int Update(SubCategories subcaterory)
        {
            return db.Update_SubCategory(subcaterory);
        }

        public int Create(SubCategories subcaterory)
        {
            return db.Insert_SubCategory(subcaterory);
        }

        public int Delete(int id)
        {
            return db.Delete_SubCategory(id);
        }

        public int Restore(int id)
        {
            return db.Restore_SubCategory(id);
        }
    }
}
