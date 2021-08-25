using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class BanGiaoController : Controller
    {
        // GET: VanHanh/BanGiao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _HRDCreate(int id)
        {
            return PartialView(id);
        }
        public ActionResult _HRItemCreate(int id)
        {
            return PartialView(id);
        }
    }
}