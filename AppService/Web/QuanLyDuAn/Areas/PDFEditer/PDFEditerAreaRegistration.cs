using System.Web.Mvc;

namespace QuanLyDuAn.Areas.PDFEditer
{
    public class PDFEditerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PDFEditer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PDFEditer_default",
                "PDFEditer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}