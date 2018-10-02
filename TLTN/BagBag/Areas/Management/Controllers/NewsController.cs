using System;
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
    public class NewsController : Controller
    {
        private MyBagBagEntities db = new MyBagBagEntities();

        // GET: Management/News
        public ActionResult Index()
        {
            var news = db.News.Include(n => n.Employee);
            return View(news.ToList());
        }

        // GET: Management/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Management/News/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass");
            return View();
        }

        // POST: Management/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsId,NewTitles,NewsDetails,NewsBy,NewsDate,EmployeeCode")] News news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", news.EmployeeCode);
            return View(news);
        }

        // GET: Management/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", news.EmployeeCode);
            return View(news);
        }

        // POST: Management/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsId,NewTitles,NewsDetails,NewsBy,NewsDate,EmployeeCode")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", news.EmployeeCode);
            return View(news);
        }

        // GET: Management/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Management/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UploadNews(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // news = db.Products.Include(s => s.ImgProducts).SingleOrDefault(p => p.ProductId == id);
            var news = db.News.Include(p => p.ImgNews).SingleOrDefault(s => s.NewsId == id);
            if (news == null)
            {
                object Err = "Không Tìm Thấy Thông Tin";
                return View("Error", Err);
            }
            return View(news);
        }
        [HttpPost]
        public ActionResult UploadNews(int id, HttpPostedFileBase[] files)
        {
            byte max = 0;
            var listImg = db.ImgNews.Where(p => p.NewsId == id).ToList();
            if (listImg.Count > 0)
                max = listImg.Max(p => p.SortNews);
            var listFile = files.Where(p => p != null);
            foreach (var f in listFile)
            {
                //Tạo một đối tượng
                var img = new ImgNew();
                img.NewsId = id;
                img.News_Img = f.FileName;
                img.SortNews = ++max;
                db.ImgNews.Add(img);
                var path = Server.MapPath("~/myImg/News/" + f.FileName);
                f.SaveAs(path);
            }
            if (listFile.Any())
                db.SaveChanges();
            return RedirectToAction("UploadNews");
        }
        public ActionResult DeleteImg(int id, int? NewsId)
        {
            if (NewsId.HasValue)
            {
                try
                {
                    var img = db.ImgNews.Find(id);
                    if (img == null)
                        return RedirectToAction("Index");
                    db.ImgNews.Remove(img);
                    var fileName = img.News_Img;
                    var path = Server.MapPath("~/myImg/News/" + fileName);
                    var file = new FileInfo(path);

                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    db.SaveChanges();
                    return RedirectToAction("UploadNews");
                }

                catch (Exception ex)
                {
                    object mess = "Không thể xóa IMG " + ex.Message;
                    return View("Error", mess);
                }
            }

            TempData["Success_Mess"] = "<script>alert('Delete Success')</script>";
            return Redirect("~/myImg/News/" + NewsId);
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
