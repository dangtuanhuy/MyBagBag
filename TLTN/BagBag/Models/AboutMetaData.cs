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


            [Display(Name = "About")]
            [Required(ErrorMessage ="Can not null")]
            public string AboutUs { get; set; }

            [Display(Name = "Img")]
            public string AboutImg { get; set; }


            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Details")]
            public string AboutDetails { get; set; }
            public string EmployeeCode { get; set; }

        }
    }
   
}