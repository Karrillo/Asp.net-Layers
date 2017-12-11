using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public interface IClientsB
    {
        int CreateCP(int id);
        int Create(Persons input);
        int Update(Persons input, int id);
        int Delete(int id);
        int Restore(int id);
        All_Clients GetById(int id);
        List<All_Clients> GetAll();
        List<All_Clients> GetAllDelete();
        List<Int64> ClientsAll();
        Int64 GetIdClientOwn();
    }
}
