using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Models.Products
{
    public class ProductData
    {

        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public decimal?  UnitPrice { get; set; }
        public decimal? UnitsInStock { get; set; }
        public decimal? UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
        public DateTime LastSupply { get; set; }
    }
}