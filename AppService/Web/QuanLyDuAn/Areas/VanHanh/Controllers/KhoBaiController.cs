using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class KhoBaiController : Controller
    {
        // GET: VanHanh/Kho
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XuatNhap()
        {
            return View();
        }
        public ActionResult DanhMucHH()
        {
            return View();
        }
        public ActionResult _XuatNhapCreate(int id,bool isIn )
        {
            bool checkin = isIn;
            return PartialView(id);
        }
        public ActionResult _NhatKyKho(int id)
        {
            return PartialView();
        }
    }
}