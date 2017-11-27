using SantaMarta.Bussines.ChartsBussines;
using SantaMarta.Data.Store_Procedures;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class HomeController : Controller
    {
        private ChartsB chartsB;

        public HomeController()
        {
            chartsB = new ChartsB();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getSubCategories(string name)
        {
            var categories = chartsB.GetSubCategories(name).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getCategories()
        {
            var categories = chartsB.GetCategories().ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getAccounts()
        {
            List<Charts_Accounts> accounts = chartsB.GetAccount().ToList();
            return Json(accounts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getAssetsLiabilities()
        {
            var assetsLiabilities = chartsB.GetAssetsLiabilities().ToList();
            return Json(assetsLiabilities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getAssetsLiabilitiesFilter(string dateFilter, string dateSearch, string date)
        {
            if (date.Length == 4)
            {
                dateFilter = "months";
                dateSearch = "years";
            }
            else {
                dateFilter = "days";
                dateSearch = "months";
            }
            var assetsLiabilities = chartsB.GetAssetsLiabilitiesFilter(dateFilter, dateSearch, date).ToList();

            return Json(assetsLiabilities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getProducts()
        {
            var assetsLiabilities = chartsB.GetProducts().ToList();
            return Json(assetsLiabilities, JsonRequestBehavior.AllowGet);
        }
      
        public ActionResult getProductsFilter(int date)
        {
            List<Sum_Products> products = chartsB.GetProductsFilter(date).ToList();
            foreach (var item in products)
            {
                item.Date = item.Date.Replace("0", "");
            }
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getClients()
        {
            var assetsLiabilities = chartsB.GetClients().ToList();
            return Json(assetsLiabilities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getClientsFilter(int date)
        {
            List<Charts_Clients> clients = chartsB.GetClientsFilter(date).ToList();
            foreach (var item in clients)
            {
                item.Date = item.Date.Replace("0", "");
            }
            return Json(clients, JsonRequestBehavior.AllowGet);
        }
    }
}