using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
            return Json(GetProducts().ToDataSourceResult(request));
        }

        public static List<ProductData> GetProducts()
        {
            List<ProductData> result;
            {
                using (var db = new Models._Databse._DatabseContextShop())
                {
                    result = db.Products
                        .Where(product => product.Discontinued != true
                        && product.UnitsInStock > 0
                        )
                        .Select(product => new ProductData
                    {
                        ProductID = product.Id,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice ?? 0,
                        UnitsInStock = product.UnitsInStock ?? 0,
                        UnitsOnOrder = product.UnitsOnOrder ?? 0,
                        Discontinued = product.Discontinued,
                        LastSupply = product.LastSupply
                    }).ToList();
                    return result;
                }
            }
        }

        [HttpGet]
        public ActionResult List()
        {            
            List<ProductData> model = GetProducts();
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddProduct(OrderData model)
        {


            return View(model);
        }


        [HttpPost]
        public JsonResult ShowProduct(int id)
        {
            return Json(id);
        }

    }
}
