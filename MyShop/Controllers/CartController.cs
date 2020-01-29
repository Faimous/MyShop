using MyShop.Models._Databse;
using MyShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class CartController : DefaultController
    {

        private List<object> states;
        private List<object> cards;

        public CartController()
        {
            states = new List<object> {
                new { SID = "NSW", SName = "New South Wales" },
                new { SID = "VIC", SName = "Victoria" },
                new { SID = "QLD", SName = "Queensland" },
                new { SID = "TAs", SName = "Tasmania" },
                new { SID = "NT", SName = "Northern Territory" },
                new { SID = "SA", SName = "South Australia" },
                new { SID = "WA", SName = "Western Australia" },
                new { SID = "ACT", SName = "Australian Capital Territory" }
            };

            cards = new List<object> {
                new { Type = "VISA" },
                new { Type = "Master Card" },
                new { Type = "AMEX" }
            };

        }

        // GET: Checkout
        public ActionResult Index()
        {
            ViewBag.Cart = Database.ShoppingCartDatas.ToList<ShoppingCartTable>();
            return View();
        }

        public JsonResult QuanityChange(int type, int pId)
        {
            using (var db = new _DatabseContextShop())
            {

                ShoppingCartTable product = db.ShoppingCartDatas.FirstOrDefault(p => p.PID == pId);
                if (product == null)
                {
                    return Json(new { d = "0" });
                }

                ProductTable actualProduct = db.Products.FirstOrDefault(p => p.Id == pId);
                int? quantity;
                // if type 0, decrease quantity
                // if type 1, increase quanity
                switch (type)
                {
                    case 0:
                        product.Quantity--;
                        actualProduct.UnitsInStock++;
                        break;
                    case 1:
                        product.Quantity++;
                        actualProduct.UnitsInStock--;
                        break;
                    case -1:
                        actualProduct.UnitsInStock += product.Quantity;
                        product.Quantity = 0;
                        break;
                    default:
                        return Json(new { d = "0" });
                }

                if (product.Quantity == 0)
                {
                    db.ShoppingCartDatas.Remove(product);
                    quantity = 0;
                }
                else
                {
                    quantity = product.Quantity;
                }

                db.SaveChanges();
                return Json(new { d = quantity });
            }
        }


        [HttpGet]
        public JsonResult UpdateTotal()
        {
            using (var db = new _DatabseContextShop())
            {
                decimal? total;

                total = db.ShoppingCartDatas.Select(p => p.UnitPrice * p.Quantity).Sum();
                if (total == null)
                {
                    return Json(new { d = "" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { d = String.Format("{0:c}", total) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Clear()
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

                return RedirectToAction("Index", "Home", null);
            }
        }




        //public ActionResult Purchase()
        //{
        //    ViewBag.States = states;
        //    ViewBag.Cards = cards;

        //    return View();
        //}

        public ActionResult AddToCart(int id)
        {
            addToCart(id);
            return RedirectToAction("Index");
        }

        private void addToCart(int pId)
        {
            // check if product is valid
            ProductTable product = Database.Products.FirstOrDefault(p => p.Id == pId);
            if (product != null && product.UnitsInStock > 0)
            {
                // check if product already existed
                ShoppingCartTable cart = Database.ShoppingCartDatas.FirstOrDefault(c => c.PID == pId);
                if (cart != null)
                {
                    cart.Quantity++;
                }
                else
                {

                    cart = new ShoppingCartTable
                    {
                        PName = product.ProductName,
                        PID = product.Id,
                        UnitPrice = (decimal)product.UnitPrice,
                        Quantity = 1
                    };

                    Database.ShoppingCartDatas.Add(cart);
                }
                product.UnitsInStock--;
                Database.SaveChanges();
            }
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Purchase(ElectricsOnlineWebApp.Models.Customer customer)
        //{
        //    ViewBag.States = states;
        //    ViewBag.Cards = cards;

        //    if (ModelState.IsValid)
        //    {
        //        if (customer.ExpDate <= DateTime.Now)
        //        {
        //            ModelState.AddModelError("", "Credit card has already expired");
        //        }

        //        if (customer.Ctype == "AMEX")
        //        {
        //            if (customer.CardNo.Length != 15)
        //            {
        //                ModelState.AddModelError("", "AMEX must be 15 digits");
        //            }
        //        }
        //        else
        //        {
        //            if (customer.CardNo.Length != 16)
        //            {
        //                ModelState.AddModelError("", customer.Ctype + "must be 16 digits");
        //            }
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            Customer c = new Customer
        //            {
        //                FName = customer.FName,
        //                LName = customer.LName,
        //                Email = customer.Email,
        //                Phone = customer.Phone,
        //                Address1 = customer.Address1,
        //                Address2 = customer.Address2,
        //                Suburb = customer.Suburb,
        //                Postcode = customer.Postcode,
        //                State = customer.State,
        //                Ctype = customer.Ctype,
        //                CardNo = customer.CardNo,
        //                ExpDate = customer.ExpDate
        //            };

        //            Order o = new Order
        //            {
        //                OrderDate = DateTime.Now,
        //                DeliveryDate = DateTime.Now.AddDays(5),
        //                CID = c.CID
        //            };

        //            Database.Customers.Add(c);
        //            Database.Orders.Add(o);

        //            foreach (var i in Database.ShoppingCartDatas.ToList<ShoppingCartData>())
        //            {
        //                Database.Order_Products.Add(new Order_Products
        //                {
        //                    OrderID = o.OrderID,
        //                    PID = i.PID,
        //                    Qty = i.Quantity,
        //                    TotalSale = i.Quantity * i.UnitPrice
        //                });
        //                Database.ShoppingCartDatas.Remove(i);
        //            }

        //            Database.SaveChanges();

        //            return RedirectToAction("PurchasedSuccess");

        //        }
        //    }

        //    List<ModelError> errors = new List<ModelError>();
        //    foreach (ModelState modelState in ViewData.ModelState.Values)
        //    {
        //        foreach (ModelError error in modelState.Errors)
        //        {
        //            errors.Add(error);
        //        }
        //    }
        //    return View(customer);
        //}



    }
}

