using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Promotion.PromotionMetaData))]
    public partial class Promotion
    {
        internal sealed class PromotionMetaData
        {
            [Display(Name = "Promotion")]
            public int PromotionId { get; set; }

            [Display(Name ="Promotion")]
            [Required(ErrorMessage = "Can not null")]
            public string PromotionName { get; set; }

            [Display(Name = "Description")]
            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage = "Can not null")]
            public string PromotionDetails { get; set; }

            [Display(Name = "Discount")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<int> PromotionDiscount { get; set; }

            [Display(Name ="Status")]
           
            public Nullable<bool> PromotionStatus { get; set; }

            [Display(Name = "Start")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date, ErrorMessage = "Input Data is not valid")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<System.DateTime> PromotionOpen { get; set; }

            [Display(Name = "End")]
          
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date, ErrorMessage = "Input Data is not valid")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<System.DateTime> PromotionClose { get; set; }
        }
    }
}