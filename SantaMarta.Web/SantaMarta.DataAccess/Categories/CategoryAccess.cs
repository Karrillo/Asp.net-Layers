using System.Collections.Generic;
using SantaMarta.Data.Models.Categories;
using SantaMarta.DataAccess.Entity;

namespace SantaMarta.DataAccess.CategoryAccess
{
    public class CategoryAccess
    {
        ContextDb db = new ContextDb();

        public List<Categories> GetAll()
        {
            return null;
        }

        public Categories GetById(int id)
        {
            return null;
        }

        public bool Update(Categories user)
        {
            return true;
        }

        public bool Create(Categories user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
