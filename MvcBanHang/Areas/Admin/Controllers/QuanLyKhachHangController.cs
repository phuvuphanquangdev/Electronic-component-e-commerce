using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBanHang.Models;

namespace MvcBanHang.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        //
        // GET: /Admin/QuanLyKhachHang/

        public ActionResult Index()
        {
            return View(db.khachhang.ToList());
        }

        //
        // GET: /Admin/QuanLyKhachHang/Details/5

        public ActionResult Details(int id = 0)
        {
            khachhang khachhang = db.khachhang.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        //
        // GET: /Admin/QuanLyKhachHang/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/QuanLyKhachHang/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.khachhang.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }

        //
        // GET: /Admin/QuanLyKhachHang/Edit/5

        public ActionResult Edit(int id = 0)
        {
            khachhang khachhang = db.khachhang.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        //
        // POST: /Admin/QuanLyKhachHang/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        //
        // GET: /Admin/QuanLyKhachHang/Delete/5

        public ActionResult Delete(int id = 0)
        {
            khachhang khachhang = db.khachhang.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        //
        // POST: /Admin/QuanLyKhachHang/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            khachhang khachhang = db.khachhang.Find(id);
            db.khachhang.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}