using System.Web.Optimization;

namespace PgsBoard
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap")
                .IncludeDirectory("~/Content/css/bootstrap", "*.css", true));
            bundles.Add(new ScriptBundle("~/bundles/site")
                .IncludeDirectory("~/Content/css/site", "*.css", true)
                .IncludeDirectory("~/Content/css/jquery-ui", "*.css", true));

            bundles.Add(new ScriptBundle("~/bundles/scripts/jquery")
                .IncludeDirectory("~/Scripts/jquery", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/scripts/bootstrap")
                .IncludeDirectory("~/Scripts/bootstrap", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/scripts/site")
                .IncludeDirectory("~/Scripts", "*.js"));
        }
    }
}