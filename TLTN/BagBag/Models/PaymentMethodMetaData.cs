using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    public partial class PaymentMethod
    {
        internal sealed class PaymentMethodMetaData
        {
            [Display(Name ="Payment Method")]
            public int PaymentId { get; set; }

            [Display(Name = "Payment method")]
            [Required(ErrorMessage = "Can not null")]
            public string PaymentName { get; set; }
        }
    }
}