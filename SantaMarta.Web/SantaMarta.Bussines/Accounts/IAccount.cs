using System.Collections.Generic;

namespace SantaMarta.Bussines.Accounts
{
    public interface IAccount
    {
        void Create(Data.Models.Accounts.Account input);
        void Update(Data.Models.Accounts.Account input);
        void Delete(int id);
        Account Get(int id);
        Account GetById(int id);
        List<Data.Models.Accounts.Account> GetAll();
    }
}
