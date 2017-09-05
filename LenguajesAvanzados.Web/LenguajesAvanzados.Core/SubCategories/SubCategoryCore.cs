using System;
using System.Collections.Generic;

namespace LenguajesAvanzados.Core.SubCategories
{
    public class SubCategoryCore : ISubCategoryCore
    {
        private readonly ISubCategoryRepository _subCategoryRepo;

        public SubCategoryCore(ISubCategoryRepository subCategoryRepo)
        {
            _subCategoryRepo = subCategoryRepo;
        }

        public SubCategory GetById(int id)
        {
            return _subCategoryRepo.GetById(id);
        }

        public List<SubCategory> GetAll()
        {
            return _subCategoryRepo.GetAll();
        }

        public void Create(SubCategory input)
        {
            _subCategoryRepo.Create(input);
        }

        public void Update(SubCategory input)
        {
            _subCategoryRepo.Update(input);
        }

        public void Delete(int id)
        {
            _subCategoryRepo.Delete(id);
        }

        public SubCategory Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
