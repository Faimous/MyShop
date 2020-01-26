using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MyShop.Models._Databse;
using MyShop.Models.Orders;
using MyShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class ProductController : DefaultController
    {

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            using (var db = new _DatabseContextShop())
            {
                return Json(Product.GetProducts(db).ToDataSourceResult(request));
            }
        }


        [HttpGet]
        public ActionResult List()
        {
            using (var db = new _DatabseContextShop())
            {
                List<ProductData> model = Product.GetProducts(db);
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddProduct()
        {
            var model = new ProductData();
            int i;

            //New product id 1 bigger than current biggest
            using (var db = new _DatabseContextShop())
            {
                i = db.Products.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            }
            model.ProductID = i + 1;
            return View(model);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductData model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new _DatabseContextShop())
                {
                    Product.Add(model, db);
                }
               // return View();

            }
            return View(model);
        }


        [HttpGet]
        public ActionResult ShowProduct(int id)
        {
            using (var db = new _DatabseContextShop())
            {
                var model = Product.GetOneProductModel(id, db);
                return View(model);
            }
        }
    }
}
