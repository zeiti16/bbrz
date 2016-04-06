using System.Web;
using System.Web.Optimization;

namespace bbrz_projekt
{
    public class BundleConfig
    {


        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/functions").Include(
                        "~/Scripts/functions.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/jsHead").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/plugins.js",
                        "~/Scripts/jquery.form-validator.js",
                        "~/Scripts/base.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/dark.css",
                      "~/Content/font-icons.css",
                      "~/Content/animate.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/responsive.css",
                      "~/Content/myStyle.css"
                      ));
        }
  
    }
}