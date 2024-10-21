using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBanHang.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcBanHang.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        //
        // GET: /Admin/Product/

        public ActionResult Index(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var sanpham = db.sanpham.Include(s => s.congnghe).Include(s => s.dungluong).Include(s => s.hangsanxuat).Include(s => s.loai).Include(s => s.nhacungcap);
            return View(sanpham.ToList().OrderBy(n => n.ngaycapnhat).ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id = 0)
        {
            sanpham sanpham = db.sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn");
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl");
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx");
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai");
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc");
            return View();
        }

        //
        // POST: /Admin/Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.sanpham.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn", sanpham.macn);
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl", sanpham.madl);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", sanpham.mahsx);
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", sanpham.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", sanpham.mancc);
            return View(sanpham);
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            sanpham sanpham = db.sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn", sanpham.macn);
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl", sanpham.madl);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", sanpham.mahsx);
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", sanpham.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", sanpham.mancc);
            return View(sanpham);
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn", sanpham.macn);
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl", sanpham.madl);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", sanpham.mahsx);
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", sanpham.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", sanpham.mancc);
            return View(sanpham);
        }

        //
        // GET: /Admin/Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            sanpham sanpham = db.sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /Admin/Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanpham sanpham = db.sanpham.Find(id);
            db.sanpham.Remove(sanpham);
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