using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    [Table("Products")]
    public class ProductTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? UnitsInStock { get; set; }

        public decimal? UnitsOnOrder { get; set; }

        public bool Discontinued { get; set; }

        public DateTime LastSupply { get; set; }
    }
}