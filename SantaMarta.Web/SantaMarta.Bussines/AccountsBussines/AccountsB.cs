using SantaMarta.Data.Models.Accounts;
using SantaMarta.DataAccess.AccountAccess;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AccountsBussines
{
    public class AccountsB : IAccountsB
    {
        private AccountAccess accountAccess = new AccountAccess();

        public int Create(Accounts input)
        {
            return accountAccess.Create(input);
        }

        public int Delete(int id)
        {
            return accountAccess.Delete(id);
        }

        public int Restore(int id)
        {
            return accountAccess.Restore(id);
        }

        public List<Accounts> GetAll()
        {
            return accountAccess.GetAll();
        }

        public List<Accounts> GetAllDelete()
        {
            return accountAccess.GetAllDelete();
        }

        public Accounts GetById(int id)
        {
            return accountAccess.GetById(id);
        }

        public int Update(Accounts input)
        {
            return accountAccess.Update(input);
        }
    }
}
