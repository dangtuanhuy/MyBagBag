﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BagBag.Models;

namespace BagBag.Areas.Management.Controllers
{
    public class DeliveriesController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();

        // GET: Management/Deliveries
        public ActionResult Index()
        {
            var deliveries = db.Deliveries.Include(d => d.Employee);
            return View(deliveries.ToList());
        }

        // GET: Management/Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Management/Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass");
            return View();
        }

        // POST: Management/Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryId,DeliveryTitle,ImgDelivery,DeliveryDetails,DeliveryQuestion,EmployeeCode")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeeCode", delivery.EmployeeCode);
            return View(delivery);
        }

        // GET: Management/Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeeCode", delivery.EmployeeCode);
            return View(delivery);
        }

        // POST: Management/Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryId,DeliveryTitle,ImgDelivery,DeliveryDetails,DeliveryQuestion,EmployeeCode")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", delivery.EmployeeCode);
            return View(delivery);
        }

        // GET: Management/Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Management/Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            db.Deliveries.Remove(delivery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UploadDelivery(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadDelivery(HttpPostedFileBase file, int id)
        {
            var defaultFolderToSaveFile = "~/myImg/Delivery/" + id + "/";

            // Kiểm tra nếu chưa tồn tại thư mục trên thì tạo mới. 
            if (Directory.Exists(Server.MapPath(defaultFolderToSaveFile)) == false)
            {
                Directory.CreateDirectory(Server.MapPath(defaultFolderToSaveFile));
            }

            if (ModelState.IsValid)
            {
                // Kiểm tra nếu người dùng có chọn file
                if (file != null && file.ContentLength > 0)
                {
                    // Lấy tên file
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName != null)
                    {
                        var path = Path.Combine(Server.MapPath(defaultFolderToSaveFile), fileName);

                        var i = 1;
                        while (System.IO.File.Exists(path))
                        {
                            path = Path.Combine(Server.MapPath(defaultFolderToSaveFile), i + "_" + fileName);
                            i++;
                        }

                        // Upload file lên Server ở thư mục ~/myImg/
                        file.SaveAs(path);

                        // Lấy imageurl để lưu vào database, có định dạng "~/myImg/Vehicle/Id/ten_file.jpg"
                        var imageUrl = defaultFolderToSaveFile + fileName;

                        // Lưu thông tin image url vào product
                        var Delivery = db.Deliveries.Find(id);
                        Delivery.ImgDelivery = imageUrl;
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
