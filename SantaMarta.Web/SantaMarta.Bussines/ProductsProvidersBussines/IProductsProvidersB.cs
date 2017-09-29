using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Store_Procedures;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsProvidersBussines
{
    public interface IProductsProvidersB
    {
        int Create(Products input);
        int Update(Products input, int id);
        int Delete(int id);
        Products GetById(int id);
        List<Products> GetAll(int id);
        List<List_Providers> GetAllProviders();
    }
}
