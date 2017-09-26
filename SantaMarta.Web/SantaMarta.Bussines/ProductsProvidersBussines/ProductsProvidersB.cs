using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.ProductsProviders;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProductsProvidersBussines
{
    public class ProductsProvidersB : IProductsProvidersB
    {
        private ProductsProvidersAccess productProvidersAccess = new ProductsProvidersAccess();

        public int Create(Products input)
        {
            return productProvidersAccess.Create(input);
        }

        public int Delete(int id)
        {
            return productProvidersAccess.Delete(id);
        }

        public List<Products> GetAll(int id)
        {
            return productProvidersAccess.GetAll(id);
        }

        public Products GetById(int id)
        {
            return productProvidersAccess.GetById(id);
        }

        public int Update(Products input, int id)
        {
            return productProvidersAccess.Update(input, id);
        }

        public List<List_Providers> GetAllProviders()
        {
            return productProvidersAccess.GetAllProviders();
        }
    }
}