using LenguajesAvanzados.Core.ConfigInterface;
using LenguajesAvanzados.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository _repository;
        private const string UserNoExists = "User does not exist!";

        public UserRepository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(User input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<User>(id);
        }

        public User GetById(int id)
        {
            var user = _repository.GetById<User>(id);

            if (user == null)
            {
                throw new Exception(UserNoExists);
            }

            return user;
        }

        public List<User> GetAll()
        {
            var user = _repository.GetAll<User>().ToList();

            return user;
        }

        public void Update(User input)
        {
            var user = _repository.GetById<User>(input.Id);
            if (user == null)
            {
                throw new Exception(UserNoExists);
            }
            _repository.Update(input);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}

