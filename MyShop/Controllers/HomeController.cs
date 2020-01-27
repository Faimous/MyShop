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
            return RedirectToAction("List", "Product");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}