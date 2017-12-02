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
            List<Accounts> accounts = new List<Accounts>();
            try
            {
                accounts = db.List_Accounts().ToList();
                return accounts;
            }
            catch (Exception)
            {
                return accounts;
            }
        }

        public List<Accounts> GetAllDelete()
        {
            List<Accounts> accounts = new List<Accounts>();
            try
            {
                accounts = db.List_Accounts_Deleted().ToList();
                return accounts;
            }
            catch (Exception)
            {
                return accounts;
            }
        }

        public Accounts GetById(Int64 id)
        {
            Accounts accounts = new Accounts();
            try
            {
                return db.View_Accounts(id);
            }
            catch (Exception)
            {
                return accounts;
            }
        }

        public int Update(Accounts accounts)
        {
            try
            {
                String name = db.Check_NameAccount(accounts.Name);

                if (name == null || name == GetById(accounts.IDAccount).Name)
                {
                    db.Update_Account(accounts);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Create(Accounts accounts)
        {
            try
            {
                if (db.Check_NameAccount(accounts.Name) == null)
                {
                    db.Insert_Account(accounts);
                    return 200;
                }
                else
                {
                    return 400;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Delete(int id)
        {
            try
            {
                Boolean? state = db.Check_Account(id) ?? false;
                if (state == false)
                {
                    db.Delete_Account(id);
                    return 200;
                }

                return 400;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int Restore(int id)
        {
            try
            {
                db.Restore_Account(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
