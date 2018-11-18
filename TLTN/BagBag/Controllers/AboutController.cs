using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        private MyBagBagEntities db = new MyBagBagEntities();
        public ActionResult About()
        {
            var abouts = db.Abouts;
            return View(abouts.ToList());
        }
    }
}