using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
   public partial class Delivery
    {
        internal sealed class DeliveryMetaData
        {
            public int DeliveryId { get; set; }
            [Display(Name ="Giao Hàng")]
            public string DeliveryTitle { get; set; }
            [Display(Name = "Phương tiện")]
            public string ImgDelivery { get; set; }
            [Display(Name = "Chi tiết")]
            [DataType(DataType.MultilineText)]
            public string DeliveryDetails { get; set; }
            [Display(Name = "Câu hỏi thường gặp")]
            public string DeliveryQuestion { get; set; }
            public string EmployeeCode { get; set; }
        }
    }
}