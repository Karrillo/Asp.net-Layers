using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Bussines.DetailsBussines;
using SantaMarta.Bussines.InvoicesBussines;
using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Bussines.ProductsProvidersBussines;
using SantaMarta.Bussines.ProvidersBussines;
using SantaMarta.Bussines.PurchasesBussines;
using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Invoices;
using SantaMarta.Data.Models.Products;
using SantaMarta.Data.Models.Purchases;
using SantaMarta.Data.Models.Users;
using SantaMarta.Data.Store_Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
    public class PurchasesController : Controller
    {
        private ProductsProvidersB productsProvidersB;
        private CategoriesB categoriesB;
        private SubCategoriesB subCategoriesB;
        private AccountsB accountB;
        private UsersB userB;
        private PurchasesB purchaseB;
        private AssetsLiabilitiesB assetsLiabilitiesB;
        private ProvidersB providerB;
        private ProductsB productsB;
        private DetailsB detailsB;
        private InvoicesB invoicesB;
        private ClientsB clientsB;

        public PurchasesController()
        {
            categoriesB = new CategoriesB();
            subCategoriesB = new SubCategoriesB();
            accountB = new AccountsB();
            userB = new UsersB();
            purchaseB = new PurchasesB();
            assetsLiabilitiesB = new AssetsLiabilitiesB();
            providerB = new ProvidersB();
            productsB = new ProductsB();
            detailsB = new DetailsB();
            invoicesB = new InvoicesB();
            productsProvidersB = new ProductsProvidersB();
            clientsB = new ClientsB();
        }

        // GET: Purchases
        public ActionResult Index()
        {
            List<InvoicesTable> invoicesTable = new List<InvoicesTable>();
            List<Views_Invoices> invoices = invoicesB.GetAllPurchases().ToList();

            DateTime date = DateTime.Now;
            Int16 state = 0;

            foreach (var item in invoices)
            {
                state = 0;
                if (item.State == true)
                {
                    if (item.LimitDate < date && item.Total != item.Rode)
                    {
                        state = 0;
                    }
                    else if (item.Total == item.Rode)
                    {
                        state = 1;
                    }
                    else if (item.Total != item.Rode && item.LimitDate > date)
                    {
                        state = 2;
                    }
                }
                else
                {
                    state = 3;
                }

                if (item.Rode == null)
                {
                    item.Rode = 0;
                }

                invoicesTable.Add(new InvoicesTable()
                {
                    IDInvoice = item.IDInvoice,
                    Name = item.FirstName + " " + item.SecondName + " " + item.Name,
                    NameCompany = item.NameCompany,
                    Code = item.Code,
                    Date = item.CurrentDate.ToShortDateString(),
                    Rode = item.Total - item.Rode ?? 0,
                    Type = state
                });
            }
            return View(invoicesTable);
        }

        // GET: Purchases Expired
        public ActionResult Index2()
        {
            List<InvoicesTable> invoicesTable = new List<InvoicesTable>();
            List<Views_Invoices> invoices = invoicesB.GetAllPurchasesExpired().ToList();

            DateTime date = DateTime.Now;
            Int16 state = 0;

            foreach (var item in invoices)
            {
                state = 0;
                if (item.State == true)
                {
                    if (item.LimitDate < date && item.Total != item.Rode)
                    {
                        state = 0;
                    }
                    else if (item.Total == item.Rode)
                    {
                        state = 1;
                    }
                    else if (item.Total != item.Rode && item.LimitDate > date)
                    {
                        state = 2;
                    }
                }
                else
                {
                    state = 3;
                }

                if (item.Rode == null)
                {
                    item.Rode = 0;
                }

                invoicesTable.Add(new InvoicesTable()
                {
                    IDInvoice = item.IDInvoice,
                    Name = item.FirstName + " " + item.SecondName + " " + item.Name,
                    NameCompany = item.NameCompany,
                    Code = item.Code,
                    Date = item.CurrentDate.ToShortDateString(),
                    Rode = item.Total - item.Rode ?? 0,
                    Type = state
                });
            }
            return View(invoicesTable);
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Views_Invoinces_Details purchases = invoicesB.GetById(id, false);

            purchases.Date = purchases.CurrentDate.ToShortDateString();
            purchases.Products = purchaseB.GetById(purchases.IdDetail).ToList();
            purchases.AssetsLiabilities = assetsLiabilitiesB.GetByIdInvoinces(id).ToList();

            if (purchases.Products != null)
            {
                foreach (var item in purchases.AssetsLiabilities)
                {
                    purchases.Payments = purchases.Payments + item.Rode;
                }

                purchases.Residue = purchases.Total - purchases.Payments;
                return PartialView(purchases);
            }

            return PartialView(purchases);
        }

        // GET: Products
        public JsonResult GetAllProduct(string id)
        {
            var products = productsProvidersB.GetAll(Convert.ToInt32(id)).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // GET: Products
        public JsonResult GetProduct(string id)
        {
            Products product = productsB.GetById(int.Parse(id));
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        // GET: Providers
        public JsonResult GetProviders(string id)
        {
            All_Providers providers = providerB.GetById(Convert.ToInt32(id));
            return Json(providers, JsonRequestBehavior.AllowGet);
        }

        // GET: SubCategories
        public JsonResult GetSubCategories(string id)
        {
            var subCategories = subCategoriesB.GetByIdAll(int.Parse(id));
            return Json(new SelectList(subCategories, "IDSubCategory", "Name"), JsonRequestBehavior.AllowGet);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            var providers = providerB.GetAll().ToList();
            ViewData["providersCode"] = new SelectList(providers, "IDProvider", "Code");
            ViewData["providersCompany"] = new SelectList(providers, "IDProvider", "NameCompany");
            var name = providers.Select(u => new { IDProvider = u.IDProvider, Name = u.Name + " " + u.FirstName + " " + u.SecondName });
            ViewData["providersName"] = new SelectList(name, "IDProvider", "Name");

            return View();
        }

        // POST: Purchases/Create
        [HttpPost]
        public ActionResult Create(string idProvider, string discount, string total, string currentDate, string code, string limitDate, List<Purchases> purchases)
        {
            var idUser = (Users)Session["users"];

            Int64 details = detailsB.Create(idUser.IDUser);

            foreach (var items in purchases)
            {
                if (items.IdProduct != null)
                {
                    Purchases purchase = new Purchases();
                    purchase.IdProduct = items.IdProduct;
                    purchase.Quantity = items.Quantity;
                    purchase.Total = items.Total;
                    purchase.IdDetails = details;
                    purchaseB.Create(purchase);
                }
            }

            Invoices invoices = new Invoices();
            invoices.IdDetail = details;
            DateTime date = DateTime.Today;

            if (limitDate != "0")
            {
                invoices.LimitDate = date.AddDays(Convert.ToInt32(limitDate));
            }
            else
            {
                invoices.LimitDate = date;
            }

            invoices.Total = Convert.ToDecimal(total);

            if (discount != "")
            {
                invoices.Discount = Convert.ToDecimal(discount);
            }

            invoices.Code = code;
            invoices.IdClient = clientsB.GetIdClientOwn();
            invoices.IdProvider = Convert.ToInt64(idProvider);
            int status = invoicesB.Create(invoices);

            if (status != 500)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else
            {
                return View();
            }
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Purchases/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = invoicesB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                TempData["message"] = "Exist";
                return Json(new { success = true });
            }
            return PartialView();
        }

        // POST: AssetsLiabilities View
        public ActionResult Assets(int id, string name, decimal rode)
        {
            ViewData["category"] = new SelectList(categoriesB.GetAll(), "IdCategory", "Name");
            ViewData["account"] = new SelectList(accountB.GetAll(), "IdAccount", "Name");

            return PartialView();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assets(int id, AssetsLiabilities assetLiability)
        {
            var user = (Users)Session["users"];
            assetLiability.IdUser = user.IDUser;
            assetLiability.IdInvoice = id;
            assetLiability.Type = false;

            int status = assetsLiabilitiesB.CreateCredit(assetLiability);

            if (status == 200)
            {
                TempData["message"] = "Asset";
                return Json(new { success = true });
            }
            else if (status == 400)
            {
                ModelState.AddModelError("Rode", "Sobre pasa el monto de credito a cancelar");
                ViewData["category"] = new SelectList(categoriesB.GetAll(), "IdCategory", "Name");
                ViewData["account"] = new SelectList(accountB.GetAll(), "IdAccount", "Name");
                return View(assetLiability);
            }
            return View(assetLiability);
        }

        // GET: Invoices Expired
        public JsonResult GetInvoicesExpired()
        {
            List<Views_Invoices> invoices = invoicesB.GetAllPurchasesExpired();
            return Json(invoices, JsonRequestBehavior.AllowGet);
        }
    }
}

