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

        public int Update(Persons personProvider, Int64 id)
        {
            try
            {
                String code = db.Check_CodePersons(personProvider.Code);
                String identification = db.Check_Identification(personProvider.Identification);

                All_Providers providers = GetById(id);

                if (code == null || code == providers.Code)
                {
                    if (identification == null || identification == providers.Identification)
                    {
                        db.Update_Provider(personProvider, providers.IDPerson);
                        return 200;
                    }
                    else
                    {
                        return 401;
                    }
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

        public int Create(Persons personProvider)
        {
            try
            {
                if (db.Check_CodePersons(personProvider.Code) == null)
                {
                    if (db.Check_Identification(personProvider.Identification) == null)
                    {
                        db.Insert_Provider(personProvider);
                        return 200;
                    }
                    else
                    {
                        return 401;
                    }
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
                db.Delete_Provider(id);
                return 200;
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
                db.Restore_Provider(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
