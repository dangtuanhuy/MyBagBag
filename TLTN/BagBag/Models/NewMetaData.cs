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


            [Required(ErrorMessage = "Can not null")]
            [Display(Name ="Title")]
            public string NewTitles { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Context")]
            [DataType(DataType.MultilineText)]
            public string NewsDetails { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Create by")]
            public string NewsBy { get; set; }


            [Display(Name ="Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Date is not valid")]
            [Required(ErrorMessage = "Can not null")]
            public Nullable<System.DateTime> NewsDate { get; set; }


            [Display(Name = "Người đăng")]
            public string EmployeeCode { get; set; }
        }
    }
}