using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Store_Procedures;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsBussines
{
    public interface IProductsB
    {
        int Create(Products input);
        int Update(Products input, int id);
        int Delete(int id);
        int Restore(int id);
        Products GetById(int id);
        List<Products> GetAll();
        List<List_Products_Deleted> GetAllDelete();
    }
}
