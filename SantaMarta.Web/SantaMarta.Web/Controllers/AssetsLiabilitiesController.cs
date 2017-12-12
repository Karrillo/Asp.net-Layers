using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SantaMarta.Bussines.AccountsBussines;
using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using SantaMarta.Bussines.CategoriesBussines;
using SantaMarta.Bussines.SubCategoriesBussines;
using SantaMarta.Bussines.UsersBussines;
using SantaMarta.Data.Models.AssetsLiabilities;
using SantaMarta.Data.Models.Users;
using SantaMarta.Data.Store_Procedures;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    [SessionExpireFilter]
    public class AssetsLiabilitiesController : Controller
    {

        private AssetsLiabilitiesB assetsLiabilitiesB;
        private CategoriesB categoriesB;
        private SubCategoriesB subCategoriesB;
        private AccountsB accountB;
        private UsersB userB;

        public AssetsLiabilitiesController()
        {
            assetsLiabilitiesB = new AssetsLiabilitiesB();
            categoriesB = new CategoriesB();
            subCategoriesB = new SubCategoriesB();
            accountB = new AccountsB();
            userB = new UsersB();
        }

        // GET: AssetsLiabilities
        public ActionResult Index(String value_from_start_date, String value_from_end_date)
        {

            if (value_from_start_date == null && value_from_end_date == null)
            {
                Session["startDate"] = null;
                Session["endDate"] = null;
            }
            else
            {
                Session["startDate"] = value_from_start_date;
                Session["endDate"] = value_from_end_date;
            }


            if (!String.IsNullOrEmpty(value_from_start_date) && !String.IsNullOrEmpty(value_from_end_date))
            {
                ViewBag.assets = assetsLiabilitiesB.TotalSum(value_from_start_date, value_from_end_date, true);
                ViewBag.liabilities = assetsLiabilitiesB.TotalSum(value_from_start_date, value_from_end_date, false);
                ViewBag.Fecha = value_from_start_date + " Hasta " + value_from_end_date;
                tableInformation(ViewBag.assets, ViewBag.liabilities);

                return View(assetsLiabilitiesB.GetAllDate(value_from_start_date, value_from_end_date).ToList());
            }
            else
            {
                ViewBag.assets = assetsLiabilitiesB.TotalSum(DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), true);
                ViewBag.liabilities = assetsLiabilitiesB.TotalSum(DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd"), false);
                ViewBag.Fecha = DateTime.Today.ToString("yyyy-MM-dd");
                tableInformation(ViewBag.assets, ViewBag.liabilities);

                return View(assetsLiabilitiesB.GetAllDate(DateTime.Today.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd")).ToList());
            }
        }

        // GET: information on ViewBag
        private void tableInformation(Decimal? assets, Decimal? liabilities)
        {
            if (ViewBag.assets == 0)
            {
                ViewBag.Total = (-ViewBag.liabilities);
            }
            else if (ViewBag.liabilities == 0)
            {
                ViewBag.Total = (ViewBag.assets);
            }
            else if (ViewBag.assets != 0 && ViewBag.liabilities != 0)
            {
                ViewBag.Total = (ViewBag.assets - ViewBag.liabilities);
            }
        }

        // GET: AssetsLiabilities/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var assetsLiabilities = assetsLiabilitiesB.GetById(id);


            AssetsLiabilitiesDetails assetsLiabilitiesDetails = new AssetsLiabilitiesDetails();

            assetsLiabilitiesDetails.NameCategory = subCategoriesB.GetByIdName((int)assetsLiabilities.IdSubCategory);
            assetsLiabilitiesDetails.NameSubCategory = subCategoriesB.GetById((int)assetsLiabilities.IdSubCategory).Name;
            assetsLiabilitiesDetails.NameUser = userB.GetById((int)assetsLiabilities.IdUser).Nickname;
            assetsLiabilitiesDetails.NameAccount = accountB.GetById((int)assetsLiabilities.IdAccount).Name;
            assetsLiabilitiesDetails.Name = assetsLiabilities.Name;
            assetsLiabilitiesDetails.Code = assetsLiabilities.Code;
            assetsLiabilitiesDetails.CurrentDate = assetsLiabilities.CurrentDate;
            assetsLiabilitiesDetails.Description = assetsLiabilities.Description;
            assetsLiabilitiesDetails.Rode = assetsLiabilities.Rode;

            if (assetsLiabilities.Type == true)
            {
                assetsLiabilitiesDetails.Type = "Ingreso";
            }
            else
            {
                assetsLiabilitiesDetails.Type = "Egreso";
            }

            return PartialView(assetsLiabilitiesDetails);
        }

        // GET: AssetsLiabilities/Create
        public ActionResult Create()
        {
            ViewData["category"] = new SelectList(categoriesB.GetAll(), "IdCategory", "Name");
            ViewData["account"] = new SelectList(accountB.GetAll(), "IdAccount", "Name");
            return View();
        }

        public JsonResult GetSubCategories(string id)
        {
            var subCategories = subCategoriesB.GetByIdAll(int.Parse(id));
            return Json(new SelectList(subCategories, "IDSubCategory", "Name"), JsonRequestBehavior.AllowGet);
        }

        // POST: AssetsLiabilities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetsLiabilities assetLiability)
        {
            var user = (Users)Session["users"];
            assetLiability.IdUser = user.IDUser;

            int status = assetsLiabilitiesB.Create(assetLiability);

            if (status == 200)
            {
                TempData["message"] = "Add";
                return Json(new { success = true });
            }
            return View(assetLiability);
        }

        // GET: AssetsLiabilities/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: AssetsLiabilities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int status = assetsLiabilitiesB.Delete(id);

            if (status == 200)
            {
                TempData["message"] = "Delete";
                return Json(new { success = true });
            }
            return PartialView();
        }

        //Create PDF 
        public void createPdf()
        {
            string pathToTemplate = Server.MapPath("~/App_Data/report.pdf");
            PdfDocument originalTemplate = PdfReader.Open(pathToTemplate, PdfDocumentOpenMode.Modify);
            XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            XGraphics graphics = XGraphics.FromPdfPage(originalTemplate.Pages[0]);
            graphics.DrawString("Productos Alimenticios Santa Marta", font, XBrushes.Black, 220, 80);
            int position = 145;

            var startDate = Session["startDate"];
            var endDate = Session["endDate"];

            if (startDate != null && endDate != null)
            {
                graphics.DrawString(startDate + " al " + endDate, font, XBrushes.Black, 450, 60);

                foreach (var item in assetsLiabilitiesB.GetAllDate(startDate.ToString(), endDate.ToString()))
                {
                    if (item.State == true)
                    {
                        graphics.DrawString(item.CurrentDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, 35, position);
                        graphics.DrawString(item.Code.ToString(), font, XBrushes.Black, 130, position);
                        graphics.DrawString(item.Name.ToString(), font, XBrushes.Black, 240, position);
                        if (item.Type == false)
                        {
                            graphics.DrawString(item.Rode.ToString(), font, XBrushes.Red, 500, position);
                        }
                        else
                        {
                            graphics.DrawString(item.Rode.ToString(), font, XBrushes.Green, 418, position);
                        }
                        position = position + 15;
                    }
                }

                var assets = assetsLiabilitiesB.TotalSum(startDate.ToString(), endDate.ToString(), true);
                var liabilities = assetsLiabilitiesB.TotalSum(startDate.ToString(), endDate.ToString(), false);

                graphics.DrawString("₡" + assets.ToString(), font, XBrushes.Green, 418, 790);
                graphics.DrawString("₡" + liabilities.ToString(), font, XBrushes.Red, 500, 790);

                if (assets == null)
                {
                    graphics.DrawString("₡" + liabilities.ToString(), font, XBrushes.Red, 500, 80);
                }
                else if (liabilities == null)
                {
                    graphics.DrawString("₡" + assets.ToString(), font, XBrushes.Green, 500, 80);
                }
                else if (assets != null && liabilities != null)
                {
                    decimal? total = ((assets) - (liabilities));
                    if (total >= 0)
                    {
                        graphics.DrawString("₡" + total.ToString(), font, XBrushes.Green, 500, 80);
                    }
                    else
                    {
                        graphics.DrawString("₡" + total.ToString(), font, XBrushes.Red, 500, 80);
                    }
                }
            }
            else
            {
                String fechaActual = DateTime.Today.ToString("yyyy-MM-dd");
                graphics.DrawString(fechaActual, font, XBrushes.Black, 500, 60);

                foreach (var item in assetsLiabilitiesB.GetAllDate(fechaActual, fechaActual))
                {
                    if (item.State == true)
                    {
                        graphics.DrawString(item.CurrentDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, 35, position);
                        graphics.DrawString(item.Code.ToString(), font, XBrushes.Black, 130, position);
                        graphics.DrawString(item.Name.ToString(), font, XBrushes.Black, 240, position);
                        if (item.Type == false)
                        {
                            graphics.DrawString(item.Rode.ToString(), font, XBrushes.Red, 500, position);
                        }
                        else
                        {
                            graphics.DrawString(item.Rode.ToString(), font, XBrushes.Green, 418, position);
                        }
                        position = position + 15;
                    }
                }

                var assets = assetsLiabilitiesB.TotalSum(fechaActual, fechaActual, true);
                var liabilities = assetsLiabilitiesB.TotalSum(fechaActual, fechaActual, false);

                graphics.DrawString("₡" + assets.ToString(), font, XBrushes.Green, 418, 790);
                graphics.DrawString("₡" + liabilities.ToString(), font, XBrushes.Red, 500, 790);

                if (assets == null)
                {
                    graphics.DrawString("₡" + liabilities.ToString(), font, XBrushes.Red, 500, 80);
                }
                else if (liabilities == null)
                {
                    graphics.DrawString("₡" + assets.ToString(), font, XBrushes.Green, 500, 80);
                }
                else if (assets != null && liabilities != null)
                {
                    Decimal? total = ((assets) - (liabilities));
                    if (total >= 0)
                    {
                        graphics.DrawString("₡" + total.ToString(), font, XBrushes.Green, 500, 80);
                    }
                    else
                    {
                        graphics.DrawString("₡" + total.ToString(), font, XBrushes.Red, 500, 80);
                    }
                }
            }

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
            Response.End();
        }
    }
}
