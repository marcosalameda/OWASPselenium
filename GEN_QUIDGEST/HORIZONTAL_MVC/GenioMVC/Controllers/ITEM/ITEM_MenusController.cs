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
using GenioMVC.ViewModels.Item;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
    public partial class ItemController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_131 = new NavigationLocation("ARTICLES59822", "PTN_Menu_131", "Item") { vueRouteName = "menu-PTN_131" };
		private static readonly NavigationLocation ACTION_PTN_MENU_141 = new NavigationLocation("ARTICLES59822", "PTN_Menu_141", "Item") { vueRouteName = "menu-PTN_141" };
		private static readonly NavigationLocation ACTION_PTN_MENU_221 = new NavigationLocation("ARTICLES59822", "PTN_Menu_221", "Item") { vueRouteName = "menu-PTN_221" };
		private static readonly NavigationLocation ACTION_GQT_MENU_451 = new NavigationLocation("ARTICLES59822", "GQT_Menu_451", "Item") { vueRouteName = "menu-GQT_451" };
		private static readonly NavigationLocation ACTION_GQT_MENU_4611 = new NavigationLocation("ARTICLES__WAREH__WAR35760", "GQT_Menu_4611", "Item") { vueRouteName = "menu-GQT_4611" };
		private static readonly NavigationLocation ACTION_GQT_MENU_4A1 = new NavigationLocation("ARTICLES59822", "GQT_Menu_4A1", "Item") { vueRouteName = "menu-GQT_4A1" };
        #endregion

        #region Menus


        //
        // GET: /Item/PTN_Menu_131
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_131")]
        public ActionResult PTN_Menu_131(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_131_ViewModel model = new PTN_Menu_131_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_131");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_131.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_131);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_131.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_131, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_131.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 131]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_131", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_131_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_131
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_131(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "ML131");
            Navigation.SetValue("item", id);
            if(item != null && ((item.ValValid ? 1 : 0)==0))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artigval_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && ((item.ValValid ? 1 : 0)==1))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artiginv_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                return new EmptyResult();
            }
        }



        //
        // GET: /Item/PTN_Menu_141
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_141")]
        public ActionResult PTN_Menu_141(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_141_ViewModel model = new PTN_Menu_141_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_141");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_141.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_141);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_141.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_141, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_141.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 141]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_141", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_141_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_1411
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_1411(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "ML141");
            Navigation.SetValue("item", id);
            if(item != null && ((item.ValValid ? 1 : 0)==0))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artigval_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && ((item.ValValid ? 1 : 0)==1))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artiginv_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                return new EmptyResult();
            }
        }



        //
        // GET: /Item/PTN_Menu_221
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_221")]
        public ActionResult PTN_Menu_221(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_221_ViewModel model = new PTN_Menu_221_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_221");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_221.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_221);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_221.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_221, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_221.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 221]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "PTN_Menu_221_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL PTN OVERRQEXPORT 221]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_PTN_MENU_221.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_221", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_221_Partial", model);
        }



        //
        // GET: /Item/GQT_Menu_451
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_451")]
        public ActionResult GQT_Menu_451(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_451_ViewModel model = new GQT_Menu_451_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_451");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_451.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_451);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_451.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_451, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_451.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 451]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_451_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 451]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_451.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_451", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_451_Partial", model);
        }



        //
        // GET: /Item/GQT_Menu_4611
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_4611")]
        public ActionResult GQT_Menu_4611(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_4611_ViewModel model = new GQT_Menu_4611_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_4611");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_4611.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_4611))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_4611);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_4611.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_4611, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_4611.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["wareh"]))
                Navigation.SetValue("wareh", querystring["wareh"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 4611]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_4611_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 4611]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_4611.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_4611", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_4611_Partial", model);
        }



        //
        // GET: /Item/GQT_Menu_4A1
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_4A1")]
        public ActionResult GQT_Menu_4A1(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_4A1_ViewModel model = new GQT_Menu_4A1_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_4A1");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_item");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_4A1.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_4A1);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_4A1.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_4A1, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_4A1.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 4A1]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_4A1_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 4A1]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_4A1.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_4A1", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_4A1_Partial", model);
        }




		#endregion



    }
}