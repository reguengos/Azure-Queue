﻿using System.Web;
using System.Web.Mvc;

namespace WebApp_Queue_DotNet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
