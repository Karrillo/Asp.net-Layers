using SantaMarta.Data.Models.Accounts;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AccountsBussines
{
    public interface IAccountsB
    {
        bool Create(Accounts input);
        bool Update(Accounts input);
        bool Delete(int id);
        Accounts GetById(int id);
        List<Accounts> GetAll();
    }
}
