﻿using Kendo.Mvc.Extensions;
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
    public class OrderController : DefaultController
    {
        //private List<object> states;
        //private List<object> cards;

        [HttpGet]
        public ActionResult Purchase()
        {
            var model = new OrderData();
            model.OrderStatus = OrderStatus.New;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Purchase(OrderData order)
        {
            if (ModelState.IsValid)
            {
                OrderTable o = new OrderTable
                {
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Email = order.Email,
                    TelephoneNumer = order.TelephoneNumer,
                    Address1 = order.Address1,
                    Address2 = order.Address2,
                    State = order.State,
                    PostCode = order.Postcode,
                    OrderStatus = OrderStatus.New,
                    OrderDateTime = DateTime.Now
                };
           

                Database.Orders.Add(o);

                foreach (var i in Database.ShoppingCartDatas.ToList<ShoppingCartTable>())
                {
                    Database.Order_Products.Add(new Orders_Products_Table
                    {
                        OrderID = o.Id,
                        ProductId = i.PID,
                        Quantity = i.Quantity,
                        TotalSale = i.Quantity * i.UnitPrice
                    });
                    Database.ShoppingCartDatas.Remove(i);

                    //decrease stock
                    Database.Products.FirstOrDefault(p => p.Id == i.PID).UnitsInStock--;
                }

                Database.SaveChanges();
                ClearCart();
            return RedirectToAction("PurchaseSuccess");
            }
            return View(order);
        }

        public void ClearCart()
        {
            using (var db = new _DatabseContextShop())
            {
                List<ShoppingCartTable> carts = Database.ShoppingCartDatas.ToList();
                carts.ForEach(a =>
                {
                    ProductTable product = Database.Products.FirstOrDefault(p => p.Id == a.PID);
                    product.UnitsInStock += a.Quantity;
                });
                Database.ShoppingCartDatas.RemoveRange(carts);
                Database.SaveChanges();
            }
        }


        public ActionResult PurchaseSuccess()
        {
            return View();
        }


        //private _DatabseContextShop db = new _DatabseContextShop();

        [Authorize]
        public ActionResult OrderList()
        {
            return View();
        }

        public ActionResult Order_Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Orders_Products_Table> order_products = Database.Order_Products;
            DataSourceResult result = order_products.ToDataSourceResult(request, orders_Products_Table => new {
                Id = orders_Products_Table.Id,
                ProductId = orders_Products_Table.ProductId,
                OrderID = orders_Products_Table.OrderID,
                Quantity = orders_Products_Table.Quantity,
                TotalSale = orders_Products_Table.TotalSale
            });

            return Json(result);
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

        public ActionResult Order_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<OrderTable> orders = Database.Orders;

            DataSourceResult result = orders.ToDataSourceResult(request, newOrder => new {
                Id = newOrder.Id,
                OrderStatus = newOrder.OrderStatus,
                TelephoneNumer = newOrder.TelephoneNumer,
                OrderDateTime = newOrder.OrderDateTime,
                FirstName = newOrder.FirstName,
                LastName = newOrder.LastName,
                Address1 = newOrder.Address1,
                Address2 = newOrder.Address2,
                Email = newOrder.Email,
                State = newOrder.State,
                PostCode = newOrder.PostCode
            });

            return Json(result);
        }


    }
}
