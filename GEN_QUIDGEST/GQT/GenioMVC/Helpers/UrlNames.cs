using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Collections.Concurrent;

namespace GenioMVC.Helpers
{
    /// <summary>
    /// Static class that is a store for commonly used filenames
    /// (so if the files are updated they only need to be amended in a single place)
    /// </summary>
    public static class UrlNames
    {
        #region Scripts

        public static string JQuery { get { return "~/Scripts/jQuery/jquery-2.0.3.js"; } }

        public static string Globalize { get { return "~/Scripts/jQuery3/jquery.globalize/globalize.js"; } }

		public static string GlobalizeCultures { get { return "~/Scripts/jQuery3/jquery.globalize/cultures/globalize.cultures.js"; } }

        public static string JQueryValidate { get { return "~/Scripts/jQuery3/jquery.validate.js"; } }

        public static string JQueryValidateGlobalize { get { return "~/Scripts/jQuery3/jquery.validate.globalize.js"; } }

        public static string JQueryValidateUnobtrusive { get { return "~/Scripts/jQuery3/jquery.validate.unobtrusive.js"; } }

        public static string JQueryUnobtrusiveAjax { get { return "~/Scripts/jQuery3/jquery.unobtrusive-ajax.js"; } }

        public static string Modernizr { get { return "~/Scripts/modernizr-2.6.2.js"; } }

        public static string Stacktrace { get { return "~/Scripts/stacktrace.js"; } }

        public static string Bootstrap { get { return "~/Scripts/bootstrap/bootstrap.js"; } }

        public static string BootstrapDatetimePicker { get { return "~/Scripts/bootstrap4/bootstrap-datetimepicker.js"; } }

        public static string JQueryUI { get { return "~/Scripts/jQuery3/jquery-ui-1.13.2.js"; } }

        /*public static string Subscriptor { get { return "~/Scripts/subscriptor.js"; } }*/

        public static string QuidgestTreetable { get { return "~/Scripts/quidgest/quidgest.treetable.js"; } }

        public static string QuidgestWebAuth { get { return "~/Scripts/quidgest/quidgest.webauth.js"; } }

        public static string JQueryHistory { get { return "~/Scripts/jQuery3/jquery.history.js"; } }

        public static string ChosenJQuery { get { return "~/Scripts/jQuery3/jquery.chosen.js"; } }

        public static string Scripts { get { return "~/Scripts/scripts.js"; } }

        public static string JQueryMask { get { return "~/Scripts/jQuery3/jquery.mask.js"; } }

        public static string QuidgestNumber { get { return "~/Scripts/quidgest/quidgest.number.js"; } }

        public static string FileUploader { get { return "~/Scripts/fileuploader.js"; } }

        public static string FulltextHelper { get { return "~/Scripts/fulltextHelper.js"; } }

		public static string JQueryQtip { get { return "~/Scripts/jQuery3/jquery.qtip.js"; } }

		public static string JQueryAutoSuggest { get { return "~/Scripts/jQuery3/jquery.autoSuggest.js"; } }
		
		public static string JQueryQRCode { get { return "~/Scripts/jQuery3/jquery-qrcode.min.js"; } }

		public static string TinyMCE5 { get { return "~/Scripts/tinymce/tinymce.min.js"; } }

		public static string D3V3 { get { return "~/Scripts/novus-nvd3/lib/d3.v3.js"; } }

		public static string NVD3 { get { return "~/Scripts/novus-nvd3/nv.d3.min.js"; } }

		public static string NVD3Utils { get { return "~/Scripts/novus-nvd3/src/utils.js"; } }

		public static string NVD3Tooltip { get { return "~/Scripts/novus-nvd3/src/tooltip.js"; } }

		public static string NVD3ModelAxis { get { return "~/Scripts/novus-nvd3/src/models/axis.js"; } }

		public static string NVD3ModelDiscreteeBarChart { get { return "~/Scripts/novus-nvd3/src/models/discreteBarChart.js"; } }

		public static string NVD3ModelDiscreteeBar { get { return "~/Scripts/novus-nvd3/src/models/discreteBar.js"; } }

		public static string NVD3ModelLegend { get { return "~/Scripts/novus-nvd3/src/models/legend.js"; } }

		public static string NVD3ModelScatter { get { return "~/Scripts/novus-nvd3/src/models/scatter.js"; } }

		public static string NVD3ModelLine { get { return "~/Scripts/novus-nvd3/src/models/line.js"; } }

		public static string NVD3ModelLineChart { get { return "~/Scripts/novus-nvd3/src/models/lineChart.js"; } }

        public static string NVD3ModelMultiBar { get { return "~/Scripts/novus-nvd3/src/models/multiBar.js"; } }

        public static string NVD3ModelMultiBarChart { get { return "~/Scripts/novus-nvd3/src/models/multiBarChart.js"; } }

        public static string FileUploadIframeTransport { get { return "~/Scripts/jQueryFileUpload/jquery.iframe-transport.js"; } }

        public static string FileUpload { get { return "~/Scripts/jQueryFileUpload/jquery.fileupload.js"; } }

        public static string FileUploadUI { get { return "~/Scripts/jQueryFileUpload/jquery.fileupload-ui.js"; } }

        public static string WidgetUI { get { return "~/Scripts/jQueryFileUpload/jquery.ui.widget.js"; } }

        public static string FileUploadProgress { get { return "~/Scripts/jQueryFileUpload/jquery.fileupload-process.js"; } }

        public static string FileUploadValidate { get { return "~/Scripts/jQueryFileUpload/jquery.fileupload-validate.js"; } }

        public static string Bowser { get { return "~/Scripts/bowser.js"; } }

		public static string QuidgestSearchSuggester { get { return "~/Scripts/quidgest/quidgest.qsearchSuggester.js"; } }

		public static string QuidgestFlashes { get { return "~/Scripts/quidgest/quidgest.flashes.js"; } }

		public static string QuidgestTableFor { get { return "~/Scripts/quidgest/quidgest.tableFor.js"; } }

		public static string QuidgestMenus { get { return "~/Scripts/quidgest/quidgest.menus.js"; } }

		public static string QuidgestMultiform { get { return "~/Scripts/quidgest/quidgest.multiform.js"; } }

		public static string QuidgestModal { get { return "~/Scripts/quidgest/quidgest.modals.js"; } }

		public static string QuidgestClientSidePersistence { get { return "~/Scripts/quidgest/quidgest.client.persistence.js"; } }

		public static string BootstrapModal { get { return "~/Scripts/bootstrap/bootstrap-modal.js"; } }

		public static string BootstrapModalManager { get { return "~/Scripts/bootstrap/bootstrap-modalmanager.js"; } }

		public static string MagnificPopup { get { return "~/Scripts/jquery.magnific-popup.js"; } }

		public static string QuidgestGlobalFunctions { get { return "~/Scripts/quidgest/quidgest.globalFunctions.js"; } }

		public static string QuidgestMsq { get { return "~/Scripts/quidgest/quidgest.msq.js"; } }
		
		public static string QuidgestCav { get { return "~/Scripts/quidgest/quidgest.cav.js"; } }

		public static string QuidgestFunctions { get { return "~/Scripts/quidgest/quidgest.functions.js"; } }

		public static string QuidgestControls { get { return "~/Scripts/quidgest/quidgest.controls.js"; } }

		public static string QuidgestDBDocument { get { return "~/Scripts/quidgest/quidgest.dbdocument.js"; } }
		
		public static string QuidgestDBDocumentLaunch { get { return "~/Scripts/quidgest/bundle.js"; } }

		public static string QuidgestHistorial { get { return "~/Scripts/quidgest/quidgest.historial.js"; } }

        public static string QuidgestValidate { get { return "~/Scripts/quidgest/quidgest.validate.js"; } }

        public static string QuidgestLocalStorage { get { return "~/Scripts/quidgest/quidgest.localStorage.js"; } }

        public static string QuidgestDebug { get { return "~/Scripts/quidgest/quidgest.debug.js"; } }

        public static string QuidgestAlerts { get { return "~/Scripts/quidgest/quidgest.alerts.js"; } }
        
        public static string QuidgestDashboard { get { return "~/Scripts/quidgest/quidgest.dashboard.js"; } }

        public static string JQuery3 { get { return "~/Scripts/jQuery3/jquery-3.7.1.js"; } }

        public static string Bootstrap4 { get { return "~/Scripts/bootstrap4/bootstrap.min.js"; } }

        public static string Bootbox { get { return "~/Scripts/bootbox/bootbox.all.min.js"; } }

        public static string Popper { get { return "~/Scripts/popper.js"; } }

        public static string Moment { get { return "~/Scripts/moment/moment.min.js"; } }

        public static string MomentTimeZone { get { return "~/Scripts/moment/moment-timezone.min.js"; } }

        public static string JQueryLazy { get { return "~/Scripts/jQuery3/jquery.lazy.js"; } }

        public static string JQueryLazyPluginScript { get { return "~/Scripts/jQuery3/jquery.lazy.script.js"; } }

        public static string JQueryMagnificPopUp { get { return "~/Scripts/jQuery3/jquery.magnific-popup.js"; } }

        public static string JQueryWizard { get { return "~/Scripts/jQuery3/jquery.wizard.js"; } }
		
		public static string jqueryMultiSelect { get { return "~/Scripts/jquery.multi-select.js"; } }
		
        public static string jqueryQuicksearch { get { return "~/Scripts/jquery.quicksearch.js"; } }

        #endregion

        #region Cache
        //JFG 2017-07-13 It seems to be no need for lock on these 2 dictionaries, because there are no updates/deletes and default values are filled in at the first request
        // at most there can be to simultaneous Add with the same key.
        //BUT they are still being used just for good measure, needs to be better evaluated
        private static ConcurrentDictionary<string, KeyValuePair<string, string>> cache_GlobalizeCultures = new ConcurrentDictionary<string, KeyValuePair<string, string>>();
        private static ConcurrentDictionary<string, KeyValuePair<string, string>> cache_MomentLocals = new ConcurrentDictionary<string, KeyValuePair<string, string>>();

        /// <summary>
        /// URL for the specific Globalize culture
        /// </summary>
        public static KeyValuePair<string, string> GlobalizeCulture
        {
            get
            {
                KeyValuePair<string, string> GlobalizeCulture = default(KeyValuePair<string, string>);
                //Check if exists in cache
                if (!cache_GlobalizeCultures.TryGetValue(CultureInfo.CurrentCulture.Name, out GlobalizeCulture))
                {
                    // Determine culture - GUI culture for preference, user selected culture as fallback
                    const string filePattern = "~/Scripts/jQuery3/jquery.globalize/cultures/globalize.culture.{0}.js";
                    var currentCulture = CultureInfo.CurrentCulture;
                    var cultureToUse = "en-GB"; //Default regionalisation to use

                    //Try to pick a more appropriate regionalisation
                    if (File.Exists(HostingEnvironment.MapPath(string.Format(filePattern, currentCulture.Name)))) //First try for a globalize.culture.en-GB.js style file
                       cultureToUse = currentCulture.Name;
                    else if (File.Exists(HostingEnvironment.MapPath(string.Format(filePattern, currentCulture.TwoLetterISOLanguageName)))) //That failed; now try for a globalize.culture.en.js style file
                        cultureToUse = currentCulture.TwoLetterISOLanguageName;

                    GlobalizeCulture = new KeyValuePair<string, string>(cultureToUse, string.Format(filePattern, cultureToUse));

                    cache_GlobalizeCultures.TryAdd(currentCulture.Name, GlobalizeCulture);
                }

                return GlobalizeCulture;
            }
        }

        /// <summary>
        /// URL for the specific Moment Local(Culture)
        /// </summary>
        public static KeyValuePair<string, string> MomentLocal
        {
            get
            {
               KeyValuePair<string, string> MomentLocal = default(KeyValuePair<string, string>);
                //Check if exists in cache
                if (!cache_MomentLocals.TryGetValue(CultureInfo.CurrentCulture.Name, out MomentLocal)) {
                    // Determine culture - GUI culture for preference, user selected culture as fallback
                    const string filePattern = "~/Scripts/moment/locale/{0}.js";
                    var currentCulture = CultureInfo.CurrentCulture;
                    var cultureToUse = string.Empty;

                    //Try to pick a more appropriate regionalisation
                    if (File.Exists(HostingEnvironment.MapPath(string.Format(filePattern, currentCulture.Name))))
                        cultureToUse = currentCulture.Name.ToLower();
                    else if (File.Exists(HostingEnvironment.MapPath(string.Format(filePattern, currentCulture.TwoLetterISOLanguageName))))
                        cultureToUse = currentCulture.TwoLetterISOLanguageName;

                    MomentLocal = new KeyValuePair<string, string>(cultureToUse, string.IsNullOrEmpty(cultureToUse) ? string.Empty : string.Format(filePattern, cultureToUse));

                    cache_MomentLocals.TryAdd(currentCulture.Name, MomentLocal);
                }

                return MomentLocal;
            }
        }
        #endregion
    }
}
