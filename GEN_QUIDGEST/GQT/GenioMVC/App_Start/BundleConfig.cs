using GenioMVC.Helpers;
using System.Web;
using System.Web.Optimization;
using CSGenio.framework;

namespace GenioMVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
// USE /[MANUAL GQT OVERRIDE_STYLE_BUNDLING]/
            bundles.Add(new StyleBundle("~/Content/css/d3andJQueryCss").Include(
                        "~/Content/stylesheets/nv.d3.css",
                        "~/Content/stylesheets/jquery.treeview.css",
                        "~/Content/stylesheets/jquery-ui-1.13.2.custom.css"));

            bundles.Add(new StyleBundle("~/Content/css/bootstrapPluginsCss").Include(
                       "~/Content/stylesheets/chosen.css"));

            //bundles.Add(new LessBundle("~/Content/css/globalStyles").Include(
            //           "~/Content/stylesheets/quidgest.less",
            //           "~/Content/stylesheets/layout.less",
            //           "~/Content/stylesheets/theme.less",
            //           "~/Content/stylesheets/customstyles.less"));

            bundles.Add(new StyleBundle("~/Content/css/fulltextCss").Include(
                        "~/Content/stylesheets/facets.css",
                        "~/Content/stylesheets/jquery.qtip.css",
                        "~/Content/stylesheets/jquery.autoSuggest.css",
                        "~/Content/stylesheets/elasticsearch/elasticsearch.css"));

            bundles.Add(new StyleBundle("~/Content/css/bootstrpcss").Include(
                        "~/Content/stylesheets/css/quidgest.css"));

// USE /[MANUAL GQT OVERRIDE_SCRIPT_BUNDLING]/
            bundles.Add(new ScriptBundle("~/Scripts/jqueryCoreJs").Include(
                        UrlNames.JQuery,
                        UrlNames.JQueryUnobtrusiveAjax,
                        UrlNames.JQueryUI));

            bundles.Add(new ScriptBundle("~/Scripts/otherCoreJs").Include(
                        UrlNames.Globalize,
                        //TODO:
                        // We need to use a dependency injector like requirejs.
                        // I've just put this because extended support forms do not work with $(document).ready
                        // and schemes using the getScript functions will not work with fileUpload dependencies,
                        // because one of them if requested twice, breaks everything.
                        UrlNames.FileUploadIframeTransport,
                        UrlNames.FileUpload,
                        UrlNames.FileUploader,
                        UrlNames.FileUploadProgress,
                        UrlNames.FileUploadValidate,
                        UrlNames.Bowser,
                        UrlNames.Modernizr,
                        UrlNames.Stacktrace));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrapCoreJs").Include(
                        UrlNames.Bootstrap,
                        UrlNames.BootstrapDatetimePicker,
                        UrlNames.Bootbox,
                        UrlNames.BootstrapModal,
                        UrlNames.BootstrapModalManager));

            // Google maps control
            bundles.UseCdn = true;   //enable CDN support
            string gmapsAPICdnPathDisplayEditor = "https://maps.googleapis.com/maps/api/js?libraries=geometry,places&key=" + Configuration.GoogleMapsKey ;
            bundles.Add(new ScriptBundle("~/Scripts/GoogleMapsDisplay&Editor", gmapsAPICdnPathDisplayEditor).Include("~/Scripts/gmapsDisplay&Edit.js"));

            bundles.Add(new ScriptBundle("~/Scripts/javascriptControls").Include(
                        /*UrlNames.Subscriptor,*/
                        UrlNames.QuidgestTreetable,
                        UrlNames.QuidgestTableFor,
                        UrlNames.QuidgestNumber,
                        UrlNames.JQueryHistory,
                        UrlNames.ChosenJQuery,
                        UrlNames.Scripts,
                        UrlNames.JQueryMask,
                        UrlNames.QuidgestLocalStorage,
                        UrlNames.QuidgestDebug,
                        UrlNames.QuidgestClientSidePersistence,
						UrlNames.QuidgestMenus,
                        UrlNames.QuidgestMultiform,
						UrlNames.QuidgestModal,
						UrlNames.QuidgestFunctions,
						UrlNames.QuidgestGlobalFunctions,
						UrlNames.QuidgestMsq,
						UrlNames.QuidgestCav,
                        UrlNames.jqueryMultiSelect,
                        UrlNames.jqueryQuicksearch,
						UrlNames.QuidgestControls,
                        UrlNames.QuidgestHistorial,
                        UrlNames.QuidgestAlerts,
                        UrlNames.QuidgestDashboard,
                        UrlNames.JQueryMagnificPopUp,
                        UrlNames.JQueryWizard));


            bundles.Add(new ScriptBundle("~/Scripts/validateJs").Include(
                        UrlNames.JQueryValidate,
                        UrlNames.JQueryValidateGlobalize,
                        UrlNames.JQueryValidateUnobtrusive,
                        UrlNames.QuidgestValidate));

             bundles.Add(new ScriptBundle("~/Scripts/jquery3CoreJs").Include(
                        UrlNames.JQuery3,
                        UrlNames.JQueryUnobtrusiveAjax,
                        UrlNames.JQueryUI,
                        UrlNames.Bootbox4,
                        UrlNames.WidgetUI,
                        UrlNames.FileUploadUI,
                        UrlNames.FileUploadIframeTransport,
                        UrlNames.FileUpload,
                        UrlNames.FileUploader,
                        UrlNames.FileUploadProgress,
                        UrlNames.FileUploadValidate,
                        UrlNames.JQueryLazy,
                        UrlNames.JQueryLazyPluginScript));

             bundles.Add(new ScriptBundle("~/Scripts/bootstrap4CoreJs").Include(
                        UrlNames.Popper,
                        UrlNames.Moment,
                        UrlNames.MomentTimeZone,
						UrlNames.Bootbox4,
                        UrlNames.Bootstrap4,
                        UrlNames.BootstrapDatetimePicker));

            bundles.Add(new ScriptBundle("~/Scripts/other3CoreJs").Include(
                        UrlNames.Globalize,
                        UrlNames.Bowser
                        //TODO:
                        // We need to use a dependency injector like requirejs.
                        // I've just put this because extended support forms do not work with $(document).ready
                        // and schemes using the getScript functions will not work with fileUpload dependencies,
                        // because one of them if requested twice, breaks everything.
                        ));
						
			// Set to «false» for bundling in Debug mode
			BundleTable.EnableOptimizations = true;

// USE /[MANUAL GQT BUNDLING]/

            // The Layout specific bundles should have the name of the Layout in its name

			//bundles.Add(new ScriptBundle("~/Scripts/VerticalMenu").Include(
                //"~/Scripts/Layouts/HorzMenu_WithHeader/jquery.mmenu.min.all.js"));
				
			//bundles.Add(new StyleBundle("~/Content/VerticalMenu").Include(
                //"~/Content/stylesheets/jquery.mmenu.all.css"));

            bundles.Add(new ScriptBundle("~/Scripts/RibbonJs").Include(
                "~/Scripts/Layouts/HorzMenu_WithHeader/ribbon.js"));
        }
    }
}
