using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantaMarta.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult SalesByYear()
        //{
        //    List<object> data = new List<object>();
        //    var enumerator = ((IEnumerable)db.Suma_ActivosPasivos()).GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        data.Add(enumerator.Current);
        //    }
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult getCategoria()
        //{
        //    List<object> mapdata = new List<object>();
        //    var enumerator = ((IEnumerable)db.Suma_Categoria()).GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        mapdata.Add(enumerator.Current);
        //    }
        //    return Json(mapdata, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult getCuenta()
        //{
        //    List<object> mapdata = new List<object>();
        //    var enumerator = ((IEnumerable)db.Suma_Cuenta()).GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        mapdata.Add(enumerator.Current);
        //    }
        //    return Json(mapdata, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult getAssetsLiabilities()
        //{
        //    List<Grafico> mapdata = new List<Grafico>();
        //    var info = db.Suma_ActivosPasivos().ToList();
        //    foreach (var item in info)
        //    {
        //        mapdata.Add(new Grafico { activo = (int)item.activo, pasivo = (int)item.pasivo, Fecha = item.Fecha.ToString("dd/MM/yyyy") });
        //    }
        //    return Json(mapdata, JsonRequestBehavior.AllowGet);
        //}

    }
}