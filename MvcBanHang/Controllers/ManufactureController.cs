using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBanHang.Models;

namespace MvcBanHang.Controllers
{
    public class ManufactureController : Controller
    {
        BanHangEntities db = new BanHangEntities();

        public ActionResult Index()
        {
            return View(db.hangsanxuat);
        }

        #region Lấy SP theo hãng sản xuất
        public ActionResult ManufactureByID(int id)
        {
            ViewBag.Tenhangsx = db.sanpham.Where(x => x.mahsx == id).FirstOrDefault().hangsanxuat.tenhsx;        
            return View(db.sanpham.Where(a => a.mahsx == id));
        }
        #endregion

        #region menu hãng sản xuất
        public ActionResult GetManufacture()
        {
            return PartialView("ManufacturePartial", db.hangsanxuat);
        }
        #endregion
    }
}
