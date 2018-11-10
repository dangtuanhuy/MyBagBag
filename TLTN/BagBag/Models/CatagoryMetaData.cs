using System.ComponentModel.DataAnnotations;
namespace BagBag.Models
{
    [MetadataType(typeof(Category.CatagoryMetaData))]
    public partial class Category
    {
        internal sealed class CatagoryMetaData
        {
            public int CategoryId { get; set; }

            [Display(Name ="Category ")]
            [Required(ErrorMessage = "Can not null")]
            public string CategoryName { get; set; }

            [Display(Name = "Details")]
            [Required(ErrorMessage = "Can not null")]
            [DataType(DataType.MultilineText)]
            public string CategoryDetails { get; set; }
        }
    }
   
}