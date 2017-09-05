using LenguajesAvanzados.Core.Accounts;
using LenguajesAvanzados.Core.ConfigInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LenguajesAvanzados.Repository.EntityFramework.Repositories
{
    public class AccountRespository : IAccountRepository
    {
        private readonly IRepository _repository;
        private const string AccountNoExists = "Account does not exist!";

        public AccountRespository(
            IRepository repository
            )
        {
            _repository = repository;
        }

        public void Create(Account input)
        {
            _repository.Create(input);
        }

        public void Delete(int id)
        {
            _repository.Delete<Account>(id);
        }

        public Account GetById(int id)
        {
            var account = _repository.GetById<Account>(id);

            if (account == null)
            {
                throw new Exception(AccountNoExists);
            }

            return account;
        }

        public List<Account> GetAll()
        {
            var account = _repository.GetAll<Account>().ToList();

            return account;
        }

        public void Update(Account input)
        {
            var account = _repository.GetById<Account>(input.Id);
            if (account == null)
            {
                throw new Exception(AccountNoExists);
            }
            _repository.Update(input);
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
