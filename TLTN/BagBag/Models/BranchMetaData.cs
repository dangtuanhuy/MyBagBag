using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    public partial class Branch
    {
        internal sealed class BranchMetaData
        {
            public int BranchId { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Tên Chi Nhánh")]
            public string BranchName { get; set; }

            [Required(ErrorMessage = "Không được rỗng")]
            [Display(Name = "Thông Tin Chi Nhánh")]
            public string BranchDetails { get; set; }
            [Display(Name = "Quản Lý")]
            public string EmployeeCode { get; set; }
        }
    }

}