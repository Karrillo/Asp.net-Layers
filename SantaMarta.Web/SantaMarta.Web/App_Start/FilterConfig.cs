﻿using SantaMarta.Web.Controllers;
using System.Web.Mvc;

namespace SantaMarta.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
