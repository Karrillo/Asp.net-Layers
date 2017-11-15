using System.Collections.Generic;
using SantaMarta.Data.Models.Categories;
using SantaMarta.DataAccess.Entity;
using System.Linq;
using System;

namespace SantaMarta.DataAccess.CategoryAccess
{
    public class CategoryAccess
    {
        private ContextDb db;

        public CategoryAccess()
        {
            db = new ContextDb();
        }

        public List<Categories> GetAll()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                categories = db.View_Categories().ToList();
                return categories;
            }
            catch (Exception)
            {
                return categories;
            }
        }

        public List<Categories> GetAllDelete()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                categories = db.View_Categories_Deleted().ToList();
                return categories;
            }
            catch (Exception)
            {
                return categories;
            }
        }

        public Categories GetById(Int64 id)
        {
            Categories categories = new Categories();
            try
            {
                return db.View_Category(id);
            }
            catch (Exception)
            {
                return categories;
            }
        }

        public int Update(Categories category)
        {
            try
            {
                String name = db.Check_NameCategory(category.Name);

                if (name == null || name == GetById(category.IDCategory).Name)
                {
                    db.Update_Category(category);
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

        public int Create(Categories category)
        {
            try
            {
                if (db.Check_NameCategory(category.Name) == null)
                {
                    db.Insert_Category(category);
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

        public int Delete(int id)
        {
            try
            {
                db.Delete_Category(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Restore(int id)
        {
            try
            {
                db.Restore_Category(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
