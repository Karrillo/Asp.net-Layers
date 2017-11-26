using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ChartsBussines
{
    public interface IChartsB
    {
        List<Charts_Accounts> GetAccount();
        List<Sum_Account_Category> GetCategories();
        List<Sum_Account_Category> GetSubCategories(String name);
        List<Sum_AssetLiability> GetAssetsLiabilities();
        List<Sum_AssetLiability> GetAssetsLiabilitiesFilter(String dateFilter, String dateSearch, String date);
        List<Sum_Products> GetProducts();
        List<Sum_Products> GetProductsFilter(Int32 date);
        List<Charts_Clients> GetClients();
        List<Charts_Clients> GetClientsFilter(Int32 date);
    }
}
