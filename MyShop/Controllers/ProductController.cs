using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MyShop.Models._Databse;
using MyShop.Models.Orders;
using MyShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Products_ReadAdmin([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new _DatabseContextShop())
            {
                IQueryable<ProductTable> products = db.Products;
                DataSourceResult result = products.ToDataSourceResult(request, productTable => new
                {
                    Id = productTable.Id,
                    ProductName = productTable.ProductName,
                    Description = productTable.Description,
                    UnitPrice = productTable.UnitPrice,
                    UnitsInStock = productTable.UnitsInStock,
                    UnitsOnOrder = productTable.UnitsOnOrder,
                    Discontinued = productTable.Discontinued,
                    LastSupply = productTable.LastSupply
                });

                return Json(result);
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

        //[HttpGet]
        //public ActionResult UploadView()
        //{
        //    return View();
        //}

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
                 return RedirectToAction("ListAdmin");

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

        [HttpGet]
        [Authorize]
        public ActionResult ListAdmin()
        {
            return View();
        }

      

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, ProductTable productTable)
        {

            if (ModelState.IsValid)
            {
                using (var db = new _DatabseContextShop())
                {
                    var entity = new ProductTable
                    {
                        Id = productTable.Id,
                        ProductName = productTable.ProductName,
                        Description = productTable.Description,
                        UnitPrice = productTable.UnitPrice,
                        UnitsInStock = productTable.UnitsInStock,
                        UnitsOnOrder = productTable.UnitsOnOrder,
                        Discontinued = productTable.Discontinued,
                        LastSupply = productTable.LastSupply
                    };

                    db.Products.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return Json(new[] { productTable }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, ProductTable productTable)
        {
            if (ModelState.IsValid)
            {
                using (var db = new _DatabseContextShop())
                {
                    var entity = new ProductTable
                    {
                        Id = productTable.Id,
                        ProductName = productTable.ProductName,
                        Description = productTable.Description,
                        UnitPrice = productTable.UnitPrice,
                        UnitsInStock = productTable.UnitsInStock,
                        UnitsOnOrder = productTable.UnitsOnOrder,
                        Discontinued = productTable.Discontinued,
                        LastSupply = productTable.LastSupply
                    };

                    db.Products.Attach(entity);
                    db.Products.Remove(entity);
                    db.SaveChanges();
                }
            }

            return Json(new[] { productTable }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}

