﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp_Queue_DotNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Claims()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;

            return View("Error");
        }
    }
}