using System.Web;
using System.Web.Optimization;

namespace SantaMarta.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.IgnoreList.Clear();

            RegisterLayout(bundles);

            RegisterShared(bundles);

            RegisterAccount(bundles);

            RegisterHome(bundles);

            RegisterCharts(bundles);

            RegisterWidgets(bundles);

            RegisterElements(bundles);

            RegisterForms(bundles);

            RegisterTables(bundles);

            RegisterCalendar(bundles);

            RegisterMailbox(bundles);

            RegisterExamples(bundles);

            RegisterDocumentation(bundles);
        }

        private static void RegisterDocumentation(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Documentation/menu").Include(
                "~/scripts/Documentation/Documentation-menu.js"));
        }

        private static void RegisterExamples(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Examples/Blank/menu").Include(
                "~/scripts/Examples/Blank-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Invoice/menu").Include(
                "~/scripts/Examples/Invoice-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Lockscreen/menu").Include(
                "~/scripts/Examples/Lockscreen-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Login").Include(
                "~/scripts/Examples/Login.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Login/menu").Include(
                "~/scripts/Examples/Login-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/P404/menu").Include(
                "~/scripts/Examples/P404-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/P500/menu").Include(
                "~/scripts/Examples/P500-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Pace").Include(
                "~/scripts/Examples/Pace.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Pace/menu").Include(
                "~/scripts/Examples/Pace-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/ProfileEx/menu").Include(
                "~/scripts/Examples/ProfileEx-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Register").Include(
                "~/scripts/Examples/Register.js"));

            bundles.Add(new ScriptBundle("~/scripts/Examples/Register/menu").Include(
                "~/scripts/Examples/Register-menu.js"));
        }

        private static void RegisterMailbox(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Mailbox/Inbox").Include(
                "~/scripts/Mailbox/Inbox.js"));

            bundles.Add(new ScriptBundle("~/scripts/Mailbox/Inbox/menu").Include(
                "~/scripts/Mailbox/Inbox-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Mailbox/Compose").Include(
                "~/scripts/Mailbox/Compose.js"));

            bundles.Add(new ScriptBundle("~/scripts/Mailbox/Compose/menu").Include(
               "~/scripts/Mailbox/Compose-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Mailbox/Read/menu").Include(
                "~/scripts/Mailbox/Read-menu.js"));
        }

        private static void RegisterCalendar(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Calendar").Include(
                "~/scripts/Calendar/Calendar.js"));

            bundles.Add(new ScriptBundle("~/scripts/Calendar/menu").Include(
                "~/scripts/Calendar/Calendar-menu.js"));
        }

        private static void RegisterTables(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Tables/Simple/menu").Include(
                "~/scripts/Tables/Simple-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Tables/Data").Include(
                "~/scripts/Tables/Data.js"));

            bundles.Add(new ScriptBundle("~/scripts/Tables/Data/menu").Include(
                "~/scripts/Tables/Data-menu.js"));
        }

        private static void RegisterForms(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Forms/Advanced").Include(
                "~/scripts/Forms/Advanced.js"));

            bundles.Add(new ScriptBundle("~/scripts/Forms/Advanced/menu").Include(
                "~/scripts/Forms/Advanced-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Forms/Editors").Include(
                "~/scripts/Forms/Editors.js"));

            bundles.Add(new ScriptBundle("~/scripts/Forms/Editors/menu").Include(
                "~/scripts/Forms/Editors-menu.js"));


            bundles.Add(new ScriptBundle("~/scripts/Forms/General/menu").Include(
                "~/scripts/Forms/General-menu.js"));
        }

        private static void RegisterElements(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Elements/Buttons/menu").Include(
                "~/scripts/Elements/Buttons-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/General/menu").Include(
                "~/scripts/Elements/General-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/General").Include(
                "~/Styles/Elements/General.css"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/Icons/menu").Include(
                "~/scripts/Elements/Icons-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Icons").Include(
                "~/Styles/Elements/Icons.css"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/Modals/menu").Include(
                "~/scripts/Elements/Modals-menu.js"));

            bundles.Add(new StyleBundle("~/Styles/Elements/Modals").Include(
                "~/Styles/Elements/Modals.css"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/Sliders").Include(
                "~/scripts/Elements/Sliders.js"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/Sliders/menu").Include(
                "~/scripts/Elements/Sliders-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Elements/Timeline/menu").Include(
                "~/scripts/Elements/Timeline-menu.js"));
        }

        private static void RegisterWidgets(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Widgets/menu").Include(
                "~/scripts/Widgets/Widgets-menu.js"));
        }

        private static void RegisterCharts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Charts/ChartsJs").Include(
                "~/scripts/Charts/ChartsJs.js"));
            bundles.Add(new ScriptBundle("~/scripts/Charts/ChartsJs/menu").Include(
                            "~/scripts/Charts/ChartsJs-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Morris").Include(
                "~/scripts/Charts/Morris.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Morris/menu").Include(
                "~/scripts/Charts/Morris-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Flot").Include(
                "~/scripts/Charts/Flot.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Flot/menu").Include(
                "~/scripts/Charts/Flot-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Inline").Include(
                "~/scripts/Charts/Inline.js"));

            bundles.Add(new ScriptBundle("~/scripts/Charts/Inline/menu").Include(
                "~/scripts/Charts/Inline-menu.js"));
        }

        private static void RegisterHome(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Home/DashboardV1").Include(
                "~/scripts/Home/DashboardV1.js"));
            bundles.Add(new ScriptBundle("~/scripts/Home/DashboardV1/menu").Include(
                "~/scripts/Home/DashboardV1-menu.js"));

            bundles.Add(new ScriptBundle("~/scripts/Home/DashboardV2").Include(
                "~/scripts/Home/DashboardV2.js"));
            bundles.Add(new ScriptBundle("~/scripts/Home/DashboardV2/menu").Include(
                "~/scripts/Home/DashboardV2-menu.js"));
        }

        private static void RegisterAccount(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Account/Login").Include(
                "~/scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/scripts/Account/Register").Include(
                "~/scripts/Account/Register.js"));
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Shared/_Layout").Include(
                "~/scripts/Shared/_Layout.js"));
        }

        private static void RegisterLayout(BundleCollection bundles)
        {
            // bootstrap
            bundles.Add(new ScriptBundle("~/AdminPacket/bootstrap/js").Include(
                "~/AdminPacket/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/bootstrap/css").Include(
                "~/AdminPacket/bootstrap/css/bootstrap.min.css"));

            // dist
            bundles.Add(new ScriptBundle("~/AdminPacket/dist/js").Include(
                "~/AdminPacket/dist/js/app.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/dist/css").Include(
                "~/AdminPacket/dist/css/admin-lte.min.css"));

            bundles.Add(new StyleBundle("~/AdminPacket/dist/css/skins").Include(
                "~/AdminPacket/dist/css/skins/_all-skins.min.css"));

            // documentation
            bundles.Add(new ScriptBundle("~/AdminPacket/documentation/js").Include(
                "~/AdminPacket/documentation/js/docs.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/documentation/css").Include(
                "~/AdminPacket/documentation/css/style.css"));

            // plugins | bootstrap-slider
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/bootstrap-slider/js").Include(
                                        "~/AdminPacket/plugins/bootstrap-slider/js/bootstrap-slider.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/bootstrap-slider/css").Include(
                                        "~/AdminPacket/plugins/bootstrap-slider/css/slider.css"));

            // plugins | bootstrap-wysihtml5
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/bootstrap-wysihtml5/js").Include(
                                         "~/AdminPacket/plugins/bootstrap-wysihtml5/js/bootstrap3-wysihtml5.all.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/bootstrap-wysihtml5/css").Include(
                                        "~/AdminPacket/plugins/bootstrap-wysihtml5/css/bootstrap3-wysihtml5.min.css"));

            // plugins | chartjs
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/chartjs/js").Include(
                                         "~/AdminPacket/plugins/chartjs/js/chart.min.js"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/ckeditor/js").Include(
                                         "~/AdminPacket/plugins/ckeditor/js/ckeditor.js"));

            // plugins | colorpicker
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/colorpicker/js").Include(
                                         "~/AdminPacket/plugins/colorpicker/js/bootstrap-colorpicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/colorpicker/css").Include(
                                        "~/AdminPacket/plugins/colorpicker/css/bootstrap-colorpicker.css"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/datatables/js").Include(
                                         "~/AdminPacket/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/AdminPacket/plugins/datatables/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/datatables/css").Include(
                                        "~/AdminPacket/plugins/datatables/css/dataTables.bootstrap.css"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/datepicker/js").Include(
                                         "~/AdminPacket/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/AdminPacket/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/datepicker/css").Include(
                                        "~/AdminPacket/plugins/datepicker/css/datepicker3.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/daterangepicker/js").Include(
                                         "~/AdminPacket/plugins/daterangepicker/js/moment.min.js",
                                         "~/AdminPacket/plugins/daterangepicker/js/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/daterangepicker/css").Include(
                                        "~/AdminPacket/plugins/daterangepicker/css/daterangepicker-bs3.css"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/fastclick/js").Include(
                                         "~/AdminPacket/plugins/fastclick/js/fastclick.min.js"));

            // plugins | flot
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/flot/js").Include(
                                         "~/AdminPacket/plugins/flot/js/jquery.flot.min.js",
                                         "~/AdminPacket/plugins/flot/js/jquery.flot.resize.min.js",
                                         "~/AdminPacket/plugins/flot/js/jquery.flot.pie.min.js",
                                         "~/AdminPacket/plugins/flot/js/jquery.flot.categories.min.js"));

            // plugins | font-awesome
            bundles.Add(new StyleBundle("~/AdminPacket/plugins/font-awesome/css").Include(
                                        "~/AdminPacket/plugins/font-awesome/css/font-awesome.min.css"));

            // plugins | fullcalendar
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/fullcalendar/js").Include(
                                         "~/AdminPacket/plugins/fullcalendar/js/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/fullcalendar/css").Include(
                                        "~/AdminPacket/plugins/fullcalendar/css/fullcalendar.min.css"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/fullcalendar/css/print").Include(
                                        "~/AdminPacket/plugins/fullcalendar/css/print/fullcalendar.print.css"));

            // plugins | icheck
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/icheck/js").Include(
                                         "~/AdminPacket/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/icheck/css").Include(
                                        "~/AdminPacket/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/icheck/css/flat").Include(
                                        "~/AdminPacket/plugins/icheck/css/flat/flat.css"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/icheck/css/sqare/blue").Include(
                                        "~/AdminPacket/plugins/icheck/css/sqare/blue.css"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/input-mask/js").Include(
                                         "~/AdminPacket/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/AdminPacket/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/AdminPacket/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionicons
            bundles.Add(new StyleBundle("~/AdminPacket/plugins/ionicons/css").Include(
                                        "~/AdminPacket/plugins/ionicons/css/ionicons.min.css"));

            // plugins | ionslider
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/ionslider/js").Include(
                                         "~/AdminPacket/plugins/ionslider/js/ion.rangeSlider.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/ionslider/css").Include(
                                        "~/AdminPacket/plugins/ionslider/css/ion.rangeSlider.css",
                                        "~/AdminPacket/plugins/ionslider/css/ion.rangeSlider.skinNice.css"));

            // plugins | jquery
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/jquery/js").Include(
                                         "~/AdminPacket/plugins/jquery/js/jQuery-2.1.4.min.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/jquery-validate/js").Include(
                                         "~/AdminPacket/plugins/jquery-validate/js/jquery.validate*"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/jquery-ui/js").Include(
                                         "~/AdminPacket/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/jvectormap/js").Include(
                                         "~/AdminPacket/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/AdminPacket/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/jvectormap/css").Include(
                                        "~/AdminPacket/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));

            // plugins | knob
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/knob/js").Include(
                                         "~/AdminPacket/plugins/knob/js/jquery.knob.js"));

            // plugins | morris
            bundles.Add(new StyleBundle("~/AdminPacket/plugins/morris/css").Include(
                                        "~/AdminPacket/plugins/morris/css/morris.css"));

            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/momentjs/js").Include(
                                         "~/AdminPacket/plugins/momentjs/js/moment.min.js"));

            // plugins | pace
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/pace/js").Include(
                                         "~/AdminPacket/plugins/pace/js/pace.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/pace/css").Include(
                                        "~/AdminPacket/plugins/pace/css/pace.min.css"));

            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/slimscroll/js").Include(
                                         "~/AdminPacket/plugins/slimscroll/js/jquery.slimscroll.min.js"));

            // plugins | sparkline
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/sparkline/js").Include(
                                         "~/AdminPacket/plugins/sparkline/js/jquery.sparkline.min.js"));

            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/timepicker/js").Include(
                                         "~/AdminPacket/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/timepicker/css").Include(
                                        "~/AdminPacket/plugins/timepicker/css/bootstrap-timepicker.min.css"));

            // plugins | raphael
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/raphael/js").Include(
                                         "~/AdminPacket/plugins/raphael/js/raphael-min.js"));

            // plugins | select2
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/select2/js").Include(
                                         "~/AdminPacket/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/AdminPacket/plugins/select2/css").Include(
                                        "~/AdminPacket/plugins/select2/css/select2.min.css"));

            // plugins | morris
            bundles.Add(new ScriptBundle("~/AdminPacket/plugins/morris/js").Include(
                                         "~/AdminPacket/plugins/morris/js/morris.min.js"));

        }
    }
}
