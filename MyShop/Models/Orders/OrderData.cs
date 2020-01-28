using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Models.Orders
{
    public class OrderData
    {
        public int? OrderID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Telephone number must have 8-13 digits")]
        public string TelephoneNumer { get; set; }

        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postcode is required")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Invalid postcode")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public OrderStatus? OrderStatus { get; set; }
    }
}