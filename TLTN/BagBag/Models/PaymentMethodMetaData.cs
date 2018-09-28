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
            [Display(Name ="Hình Thức Thanh Toán")]
            public int PaymentId { get; set; }
            [Display(Name = "Hình Thức Thanh Toán")]
            [Required(ErrorMessage ="Vui lòng điền hình thức thanh toán")]
            public string PaymentName { get; set; }
        }
    }
}