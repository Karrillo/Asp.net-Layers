using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Bussines.DetailsBussines;
using SantaMarta.Bussines.InvoicesBussines;
using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Bussines.SalesBussines;
using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Models.Sales;
using SantaMarta.Data.Models.Users;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class SalesController : Controller
    {
        private CategoriesB categoriesB = new CategoriesB();
        private SubCategoriesB subCategoriesB = new SubCategoriesB();
        private AccountsB accountB = new AccountsB();
        private UsersB userB = new UsersB();
        private SalesB saleB = new SalesB();
        private AssetsLiabilitiesB assetsLiabilitiesB = new AssetsLiabilitiesB();
        private ClientsB clientsB = new ClientsB();
        private ProductsB productsB = new ProductsB();
        private DetailsB detailsB = new DetailsB();
        private InvoicesB invoicesB = new InvoicesB();

        // GET: Sales
        public ActionResult Index()
        {
            return View(invoicesB.GetAllSales().ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sale = invoicesB.GetById(id);

            if (sale == null)
            {
                return HttpNotFound();
            }

            return PartialView(sale);
        }

        public JsonResult GetProduct(string id)
        {
            Products product = productsB.GetById(int.Parse(id));
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClient(string id)
        {
            All_Clients client = clientsB.GetById(Convert.ToInt32(id));
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            try
            {

                var clients = clientsB.GetAll().ToList();
                ViewData["clientsCode"] = new SelectList(clients, "IdClient", "Code");
                ViewData["clientsCompany"] = new SelectList(clients, "IdClient", "NameCompany");
                var name = clients.Select(u => new { IdClient = u.IDClient, Name = u.Name + " " + u.FirstName + " " + u.SecondName });
                ViewData["clientsName"] = new SelectList(name, "IDClient", "Name");

                var products = productsB.GetAll().ToList();
                ViewData["productsName"] = new SelectList(products, "IdProduct", "Name");
                ViewData["productsCode"] = new SelectList(products, "IdProduct", "Code");

                return View();
            }
            catch (Exception)
            {
                return PartialView();
            }
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(string idClient, string discount, string total, string currentDate, string code, string limitDate, List<Sales> sale)
        {

            try
            {
                var idUser = (Users)Session["users"];
                Int64 details = detailsB.Create(idUser.IDUser);

                foreach (var items in sale)
                {
                    if (items.IdProduct != null)
                    {
                        Sales sales = new Sales();
                        sales.IdProduct = items.IdProduct;
                        sales.Quantity = items.Quantity;
                        sales.Total = items.Total;
                        sales.IdDetails = details;
                        saleB.Create(sales);
                    }
                }

                Invoices invoices = new Invoices();
                invoices.IdDetail = details;
                DateTime date = DateTime.Today;
                if (limitDate != "0")
                {
                    invoices.LimitDate = date.AddDays(Convert.ToInt32(limitDate));
                }
                invoices.Total = Convert.ToDecimal(total);
                if (discount != "")
                {
                    invoices.Discount = Convert.ToDecimal(discount);
                }
                invoices.Code = code;
                invoices.IdClient = Convert.ToInt64(idClient);
                invoices.IdProvider = 1;
                invoicesB.Create(invoices);

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                invoicesB.Delete(id);
                return Json(new { success = true });
            }
            catch
            {
                return PartialView();
            }
        }

        public ActionResult Assets(int id)
        {
            ViewData["category"] = new SelectList(categoriesB.GetAll(), "IdCategory", "Name");
            ViewData["account"] = new SelectList(accountB.GetAll(), "IdAccount", "Name");
            return PartialView();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assets(int id, FormCollection collection)
        {
            var user = (Users)Session["users"];
            try
            {
                AssetsLiabilities assetLiability = new AssetsLiabilities();

                assetLiability.CurrentDate = DateTime.Parse(collection["CurrentDate"]);
                assetLiability.Code = collection["Code"];
                assetLiability.Rode = Decimal.Parse(collection["Rode"]);
                assetLiability.Description = collection["Description"];
                assetLiability.IdUser = user.IDUser;
                assetLiability.IdAccount = Convert.ToInt64(collection["account"]);
                assetLiability.IdSubCategory = Convert.ToInt64(collection["subCategory"]);

                assetsLiabilitiesB.Create(assetLiability);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AssetsLiabilities", "Create"));
            }
        }

        public JsonResult GetSubCategories(string id)
        {
            var subCategories = subCategoriesB.GetByIdAll(int.Parse(id));
            return Json(new SelectList(subCategories, "IDSubCategory", "Name"), JsonRequestBehavior.AllowGet);
        }
    }
}
