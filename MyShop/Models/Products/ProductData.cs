using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyShop.Models.Products
{
    public class ProductData
    {
        [DisplayName("Id")]
        public int ProductID { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Desription of a product")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Price per unit")]
        [Required]
        public decimal?  UnitPrice { get; set; }

        [DisplayName("Units currently in stock")]
        [Required]
        public decimal? UnitsInStock { get; set; }

        [DisplayName("units on order")]
        public decimal? UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; }

        [DisplayName("Date of last Supply")]
        public DateTime LastSupply { get; set; }
    }
}