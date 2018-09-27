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
            [Display(Name ="Công Ty Cung Cấp")]
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string HomePage { get; set; }
        }
    }
  
}