using SantaMarta.Data.Models.SubCategories;
using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.SubCategoryAccess
{
    public class SubCategoryAccess
    {
        ContextDb db = new ContextDb();

        public List<SubCategories> GetAll()
        {
            List<SubCategories> subCategories = db.View_SubCategories().ToList();
            return subCategories;
        }

        public SubCategories GetById(int id)
        {
            return null;
        }

        public int Update(SubCategories user)
        {
            return 0;
        }

        public int Create(SubCategories user)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}
