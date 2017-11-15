using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantaMarta.WebAPI.Controllers
{
    
    public class UserController : ApiController
    {
        // GET: api/User
        [Authorize]
        public IHttpActionResult Get()
        {
            IList<Users> user = null;

            UsersB userB = new UsersB();

            user = userB.GetAll();

            if (user == null)
            {
                return Ok(false);
            }

            return Ok(user);
        }

        // GET: api/User/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            Users user = null;

            UsersB userB = new UsersB();

            user = userB.GetById(id);

            if (user == null)
            {
                return Ok(false);
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IHttpActionResult Post(Users users)
        {
            Users userCheck = null;

            UsersB userB = new UsersB();

            users = Encrypt(users);

            userCheck = userB.Check(users.Nickname,users.Password);

            switch (userCheck.ConfirmStatus)
            {
                case 200:
                    return Ok(userCheck);
                    break;
                case 500:
                    return Ok(500);
                    break;
                default:
                    return Ok(false);
                    break;
            }
        }
        private Users Encrypt(Users user)
        {
            string pass = user.Password;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(pass);
            user.Password = Convert.ToBase64String(encrypted);
            return user;
        }
    }
}
