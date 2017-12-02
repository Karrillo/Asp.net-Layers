using SantaMarta.Bussines.MailsBussines;
using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.Mails;
using SantaMarta.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class LoginController : Controller
    {

        private UsersB userB;
        private MailsB mailB;

        public LoginController()
        {
            userB = new UsersB();
            mailB = new MailsB();
        }

        // GET: Login
        public ActionResult Index()
        {
            Check();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nickname, string password)
        {
            Check();

            var userLogin = userB.Check(nickname, password);

            if (userLogin.ConfirmStatus == 200)
            {
                if (userLogin.Nickname != null)
                {
                    Session["users"] = userLogin;
                    if (userLogin.Type == true)
                    {
                        Session["type"] = userLogin.Type;
                    }
                    else
                    {
                        Session["type"] = null;
                    }
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "Error en el username o password");
                }
                return View();
            }
            else
            {
                TempData["message"] = "Error";
                return View();
            }
        }

        private void Check()
        {
            List<Users> users = userB.GetAll();
            Mails email = mailB.Get();

            if (users.Count == 0)
            {
                TempData["type"] = false;
            }

            foreach (var item in users)
            {
                if (item.Type == true)
                {
                    TempData["type"] = true;
                    break;
                }
            }

            if (email == null)
            {
                TempData["email"] = false;
            }
            else
            {
                TempData["email"] = true;
            }
        }

        public void Logout()
        {
            Session.Abandon();
            Response.Redirect("~/Login/Index");
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            users.Type = true;
            int status = userB.Create(users);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("NickName", "El NickName se esta usando actualmente");
                return View(users);
            }
            return View(users);
        }

        public void Recover()
        {
            Mails email = mailB.Get();
            if (email != null)
            {
                List<Users> users = userB.GetAll();
                String subJect = "Recuperacion de contraseña del sistema";
                String body = "Las contraseñas de usuarios administradores son las siguientes: ";
                foreach (var item in users)
                {
                    if (item.Type == true)
                    {
                        Users user = userB.GetById(Convert.ToInt32(item.IDUser));
                        body = body + "Nickname: " + user.Nickname + ", Clave: " + user.Password + ". ";
                    }
                }
                int state = mailB.SendEmail(email.Email, subJect, body);
                if (state == 500)
                {
                    TempData["message"] = "ErrorEmail";
                }
                else {
                    TempData["message"] = "SendEmail";
                }
            }
        }
    }
}