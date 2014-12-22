using System.Web;
using System.Web.Optimization;

namespace QverbITMS.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            // javascript
            bundles.Add(new ScriptBundle("~/bundles/adminlte/plugins").Include(
                //Morris charts
               "~/Scripts/plugins/morris/morris.min.js",
                // Sparkline 
               "~/Scripts/plugins/sparkline/jquery.sparkline.min.js",
                // jvectormap 
               "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
               "~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                // jQuery Knob Chart 
               "~/Scripts/plugins/jqueryKnob/jquery.knob.js",
                // daterangepicker
               "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                // datepicker 
               "~/Scripts/plugins/datepicker/bootstrap-datepicker.js",
                // timepicker
               "~/Scripts/plugins/timepicker/bootstrap-timepicker.js",
                // Bootstrap WYSIHTML5 
               "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                // iCheck 
               "~/Scripts/plugins/iCheck/icheck.min.js",
                // AdminLTE App
               "~/Scripts/AdminLTE/app.js",
                // AdminLTE dashboard demo (This is only for demo purposes) 
               "~/Scripts/AdminLTE/dashboard.js",
                // AdminLTE for demo purposes 
               "~/Scripts/AdminLTE/demo.js",
               // Bootstrap validation js
               "~/Scripts/plugins/validation/bootstrap-validation.js"));

             // javascript
            bundles.Add(new ScriptBundle("~/bundles/adminlte/plugins/dataTable").Include(
                // dataTable 
               "~/Scripts/plugins/datatables/jquery.dataTables.js",
                // bootstrap dataTable
               "~/Scripts/plugins/datatables/dataTables.bootstrap.js"));

            //using CDN with MVC bundles - ref http://venkatbaggu.com/use-cdn-bundle-config-in-asp-net-mvc/
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", "http://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js").Include(
                 "~/Scripts/jquery-{version}.js");
            bundles.Add(jqueryBundle);

            var bootstrapBundle = new ScriptBundle("~/bundles/bootstrap", "http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js").Include(
            "~/Scripts/bootstrapcdn-{version}.js");
            bundles.Add(bootstrapBundle);

            var jqueryuiBundle = new ScriptBundle("~/bundles/jqueryui", "http://code.jquery.com/ui/1.11.1/jquery-ui.min.js").Include(
               "~/Scripts/bootstrapcdn-{version}.js");
            bundles.Add(jqueryuiBundle);

            var morrisBundle = new ScriptBundle("~/bundles/morris", "http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js").Include(
                "~/Scripts/bootstrapcdn-{version}.js");
            bundles.Add(morrisBundle);

            // css
            bundles.Add(new StyleBundle("~/Content/themes/adminlte/css").Include(
                // Morris chart
                   "~/Content/themes/adminlte/css/morris/morris.css",
                // jvectormap 
                   "~/Content/themes/adminlte/css/jvectormap/jquery-jvectormap-1.2.2.css",
                // Date Picker
                   "~/Content/themes/adminlte/css/datepicker/datepicker3.css",
                // Daterange picker 
                   "~/Content/themes/adminlte/css/daterangepicker/daterangepicker-bs3.css",
                // Time Picker
                   "~/Content/themes/adminlte/css/timepicker/bootstrap-timepicker.css",
                // bootstrap wysihtml5 - text editor 
                   "~/Content/themes/adminlte/css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                // Theme style
                    "~/Content/themes/adminlte/css/AdminLTE.css"));

            //adminLte css 
            bundles.Add(new StyleBundle("~/Content/themes/adminlte-only/css").Include(
                // Theme style
                    "~/Content/themes/adminlte/css/AdminLTE.css"));

            // datatables
            bundles.Add(new StyleBundle("~/Content/themes/adminlte/css/dataTables").Include(
                // Theme style
                    "~/Content/themes/adminlte/css/datatables/dataTables.bootstrap.css"));
        }
    }
}