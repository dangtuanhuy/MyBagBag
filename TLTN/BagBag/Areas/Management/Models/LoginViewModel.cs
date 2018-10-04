using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Areas.Management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username không được để rỗng")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage ="Password không được để rỗng")]
        public string EmployeePass { get; set; }
    }
}