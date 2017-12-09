using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.ClientsBussines;
using SantaMarta.Bussines.DetailsBussines;
using SantaMarta.Bussines.InvoicesBussines;
using SantaMarta.Bussines.ProductsBussines;
using SantaMarta.Bussines.ProvidersBussines;
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
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
    public class SalesController : Controller
    {
        private CategoriesB categoriesB;
        private SubCategoriesB subCategoriesB;
        private AccountsB accountB;
        private UsersB userB;
        private SalesB saleB;
        private AssetsLiabilitiesB assetsLiabilitiesB;
        private ClientsB clientsB;
        private ProductsB productsB;
        private DetailsB detailsB;
        private InvoicesB invoicesB;
        private ProvidersB providersB;

        public SalesController()
        {
            categoriesB = new CategoriesB();
            subCategoriesB = new SubCategoriesB();
            accountB = new AccountsB();
            userB = new UsersB();
            saleB = new SalesB();
            assetsLiabilitiesB = new AssetsLiabilitiesB();
            clientsB = new ClientsB();
            productsB = new ProductsB();
            detailsB = new DetailsB();
            invoicesB = new InvoicesB();
            providersB = new ProvidersB();
        }

        // GET: Sales
        public ActionResult Index()
        {
            List<InvoicesTable> invoicesTable = new List<InvoicesTable>();
            List<Views_Invoices> invoices = invoicesB.GetAllSales().ToList();

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

        // GET: Sales Expired
        public ActionResult Index2()
        {
            List<InvoicesTable> invoicesTable = new List<InvoicesTable>();
            List<Views_Invoices> invoices = invoicesB.GetAllSalesExpired().ToList();

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

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Views_Invoinces_Details sales = invoicesB.GetById(id, true);

            sales.Date = sales.CurrentDate.ToShortDateString();
            sales.Products = saleB.GetById(sales.IdDetail).ToList();
            sales.AssetsLiabilities = assetsLiabilitiesB.GetByIdInvoinces(id).ToList();

            if (sales.Products != null)
            {
                foreach (var item in sales.AssetsLiabilities)
                {
                    sales.Payments = sales.Payments + item.Rode;
                }

                sales.Residue = sales.Total - sales.Payments;
                return PartialView(sales);
            }

            return PartialView(sales);
        }

        // GET: Products
        public JsonResult GetProduct(string id)
        {
            Products product = productsB.GetById(int.Parse(id));
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        // GET: Clients
        public JsonResult GetClient(string id)
        {
            All_Clients client = clientsB.GetById(Convert.ToInt32(id));
            return Json(client, JsonRequestBehavior.AllowGet);
        }

        // GET: Sales/Create
        public ActionResult Create()
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

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(string idClient, string discount, string total, string currentDate, string code, string limitDate, List<Sales> sale)
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
            invoices.IdClient = Convert.ToInt64(idClient);
            invoices.IdProvider = providersB.GetIdOwn();
            int status = invoicesB.Create(invoices);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            else if (status == 501)
            {
                TempData["message"] = "Add";
                TempData["message"] = "ErrorEmail";
                return Json(new { success = true });
            }
            else
            {
                return View();
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
            assetLiability.Type = true;

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

        // GET: Client Code
        public JsonResult GetCode(string id)
        {
            var code = invoicesB.GetCode();
            return Json(code, JsonRequestBehavior.AllowGet);
        }

        // GET: SubCategories
        public JsonResult GetSubCategories(string id)
        {
            var subCategories = subCategoriesB.GetByIdAll(int.Parse(id));
            return Json(new SelectList(subCategories, "IDSubCategory", "Name"), JsonRequestBehavior.AllowGet);
        }

        // GET: categories
        public JsonResult GetPayment(string id)
        {
            var subCategories = subCategoriesB.GetByIdAll(int.Parse(id));
            return Json(new SelectList(subCategories, "IDSubCategory", "Name"), JsonRequestBehavior.AllowGet);
        }

        //Create PDF 
        [HttpGet]
        public FileResult CreatePDF(string id)
        {
            Decimal totalProduct = 0;
            string pathToTemplate = Server.MapPath("~/App_Data/invoice.pdf");

            PdfDocument originalTemplate = PdfReader.Open(pathToTemplate, PdfDocumentOpenMode.Modify);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XGraphics graphics = XGraphics.FromPdfPage(originalTemplate.Pages[0]);
            graphics.DrawString("Productos Alimenticios Santa Marta", font, XBrushes.Black, 300, 80);
            int position = 200;

            Views_Invoinces_Details sales = invoicesB.GetById(Int64.Parse(id), true);

            sales.Date = sales.CurrentDate.ToShortDateString();
            sales.Products = saleB.GetById(sales.IdDetail).ToList();
            sales.AssetsLiabilities = assetsLiabilitiesB.GetByIdInvoinces(Int64.Parse(id)).ToList();

            graphics.DrawString("Cliente: " + sales.Name + " " + sales.FirstName + " " + sales.SecondName, font, XBrushes.Black, 300, 95);
            graphics.DrawString("Compañía: " + sales.NameCompany, font, XBrushes.Black, 300, 110);

            graphics.DrawString(sales.Date, font, XBrushes.Black, 500, 30);
            graphics.DrawString("Documento: " + sales.Code, font, XBrushes.Black, 500, 45);

            graphics.DrawString("Codigo", font, XBrushes.Black, 35, position);
            graphics.DrawString("Precio", font, XBrushes.Black, 185, position);
            graphics.DrawString("Cantidad", font, XBrushes.Black, 335, position);
            graphics.DrawString("SubTotal", font, XBrushes.Black, 485, position);

            position = position + 15;

            foreach (var item in sales.Products)
            {
                graphics.DrawString(item.Code.ToString(), font, XBrushes.Black, 35, position);
                graphics.DrawString("₡" + item.Price.ToString(), font, XBrushes.Black, 185, position);
                graphics.DrawString(item.Quantity.ToString(), font, XBrushes.Black, 335, position);
                graphics.DrawString("₡" + item.Total.ToString(), font, XBrushes.Black, 485, position);
                totalProduct = totalProduct + item.Total;
                position = position + 15;
            }

            graphics.DrawString("Total: ₡" + totalProduct.ToString(), font, XBrushes.Black, 465, 545);

            position = 575;

            graphics.DrawString("Fecha", font, XBrushes.Black, 35, position);
            graphics.DrawString("Nombre", font, XBrushes.Black, 140, position);
            graphics.DrawString("Codigo", font, XBrushes.Black, 335, position);
            graphics.DrawString("Monto", font, XBrushes.Black, 485, position);

            position = position + 15;

            foreach (var item in sales.AssetsLiabilities)
            {
                graphics.DrawString(item.CurrentDate.ToShortDateString(), font, XBrushes.Black, 35, position);
                graphics.DrawString(item.Name.ToString(), font, XBrushes.Black, 140, position);
                graphics.DrawString(item.Code.ToString(), font, XBrushes.Black, 335, position);
                graphics.DrawString("₡" + item.Rode.ToString(), font, XBrushes.Black, 485, position);

                position = position + 15;
            }

            if (sales.Products != null)
            {
                foreach (var item in sales.AssetsLiabilities)
                {
                    sales.Payments = sales.Payments + item.Rode;
                }
                sales.Residue = sales.Total - sales.Payments;
            }

            graphics.DrawString("Descuento aplicado: " + sales.Discount.ToString() + "%", font, XBrushes.Black, 35, 700);
            if (sales.LimitDate != null)
            {
                graphics.DrawString("Cancelar el: " + sales.LimitDate.GetValueOrDefault(DateTime.Now).ToShortDateString(), font, XBrushes.Black, 35, 720);
            }

            graphics.DrawString("SubTotal ₡" + sales.Total.ToString(), font, XBrushes.Black, 450, 700);
            graphics.DrawString("Abonos ₡" + sales.Payments.ToString(), font, XBrushes.Black, 450, 720);
            graphics.DrawString("Total ₡" + sales.Residue.ToString(), font, XBrushes.Black, 450, 740);

            MemoryStream stream = new MemoryStream();
            originalTemplate.Save(stream, false);

            byte[] bytesMemory = stream.ToArray();

            Byte[] bytes = bytesMemory;
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.AddHeader("content-disposition", "attachment; filename = Reporte_" + DateTime.Now.ToString("yyyy-MM-dd") + ".pdf");
            Response.ContentType = "application/pdf";

            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.Close();
            Response.End();
            return File(bytes, "application/pdf");
        }

        // GET: Invoices Expired
        public JsonResult GetInvoicesExpired()
        {
            List<Views_Invoices> invoices = invoicesB.GetAllSalesExpired();
            return Json(invoices, JsonRequestBehavior.AllowGet);
        }
    }
}

