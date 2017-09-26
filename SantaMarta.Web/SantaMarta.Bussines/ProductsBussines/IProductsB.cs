using SantaMarta.Data.Models.Products;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsBussines
{
    public interface IProductsB
    {
        int Create(Products input);
        int Update(Products input, int id);
        int Delete(int id);
        Products GetById(int id);
        List<Products> GetAll();
    }
}
