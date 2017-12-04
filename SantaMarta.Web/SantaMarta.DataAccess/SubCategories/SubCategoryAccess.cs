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

        //Get All SubCategories
        public List<SubCategories> GetAll()
        {
            List<SubCategories> subCategories = new List<SubCategories>();
            try
            {
                subCategories = db.View_SubCategories().ToList();
                return subCategories;
            }
            catch (Exception)
            {
                return subCategories;
            }
        }

        //Get All SubCategories Deleted
        public List<View_SubCategories_Deleted> GetAllDelete()
        {
            List<View_SubCategories_Deleted> subCategories = new List<View_SubCategories_Deleted>();
            try
            {
                subCategories = db.View_SubCategories_Deleted().ToList();
                return subCategories;
            }
            catch (Exception)
            {
                return subCategories;
            }
        }

        //Check Name SubCategories
        public String CheckName(string name, int id)
        {
            String subCategories = db.Check_NameSubCategory(name, id);
            return subCategories;
        }

        //Get all SubCategories by id
        public List<SubCategories> GetByIdAll(int id)
        {
            List<SubCategories> subCategories = new List<SubCategories>();
            try
            {
                subCategories = db.View_SubCategoryByCategory(id).ToList();
                return subCategories;
            }
            catch (Exception)
            {
                return subCategories;
            }
        }

        //Get SubCategories
        public SubCategories GetById(Int64 id)
        {
            SubCategories subCategories = new SubCategories();
            try
            {
                return db.View_SubCategory(id);
            }
            catch (Exception)
            {
                return subCategories;
            }
        }

        //Get SubCategories by Name
        public String GetByIdName(int id)
        {
            SubCategories subCategories = new SubCategories();
            try
            {
                return db.View_CategoryName(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Update SubCategories
        public int Update(SubCategories subCategory)
        {
            try
            {
                SubCategories tempSubCategory = GetById(subCategory.IDSubCategory);

                String name = db.Check_NameSubCategory(subCategory.Name, tempSubCategory.IdCategory);

                if (name == null || name == tempSubCategory.Name)
                {
                    db.Update_SubCategory(subCategory);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Create SubCategories
        public int Create(SubCategories subCategory)
        {
            try
            {
                if (db.Check_NameSubCategory(subCategory.Name, subCategory.IdCategory) == null)
                {
                    db.Insert_SubCategory(subCategory);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Delete SubCategories
        public int Delete(int id)
        {
            try
            {
                Boolean? state = db.Check_SubCategory(id) ?? false;
                if (state == false)
                {
                    db.Delete_SubCategory(id);
                    return 200;
                }
                return 400;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Restore SubCategories
        public int Restore(int id)
        {
            try
            {
                db.Restore_SubCategory(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
