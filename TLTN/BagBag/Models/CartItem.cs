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
        public int PromotionId { get; set; }
        public CartItem(int ProductId)
        {
            using (MyBagBagEntities db = new MyBagBagEntities())
            {
                Product pro = db.Products.Include("ImgProducts").Single(x => x.ProductId == ProductId);
                this.ProductId = ProductId;
                this.ProductQtyUser = 1;
                this.ProductName = pro.ProductName;
                this.ImgPro = pro.ImgProducts.ToList();
                this.ProductQty = pro.ProductQty.Value;
                if (pro.PromotionId == null)
                {
                    this.ProductSold = pro.ProductSold.Value;
                }
                else
                {
                    Promotion promotion = db.Promotions.SingleOrDefault(x => x.PromotionId == pro.PromotionId);
                    if (promotion.PromotionDiscount == 0 || promotion.PromotionDiscount == null)
                    {
                        this.ProductSold = pro.ProductSold.Value;
                    }
                    else
                    {
                        this.ProductSold = pro.ProductSold.Value - ((pro.ProductSold.Value * pro.Promotion.PromotionDiscount.Value) / 100);
                    }
                }
                this.Total = pro.ProductSold.Value * this.ProductQtyUser;



            }
        }
    }
}