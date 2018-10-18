using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class ProductController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();
        // GET: Product
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include("ImgProducts").SingleOrDefault(item => item.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}