using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.VanHanh.Controllers
{
    public class HomeController : Controller
    {
        // GET: VanHanh/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}