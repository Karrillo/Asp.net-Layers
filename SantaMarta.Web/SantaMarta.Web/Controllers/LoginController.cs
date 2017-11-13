using SantaMarta.Bussines.UsersBussines;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class LoginController : Controller
    {

        private UsersB userB;

        public LoginController()
        {
            userB = new UsersB();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nickname, string password)
        {
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

        public void Logout()
        {
            Session.Abandon();
            Response.Redirect("~/Login/Index");
        }
    }
}