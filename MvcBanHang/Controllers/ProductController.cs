using MvcBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBanHang.Controllers
{
    public class ProductController : Controller
    {
        BanHangEntities db = new BanHangEntities();

        #region Hiển thị SP
        public ActionResult Index()
        {
            ViewBag.BestSellsers = db.sanpham.OrderByDescending(x => x.solanxem).Take(8);
            var sanpham = db.sanpham.OrderByDescending(x => x.ngaycapnhat).Take(12);
            return View(sanpham);
        }
        public ActionResult ProductId(int id)
        {
            return View(db.sanpham.Where(m => m.maloai == id));
        }
        public ActionResult Details(int id)
        {
            var currentProduct = db.sanpham.Find(id);
            ViewBag.SPcungLoai = db.sanpham.Where(x => x.maloai == currentProduct.maloai);

            // Cap nhat so lan xem
            currentProduct.solanxem = currentProduct.solanxem + 1;
            db.Entry(currentProduct).State = EntityState.Modified;
            db.SaveChanges();

            return View(db.sanpham.Find(id));
        }        
        #endregion

        #region Thêm SP
        public ActionResult Create()
        {
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai");
            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn");
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl");
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx");            
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc");
            return View();
        }

        [HttpPost]
        public ActionResult Create(sanpham sanpham, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {                
                sanpham.hinhsp = Path.GetFileName(file.FileName);
                sanpham.ngaycapnhat = DateTime.Now;
                sanpham.donvitinh = "Cái";                
                sanpham.solanxem = 0;
                db.sanpham.Add(sanpham);
                db.SaveChanges();
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Sanpham"), fileName);
                    file.SaveAs(path);
                }
                return RedirectToAction("Index");
            }

            ViewBag.macn = new SelectList(db.congnghe, "macn", "loaicn", sanpham.macn);
            ViewBag.madl = new SelectList(db.dungluong, "madl", "loaidl", sanpham.madl);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", sanpham.mahsx);
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", sanpham.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", sanpham.mancc);
            return View(sanpham);
        }
        #endregion

        #region Sửa SP
        public ActionResult Edit(int id)
        {
            var product = db.sanpham.Find(id);
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", product.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", product.mancc);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", product.mahsx);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(sanpham model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                model.hinhsp = Path.GetFileName(file.FileName);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Sanpham"), fileName);
                    file.SaveAs(path);
                }

                return RedirectToAction("Details", new { id = model.masp });
            }
            ViewBag.maloai = new SelectList(db.loai, "maloai", "tenloai", model.maloai);
            ViewBag.mancc = new SelectList(db.nhacungcap, "mancc", "tenncc", model.mancc);
            ViewBag.mahsx = new SelectList(db.hangsanxuat, "mahsx", "tenhsx", model.mahsx);
            return View(model);
        }
        #endregion

        #region Xóa SP
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var product = db.sanpham.Find(id);
            db.sanpham.Remove(product);
            db.SaveChanges();
            return Json(new { Status = 1 }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
    }
}
