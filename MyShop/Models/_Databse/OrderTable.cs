using MyShop.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyShop.Models._Databse
{
    [Table("Orders")]
    public class OrderTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("OrderStatus")]
        public virtual OrderStatusTable Order { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumer { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Email { get; set; }

        public string State { get; set; }

        public string PostCode { get; set; }

        public DateTime? OrderDateTime { get; set; }





    }
}