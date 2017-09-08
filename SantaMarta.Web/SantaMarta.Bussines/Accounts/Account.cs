using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.Accounts
{
    public class Account : IAccount
    {
        private UsersAccess userAccess = new UsersAccess;
       
        public Account GetById(int id)
        {
            return _accountRepo.GetById(id);
        }

        public List<Account> GetAll()
        {
            return _accountRepo.GetAll();
        }

        public void Create(Account input)
        {
            _accountRepo.Create(input);
        }

        public void Update(Account input)
        {
            _accountRepo.Update(input);
        }

        public void Delete(int id)
        {
            _accountRepo.Delete(id);
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Data.Models.Accounts.Account input)
        {
            throw new NotImplementedException();
        }

        public void Update(Data.Models.Accounts.Account input)
        {
            throw new NotImplementedException();
        }

        List<Data.Models.Accounts.Account> IAccount.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

