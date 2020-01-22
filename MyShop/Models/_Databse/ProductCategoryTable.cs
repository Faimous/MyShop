using MyShop.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    [Table("ProductCategories")]

    public class ProductCategoryTable
    {

        public ProductCategory Id { get; set; }

        public string ProductCategoryName { get; set; }
    }
}