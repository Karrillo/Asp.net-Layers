using System.Collections.Generic;

namespace LenguajesAvanzados.Core.SubCategories
{
    public interface ISubCategoryCore
    {
        void Create(SubCategory input);
        void Update(SubCategory input);
        void Delete(int id);
        SubCategory Get(int id);
        SubCategory GetById(int id);
        List<SubCategory> GetAll();
    }
}
