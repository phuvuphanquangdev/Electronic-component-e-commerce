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
    public class DonHangController : Controller
    {
        private BanHangEntities db = new BanHangEntities();

        //
        // GET: /Admin/DonHang/

        public ActionResult Index()
        {
            return View(db.donhang.ToList());
        }

        //
        // GET: /Admin/DonHang/Details/5

        public ActionResult Details(int id = 0)
        {
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        public ActionResult Edit(int id = 0)
        {
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        //
        // POST: /Admin/DonHang/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donhang);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}