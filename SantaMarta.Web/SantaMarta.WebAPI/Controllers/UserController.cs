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
            IList<Users> students = null;

            UsersB userB = new UsersB();

            students = userB.GetAll();

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
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
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public IHttpActionResult Post(Users users)
        {
            Users userCheck = null;

            UsersB userB = new UsersB();

            userCheck = userB.Check(users.Nickname,users.Password);

            if (userCheck == null)
            {
                return NotFound();
            }

            return Ok(userCheck);
        }
    }
}
