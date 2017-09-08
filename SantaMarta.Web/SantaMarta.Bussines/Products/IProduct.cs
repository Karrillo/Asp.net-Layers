using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Products
{
    public interface IProductCore
    {
        void Create(Product input);
        void Update(Product input);
        void Delete(int id);
        Product Get(int id);
        Product GetById(int id);
        List<Product> GetAll();
    }
}
