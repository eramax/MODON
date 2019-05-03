using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        private static string currentVersionNp = string.Empty;
        public static string CurrentVersionNo
        {
            get
            {
                if (currentVersionNp == string.Empty)
                {
                    var fileCreatedDate = File.GetCreationTime(HostingEnvironment.MapPath("~/bin/Modon.Portal.dll"));
                    return fileCreatedDate.ToString("ddMMyyyyHHmmss") + "-13";
                }
                return currentVersionNp;
            }
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundlesList = new List<Bundle>();

            //bundlesList.Add(new StyleBundle("~/bundles/layoutstyles").Include(
            //    "~/assets/plugins/jquery-ui/themes/base/minified/jquery-ui.min.css"
            //    , "~/assets/plugins/bootstrap/css/bootstrap.min.css"
            //    , "~/assets/plugins/font-awesome/css/font-awesome.min.css"
            //    , "~/assets/css/css/animate.min.css"
            //    , "~/assets/css/style.css"
            //    , "~/assets/css/css/style.css"
            //    , "~/assets/css/css/style-responsive.min.css"
            //    , "~/assets/css/css/theme/default.css"
            //    , "~/assets/plugins/switchery/switchery.min.css"
            //    , "~/assets/css/jquery.calendars.picker.css"
            //    , "~/assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css"
            //    , "~/assets/plugins/bootstrap-wizard/css/bwizard.css"
            //    , "~/assets/plugins/parsley/src/parsley.css"
            //    , "~/assets/plugins/select2/dist/css/select2.css"
            //    , "~/assets/plugins/DataTables/media/css/dataTables.bootstrap.min.css"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/css/buttons.bootstrap.min.css"
            //    , "~/assets/plugins/DataTables/extensions/Responsive/css/responsive.bootstrap.min.css"
            //    , "~/assets/plugins/bootstrap-sweetalert/sweetalert.css"
            //    , "~/assets/plugins/gritter/css/jquery.gritter.css"
            //    , "~/assets/plugins/nvd3/build/nv.d3.css"
            //    , "~/assets/css/sumoselect.min.css"
            //    , "~/Content/Site.css"));

            //bundlesList.Add(new ScriptBundle("~/ScriptBundles/SBS").Include("~/Scripts/SBS.js"));

            //bundlesList.Add(new ScriptBundle("~/bundles/layoutscripts").Include(
            //     "~/Scripts/jquery.validate.min.js"
            //    , "~/Scripts/jquery.validate.unobtrusive.min.js"
            //    , "~/assets/plugins/jquery-ui/ui/minified/jquery-ui.min.js"
            //    , "~/assets/plugins/bootstrap/js/bootstrap.min.js"
            //    , "~/assets/plugins/slimscroll/jquery.slimscroll.min.js"
            //    , "~/assets/plugins/gritter/js/jquery.gritter.js"
            //    , "~/assets/plugins/morris/raphael.min.js"
            //    , "~/assets/plugins/switchery/switchery.min.js"
            //    , "~/assets/plugins/morris/morris.js"
            //    , "~/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"
            //    , "~/assets/plugins/jquery-cookie/jquery.cookie.js"
            //    , "~/assets/plugins/select2/dist/js/select2.min.js"
            //    , "~/assets/plugins/parsley/dist/parsley.js"
            //    , "~/assets/plugins/lightbox/js/lightbox-2.6.min.js"
            //    , "~/assets/plugins/moment/moment.min.js"
            //    , "~/assets/plugins/morris/raphael.min.js"
            //    , "~/assets/plugins/morris/morris.js"
            //    , "~/assets/js/chart-morris.demo.min.js"
            //    , "~/assets/js/jquery.chained.min.js"
            //    , "~/assets/js/apps.js"
            //    , "~/assets/plugins/DataTables/media/js/jquery.dataTables.js"
            //    , "~/assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/dataTables.buttons.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/buttons.bootstrap.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/buttons.flash.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/jszip.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/pdfmake.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/vfs_fonts.min.js"
            //    , "~/assets/plugins/DataTables/extensions/Buttons/js/buttons.html5.js"
            //    , "~/assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"
            //    , "~/assets/plugins/bootstrap-sweetalert/sweetalert.js"
            //    , "~/assets/js/ui-modal-notification.demo.min.js"
            //    , "~/assets/js/table-manage-buttons.demo.js"
            //    //, "~/assets/plugins/nvd3/build/nv.d3.js"
            //    //, "~/assets/js/chart-d3.demo.min.js"
            //    , "~/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"
            //    ,"~/assets/js/form-wizards-validation.demo.js"
            //    ,"~/assets/js/jquery.sumoselect.min.js"
            //));

            var path = HostingEnvironment.MapPath("~/Scripts");
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                var scriptDirs = Directory.GetDirectories(path);
                for (int d = 0; d < scriptDirs.Length; d++)
                {
                    var scripts = Directory.GetFiles(scriptDirs[d], "*.js");
                    for (int jsf = 0; jsf < scripts.Length; jsf++)
                    {
                        var jsFilePath = string.Format("~/Scripts/{0}/{1}", Path.GetFileNameWithoutExtension(scriptDirs[d]), Path.GetFileName(scripts[jsf]));
                        var jsFilePathBundles = string.Format("~/ScriptBundles/{0}/{1}", Path.GetFileNameWithoutExtension(scriptDirs[d]), Path.GetFileNameWithoutExtension(scripts[jsf]));
                        bundlesList.Add(new ScriptBundle(jsFilePathBundles).Include(jsFilePath));
                    }
                }
            }

            for (int i = 0; i < bundlesList.Count; i++)
            {
                bundlesList[i].Transforms.Add(new LastModifiedBundleTransform());
                bundles.Add(bundlesList[i]);
            }
        }
    }

    public class LastModifiedBundleTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            foreach (var file in response.Files)
            {
                file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", BundleConfig.CurrentVersionNo);
            }
        }
    }
}
