using BagBag.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class TypeBagController : Controller
    {
        // GET: TypeBag
        MyBagBagEntities db = new MyBagBagEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Men(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.Style == true && u.ProductStatus == true && (u.Category.CategoryId == 1
                                             || u.Category.CategoryId == 2
                                             || u.Category.CategoryId == 3
                                             || u.Category.CategoryId == 4
                                             || u.Category.CategoryId == 5
                                             || u.Category.CategoryId == 6
                                             || u.Category.CategoryId == 7
                                             || u.Category.CategoryId == 8
                                             || u.Category.CategoryId == 9
                                             || u.Category.CategoryId == 10));
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstTouris = lstTouris.Where(s => s.ProductName.Contains(searchString)
                                       || s.Category.CategoryName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Women(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.Style == false && u.ProductStatus == true && (u.Category.CategoryId == 1
                                             || u.Category.CategoryId == 2
                                             || u.Category.CategoryId == 3
                                             || u.Category.CategoryId == 4
                                             || u.Category.CategoryId == 5
                                             || u.Category.CategoryId == 6
                                             || u.Category.CategoryId == 7
                                             || u.Category.CategoryId == 8
                                             || u.Category.CategoryId == 9
                                             || u.Category.CategoryId == 10));
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstTouris = lstTouris.Where(s => s.ProductName.Contains(searchString)
                                       || s.Category.CategoryName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
    }
}