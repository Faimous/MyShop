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
            //ViewBag.States = states;
            //ViewBag.Cards = cards;

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
           

                // Database.Customers.Add(c);
                Database.Orders.Add(o);

                //foreach (var i in Database.ShoppingCartDatas.ToList<ShoppingCartTable>())
                //{
                //    Database.Order_Products.Add(new Order_Products
                //    {
                //        OrderID = o.OrderID,
                //        PID = i.PID,
                //        Qty = i.Quantity,
                //        TotalSale = i.Quantity * i.UnitPrice
                //    });
                //    Database.ShoppingCartDatas.Remove(i);
                //}

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
    }
}