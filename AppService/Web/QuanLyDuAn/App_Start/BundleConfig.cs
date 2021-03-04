using System.Web;
using System.Web.Optimization;

namespace QuanLyDuAn
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/ScriptsBundle");
            var styleBundle = new StyleBundle("~/StyleBundle");

            var scriptBundleDX = new ScriptBundle("~/ScriptsBundleDx");
            var styleBundleDX = new StyleBundle("~/StyleBundleDx");

            styleBundle.Include(
                "~/Content/plugins/fontawesome-free/css/all.min.css",
                "~/Content/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                "~/Content/plugins/themify-icons/themify-icons.css",
                "~/Content/css/adminlte.css",
                "~/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css");

            styleBundleDX.Include(
                "~/Content/dx.common.css",
                "~/Content/dx.material.orange.light.compact.css");

            scriptBundle.Include(
                "~/Content/plugins/jquery/jquery.js",
                "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/plugins/jquery-ui/jquery-ui.min.js",
                "~/Content/plugins/moment/moment.min.js",
                "~/Content/plugins/moment/moment-with-locales.min.js",
                "~/Content/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                "~/Content/js/adminlte.js");

            scriptBundleDX.Include(
                "~/Scripts/jszip.js",
                //"~/Scripts/dx.all.js",
                "~/Scripts/localization/dx.messages.vi.js",
                //"~/Scripts/aspnet/dx.aspnet.mvc.js",
                "~/Scripts/aspnet/dx.aspnet.data.js");

            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);
            bundles.Add(scriptBundleDX);
            bundles.Add(styleBundleDX);

            BundleTable.EnableOptimizations = true;
        }
    }
}
