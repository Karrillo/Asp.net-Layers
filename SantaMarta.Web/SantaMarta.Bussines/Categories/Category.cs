using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Categories
{
    public class CategoryCore : ICategoryCore
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryCore(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public Category GetById(int id)
        {
            return _categoryRepo.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepo.GetAll();
        }

        public void Create(Category input)
        {
            _categoryRepo.Create(input);
        }

        public void Update(Category input)
        {
            _categoryRepo.Update(input);
        }

        public void Delete(int id)
        {
            _categoryRepo.Delete(id);
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
