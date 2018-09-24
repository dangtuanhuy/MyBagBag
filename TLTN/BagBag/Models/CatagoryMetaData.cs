using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Category.CatagoryMetaData))]
    public partial class Category
    {
        internal sealed class CatagoryMetaData
        {
            public int CategoryId { get; set; }
            [Display(Name ="Danh Mục Sản Phẩm")]
            public string CategoryName { get; set; }
            [Display(Name = "Mô tả")]
            public string CategoryDetails { get; set; }
        }
    }
   
}