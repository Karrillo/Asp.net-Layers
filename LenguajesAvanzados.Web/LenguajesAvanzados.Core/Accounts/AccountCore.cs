using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Accounts
{
    public class AccountCore : IAccountCore
    {
        private readonly IAccountRepository _accountRepo;
        public AccountCore(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }
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
    }
}

