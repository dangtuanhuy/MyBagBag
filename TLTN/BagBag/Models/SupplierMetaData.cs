using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Supplier.SupplierMetaData))]
    public partial class Supplier
    {
        
        internal sealed class SupplierMetaData
        {
            public int SupplierId { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name ="Company")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Representative")]
            public string ContactName { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Content")]
            [DataType(DataType.MultilineText)]
            public string ContactTitle { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Address")]
            [DataType(DataType.MultilineText)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Phone")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Can not null")]
            [Display(Name = "Fax")]
            public string Fax { get; set; }

            [Display(Name = "Link")]
            public string HomePage { get; set; }
        }
    }
  
}