using System.Web;
using System.Web.Optimization;

namespace QverbITMS.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Content/themes/adminlte/css").Include(
                // Morris chart
                   "~/Content/themes/adminlte/css/morris/morris.css",
                // jvectormap 
                   "~/Content/themes/adminlte/css/jvectormap/jquery-jvectormap-1.2.2.css",
                // Date Picker
                   "~/Content/themes/adminlte/css/datepicker/datepicker3.css",
                // Daterange picker 
                   "~/Content/themes/adminlte/css/daterangepicker/daterangepicker-bs3.css",
                // bootstrap wysihtml5 - text editor 
                   "~/Content/themes/adminlte/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                // Theme style
                    "~/Content/themes/adminlte/css/AdminLTE.css"));
        }
    }
}