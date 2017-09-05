using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Categories
{
    public interface ICategoryRepository
    {
        void Create(Category input);
        void Update(Category input);
        void Delete(int id);
        Category Get(int id);
        Category GetById(int id);
        List<Category> GetAll();
    }
}
