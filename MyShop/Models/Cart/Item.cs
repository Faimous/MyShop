using MyShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Models.Cart
{
    public class Item
    {
        public ProductData Product { get; set; }    
        public int Quantity { get; set; }
    }
}