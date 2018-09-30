using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Employee.EmployeeMetaData))]
    public partial class Employee
    {
        internal sealed class EmployeeMetaData
        {
            [Display(Name ="Mã Nhân Viên")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string EmployeeCode { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = "Không được rỗng")]
            public string EmployeePass { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Tên")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Họ")]
            public string FirstName { get; set; }


            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Dữ liệu phải là kiểu ngày tháng")]
            [Required(ErrorMessage = "Vui lòng điền ngày sinh")]
            public Nullable<System.DateTime> BirthDate { get; set; }

            [Display(Name = "Hình đại diện")]
            public string EmployeImg { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress,ErrorMessage ="Email phải đúng định dạng")]
            public string EmployeeEmail { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Địa chỉ")]
            [DataType(DataType.MultilineText)]
            public string EmployeeAddress { get; set; }


            public Nullable<int> RoleId { get; set; }
        }
    }
}