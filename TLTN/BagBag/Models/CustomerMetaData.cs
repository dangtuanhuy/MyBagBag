using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Customer.CustomerMetaData))]
    public partial class Customer
    {
        internal sealed class CustomerMetaData
        {
            [Display(Name = "Username")]
            [Required(ErrorMessage = "Can not null")]
            public string CustomerCode { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.Password)]
            public string CustomerPass { get; set; }

            [Display(Name = "FullName")]
            [Required(ErrorMessage = "Can not null")]
            public string CustomerFullName { get; set; }

            [Display(Name = "Gender")]
            
            public Nullable<int> CustomerGender { get; set; }

            public string ContactCompany { get; set; }

            [Display(Name = "Address")]
            [DataType(DataType.MultilineText)]
            public string CustomerAddress { get; set; }

            [Display(Name = "Region")]
            [Required(ErrorMessage = "Can not null")]
            public string CustomerRegion { get; set; }

            [Display(Name = "ZIP code")]
            [Required(ErrorMessage = "Can not null")]
            public string CustomerPostalCode { get; set; }

            [Display(Name = "Phone")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
            public string CustomerPhone { get; set; }

            [Display(Name = "Fax")]
            [Required(ErrorMessage = "Can not null")]
            public string CustomerFax { get; set; }
        }
    }
}