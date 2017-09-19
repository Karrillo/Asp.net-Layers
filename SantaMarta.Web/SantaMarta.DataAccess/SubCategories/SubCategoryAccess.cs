using SantaMarta.Data.Models.SubCategories;
using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;

namespace SantaMarta.DataAccess.SubCategoryAccess
{
    public class SubCategoryAccess
    {
        ContextDb db = new ContextDb();

        public List<SubCategories> GetAll()
        {
            return null;
        }

        public SubCategories GetById(int id)
        {
            return null;
        }

        public bool Update(SubCategories user)
        {
            return true;
        }

        public bool Create(SubCategories user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
