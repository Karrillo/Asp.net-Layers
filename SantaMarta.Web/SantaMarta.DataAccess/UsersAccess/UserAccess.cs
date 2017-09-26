using System.Collections.Generic;
using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.Entity;
using System.Linq;

namespace SantaMarta.DataAccess.UserAccess
{
    public class UserAccess
    {
        ContextDb db = new ContextDb();
        public Users Check(string nickname, string password)
        {
            Users user = db.Check_Users(nickname, password);
            return user;
        }

        public List<Users> GetAll()
        {
            List<Users> users = db.List_Users().ToList();
            return users;
        }

        public Users GetById(int id)
        {
            return db.View_Users(id);
        }

        public int Update(Users user)
        {
            return db.Update_User(user);
        }

        public int Create(Users user)
        {
            return db.Insert_User(user);
        }

        public int Delete(int id)
        {
            return db.Delete_User(id);
        }
    }
}
