using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BagBag.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username không được rỗng")]
        public string CustomerCode { get; set; }
        [Required(ErrorMessage = "Password không được để rỗng")]
        public string CustomerPass { get; set; }
    }
}