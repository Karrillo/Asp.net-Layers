using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Users
{
    public interface IUserRepository
    {
        void Create(User input);
        void Update(User input);
        void Delete(int id);
        User Get(int id);
        User GetById(int id);
        List<User> GetAll();
    }
}
