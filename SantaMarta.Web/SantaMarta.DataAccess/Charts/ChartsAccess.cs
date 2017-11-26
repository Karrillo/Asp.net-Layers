using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.Charts
{
    public class ChartsAccess
    {
        private ContextDb db;

        public ChartsAccess()
        {
            db = new ContextDb();
        }

        public List<Charts_Accounts> GetAccount()
        {
            List<Charts_Accounts> accounts = new List<Charts_Accounts>();
            try
            {
                accounts = db.Sum_Account().ToList();
                return accounts;
            }
            catch (Exception)
            {
                return accounts;
            }
        }

        public List<Sum_Account_Category> GetCategories()
        {
            List<Sum_Account_Category> categories = new List<Sum_Account_Category>();
            try
            {
                categories = db.Sum_Category().ToList();
                return categories;
            }
            catch (Exception)
            {
                return categories;
            }
        }

        public List<Sum_Account_Category> GetSubCategories(String name)
        {
            List<Sum_Account_Category> subCategories = new List<Sum_Account_Category>();
            try
            {
                subCategories = db.Sum_SubCategory(name).ToList();
                return subCategories;
            }
            catch (Exception)
            {
                return subCategories;
            }
        }

        public List<Sum_AssetLiability> GetAssetsLiabilities()
        {
            List<Sum_AssetLiability> assetsLiabilities = new List<Sum_AssetLiability>();
            try
            {
                assetsLiabilities = db.Sum_AssetLiability_All().ToList();
                return assetsLiabilities;
            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }

        public List<Sum_AssetLiability> GetAssetsLiabilitiesFilter(String dateFilter, String dateSearch, String date)
        {
            List<Sum_AssetLiability> assetsLiabilities = new List<Sum_AssetLiability>();
            try
            {
                assetsLiabilities = db.Sum_AssetLiability_Filter(dateFilter, dateSearch, date).ToList();
                return assetsLiabilities;
            }
            catch (Exception)
            {
                return assetsLiabilities;
            }
        }

        public List<Sum_Products> GetProducts()
        {
            List<Sum_Products> products = new List<Sum_Products>();
            try
            {
                products = db.Sum_Products_All().ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        public List<Sum_Products> GetProductsFilter(Int32 date)
        {
            List<Sum_Products> products = new List<Sum_Products>();
            try
            {
                products = db.Sum_Products_Filter(date).ToList();
                return products;
            }
            catch (Exception)
            {
                return products;
            }
        }

        public List<Charts_Clients> GetClients()
        {
            List<Charts_Clients> clients = new List<Charts_Clients>();
            try
            {
                clients = db.Sum_Clients_All().ToList();
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }

        public List<Charts_Clients> GetClientsFilter(Int32 date)
        {
            List<Charts_Clients> clients = new List<Charts_Clients>();
            try
            {
                clients = db.Sum_Clients_Filter(date).ToList();
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }
    }
}
