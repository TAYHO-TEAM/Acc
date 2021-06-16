using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class BaoTriController : Controller
    {
        // GET: VanHanh/BaoTri
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhatKyBaoTri()
        {
            return View();
        }
        public ActionResult BaoTriDinhKy()
        {
            return View();
        }
    }
}