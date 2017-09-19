using SantaMarta.Data.Models.Clients;
using SantaMarta.DataAccess.ClientAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public class ClientsB : IClientsB
    {
        private ClientAccess clientAccess = new ClientAccess();

        public bool Create(Clients input)
        {
            return clientAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return clientAccess.Delete(id);
        }

        public List<Clients> GetAll()
        {
            return clientAccess.GetAll();
        }

        public Clients GetById(int id)
        {
            return clientAccess.GetById(id);
        }

        public bool Update(Clients input)
        {
            return clientAccess.Update(input);
        }
    }
}
