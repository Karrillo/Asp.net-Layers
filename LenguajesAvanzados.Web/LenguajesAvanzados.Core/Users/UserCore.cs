using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.Users
{
    public class UserCore : IUserCore
    {
        private readonly IUserRepository _userRepo;
        public UserCore(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public User GetById(int id)
        {
            return _userRepo.GetById(id);
        }

        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public void Create(User input)
        {
            _userRepo.Create(input);
        }

        public void Update(User input)
        {
            _userRepo.Update(input);
        }

        public void Delete(int id)
        {
            _userRepo.Delete(id);
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
