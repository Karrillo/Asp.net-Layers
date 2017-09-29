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
            return null;
        }

        public int Update(Categories user)
        {
            return 0;
        }

        public int Create(Categories user)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}
