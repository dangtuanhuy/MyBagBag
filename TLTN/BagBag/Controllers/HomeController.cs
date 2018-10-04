using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class HomeController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();
        public ActionResult Index()
        {

            var listProducts1 = (from p in db.Products where p.Category.CategoryName == "Balo Quân Sự" orderby p.ProductUpdate select p).Take(3);
            ViewBag.ListProduct1 = listProducts1;

            //Danh Sách Balo Laptop
            var listProducts2 = (from p in db.Products where p.Category.CategoryName == "Ba Lô LapTop" orderby p.ProductName select p).Take(3);
            ViewBag.ListProduct2 = listProducts2;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}