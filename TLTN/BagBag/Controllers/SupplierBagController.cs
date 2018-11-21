using BagBag.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class SupplierBagController : Controller
    {
        // GET: SupplierBag
        MyBagBagEntities db = new MyBagBagEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Aru(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Supplier")
                .Where(u => u.SupplierId == 1 && u.ProductStatus == true);
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
                                       || s.Supplier.CompanyName.Contains(searchString) || s.Supplier.ContactName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult BenTre(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Supplier")
                .Where(u => u.SupplierId == 6 && u.ProductStatus == true);
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
                                       || s.Supplier.CompanyName.Contains(searchString) || s.Supplier.ContactName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Luna(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Supplier")
                .Where(u => u.SupplierId == 4 && u.ProductStatus == true);
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
                                       || s.Supplier.CompanyName.Contains(searchString) || s.Supplier.ContactName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Hara(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Supplier")
                .Where(u => u.SupplierId == 2 && u.ProductStatus == true);
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
                                       || s.Supplier.CompanyName.Contains(searchString) || s.Supplier.ContactName.Contains(searchString));
            }
            int PageSize = 8;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Coco(string sortOrder, string searchString, int? page, string currentFilter)
        {
            var lstTouris = db.Products
                .Include("Supplier")
                .Where(u => u.SupplierId == 3 && u.ProductStatus == true);
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
                                       || s.Supplier.CompanyName.Contains(searchString) || s.Supplier.ContactName.Contains(searchString));
            }
            int PageSize = 4;
            int PageNumber = (page ?? 1);
            return View(lstTouris.OrderBy(n => n.Create_Product).ToPagedList(PageNumber, PageSize));
        }
    }
}