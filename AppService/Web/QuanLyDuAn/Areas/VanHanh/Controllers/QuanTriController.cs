using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class QuanTriController : Controller
    {
        // GET: VanHanh/QuanTri
        public ActionResult Index()
        {
            return View();
        }
        // GET: VanHanh/QuanTri
        public ActionResult KhachHang()
        {
            return View();
        }
        public ActionResult _KhachHangCreate()
        {
            return PartialView();
        }
        // GET: VanHanh/QuanTri
        public ActionResult CanHo()
        {
            return View();
        }
        public ActionResult _CanHoCreate()
        {
            return PartialView();
        }
        public ActionResult Defect()
        {
            return View();
        }
        public ActionResult _DefectCreate()
        {
            return PartialView();
        }
        public ActionResult HeThongVH()
        {
            return View();
        }
        public ActionResult QuanLyKho()
        {
            return View();
        }
        public ActionResult DonVi()
        {
            return View();
        }
        public ActionResult DonViKyThuat()
        {
            return View();
        }
        public ActionResult KhieuNai()
        {
            return View();
        }
        public ActionResult _LichBaoTriCreate(int id)
        {
            return PartialView(id);
        }
        public ActionResult _LichBaoTriDetail(int id)
        {
            return PartialView(id);
        }
    }
}