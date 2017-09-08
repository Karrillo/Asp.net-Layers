using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Clients
{
    public class ClientCore : IClientCore
    {
        private readonly IClientRepository _clientRepo;
        public ClientCore(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }
        public Client GetById(int id)
        {
            return _clientRepo.GetById(id);
        }

        public List<Client> GetAll()
        {
            return _clientRepo.GetAll();
        }

        public void Create(Client input)
        {
            _clientRepo.Create(input);
        }

        public void Update(Client input)
        {
            _clientRepo.Update(input);
        }

        public void Delete(int id)
        {
            _clientRepo.Delete(id);
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
