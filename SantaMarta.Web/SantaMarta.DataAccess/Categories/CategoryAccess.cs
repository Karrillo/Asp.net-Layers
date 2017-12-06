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

        //Get All Categories
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

        //Get All Categories Deleted
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

        //Get Categories
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

        //Update Categories
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

        //Create Categories
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

        //Delete Categories
        public int Delete(int id)
        {
            try
            {
                Boolean? state = db.Check_Category(id) ?? false;
                if (state == false)
                {
                    db.Delete_Category(id);
                    return 200;
                }
                return 400;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Restore Categories
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
