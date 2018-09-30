using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    public  partial class News
    {
        internal sealed class NewMetaData
        {
            public int NewsId { get; set; }


            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name ="Tên Tin Tức")]
            public string NewTitles { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Nội dung")]
            [DataType(DataType.MultilineText)]
            public string NewsDetails { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Tạo bởi")]
            public string NewsBy { get; set; }


            [Display(Name ="Ngày đăng")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Dữ liệu phải là kiểu ngày tháng")]
            [Required(ErrorMessage = "Vui lòng điền ngày đăng tin")]
            public Nullable<System.DateTime> NewsDate { get; set; }


            [Display(Name = "Người đăng")]
            public string EmployeeCode { get; set; }
        }
    }
}