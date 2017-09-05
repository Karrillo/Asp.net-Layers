using LenguajesAvanzados.Core.Clients;
using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IRepository _repository;
        private const string ClientNoExists = "Client does not exist!";

        public ClientRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Client input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Client>(id);
        }

        public Client GetById(int id)
        {
            var client = _repository.GetById<Client>(id);

            if (client == null)
            {
                throw new Exception(ClientNoExists);
            }

            return client;
        }

        public List<Client> GetAll()
        {
            var client = _repository.GetAll<Client>().ToList();

            return client;
        }

        public void Update(Client input)
        {
            var client = _repository.GetById<Client>(input.Id);
            if (client == null)
            {
                throw new Exception(ClientNoExists);
            }
            _repository.Update(input);
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
