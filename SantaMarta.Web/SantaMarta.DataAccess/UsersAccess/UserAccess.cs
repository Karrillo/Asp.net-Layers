using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SantaMarta.DataAccess.UserAccess
{
    public class UserAccess
    {
        private ContextDb db;

        public UserAccess()
        {
            db = new ContextDb();
        }

        public Users Check(string nickname, string password)
        {
            Users user = db.Check_Users(nickname, password);
            if (user != null)
            {
                return Decrypt(user);
            }
            return user;
        }

        public String CheckNickname(string nickname)
        {
            String user = db.Check_Nickname(nickname);
            return user;
        }

        public List<Users> GetAll()
        {
            List<Users> users = db.List_Users().ToList();
            return users;
        }

        public Users GetById(int id)
        {
            Users user = db.View_Users(id);
            return Decrypt(user);
        }

        public int Update(Users user)
        {
            return db.Update_User(Encrypt(user));
        }

        public int Create(Users user)
        {
            return db.Insert_User(Encrypt(user));
        }

        public int Delete(int id)
        {
            return db.Delete_User(id);
        }

        private Users Encrypt(Users user)
        {
            string pass = user.Password;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(pass);
            user.Password = Convert.ToBase64String(encrypted);
            return user;
        }

        private Users Decrypt(Users user)
        {
            string pass = user.Password;
            byte[] decrypted = Convert.FromBase64String(pass);
            user.Password = System.Text.Encoding.Unicode.GetString(decrypted);
            return user;
        }
    }
}
