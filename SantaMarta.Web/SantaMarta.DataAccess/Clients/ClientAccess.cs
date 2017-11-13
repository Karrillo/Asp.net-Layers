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

        public int Update(Persons personClient, Int64 id)
        {
            try
            {
                String code = db.Check_CodePersons(personClient.Code);
                String identification = db.Check_Identification(personClient.Identification);

                All_Clients client = GetById(id);

                if (code == null || code == client.Code)
                {
                    if (identification == null || identification == client.Identification)
                    {
                        db.update_Client(personClient, client.IDPerson);
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

        public int Create(Persons personClient)
        {
            try
            {
                if (db.Check_CodePersons(personClient.Code) == null)
                {
                    if (db.Check_Identification(personClient.Identification) == null)
                    {
                        db.Insert_Client(personClient);
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
                db.Delete_Client(id);
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
                db.Restore_Client(id);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }
    }
}
