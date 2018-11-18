using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagBag.Models
{
    public class CartItem
    {
        public Product product { set; get; }
        public ImgProduct ImgProduct { set; get; }
        public int ProductQtyUser { set; get; }
        public int ProductId { set; get; }
        public decimal ProductSold { get; set; }
        public List<ImgProduct> ImgPro { get; set; }
        public String ProductName { get; set; }
        public Decimal Total { get; set; }
        public Nullable<int> PaymentMethod { get; set; }
        public int ProductQty { get; set; }
        public CartItem(int ProductId)
        {
            using (MyBagBagEntities db = new MyBagBagEntities())
            {
                Product pro = db.Products.Include("ImgProducts").Single(x => x.ProductId == ProductId);
                this.ProductId = ProductId;
                this.ProductQtyUser = 1;
                this.ProductName = pro.ProductName;
                this.ProductSold = pro.ProductSold.Value;
                this.Total = pro.ProductSold.Value * this.ProductQtyUser;
                this.ImgPro = pro.ImgProducts.ToList();
                this.ProductQty = pro.ProductQty.Value;
            }
        }
    }
}