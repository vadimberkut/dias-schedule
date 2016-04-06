using System.Web;
using System.Web.Optimization;

namespace ScheduleApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Schedule.css"));

            //jquery-ui-1.11.4
            bundles.Add(new ScriptBundle("~/libs/jquery-ui/js").Include(
                            "~/Libs/jquery-ui-1.11.4/jquery-ui.min.js"
                            ));

            bundles.Add(new StyleBundle("~/libs/jquery-ui/css").Include(
                "~/Libs/jquery-ui-1.11.4/jquery-ui.min.css"
                ));

            //font-awesome-4.5.0
            bundles.Add(new StyleBundle("~/libs/font-awesome/css").Include(
                "~/Libs/font-awesome-4.5.0/css/font-awesome.css"
                ));

            //bootstrap-select-1.10.0
            bundles.Add(new ScriptBundle("~/libs/bootstrap-select/js").Include(
                            "~/Libs/bootstrap-select-1.10.0/dist/js/bootstrap-select.js"
                            ));

            bundles.Add(new StyleBundle("~/libs/bootstrap-select/css").Include(
                "~/Libs/bootstrap-select-1.10.0/dist/css/bootstrap-select.css"
                ));
        }
    }
}
