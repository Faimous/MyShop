using MyShop.Models._Databse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public abstract class DefaultController : Controller
    {
        protected _DatabseContextShop Database { get; set; }

            public DefaultController()
            {
                Database = new _DatabseContextShop();
            }


            protected override void Dispose(bool disposing)
            {
                Database.Dispose();
                base.Dispose(disposing);
            }
        }
    
}