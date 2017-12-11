using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ProvidersBussines
{
    public interface IProvidersB
    {
        int CreatePC(int id);
        int Create(Persons input);
        int Update(Persons input, int id);
        int Delete(int id);
        int Restore(int id);
        All_Providers GetById(int id);
        List<All_Providers> GetAll();
        List<All_Providers> GetAllDelete();
        List<Int64> ProvidersAll();
        Int64 GetIdProviderOwn();
    }
}
