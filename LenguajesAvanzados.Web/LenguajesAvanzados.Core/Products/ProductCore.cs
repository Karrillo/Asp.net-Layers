using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Products
{
    public class ProductCore : IProductCore
    {
        private readonly IProductRepository _productRepo;
        public ProductCore(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public void Create(Product input)
        {
            _productRepo.Create(input);
        }

        public void Update(Product input)
        {
            _productRepo.Update(input);
        }

        public void Delete(int id)
        {
            _productRepo.Delete(id);
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
