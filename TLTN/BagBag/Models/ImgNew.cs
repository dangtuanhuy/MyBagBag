//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BagBag.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImgNew
    {
        public int ImgNewId { get; set; }
        public string News_Img { get; set; }
        public byte SortNews { get; set; }
        public Nullable<int> NewsId { get; set; }
    
        public virtual News News { get; set; }
    }
}
