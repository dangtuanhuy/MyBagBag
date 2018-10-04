using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Areas.Management.Controllers
{
    public class PageController : BaseController
    {
        private MyBagBagEntities db = new MyBagBagEntities();
        // GET: Management/Page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _statusPromotion()
        {
            var statusPromotion = (from p in db.Promotions where p.PromotionStatus == true select p).Count();
            ViewBag.statusPromotion = statusPromotion;
            return PartialView();
        }
        public ActionResult _countProducts()
        {
            var countProducts = db.Products.Count();
            ViewBag.countProducts = countProducts;
            return PartialView();
        }
        public ActionResult _countContacts()
        {
            var statusContacts = (from p in db.Contacts where p.Status == false select p).Count();

            ViewBag.statusContacts = statusContacts;
            return PartialView();
        }
        public ActionResult _countCart()
        {
            var countCarts = (from p in db.Orders select p).Count();

            ViewBag.countCarts = countCarts;
            return PartialView();
        }
        public ActionResult _FooterPage()
        {
            return PartialView("_FooterPage");
        }
    }
}