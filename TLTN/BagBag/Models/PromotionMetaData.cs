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
            [Display(Name = "Khuyến Mãi")]
            public int PromotionId { get; set; }

            [Display(Name ="Tên Khuyến Mãi")]
            [Required(ErrorMessage = "Vui lòng nhập tên của khuyến mãi")]
            public string PromotionName { get; set; }

            [Display(Name = "Thông Tin")]
            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage = "Vui lòng nhập thông tin của khuyến mãi này")]
            public string PromotionDetails { get; set; }

            [Display(Name = "Giảm Giá")]
            [Required(ErrorMessage = "Vui lòng nhập giảm giá của chương trình khuyến mãi này")]
            public Nullable<int> PromotionDiscount { get; set; }

            [Display(Name ="Trạng Thái")]
            [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
            public Nullable<bool> PromotionStatus { get; set; }

            [Display(Name = "Ngày Bắt Đầu")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Dữ liệu phải là kiểu ngày tháng")]
            [Required(ErrorMessage = "Vui lòng điền ngày bắt đầu")]
            public Nullable<System.DateTime> PromotionOpen { get; set; }

            [Display(Name = "Ngày Kết Thúc")]
          
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Dữ liệu phải là kiểu ngày tháng")]
            [Required(ErrorMessage = "Vui lòng điền ngày kết thúc")]
            public Nullable<System.DateTime> PromotionClose { get; set; }
        }
    }
}