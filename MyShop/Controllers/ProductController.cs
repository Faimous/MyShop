using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
        private Product productService;

        //public ListViewController()
        //{
        //    productService = new ProductService(new SampleEntities());
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    productService.Dispose();

        //    base.Dispose(disposing);
        //}
        [HttpGet]
        public ActionResult Index()
        {
            List<ProductData> model = GetProducts();
            return View(model);
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
                result = db.Products.Select(product => new ProductData
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
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult ProductList([DataSourceRequest]DataSourceRequest request)
        //{
        //    try
        //    {
        //        list<product> _emp = new list<product>();
        //        _emp.add(new product(1, "bobb", "ross"));
        //        _emp.add(new product(2, "pradeep", "raj"));
        //        _emp.add(new product(3, "arun", "kumar"));
        //        datasourceresult result = _emp.todatasourceresult(request);
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);

        //    }
        //}
    }
}
