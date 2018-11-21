using BagBag.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class CategoryBagController : Controller
    {
        // GET: CategoryBag
        MyBagBagEntities db = new MyBagBagEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Withdraw(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.CategoryId == 1 && u.ProductStatus == true);
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
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Backpack(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.CategoryId == 2 && u.ProductStatus == true);
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
                lstTouris = lstTouris.Where(s => s.ProductName.Contains(searchString) || s.Category.CategoryName.Contains(searchString));
            }
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Traditional(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.CategoryId == 3 && u.ProductStatus == true);
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
                lstTouris = lstTouris.Where(s => s.ProductName.Contains(searchString) || s.Category.CategoryName.Contains(searchString));
            }
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Workplace(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Category")
                .Where(u => u.CategoryId == 4 && u.ProductStatus == true);
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
                lstTouris = lstTouris.Where(s => s.ProductName.Contains(searchString) || s.Category.CategoryName.Contains(searchString));
            }
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
    }
}