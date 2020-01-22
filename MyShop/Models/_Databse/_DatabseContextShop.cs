using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    public class _DatabseContextShop : DbContext
    {
        public _DatabseContextShop() : base("DatabseContextShop")
        {

        }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<OrderTable> Orders { get; set; }
        public DbSet<OrderStatusTable> OrderStatuses { get; set; }
    }
}