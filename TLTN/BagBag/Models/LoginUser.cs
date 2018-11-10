using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BagBag.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username can not null")]
        public string CustomerCode { get; set; }
        [Required(ErrorMessage = "Password can not null")]
        public string CustomerPass { get; set; }
    }
}