using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class ProductRespository : IProductRepository
    {
        private readonly IRepository _repository;
        private const string ProductNoExists = "Role does not exist!";

        public ProductRespository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Product input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Product>(id);
        }

        public Product GetById(int id)
        {
            var product = _repository.GetById<Product>(id);

            if (product == null)
            {
                throw new Exception(ProductNoExists);
            }

            return product;
        }

        public List<Product> GetAll()
        {
            var product = _repository.GetAll<Product>().ToList();

            return product;
        }

        public void Update(Product input)
        {
            var product = _repository.GetById<Product>(input.Id);
            if (product == null)
            {
                throw new Exception(ProductNoExists);
            }
            _repository.Update(input);
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
