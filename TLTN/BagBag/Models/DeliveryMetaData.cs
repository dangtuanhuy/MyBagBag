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

            [Required(ErrorMessage ="Không được rỗng")]
            [Display(Name ="Giao Hàng")]
            public string DeliveryTitle { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Phương tiện")]
            public string ImgDelivery { get; set; }

            [Display(Name = "Chi tiết")]
            [Required(ErrorMessage = "Không được rỗng")]
            [DataType(DataType.MultilineText)]
            public string DeliveryDetails { get; set; }

            [Display(Name = "Câu hỏi thường gặp")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string DeliveryQuestion { get; set; }
            public string EmployeeCode { get; set; }
        }
    }
}