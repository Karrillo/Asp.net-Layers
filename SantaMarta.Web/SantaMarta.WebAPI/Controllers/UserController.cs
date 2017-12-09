using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.Users;
using System;
using System.Collections.Generic;
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

        [Authorize]
        [Route("api/User/GetSession")]
        [HttpGet]
        public IHttpActionResult GetSession()
        {
            return Ok(true);
        }
        // POST: api/User
        [HttpPost]
        public IHttpActionResult Post(Users users)
        {
            Users userCheck = null;

            UsersB userB = new UsersB();

            userCheck = userB.Check(users.Nickname,users.Password);

            switch (userCheck.ConfirmStatus)
            {
                case 200:
                    return Ok(userCheck);
                case 500:
                    return Ok(500);
                default:
                    return Ok(false);
            }
        }
    }
}
