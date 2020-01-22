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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Add(ProductData model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            //var model = xxx
            return View();
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
