using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Customer.CustomerMetaData))]
    public partial class Customer
    {
        internal sealed class CustomerMetaData
        {
            [Display(Name = "Username")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerCode { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = "Không được rỗng")]
            [DataType(DataType.Password)]
            public string CustomerPass { get; set; }

            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerFullName { get; set; }

            [Display(Name = "Giới tính")]
            
            public Nullable<int> CustomerGender { get; set; }

            public string ContactCompany { get; set; }

            [Display(Name = "Địa chỉ")]
            [DataType(DataType.MultilineText)]
            public string CustomerAddress { get; set; }

            [Display(Name = "Vùng")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerRegion { get; set; }

            [Display(Name = "Mã bưu điện")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerPostalCode { get; set; }

            [Display(Name = "Điện Thoại")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerPhone { get; set; }

            [Display(Name = "Fax")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string CustomerFax { get; set; }
        }
    }
}