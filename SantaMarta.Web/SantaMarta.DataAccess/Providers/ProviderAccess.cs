using System.Collections.Generic;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using System.Linq;
using SantaMarta.Data.Models.Persons;
using System;

namespace SantaMarta.DataAccess.ProviderAccess
{
    public class ProviderAccess
    {
        private ContextDb db;

        public ProviderAccess()
        {
            db = new ContextDb();
        }

        //Get All Providers
        public List<Int64> ProvidersAll()
        {
            List<Int64> providers = new List<Int64>();

            try
            {
                providers = db.ProvidersAll().ToList();
                return providers;
            }
            catch (Exception)
            {
                return providers;
            }
        }

        //Get All Providers Active
        public List<All_Providers> GetAll()
        {
            List<All_Providers> providers = new List<All_Providers>();

            try
            {
                providers = db.All_Providers_Active().ToList();
                return providers;
            }
            catch (Exception)
            {
                return providers;
            }
        }

        //Get All Providers Deleted
        public List<All_Providers> GetAllDelete()
        {
            List<All_Providers> providers = new List<All_Providers>();

            try
            {
                providers = db.All_Providers_Deleted().ToList();
                return providers;
            }
            catch (Exception)
            {
                return providers;
            }
        }

        //Get Providers
        public All_Providers GetById(Int64 id)
        {
            All_Providers prividers = new All_Providers();
            try
            {
                return db.View_Provider(id);
            }
            catch (Exception)
            {
                return prividers;
            }
        }

        //Update Providers
        public int Update(Persons personProvider, Int64 id)
        {
            try
            {
                String code = db.Check_CodePersons(personProvider.Code);

                All_Providers providers = GetById(id);

                if (code == null || code == providers.Code)
                {
                    db.Update_Provider(personProvider, providers.IDPerson);
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

        //Create Providers to Clients
        public int CreatePC(int id)
        {
            try
            {
                db.Insert_Provider_Client(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Create Providers
        public int Create(Persons personProvider)
        {
            try
            {
                if (db.Check_CodePersons(personProvider.Code) == null)
                {
                    db.Insert_Provider(personProvider);
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

        //Delete Providers
        public int Delete(int id)
        {
            try
            {
                db.Delete_Provider(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Restore Providers
        public int Restore(int id)
        {
            try
            {
                db.Restore_Provider(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //GET Id Productos Alimenticios Santa Marta
        public Int64 GetIdProviderOwn()
        {
            try
            {
                return db.Get_IdProvider_Own();
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
