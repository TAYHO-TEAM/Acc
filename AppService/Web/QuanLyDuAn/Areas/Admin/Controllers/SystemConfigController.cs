
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Areas.Admin.Controllers
{
    public class SystemConfigController : Controller
    {
        // GET: Admin/SystemConfig
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Actions()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            return View();
        }
        public ActionResult Functions()
        {
            return View();
        }
        public ActionResult Groups()
        {
            return View();
        }
        public ActionResult GroupAccount()
        {
            return View();
        }
        public ActionResult GroupActionPermistion()
        {
            return View();
        }
        public ActionResult GroupFunction()
        {
            return View();
        }
        public ActionResult LogEvent()
        {
            return View();
        }
        public ActionResult UserInfo()
        {
            return View();
        }
        public ActionResult _ContractorInfoAdd()
        {
            return PartialView();
        }
    }
}