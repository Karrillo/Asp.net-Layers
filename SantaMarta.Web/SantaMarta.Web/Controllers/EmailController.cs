using SantaMarta.Bussines.MailsBussines;
using SantaMarta.Data.Models.Mails;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class EmailController : Controller
    {
        private MailsB emailsB;

        public EmailController()
        {
            emailsB = new MailsB();
        }

        // GET: Email
        public ActionResult Index()
        {
            Mails email = emailsB.Get();
            if (email == null)
            {
                TempData["email"] = true;
            }
            else
            {
                TempData["email"] = false;
            }
            return View(email);
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Email/Create
        [HttpPost]
        public ActionResult Create(Mails emails)
        {
            int status = emailsB.Create(emails);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return View(emails);
        }

        // GET: Email/Edit/5
        public ActionResult Edit()
        {
            return PartialView(emailsB.Get());
        }

        // POST: Email/Edit/5
        [HttpPost]
        public ActionResult Edit(Mails emails)
        {
            int status = emailsB.Update(emails);

            if (status == 200)
            {
                TempData["message"] = "Update";
                return Json(new { success = true });
            }
            return View(emails);
        }
    }
}
