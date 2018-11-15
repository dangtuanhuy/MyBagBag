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
            [Display(Name ="Employee Code")]
            [Required(ErrorMessage ="Can not null")]
            public string EmployeeCode { get; set; }

            [Display(Name ="Password")]
            [Required(ErrorMessage = "Can not nullg")]
            [DataType(DataType.Password)]
            public string EmployeePass { get; set; }

            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "Can not null")]
            public string LastName { get; set; }

            [Display(Name = "Firts Name")]
            [Required(ErrorMessage = "Can not null")]
            public string FirstName { get; set; }

            [Display(Name = "Gender")]
           
            public Nullable<bool> EmployeeGender { get; set; }

            [Display(Name = "Birthday")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.DateTime, ErrorMessage = "Input data must be a date type")]
            public Nullable<System.DateTime> BirthDate { get; set; }

            [Display(Name ="IMG")]
            public string EmployeImg { get; set; }

            [Display(Name ="Email")]
            [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
            [Required(ErrorMessage = "Can not null")]
            public string EmployeeEmail { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            [Display(Name ="Address")]
            public string EmployeeAddress { get; set; }

            public Nullable<int> RoleId { get; set; }

            public System.DateTime Create_Emp { get; set; }

            public bool Status_Emp { get; set; }
        }
    }
}