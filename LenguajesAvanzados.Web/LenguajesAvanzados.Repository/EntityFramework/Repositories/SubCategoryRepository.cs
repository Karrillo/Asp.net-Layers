using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class SubCategoryRespository : ISubCategoryRepository
    {
        private readonly IRepository _repository;
        private const string SubCategoryNoExists = "Sub-Category does not exist!";

        public SubCategoryRespository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(SubCategory input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<SubCategory>(id);
        }

        public SubCategory GetById(int id)
        {
            var subCategory = _repository.GetById<SubCategory>(id);

            if (subCategory == null)
            {
                throw new Exception(SubCategoryNoExists);
            }

            return subCategory;
        }

        public List<SubCategory> GetAll()
        {
            var subCategory = _repository.GetAll<SubCategory>().ToList();

            return subCategory;
        }

        public void Update(SubCategory input)
        {
            var subCategory = _repository.GetById<SubCategory>(input.Id);
            if (subCategory == null)
            {
                throw new Exception(SubCategoryNoExists);
            }
            _repository.Update(input);
        }

        public SubCategory Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

