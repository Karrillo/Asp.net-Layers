using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace SantaMarta.Web.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        HttpSessionStateBase session = filterContext.HttpContext.Session;
        var user = session["users"];

        if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
        {
                
            //send them off to the login page
           
            session.RemoveAll();
            session.Clear();
            session.Abandon();
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                    { "Controller", "Login" },
                    { "Action", "Index" }
                });
            }
            else
            {
                System.Int32 timeOut = System.Web.HttpContext.Current.Session.Timeout;
                if (timeOut < 5)
                {
                    session.Timeout = timeOut + 10;
                }
            }
        }
    }
}