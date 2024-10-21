using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBanHang.ViewModel;
using MvcBanHang.Models;
using System.Web.Security;

namespace MvcBanHang.Controllers
{
    public class CustomerController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lienhe()
        {
            return View();
        }

        public ActionResult Gioithieu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogOnModel model)
        {
            BanHangEntities db = new BanHangEntities();
            if (ModelState.IsValid)
            {
                var kh = BanHangLogic.CheckKhachHang(model.tenDN, model.matkhau);
                if (kh != null)
                {
                    Session["KhachHang"] = kh;
                    return RedirectToAction("ShowCart", "Shopping");
                }
                return View("Index", model);
            }
            return View("Index", model);
        }

        public ActionResult Register()
        {            
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Product");
        }

        #region Tạo Tài Khoản
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            BanHangEntities db = new BanHangEntities();
            var _OldUserName = (from kh in db.khachhang where kh.tenDN.Contains(model.tenDN) select kh).FirstOrDefault();
            if (_OldUserName == null)
            {
                var _User = new khachhang
                {
                    tenkh = model.tenkh,
                    phai = model.phai,
                    diachi = model.diachi,
                    email = model.email,
                    dienthoai = model.dienthoai,
                    tenDN = model.tenDN,
                    matkhau = model.matkhau.GetMD5()
                };

                db.khachhang.Add(_User);
                db.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            ViewBag.Message = "Tên đăng nhập đã tồn tại";
            return View(model);
        }
        #endregion
    }
}
