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
    }
}