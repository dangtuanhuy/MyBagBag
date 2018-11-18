using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Contact.ContactMetaData))]
    public partial class Contact
    {
        internal sealed class ContactMetaData
        {
            public int ContactId { get; set; }

            [Display(Name = "Company")]
            [Required(ErrorMessage = "Can not null")]

         
            public string CompanyName { get; set; }

            [Display(Name = "Name")]
            [Required(ErrorMessage = "Can not null")]
            public string ContactName { get; set; }

            [Display(Name = "Address")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            public string Address { get; set; }

            [Display(Name = "Region")]
            [Required(ErrorMessage = "Can not null")]
            public string Region { get; set; }

            [Display(Name = "Postal Code")]
            [Required(ErrorMessage = "Can not null")]
            public string PostalCode { get; set; }

            [Display(Name = "Phone")]
            [Required(ErrorMessage = "Can not null")]
            public string Phone { get; set; }

            [Display(Name = "Title")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            public string ContactsTitle { get; set; }

            [Display(Name = "Fax")]
            [Required(ErrorMessage = "Can not null")]
            public string Fax { get; set; }
            public bool Status { get; set; }
            public System.DateTime Create_Contact { get; set; }
        }
    }
}