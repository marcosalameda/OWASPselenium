using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Models;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Resources;
using Quidgest.Persistence.GenericQuery;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using CSGenio.reporting;
using System.Collections.Specialized;
using Newtonsoft.Json;
using GenioMVC.ViewModels.Produ;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PRODU]/

namespace GenioMVC.Controllers
{
    public partial class ProduController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_WMS_MENU_311 = new NavigationLocation("PRODUCTS34689", "WMS_Menu_311", "Produ") { vueRouteName = "menu-WMS_311" };
		private static readonly NavigationLocation ACTION_WMS_MENU_321 = new NavigationLocation("PRODUCTS34689", "WMS_Menu_321", "Produ") { vueRouteName = "menu-WMS_321" };
        #endregion

        #region Menus


        //
        // GET: /Produ/WMS_Menu_311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_311")]
        public ActionResult WMS_Menu_311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_311_ViewModel model = new WMS_Menu_311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_produ")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_produ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
            CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
            if (result.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest() && !isHomePage)
                    return View("_PermissionError", model: result.Message);
                else
                    return PartialView("_PermissionError", model: result.Message);
            }

            NameValueCollection querystring = Request.Form.Count > 0 ? Request.Form : Request.QueryString;
			if (!isHomePage && !Request.IsAjaxRequest())
            {
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 311]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "WMS_Menu_311_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAprodu> listing = null;
                CriteriaSet conditions = null;
                List<CSGenio.framework.Exports.QColumn> columns = null;
                model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

                // Validate export format
                if (querystring["ExportValidate"] == "true")
                {
                    bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
                    return Json(new { ValidFormat = isValidExport }, JsonRequestBehavior.AllowGet);
                }

				byte[] fileBytes = null;
// USE /[MANUAL WMS OVERRQEXPORT 311]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_WMS_MENU_311.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_311_Partial", model);
        }



        //
        // GET: /Produ/WMS_Menu_321
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_321")]
        public ActionResult WMS_Menu_321(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_321_ViewModel model = new WMS_Menu_321_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_321");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_produ")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_produ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
            CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
            if (result.Status.Equals(CSGenio.framework.Status.E))
            {
                if (!Request.IsAjaxRequest() && !isHomePage)
                    return View("_PermissionError", model: result.Message);
                else
                    return PartialView("_PermissionError", model: result.Message);
            }

            NameValueCollection querystring = Request.Form.Count > 0 ? Request.Form : Request.QueryString;
			if (!isHomePage && !Request.IsAjaxRequest())
            {
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_321.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_321);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_321.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_321, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_321.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 321]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "WMS_Menu_321_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAprodu> listing = null;
                CriteriaSet conditions = null;
                List<CSGenio.framework.Exports.QColumn> columns = null;
                model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

                // Validate export format
                if (querystring["ExportValidate"] == "true")
                {
                    bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
                    return Json(new { ValidFormat = isValidExport }, JsonRequestBehavior.AllowGet);
                }

				byte[] fileBytes = null;
// USE /[MANUAL WMS OVERRQEXPORT 321]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_WMS_MENU_321.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
            {
				string importType =  querystring["ImportType"];
				string file = "WMS_Menu_321_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_WMS_MENU_321.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, importType), JsonRequestBehavior.AllowGet);
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_321", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_321_Partial", model);
        }

        //
        // POST: /Produ/WMS_Menu_321_UploadFile
        [AuthorizeForUsers]
        [HttpPost]
        public ActionResult WMS_Menu_321_UploadFile(string importType, string qqfile) {
            WMS_Menu_321_ViewModel model = new WMS_Menu_321_ViewModel(Navigation);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            List<CSGenioAprodu> rows = new List<CSGenioAprodu>();
            List<String> results = new List<String>();

            try
            {
                var stream = Request.InputStream;
                if (String.IsNullOrEmpty(Request["qqfile"]))
                {
                    // IE
                    System.Web.HttpPostedFileBase postedFile = Request.Files[0];
                    stream = postedFile.InputStream;
                }

                byte[] fileBytes = new byte[Request.ContentLength];
                var data = Request.InputStream.Read(fileBytes, 0, Convert.ToInt32(Request.ContentLength));

                List<CSGenio.framework.Exports.QColumn> columns = null;
                model.LoadToExportTemplate(out columns);

                rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAprodu>(columns, importType, fileBytes);

                sp.openTransaction();
                int lineNumber = 0;
                foreach (CSGenioAprodu importRow in rows)
                {
                    try
                    {
                        lineNumber++;
                        importRow.ValidateIfIsNull = true;
                        importRow.insertPseud(UserContext.Current.PersistentSupport);
                        importRow.change(UserContext.Current.PersistentSupport, (CriteriaSet)null);
                    }
                    catch (GenioException ex)
                    {
                        string lineNumberMsg = String.Format(Resources.Resources.ERROR_IN_LINE__0__45377 + " ", lineNumber);
                        ex.UserMessage = lineNumberMsg + ex.UserMessage;
                        throw ex;
                    }
                }
                sp.closeTransaction();

                results.Add(string.Format(Resources.Resources._0__LINHAS_IMPORTADA15937, rows.Count));

                return Json(new { success = true, lines = results, msg = Resources.Resources.FICHEIRO_IMPORTADO_C51013 }, "application/json");
            }
            catch (GenioException e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                CSGenio.framework.Log.Error(e.Message);
                results.Add(e.UserMessage);

                return Json(new { success = false, errors = results, msg = Resources.Resources.ERROR_IMPORTING_FILE09339 }, "application/json");
            }
        }



		#endregion



    }
}