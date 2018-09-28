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
            [Display(Name ="Tên Sản Phẩm")]
            [Required(ErrorMessage = "Vui lòng điền tên sản phẩm")]
            public string ProductName { get; set; }

            [Display(Name ="Chi Tiết")]
            [Required(ErrorMessage = "Vui lòng điền thông tin chi tiết sản phẩm")]
            [DataType(DataType.MultilineText)]
            public string ProductDetails { get; set; }

            [Display(Name = "Trạng Thái")]
            [Required(ErrorMessage = "Vui lòng chọn trạng thái sản phẩm")]
            public Nullable<bool> ProductStatus { get; set; }

            [Display(Name = "Ngày Nhận Hàng")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Dữ liệu phải là kiểu ngày tháng")]
            [Required(ErrorMessage = "Vui lòng điền ngày nhận hàng")]
            public Nullable<System.DateTime> ProductUpdate { get; set; }

            [Display(Name ="Số lượng")]
            [Required(ErrorMessage ="Vui lòng nhập số lượng")]
            public Nullable<int> ProductQty { get; set; }

            [Display(Name = "Giá Bán")]
            [Required(ErrorMessage = "Vui lòng nhập giá bán")]
            [DataType(DataType.Currency,ErrorMessage ="Nhập vào đơn vị tiền tệ")]
            public Nullable<decimal> ProductSold { get; set; }

        }
    }
}