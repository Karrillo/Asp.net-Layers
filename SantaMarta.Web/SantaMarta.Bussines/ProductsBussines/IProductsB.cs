using SantaMarta.Data.Models.Products;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsBussines
{
    public interface IProductsB
    {
        bool Create(Products input);
        bool Update(Products input);
        bool Delete(int id);
        Products GetById(int id);
        List<Products> GetAll();
    }
}
