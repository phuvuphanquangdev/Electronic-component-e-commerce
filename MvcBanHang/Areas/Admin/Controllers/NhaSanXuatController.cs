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
    public class NhaSanXuatController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        //
        // GET: /Admin/NhaSanXuat/

        public ActionResult Index()
        {
            return View(db.hangsanxuat.ToList());
        }
        //
        // GET: /Admin/NhaSanXuat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/NhaSanXuat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.hangsanxuat.Add(hangsanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangsanxuat);
        }

        //
        // GET: /Admin/NhaSanXuat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            hangsanxuat hangsanxuat = db.hangsanxuat.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        //
        // POST: /Admin/NhaSanXuat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(hangsanxuat hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangsanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangsanxuat);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}