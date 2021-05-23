using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class BaoHanhController : Controller
    {
        // GET: VanHanh/BaoHanh
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeuCau()
        {
            return View();
        }
        public ActionResult _YeuCauCreate()
        {
            return PartialView();
        }
    }
}