using SantaMarta.Data.Models.Users;
using System;
using System.Collections.Generic;

namespace SantaMarta.Bussines.UsersBussines
{
    public interface IUsersB
    {
        Users Check(string nickname, string password);
        String CheckNickname(string nickname);
        int Create(Users input);
        int Update(Users input);
        int Delete(int id);
        Users GetById(int id);
        List<Users> GetAll();
    }
}
