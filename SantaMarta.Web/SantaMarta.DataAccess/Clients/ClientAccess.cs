﻿using System.Collections.Generic;
using SantaMarta.DataAccess.Entity;
using SantaMarta.Data.Store_Procedures;
using SantaMarta.Data.Models.Persons;
using System.Linq;
using System;

namespace SantaMarta.DataAccess.ClientAccess
{
    public class ClientAccess
    {
        private ContextDb db;

        public ClientAccess()
        {
            db = new ContextDb();
        }

        public List<All_Clients> GetAll()
        {
            List<All_Clients> clients = db.All_Clients_Active().ToList();
            return clients;
        }

        public All_Clients GetById(int id)
        {
            return db.View_Client(id);
        }
        public List<All_Clients> GetByName(String name)
        {
            return db.Seach_Client_Word(name);
        }
        public int Update(Persons personClient, Int64 id)
        {
            return db.update_Client(personClient, id);
        }
        public int CreateCP(int id)
        {
            return db.Insert_Client_Provider(id);
        }
        public int Create(Persons personClient)
        {
            return db.Insert_Client(personClient);
        }

        public int Delete(int id)
        {
            return db.Delete_Client(id);
        }
    }
}
