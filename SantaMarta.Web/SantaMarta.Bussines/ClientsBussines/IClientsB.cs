using SantaMarta.Data.Models.Clients;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public interface IClientsB
    {
        bool Create(Clients input);
        bool Update(Clients input);
        bool Delete(int id);
        Clients GetById(int id);
        List<Clients> GetAll();
    }
}
