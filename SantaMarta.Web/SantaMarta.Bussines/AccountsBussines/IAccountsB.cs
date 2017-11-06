using SantaMarta.Data.Models.Accounts;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.AccountsBussines
{
    public interface IAccountsB
    {
        int Create(Accounts input);
        String CheckName(string name);
        int Update(Accounts input);
        int Delete(int id);
        Accounts GetById(int id);
        List<Accounts> GetAll();
    }
}
