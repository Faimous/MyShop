using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    [Table("Orders_Products")]
    public class Orders_Products_Table
    {
        [Key]
        public int Id { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual OrderTable Order { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductTable Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalSale { get; set; }
    }
}