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

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Branch")]
            public string BranchName { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Information")]
            public string BranchDetails { get; set; }
            [Display(Name = "Manager")]
            public string EmployeeCode { get; set; }
        }
    }

}