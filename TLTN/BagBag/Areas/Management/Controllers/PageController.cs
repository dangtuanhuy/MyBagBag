using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Areas.Management.Controllers
{
    public class PageController : Controller
    {
        // GET: Management/Page
        public ActionResult Index()
        {
            return View();
        }
    }
}