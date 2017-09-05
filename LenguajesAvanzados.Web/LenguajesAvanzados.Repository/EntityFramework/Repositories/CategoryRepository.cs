using LenguajesAvanzados.Core.Categories;
using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository _repository;
        private const string CategoryNoExists = "Category does not exist!";

        public CategoryRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Category input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Category>(id);
        }

        public Category GetById(int id)
        {
            var category = _repository.GetById<Category>(id);

            if (category == null)
            {
                throw new Exception(CategoryNoExists);
            }

            return category;
        }

        public List<Category> GetAll()
        {
            var category = _repository.GetAll<Category>().ToList();

            return category;
        }

        public void Update(Category input)
        {
            var category = _repository.GetById<Category>(input.Id);
            if (category == null)
            {
                throw new Exception(CategoryNoExists);
            }
            _repository.Update(input);
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

