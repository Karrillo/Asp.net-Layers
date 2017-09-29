using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public interface IClientsB
    {
        int Create(Persons input);
        int Update(Persons input, int id);
        int Delete(int id);
        All_Clients GetById(int id);
        List<All_Clients> GetAll();
    }
}
