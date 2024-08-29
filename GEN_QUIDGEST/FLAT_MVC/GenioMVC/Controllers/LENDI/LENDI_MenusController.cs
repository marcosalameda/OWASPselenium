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
using GenioMVC.ViewModels.Lendi;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
    public partial class LendiController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_GQT_MENU_111 = new NavigationLocation("LENDING18782", "GQT_Menu_111", "Lendi") { vueRouteName = "menu-GQT_111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1211 = new NavigationLocation("LENDING18782", "GQT_Menu_1211", "Lendi") { vueRouteName = "menu-GQT_1211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1311 = new NavigationLocation("LENDING18782", "GQT_Menu_1311", "Lendi") { vueRouteName = "menu-GQT_1311" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_141 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_141", "Lendi") { vueRouteName = "menu-GQT_141" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1411 = new NavigationLocation("LENDING18782", "GQT_Menu_1411", "Lendi") { vueRouteName = "menu-GQT_1411" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_151 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_151", "Lendi") { vueRouteName = "menu-GQT_151" };
		private static readonly NavigationLocation ACTION_GQT_MENU_DEVOL = new NavigationLocation("OUT_OF_DATE_LENDINGS05506", "GQT_Menu_DEVOL", "Lendi") { vueRouteName = "menu-GQT_DEVOL" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1711 = new NavigationLocation("LENDINGS_OF__EQUIP__22198", "GQT_Menu_1711", "Lendi") { vueRouteName = "menu-GQT_1711" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3111 = new NavigationLocation("LENDING18782", "PTN_Menu_3111", "Lendi") { vueRouteName = "menu-PTN_3111" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3121 = new NavigationLocation("LENDING18782", "PTN_Menu_3121", "Lendi") { vueRouteName = "menu-PTN_3121" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3E1 = new NavigationLocation("LENDING18782", "PTN_Menu_3E1", "Lendi") { vueRouteName = "menu-PTN_3E1" };
        #endregion

        #region Menus


        //
        // GET: /Lendi/GQT_Menu_111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_111")]
        public ActionResult GQT_Menu_111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_111_ViewModel model = new GQT_Menu_111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 111]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_111_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 111]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_111.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }
            if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
            {
				string importType =  querystring["ImportType"];
				string file = "GQT_Menu_111_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_GQT_MENU_111.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, importType), JsonRequestBehavior.AllowGet);
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_111_Partial", model);
        }

        //
        // POST: /Lendi/GQT_Menu_111_UploadFile
        [AuthorizeForUsers]
        [HttpPost]
        public ActionResult GQT_Menu_111_UploadFile(string importType, string qqfile) {
            GQT_Menu_111_ViewModel model = new GQT_Menu_111_ViewModel(Navigation);

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            List<CSGenioAlendi> rows = new List<CSGenioAlendi>();
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

                rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAlendi>(columns, importType, fileBytes);

                sp.openTransaction();
                int lineNumber = 0;
                foreach (CSGenioAlendi importRow in rows)
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
        // GET: /Lendi/GQT_Menu_1211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_1211")]
        public ActionResult GQT_Menu_1211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_1211_ViewModel model = new GQT_Menu_1211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_1211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_1211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_1211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 1211]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_1211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 1211]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_1211.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_1211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_1211_Partial", model);
        }



        //
        // GET: /Lendi/GQT_Menu_1311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_1311")]
        public ActionResult GQT_Menu_1311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_1311_ViewModel model = new GQT_Menu_1311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_1311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_1311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_1311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


 
			//History Limit
            if("" != null)
                Navigation.SetValue("pess1", "");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 1311]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_1311_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 1311]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_1311.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_1311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_1311_Partial", model);
        }






        //
        // GET: /Lendi/GQT_Menu_1411
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_1411")]
        public ActionResult GQT_Menu_1411(DateTime? minLendiValStart = null, DateTime? maxLendiValStart = null, bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            if (GlobalFunctions.emptyD(minLendiValStart) == 1 && Navigation.GetValue("minLendiValStart") != null)
                minLendiValStart = Navigation.GetDateValue("minLendiValStart").GetValueOrDefault();

            if (GlobalFunctions.emptyD(maxLendiValStart) == 1 && Navigation.GetValue("maxLendiValStart") != null)
                maxLendiValStart = Navigation.GetDateValue("maxLendiValStart").GetValueOrDefault();
            // MH - Compatibilidade com antiga versão dos menus SE / SU
            var ValMinvalue = minLendiValStart;
            var ValMaxvalue = maxLendiValStart;
            GQT_Menu_1411_ViewModel model = new GQT_Menu_1411_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_1411");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1411.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_1411);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1411.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_1411, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1411.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            // SE / SU Limitations
            Navigation.SetValue("minLendiValStart", minLendiValStart);
            Navigation.SetValue("maxLendiValStart", maxLendiValStart);
            // MH - Compatibilidade com antiga versão dos menus SE
            Navigation.SetValue("ValMinvalue", minLendiValStart);
            Navigation.SetValue("ValMaxvalue", maxLendiValStart);

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 1411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_1411", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_1411_Partial", model);
        }






        //
        // GET: /Lendi/GQT_Menu_DEVOL
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_DEVOL")]
        public ActionResult GQT_Menu_DEVOL(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_DEVOL_ViewModel model = new GQT_Menu_DEVOL_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_DEVOL");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_DEVOL.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_DEVOL);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_DEVOL.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_DEVOL, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_DEVOL.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("lendi.returned", "0");
            Navigation.SetValue("lendi.ifoutdt", "1");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET DEVOL]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_DEVOL_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT DEVOL]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_DEVOL.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_DEVOL", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_DEVOL_Partial", model);
        }



        //
        // GET: /Lendi/GQT_Menu_1711
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_1711")]
        public ActionResult GQT_Menu_1711(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_1711_ViewModel model = new GQT_Menu_1711_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_1711");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1711.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_1711))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_1711);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1711.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_1711, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1711.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["equip"]))
                Navigation.SetValue("equip", querystring["equip"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 1711]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_1711", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_1711_Partial", model);
        }



        //
        // GET: /Lendi/PTN_Menu_3111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3111")]
        public ActionResult PTN_Menu_3111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3111_ViewModel model = new PTN_Menu_3111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3111_Partial", model);
        }



        //
        // GET: /Lendi/PTN_Menu_3121
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3121")]
        public ActionResult PTN_Menu_3121(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3121_ViewModel model = new PTN_Menu_3121_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3121");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3121.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3121);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3121.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3121, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3121.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3121]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3121", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3121_Partial", model);
        }



        //
        // GET: /Lendi/PTN_Menu_3E1
        [AuthorizeForUsers]
        [ActionName("PTN_Menu_3E1_Selections")]
        [HttpPost]
        public ActionResult PTN_Menu_3E1_Selections(string[] ids)
        {
            Navigation.ClearValue("lendi_Selections");
            if(ids != null && ids.Length != 0)
                Navigation.SetValue("lendi_Selections", ids);
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3E1")]
        public ActionResult PTN_Menu_3E1(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3E1_ViewModel model = new PTN_Menu_3E1_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3E1");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_lendi");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3E1.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3E1);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3E1.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3E1, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3E1.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3E1]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3E1", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3E1_Partial", model);
        }




		#endregion

		#region Limit Seletions (SE // SU)

        //
        // GET: /Lendi/GQT_MenuSE_141
        [AuthorizeForUsers]
        public ActionResult GQT_MenuSE_141()
        {
            if (Navigation.CurrentLevel != null)
            {
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
            }

            GQT_MenuSE_141_ViewModel model = new GQT_MenuSE_141_ViewModel(Navigation);


            return PartialView("GQT_MenuSE_141", model);
        }
        //
        // GET: /Lendi/GQT_MenuSE_151
        [AuthorizeForUsers]
        public ActionResult GQT_MenuSE_151()
        {
            if (Navigation.CurrentLevel != null)
            {
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
            }

            GQT_MenuSE_151_ViewModel model = new GQT_MenuSE_151_ViewModel(Navigation);


            return PartialView("GQT_MenuSE_151", model);
        }

		#endregion


    }
}