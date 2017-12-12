using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.ProviderAccess;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProvidersBussines
{
    public class ProvidersB : IProvidersB
    {
        private ProviderAccess providerAccess = new ProviderAccess();
        public int CreatePC(int id)
        {
            return providerAccess.CreatePC(id);
        }
        public int Create(Persons input)
        {
            return providerAccess.Create(input);
        }

        public int Delete(int id)
        {
            return providerAccess.Delete(id);
        }

        public int Restore(int id)
        {
            return providerAccess.Restore(id);
        }

        public List<All_Providers> GetAll()
        {
            return providerAccess.GetAll();
        }

        public List<Int64> ProvidersAll()
        {
            return providerAccess.ProvidersAll();
        }

        public List<All_Providers> GetAllDelete()
        {
            return providerAccess.GetAllDelete();
        }

        public All_Providers GetById(int id)
        {
            return providerAccess.GetById(id);
        }

        public int Update(Persons input, int id)
        {
            return providerAccess.Update(input, id);
        }

        public Int64 GetIdProviderOwn()
        {
            return providerAccess.GetIdProviderOwn();
        }
    }
}
