using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    [RequireHttps]
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {


            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;

            ViewBag.Message = "Details about this app";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}