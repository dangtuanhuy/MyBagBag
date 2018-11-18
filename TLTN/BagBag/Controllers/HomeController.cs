using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            var listProducts1 = (from p in db.Products where p.Category.CategoryName == "Military backpack" orderby p.ProductUpdate select p).Take(3);
            ViewBag.ListProduct1 = listProducts1;

            //Danh Sách Balo Laptop
            var listProducts2 = (from p in db.Products where p.Category.CategoryName == "Backpack LapTop" orderby p.ProductName select p).Take(3);
            ViewBag.ListProduct2 = listProducts2;

            //Danh sách Balo Tiện Ích
            var listProducts3 = (from p in db.Products where p.CategoryId == 9 orderby p.ProductUpdate select p).Take(3);
            ViewBag.ListProduct3 = listProducts3;

            //Danh sách túi đeo chéo
            var listProducts4 = (from p in db.Products where p.Category.CategoryName == "Bag Withdrawn" orderby p.ProductQty select p).Take(3);
            ViewBag.ListProduct4 = listProducts4;

            //Danh sách balo du lịch

            var listProducts5 = (from p in db.Products where p.CategoryId == 8 orderby p.ProductName select p).Take(3);
            ViewBag.ListProduct5 = listProducts5;

            return View();
        }

       

        public ActionResult Contact()
        {
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "ContactId,CompanyName,ContactName,Address,Region,PostalCode,Phone,ContactsTitle,Fax,Status,Create_Contact")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.Create_Contact = DateTime.Now;
                    contact.Status = false;

                    db.Contacts.Add(contact);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        
    }
}