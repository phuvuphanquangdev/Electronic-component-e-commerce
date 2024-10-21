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
    public class DanhMucController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        //
        // GET: /Admin/DanhMuc/

        public ActionResult Index()
        {
            return View(db.loai.ToList());
        }

        
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/DanhMuc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(loai loai)
        {
            if (ModelState.IsValid)
            {
                db.loai.Add(loai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai);
        }

        public ActionResult Edit(int id = 0)
        {
            loai loai = db.loai.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        //
        // POST: /Admin/DanhMuc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai);
        }

       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}