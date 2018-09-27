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
            [DataType(DataType.MultilineText)]
            public string CategoryDetails { get; set; }
        }
    }
   
}