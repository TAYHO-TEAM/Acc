using System.Web.Mvc;

namespace QuanLyDuAn.Areas.ThongTin
{
    public class ThongTinAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ThongTin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
              "ThongTin_default_2",
              "ThongTin/{controller}/{action}/{id}",
              new { action = "Index", id = UrlParameter.Optional }
          );
            context.MapRoute(
                "ThongTin_default",
                "ThongTin/{controller}/{action}/{id}",
                new { controller ="Home",action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "ThongTin_CustomTable_Detail",
                "ThongTin/{controller}/{action}/{id}/{code}",
                new { controller = "CauHinh", action = "_CustomTableDetail", id = UrlParameter.Optional , code = UrlParameter.Optional }
            );
        }
    }
}