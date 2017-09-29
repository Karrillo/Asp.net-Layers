using SantaMarta.Data.Models.Persons;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.DataAccess.ClientAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.ClientsBussines
{
    public class ClientsB : IClientsB
    {
        private ClientAccess clientAccess = new ClientAccess();
        public int CreateCP(int id)
        {
            return clientAccess.CreateCP(id);
        }
        public int Create(Persons input)
        {
            return clientAccess.Create(input);
        }

        public int Delete(int id)
        {
            return clientAccess.Delete(id);
        }

        public List<All_Clients> GetAll()
        {
            return clientAccess.GetAll();
        }

        public All_Clients GetById(int id)
        {
            return clientAccess.GetById(id);
        }

        public int Update(Persons input, int id)
        {
            return clientAccess.Update(input, id);
        }
    }
}
