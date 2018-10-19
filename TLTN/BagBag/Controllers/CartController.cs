using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Areas.Management.Controllers
{
    public class CartController : Controller
    {
        // GET: Management/Cart
        MyBagBagEntities db = new MyBagBagEntities();
        //Lấy giỏ hàng
        public List<CartItem> LayGioHang()
        {
            // Giỏ hàng đã tồn tại
            List<CartItem> lstGioHang = Session["GioHang"] as List<CartItem>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<CartItem>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng thông thường load lại trang

        public ActionResult ThemGioHang(int ProductId, String strUrl)
        {
            // Kiểm tra sản phẩm có tồn tại trong CSLD hay không?
            Product sp = db.Products.SingleOrDefault(n => n.ProductId == ProductId);
            if (sp == null)
            {
                // Trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
            }
            // Lấy giỏ hàng
            List<CartItem> lstGioHang = LayGioHang();

            //TH1 sản phẩm đã tồn tại trong giỏ hàng
            CartItem spCheck = lstGioHang.SingleOrDefault(n => n.ProductId == ProductId);
            if (spCheck != null)
            {
                if (sp.ProductStatus == false)
                {
                    return View("ThongBao");
                }
                spCheck.ProductQtyUser++;
                spCheck.Total = spCheck.ProductQtyUser * spCheck.ProductSold;
                return Redirect(strUrl);
            }
            if (sp.ProductStatus == false)
            {
                return View("ThongBao");
            }
            CartItem itemGH = new CartItem(ProductId);
            lstGioHang.Add(itemGH);
            return Redirect(strUrl);

        }
        public double TinhTongSoLuong()
        {
            List<CartItem> lstGioHang = Session["GioHang"] as List<CartItem>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ProductQtyUser);
        }
        public decimal TinhTongTien()
        {
            List<CartItem> lstGioHang = Session["GioHang"] as List<CartItem>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.Total);

        }

        // GET: ShoppingCart
        public ActionResult XemGioHang()
        {
            List<CartItem> giohang = Session["GioHang"] as List<CartItem>;
            return View(giohang);
        }
        public ActionResult ShoppingPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();

        }
        public ActionResult SuaSoLuong(int ProductId, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["GioHang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.ProductId == ProductId);
            if (itemSua != null)
            {
                itemSua.ProductQtyUser = soluongmoi;
                itemSua.Total = itemSua.ProductQtyUser * itemSua.ProductSold;
            }
            return RedirectToAction("XemGioHang");
        }
        public RedirectToRouteResult XoaKhoiGio(int ProductId)
        {
            List<CartItem> giohang = Session["GioHang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.ProductId == ProductId);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("XemGioHang");
        }

        public ActionResult ConfirmCheckOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmCheckOut([Bind(Include = "OrderAddress,Phone")] Order order)
        {
            if (ModelState.IsValid)
            {
                var userId = Session["username"];
                order.OrderDate = DateTime.Now;
                order.CustomerCode = Convert.ToString(userId);
                //order.UserId = null;
                order.Order_Status = false;
                db.Orders.Add(order);
                db.SaveChanges();
                // Them chi tiet
                List<CartItem> lstGH = LayGioHang();
                foreach (var item in lstGH)
                {
                    var details = new OrderDetail();
                    details.OrderId = order.OrderId;
                    details.ProductId = item.ProductId;
                    details.Quantity = item.ProductQtyUser;
                    details.SoldPrice = item.ProductSold;
                    db.OrderDetails.Add(details);

                }
                db.SaveChanges();
                foreach (var item in lstGH)
                {
                    var lst = db.Products.SingleOrDefault(u => u.ProductId == item.ProductId);
                    lst.ProductQty = lst.ProductQty - item.ProductQtyUser;
                }
                db.SaveChanges();
                Session["GioHang"] = null;
                return RedirectToAction("Susses", "Cart");
            }
            return View();
        }
        public ActionResult Susses()
        {
            return View();
        }
    }
}