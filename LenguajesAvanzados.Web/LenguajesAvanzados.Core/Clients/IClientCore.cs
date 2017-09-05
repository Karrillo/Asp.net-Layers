using System.Collections.Generic;

namespace LenguajesAvanzados.Core.Clients
{
    public interface IClientCore
    {
        void Create(Client input);
        void Update(Client input);
        void Delete(int id);
        Client Get(int id);
        Client GetById(int id);
        List<Client> GetAll();
    }
}
