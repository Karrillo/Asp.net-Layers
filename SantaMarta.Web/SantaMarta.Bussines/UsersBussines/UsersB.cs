using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SantaMarta.Data.Models.Users;
using SantaMarta.DataAccess.UserAccess;

namespace SantaMarta.Bussines.UsersBussines
{
    public class UsersB : IUsersB
    {

        private UserAccess userAccess = new UserAccess();

        public bool Create(Users input)
        {
            return userAccess.Create(input);
        }

        public bool Delete(int id)
        {
            return userAccess.Delete(id);
        }

        public List<Users> GetAll()
        {
            return userAccess.GetAll();
        }

        public Users GetById(int id)
        {
            return userAccess.GetById(id);
        }

        public bool Update(Users input)
        {
            return userAccess.Update(input);
        }
    }
}
