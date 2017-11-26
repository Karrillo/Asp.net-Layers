using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.Charts;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ChartsBussines
{
    public class ChartsB : IChartsB
    {
        private ChartsAccess chartsAccess = new ChartsAccess();

        public List<Charts_Accounts> GetAccount()
        {
            return chartsAccess.GetAccount();
        }
        public List<Sum_Account_Category> GetCategories()
        {
            return chartsAccess.GetCategories();
        }
        public List<Sum_Account_Category> GetSubCategories(String name)
        {
            return chartsAccess.GetSubCategories(name);
        }
        public List<Sum_AssetLiability> GetAssetsLiabilities()
        {
            return chartsAccess.GetAssetsLiabilities();
        }
        public List<Sum_AssetLiability> GetAssetsLiabilitiesFilter(String dateFilter, String dateSearch, String date)
        {
            return chartsAccess.GetAssetsLiabilitiesFilter(dateFilter, dateSearch, date);
        }
        public List<Sum_Products> GetProducts()
        {
            return chartsAccess.GetProducts();
        }
        public List<Sum_Products> GetProductsFilter(Int32 date)
        {
            return chartsAccess.GetProductsFilter(date);
        }
        public List<Charts_Clients> GetClients()
        {
            return chartsAccess.GetClients();
        }
        public List<Charts_Clients> GetClientsFilter(Int32 date)
        {
            return chartsAccess.GetClientsFilter(date);
        }
    }
}
