using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BagBag.Controllers
{
    public class LoginUserController : Controller
    {
        public static bool CheckRegister(string username, string password)
        {
            var encrpytedPassword = Encrypt.MD5_Encode(password);
            using (MyBagBagEntities db = new MyBagBagEntities())
            {
                var singin = from p in db.Customers
                             where p.CustomerCode == username && p.CustomerPass == encrpytedPassword
                             select p;
                return singin.Any();
            }
        }
        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var result = CheckRegister(model.CustomerCode, model.CustomerPass);
                if (result)
                {
                    Session["username"] = model.CustomerCode;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View("Login");
        }
        public ActionResult LoginCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCart(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                var result = CheckRegister(model.CustomerCode, model.CustomerPass);
                if (result)
                {
                    Session["username"] = model.CustomerCode;
                    return RedirectToAction("ConfirmCheckOut", "Cart");
                }
                else
                {
                    return RedirectToAction("LoginCart");
                }
            }
            return View("LoginCart");
        }
        public ActionResult LogOff()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}