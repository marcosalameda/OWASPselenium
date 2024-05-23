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
using GenioMVC.ViewModels.Cntry;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CNTRY]/

namespace GenioMVC.Controllers
{
    public partial class CntryController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_IMO_MENU_131 = new NavigationLocation("COUNTRIES64527", "IMO_Menu_131", "Cntry") { vueRouteName = "menu-IMO_131" };
		private static readonly NavigationLocation ACTION_IMO_MENU_211 = new NavigationLocation("COUNTRIES64527", "IMO_Menu_211", "Cntry") { vueRouteName = "menu-IMO_211" };
		private static readonly NavigationLocation ACTION_IMO_MENU_231 = new NavigationLocation("COUNTRIES64527", "IMO_Menu_231", "Cntry") { vueRouteName = "menu-IMO_231" };
        #endregion

        #region Menus


        //
        // GET: /Cntry/IMO_Menu_131
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_131")]
        public ActionResult IMO_Menu_131(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_131_ViewModel model = new IMO_Menu_131_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_131");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_131.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_131);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_131.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_131, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_131.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 131]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "IMO_Menu_131_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAcntry> listing = null;
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
// USE /[MANUAL IMO OVERRQEXPORT 131]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_IMO_MENU_131.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
            {
				string importType =  querystring["ImportType"];
				string file = "IMO_Menu_131_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_IMO_MENU_131.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, importType), JsonRequestBehavior.AllowGet);
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodcntry;
				var navKey = "cntry";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("IMO_Menu_1311", "Propr", new { nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("IMO_Menu_131", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_131_Partial", model);
        }

        //
        // POST: /Cntry/IMO_Menu_131_UploadFile
        [AuthorizeForUsers]
        [HttpPost]
        public ActionResult IMO_Menu_131_UploadFile(string importType, string qqfile) {
            IMO_Menu_131_ViewModel model = new IMO_Menu_131_ViewModel(Navigation);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            List<CSGenioAcntry> rows = new List<CSGenioAcntry>();
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

                rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAcntry>(columns, importType, fileBytes);

                sp.openTransaction();
                int lineNumber = 0;
                foreach (CSGenioAcntry importRow in rows)
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


        //
        // GET: /Cntry/IMO_Menu_211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_211")]
        public ActionResult IMO_Menu_211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_211_ViewModel model = new IMO_Menu_211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 211]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "IMO_Menu_211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAcntry> listing = null;
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
// USE /[MANUAL IMO OVERRQEXPORT 211]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_IMO_MENU_211.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
            {
				string importType =  querystring["ImportType"];
				string file = "IMO_Menu_211_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_IMO_MENU_211.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, importType), JsonRequestBehavior.AllowGet);
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_211_Partial", model);
        }

        //
        // POST: /Cntry/IMO_Menu_211_UploadFile
        [AuthorizeForUsers]
        [HttpPost]
        public ActionResult IMO_Menu_211_UploadFile(string importType, string qqfile) {
            IMO_Menu_211_ViewModel model = new IMO_Menu_211_ViewModel(Navigation);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            List<CSGenioAcntry> rows = new List<CSGenioAcntry>();
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

                rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAcntry>(columns, importType, fileBytes);

                sp.openTransaction();
                int lineNumber = 0;
                foreach (CSGenioAcntry importRow in rows)
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


        //
        // GET: /Cntry/IMO_Menu_231
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_231")]
        public ActionResult IMO_Menu_231(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_231_ViewModel model = new IMO_Menu_231_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_231");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_231.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_231);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_231.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_231, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_231.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 231]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "IMO_Menu_231_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAcntry> listing = null;
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
// USE /[MANUAL IMO OVERRQEXPORT 231]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_IMO_MENU_231.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
            {
				string importType =  querystring["ImportType"];
				string file = "IMO_Menu_231_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_IMO_MENU_231.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, importType), JsonRequestBehavior.AllowGet);
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_231", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_231_Partial", model);
        }

        //
        // POST: /Cntry/IMO_Menu_231_UploadFile
        [AuthorizeForUsers]
        [HttpPost]
        public ActionResult IMO_Menu_231_UploadFile(string importType, string qqfile) {
            IMO_Menu_231_ViewModel model = new IMO_Menu_231_ViewModel(Navigation);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            List<CSGenioAcntry> rows = new List<CSGenioAcntry>();
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

                rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAcntry>(columns, importType, fileBytes);

                sp.openTransaction();
                int lineNumber = 0;
                foreach (CSGenioAcntry importRow in rows)
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