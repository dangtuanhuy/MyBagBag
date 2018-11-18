﻿using BagBag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace BagBag.Controllers
{
    public class DelieveryController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();
        // GET: Delievery
        public ActionResult Delevery()
        {
            var deliveries = db.Deliveries.Take(2);
            return View(deliveries.ToList());
        }
    }
}