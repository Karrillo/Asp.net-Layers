using SantaMarta.Data.Models.Accounts;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AccountsBussines
{
    public interface IAccountsB
    {
        int Create(Accounts input);
        int Update(Accounts input);
        int Delete(int id);
        Accounts GetById(int id);
        List<Accounts> GetAll();
    }
}
