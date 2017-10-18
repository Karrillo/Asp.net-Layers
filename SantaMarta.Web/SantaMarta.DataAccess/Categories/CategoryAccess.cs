using System.Collections.Generic;
using SantaMarta.Data.Models.Categories;
using SantaMarta.DataAccess.Entity;
using System.Linq;

namespace SantaMarta.DataAccess.CategoryAccess
{
    public class CategoryAccess
    {
        ContextDb db = new ContextDb();

        public List<Categories> GetAll()
        {
            List<Categories> categories = db.View_Categories().ToList();
            return categories;
        }

        public Categories GetById(int id)
        {
            return db.View_Category(id);
        }

        public int Update(Categories category)
        {
            return db.Update_Category(category);
        }

        public int Create(Categories category)
        {
            return db.Insert_Category(category);
        }

        public int Delete(int id)
        {
            return db.Delete_Category(id);
        }
    }
}
