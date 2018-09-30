using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BagBag.Models
{
    [MetadataType(typeof(About.AboutMetaData))]
    public partial class About
    {
        internal sealed class AboutMetaData
        {
            public int AboutId { get; set; }


            [Display(Name = "Về Chúng Tôi")]
            [Required(ErrorMessage ="Vui lòng điền vào đây")]
            public string AboutUs { get; set; }

            [Display(Name = "Hình Mô Tả")]
            public string AboutImg { get; set; }


            [Required(ErrorMessage = "Vui lòng điền vào đây")]
            [Display(Name = "Chi Tiết")]
            public string AboutDetails { get; set; }
            public string EmployeeCode { get; set; }

        }
    }
   
}