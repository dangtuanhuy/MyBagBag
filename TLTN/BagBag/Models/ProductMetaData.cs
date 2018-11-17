using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Product.ProductMetaData))]
   public partial class Product
    {
        internal sealed class ProductMetaData
        {
            public int ProductId { get; set; }
            [Display(Name ="Product's Name")]
            [Required(ErrorMessage = "Can not null")]
            public string ProductName { get; set; }

            [Display(Name ="Details")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            public string ProductDetails { get; set; }

            [Display(Name = "Status")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<bool> ProductStatus { get; set; }

            [Display(Name = "Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Input data must be a date type")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<System.DateTime> ProductUpdate { get; set; }

            [Display(Name ="Qty")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<int> ProductQty { get; set; }

            [Display(Name = "Product Sold")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.Currency,ErrorMessage = "Input Data is not valid")]
            public Nullable<decimal> ProductSold { get; set; }

        }
    }
}