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
            [Required(ErrorMessage ="Không Được Để Rỗng")]
            public string EmployeeCode { get; set; }

            [Display(Name ="Password")]
            [Required(ErrorMessage ="Không được để rỗng")]
            [DataType(DataType.Password)]
            public string EmployeePass { get; set; }

            [Display(Name = "Họ")]
            [Required(ErrorMessage = "Không được để rỗng")]
            public string LastName { get; set; }

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Không được để rỗng")]
            public string FirstName { get; set; }

            [Display(Name = "Giới Tính")]
           
            public Nullable<bool> EmployeeGender { get; set; }

            [Display(Name ="Sinh Nhật")]
            [DataType(DataType.Date,ErrorMessage ="Dữ Liệu Phài là kiểu ngày tháng")]
            [Required(ErrorMessage = "Không Được Để Rỗng")]
            public Nullable<System.DateTime> BirthDate { get; set; }

            [Display(Name ="Hình đại diện")]
            public string EmployeImg { get; set; }

            [Display(Name ="Email")]
            [DataType(DataType.EmailAddress, ErrorMessage = "Sai định dạng Email")]
            [Required(ErrorMessage = "Không Được Để Rỗng")]
            public string EmployeeEmail { get; set; }

            [Required(ErrorMessage = "Không Được Để Rỗng")]
            [DataType(DataType.MultilineText)]
            [Display(Name ="Địa Chỉ")]
            public string EmployeeAddress { get; set; }

            public Nullable<int> RoleId { get; set; }

            public System.DateTime Create_Emp { get; set; }

            public bool Status_Emp { get; set; }
        }
    }
}