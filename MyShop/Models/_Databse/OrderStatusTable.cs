using MyShop.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    [Table("OrderStatuses")]
    public class OrderStatusTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public OrderStatus Id { get; set; }

        public string Name { get; set; }
    }
}