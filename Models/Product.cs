using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeenaBazar.Models
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Seller Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Brand Name is required.")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}