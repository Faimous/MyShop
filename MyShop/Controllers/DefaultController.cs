using MyShop.Models._Databse;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public abstract class DefaultController : Controller
    {
        protected _DatabseContextShop Database = new _DatabseContextShop();

        public DefaultController()
        {
            ViewBag.CartTotalPrice = CartTotalPrice;
            ViewBag.Cart = Cart;
            ViewBag.CartUnits = Cart.Count;
            Database = new _DatabseContextShop();
        }


        protected override void Dispose(bool disposing)
        {
            Database.Dispose();
            base.Dispose(disposing);
        }



        private List<ShoppingCartTable> Cart
        {
            get
            {
                return Database.ShoppingCartDatas.ToList();
            }
        }

        private decimal? CartTotalPrice
        {
            get
            {
                return Cart.Sum(c => c.Quantity * c.UnitPrice);
            }
        }
    }
}