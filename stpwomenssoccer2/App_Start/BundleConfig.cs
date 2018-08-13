using System.Web;
using System.Web.Optimization;

namespace stpwomenssoccer2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/styles.css",
                      "~/Content/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/flipclock").Include(
                      //"~/Scripts/FlipClock/faces/counter.js",
                      //"~/Scripts/FlipClock/faces/dailycounter.js",
                      //"~/Scripts/FlipClock/faces/hourlycounter.js",
                      //"~/Scripts/FlipClock/faces/minutecounter.js",
                      //"~/Scripts/FlipClock/faces/twelvehourclock.js",
                      //"~/Scripts/FlipClock/faces/twentyfourhourclock.js",
                      //"~/Scripts/FlipClock/lang/en-us.js",
                      //"~/Scripts/FlipClock/libs/core.js",
                      //"~/Scripts/FlipClock/libs/face.js",
                      //"~/Scripts/FlipClock/libs/factory.js",
                      //"~/Scripts/FlipClock/libs/list.js",
                      //"~/Scripts/FlipClock/libs/plugins.js",
                      //"~/Scripts/FlipClock/libs/time.js",
                      //"~/Scripts/FlipClock/libs/timer.js",
                      //"~/Scripts/FlipClock/vendor/base.js",
                      "~/Content/compiled/flipclock.js",
                      "~/Content/compiled/flipclock.min.js"));

            bundles.Add(new StyleBundle("~/Content/compiled/css").Include(
                      "~/Content/compiled/flipclock.css"));

            bundles.Add(new ScriptBundle("~/bundles/gallery").Include(
                      "~/Scripts/gallery/player.min.js",
                      "~/Scripts/gallery/script.js"));
        }
    }
}
