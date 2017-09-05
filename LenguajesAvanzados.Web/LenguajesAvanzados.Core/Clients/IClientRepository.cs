using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Clients
{
    public interface IClientRepository
    {
        void Create(Client input);
        void Update(Client input);
        void Delete(int id);
        Client Get(int id);
        Client GetById(int id);
        List<Client> GetAll();
    }
}
