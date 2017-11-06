using SantaMarta.DataAccess.Entity;
using System.Collections.Generic;
using SantaMarta.Data.Models.Accounts;
using System.Linq;
using System;

namespace SantaMarta.DataAccess.AccountAccess
{
    public class AccountAccess
    {
        private ContextDb db;

        public AccountAccess()
        {
            db = new ContextDb();
        }

        public List<Accounts> GetAll()
        {
            List<Accounts> accounts = db.List_Accounts().ToList();
            return accounts;
        }

        public String CheckName(string name)
        {
            String account = db.Check_NameAccount(name);
            return account;
        }

        public Accounts GetById(int id)
        {
            return db.View_Accounts(id);
        }

        public int Update(Accounts user)
        {
            return db.Update_Account(user);
        }

        public int Create(Accounts user)
        {
            return db.Insert_Account(user);
        }

        public int Delete(int id)
        {
            return db.Delete_Account(id);
        }
    }
}
