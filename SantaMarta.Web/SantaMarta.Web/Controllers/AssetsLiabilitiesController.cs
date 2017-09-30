using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SantaMarta.Bussines.AssetsLiabilitiesBussines;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class AssetsLiabilitiesController : Controller
    {
        AssetsLiabilitiesB assetsLiabilitiesB = new AssetsLiabilitiesB();
        // GET: AssetsLiabilities
        public ActionResult Index(String dateStart, String dateEnd)
        {
            if (!String.IsNullOrEmpty(dateStart) && !String.IsNullOrEmpty(dateEnd))
            {
                assetsLiabilitiesB.GetAllDate(dateStart, dateEnd);
                assetsLiabilitiesB.TotalSum(dateStart, dateEnd, true);
                assetsLiabilitiesB.TotalSum(dateStart, dateEnd, false);
            }
           

            ViewBag.assets = assetsLiabilitiesB.TotalSum(DateTime.Today.ToString("MM-dd-yyyy"), DateTime.Today.ToString("MM-dd-yyyy"), true);
            ViewBag.liabilities = assetsLiabilitiesB.TotalSum(DateTime.Today.ToString("MM-dd-yyyy"), DateTime.Today.ToString("MM-dd-yyyy"), false);

            if (ViewBag.assets == null)
            {
                ViewBag.Total = (-ViewBag.liabilities);

            }
            else if (ViewBag.liabilities == null)
            {
                ViewBag.Total = (ViewBag.assets);
            }
            else if (ViewBag.assets != null && ViewBag.liabilities != null)
            {
                ViewBag.Total = (ViewBag.assets - ViewBag.liabilities);
            }
            //ViewBag.Movimientos = movimientos.Last();
            ViewBag.Fecha = DateTime.Today.ToString("MM-dd-yyyy");

            return View(assetsLiabilitiesB.GetAllDate(DateTime.Today.ToString("MM-dd-yyyy"), DateTime.Today.ToString("MM-dd-yyyy")).ToList());
        }

        // GET: AssetsLiabilities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetsLiabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetsLiabilities/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetsLiabilities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetsLiabilities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetsLiabilities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetsLiabilities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public void createPdf()
        //{
        //    //path to template
        //    string pathToTemplate = Server.MapPath("~/App_Data/reporte.pdf");
        //    //original document
        //    PdfDocument originalTemplate = PdfReader.Open(pathToTemplate, PdfDocumentOpenMode.Modify);
        //    XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);
        //    //graphics
        //    XGraphics graphics = XGraphics.FromPdfPage(originalTemplate.Pages[0]);
        //    graphics.DrawString("Productos Alimenticios Santa Marta", font, XBrushes.Black, 220, 80);

        //    int position = 145;
        //    if (Session["fecha"] != null)
        //    {
        //        graphics.DrawString(Session["fecha"].ToString(), font, XBrushes.Black, 450, 60);

        //        String[] Fechas = new String[1];

        //        DateTime fechaMin = new DateTime();
        //        DateTime fechaMax = new DateTime();

        //        Fechas = Session["fecha"].ToString().Split('-');

        //        fechaMin = DateTime.Parse(Fechas[0]);
        //        fechaMax = DateTime.Parse(Fechas[1].Trim());

        //        x = fechaMax.ToString("MM-dd-yyyy");
        //        y = fechaMin.ToString("MM-dd-yyyy");

        //        foreach (var item in db.Fecha_ActivoPasivo(y, x))
        //        {
        //            graphics.DrawString(item.Fecha.ToString("MM/dd/yy"), font, XBrushes.Black, 35, position);
        //            graphics.DrawString(item.Numero.ToString(), font, XBrushes.Black, 130, position);
        //            graphics.DrawString(item.Nombre.ToString(), font, XBrushes.Black, 240, position);
        //            if (item.Tipo == true)
        //            {
        //                graphics.DrawString(item.Monto.ToString(), font, XBrushes.Red, 500, position);
        //            }
        //            else
        //            {
        //                graphics.DrawString(item.Monto.ToString(), font, XBrushes.Green, 418, position);
        //            }
        //            position = position + 15;
        //        }

        //        var ingreso = db.Fecha_Suma_ActivoPasivo(y, x, false).ToArray();
        //        var gasto = db.Fecha_Suma_ActivoPasivo(y, x, true).ToArray();

        //        graphics.DrawString("₡" + ingreso.Last().ToString(), font, XBrushes.Green, 418, 790);
        //        graphics.DrawString("₡" + gasto.Last().ToString(), font, XBrushes.Red, 500, 790);

        //        if (ingreso.Last() == null)
        //        {
        //            graphics.DrawString("₡" + gasto.Last().ToString(), font, XBrushes.Red, 500, 80);
        //        }
        //        else if (gasto.Last() == null)
        //        {
        //            graphics.DrawString("₡" + ingreso.Last().ToString(), font, XBrushes.Green, 500, 80);
        //        }
        //        else if (ingreso.Last() != null && gasto.Last() != null)
        //        {
        //            int total = (int)ingreso.Last() - (int)gasto.Last();
        //            if (total >= 0)
        //            {
        //                graphics.DrawString("₡" + total.ToString(), font, XBrushes.Green, 500, 80);
        //            }
        //            else
        //            {
        //                graphics.DrawString("₡" + total.ToString(), font, XBrushes.Red, 500, 80);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        graphics.DrawString(DateTime.Now.ToString("MM/dd/yy"), font, XBrushes.Black, 500, 60);

        //        String fechaActual = DateTime.Today.ToString("dd-MM-yyyy");

        //        foreach (var item in db.Fecha_ActivoPasivo(fechaActual, fechaActual))
        //        {
        //            graphics.DrawString(item.Fecha.ToString("MM/dd/yy"), font, XBrushes.Black, 35, position);
        //            graphics.DrawString(item.Numero.ToString(), font, XBrushes.Black, 130, position);
        //            graphics.DrawString(item.Nombre.ToString(), font, XBrushes.Black, 240, position);
        //            if (item.Tipo == true)
        //            {
        //                graphics.DrawString(item.Monto.ToString(), font, XBrushes.Red, 500, position);
        //            }
        //            else
        //            {
        //                graphics.DrawString(item.Monto.ToString(), font, XBrushes.Green, 418, position);
        //            }
        //            position = position + 15;
        //        }

        //        var ingreso = db.Fecha_Suma_ActivoPasivo(fechaActual, fechaActual, false).ToArray();
        //        var gasto = db.Fecha_Suma_ActivoPasivo(fechaActual, fechaActual, true).ToArray();

        //        graphics.DrawString("₡" + ingreso.Last().ToString(), font, XBrushes.Green, 418, 790);
        //        graphics.DrawString("₡" + gasto.Last().ToString(), font, XBrushes.Red, 500, 790);

        //        if (ingreso.Last() == null)
        //        {
        //            graphics.DrawString("₡" + gasto.Last().ToString(), font, XBrushes.Red, 500, 80);
        //        }
        //        else if (gasto.Last() == null)
        //        {
        //            graphics.DrawString("₡" + ingreso.Last().ToString(), font, XBrushes.Green, 500, 80);
        //        }
        //        else if (ingreso.Last() != null && gasto.Last() != null)
        //        {
        //            int total = (int)ingreso.Last() - (int)gasto.Last();
        //            if (total >= 0)
        //            {
        //                graphics.DrawString("₡" + total.ToString(), font, XBrushes.Green, 500, 80);
        //            }
        //            else
        //            {
        //                graphics.DrawString("₡" + total.ToString(), font, XBrushes.Red, 500, 80);
        //            }
        //        }
        //    }

        //    MemoryStream stream = new MemoryStream();
        //    originalTemplate.Save(stream, false);

        //    byte[] bytesMemory = stream.ToArray();

        //    Byte[] bytes = bytesMemory;
        //    Response.Buffer = true;
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    Response.AddHeader("content-disposition", "attachment; filename=Reporte_" + DateTime.Now.ToString("MM/dd/yy") + ".pdf");
        //    Response.ContentType = "application/pdf";

        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();
        //}
    }
}
