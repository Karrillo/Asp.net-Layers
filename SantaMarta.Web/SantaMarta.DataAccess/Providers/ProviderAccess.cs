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
        ContextDb db = new ContextDb();

        public List<All_Providers> GetAll()
        {
            List<All_Providers> providers = db.All_Providers_Active().ToList();
            return providers;
        }

        public All_Providers GetById(int id)
        {
            return db.View_Provider(id);
        }

        public int Update(Persons personProvider, Int64 id)
        {
            return db.Update_Provider(personProvider, id);
        }
        public int CreatePC(int id)
        {
            return db.Insert_Provider_Client(id);
        }
        public int Create(Persons personProvider)
        {
            return db.Insert_Provider(personProvider);
        }

        public int Delete(int id)
        {
            return db.Delete_Provider(id);
        }
    }
}
