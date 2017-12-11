using System.Collections.Generic;
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

        //Get All Clients
        public List<Int64> ClientsAll()
        {
            List<Int64> clients = new List<Int64>();

            try
            {
                clients = db.ClientsAll().ToList();
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }

        //Get All Clients Active
        public List<All_Clients> GetAll()
        {
            List<All_Clients> clients = new List<All_Clients>();

            try
            {
                clients = db.All_Clients_Active().ToList();
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }

        //Get All Clients Deleted
        public List<All_Clients> GetAllDelete()
        {
            List<All_Clients> clients = new List<All_Clients>();

            try
            {
                clients = db.All_Clients_Deleted().ToList();
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }

        //Get Client
        public All_Clients GetById(Int64 id)
        {
            All_Clients clients = new All_Clients();
            try
            {
                return db.View_Client(id);
            }
            catch (Exception)
            {
                return clients;
            }
        }

        //Get Client by Name
        public List<All_Clients> GetByName(String name)
        {
            List<All_Clients> clients = new List<All_Clients>();

            try
            {
                clients = db.Seach_Client_Word(name);
                return clients;
            }
            catch (Exception)
            {
                return clients;
            }
        }

        //Update Client
        public int Update(Persons personClient, Int64 id)
        {
            try
            {
                String code = db.Check_CodePersons(personClient.Code);

                All_Clients client = GetById(id);

                if (code == null || code == client.Code)
                {
                    db.update_Client(personClient, client.IDPerson);
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

        //Create Client to Providers
        public int CreateCP(int id)
        {
            try
            {
                db.Insert_Client_Provider(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Create Client
        public int Create(Persons personClient)
        {
            try
            {
                if (db.Check_CodePersons(personClient.Code) == null)
                {
                    db.Insert_Client(personClient);
                    return 200;
                }
                return 400;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Delete Client
        public int Delete(int id)
        {
            try
            {
                db.Delete_Client(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Restore Client
        public int Restore(int id)
        {
            try
            {
                db.Restore_Client(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //GET Id Productos Alimenticios Santa Marta
        public Int64 GetIdClientOwn()
        {
            try
            {
                return db.Get_IdClient_Own();
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
