using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class RegistersController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();
        // GET: Registers
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CustomerCode,CustomerPass,CustomerFullName,CustomerGender,CustomerAddress,CustomerRegion,CustomerPostalCode,CustomerPhone,CustomerFax,RoleId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.CustomerGender = 1;
                    customer.RoleId = 3;
                    customer.CustomerPass = Encrypt.MD5_Encode(customer.CustomerPass);
                    db.Customers.Add(customer);
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
                return RedirectToAction("Success", "Registers");
            }

  
            return View(customer);
        }

        public ActionResult UpdateAcount(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", customer.RoleId);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAcount([Bind(Include = "CustomerCode,CustomerPass,CustomerFullName,CustomerGender,CustomerAddress,CustomerRegion,CustomerPostalCode,CustomerPhone,CustomerFax,RoleId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(customer).State = EntityState.Modified;
                    customer.CustomerGender = 1;
                    customer.RoleId = 3;
                    customer.CustomerPass = Encrypt.MD5_Encode(customer.CustomerPass);
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
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", customer.RoleId);
            return View(customer);
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}