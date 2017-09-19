using System.Collections.Generic;
using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.Entity;

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
            return null;
        }

        public Users GetById(int id)
        {
            return null;
        }

        public bool Update(Users user)
        {
            return true;
        }

        public bool Create(Users user)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}
