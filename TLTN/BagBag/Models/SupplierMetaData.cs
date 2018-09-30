using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Supplier.SupplierMetaData))]
    public partial class Supplier
    {
        
        internal sealed class SupplierMetaData
        {
            public int SupplierId { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name ="Công Ty Cung Cấp")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Người đại diện")]
            public string ContactName { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Vấn đề chính")]
            [DataType(DataType.MultilineText)]
            public string ContactTitle { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Địa chỉ")]
            [DataType(DataType.MultilineText)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Số điện thoại")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Fax")]
            public string Fax { get; set; }

            [Display(Name = "Link")]
            public string HomePage { get; set; }
        }
    }
  
}