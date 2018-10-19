using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BagBag.Areas.Management.Models;
using BagBag.Models;
using CaptchaMvc.HtmlHelpers;

namespace BagBag.Areas.Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Management/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid && this.IsCaptchaValid("Capcha is not valid"))
            {
                var result = CheckRegister(model.EmployeeCode, model.EmployeePass);
                if (result)
                {
                    Session["employee"] = model.EmployeeCode;
                    return RedirectToAction("Index", "Page");

                }
                else
                {
                    ModelState.AddModelError("", "Please check username  or Password!");
                }
            }
            return View("Login");
        }
        public static bool CheckRegister(string employeecode, string employeepassword)
        {
            //var pass = Encrypt.MD5_Encode(password);


            var encrpytedPassword = Encrypt.MD5_Encode(employeepassword);
            using (MyBagBagEntities db = new MyBagBagEntities())
            {
                var singin = from p in db.Employees
                             where p.EmployeeCode == employeecode && p.EmployeePass == encrpytedPassword
                             select p;
                return singin.Any();
            }

        }
        public ActionResult LogOff()
        {
            Session["employee"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}