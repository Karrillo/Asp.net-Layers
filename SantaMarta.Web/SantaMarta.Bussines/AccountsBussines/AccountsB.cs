using SantaMarta.Data.Models.Accounts;
using SantaMarta.DataAccess.AccountAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Bussines.AccountsBussines
{
    public class AccountsB : IAccountsB
    {
        private AccountAccess accountAccess = new AccountAccess();

        public int Create(Accounts input)
        {
            return accountAccess.Create(input);
        }

        public String CheckName(string name)
        {
            return accountAccess.CheckName(name);
        }

        public int Delete(int id)
        {
            return accountAccess.Delete(id);
        }

        public List<Accounts> GetAll()
        {
            return accountAccess.GetAll();
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
