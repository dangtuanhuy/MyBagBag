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
            [Required(ErrorMessage = "Không được rỗng")]
            public string CategoryName { get; set; }

            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "Không được rỗng")]
            [DataType(DataType.MultilineText)]
            public string CategoryDetails { get; set; }
        }
    }
   
}