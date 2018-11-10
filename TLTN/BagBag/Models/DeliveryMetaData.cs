using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Delivery.DeliveryMetaData))]
   public partial class Delivery
    {
        internal sealed class DeliveryMetaData
        {
            public int DeliveryId { get; set; }

            [Required(ErrorMessage ="Can not null")]
            [Display(Name ="Delivery")]
            public string DeliveryTitle { get; set; }

            [Display(Name = "Vehicle")]
            public string ImgDelivery { get; set; }

            [Display(Name = "Details")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            public string DeliveryDetails { get; set; }

            [Display(Name = "Question")]
            [Required(ErrorMessage = "Can not null")]
            public string DeliveryQuestion { get; set; }
            public string EmployeeCode { get; set; }
        }
    }
}