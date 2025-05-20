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
		private static readonly NavigationLocation ACTION_GQT_MENU_451 = new NavigationLocation("ARTICLES59822", "GQT_Menu_451", "Item") { vueRouteName = "menu-GQT_451" };
		private static readonly NavigationLocation ACTION_GQT_MENU_4611 = new NavigationLocation("ARTICLES__WAREH__WAR35760", "GQT_Menu_4611", "Item") { vueRouteName = "menu-GQT_4611" };
		private static readonly NavigationLocation ACTION_GQT_MENU_UNUSED_ITEMS = new NavigationLocation("ARTICLES59822", "GQT_Menu_UNUSED_ITEMS", "Item") { vueRouteName = "menu-GQT_UNUSED_ITEMS" };
		private static readonly NavigationLocation ACTION_PTN_MENU_121 = new NavigationLocation("ARTICLES59822", "PTN_Menu_121", "Item") { vueRouteName = "menu-PTN_121" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MC_F = new NavigationLocation("ARTICLES59822", "PTN_Menu_LIST_DB_MC_F", "Item") { vueRouteName = "menu-PTN_LIST_DB_MC_F" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_MC_F = new NavigationLocation("ARTICLES59822", "PTN_Menu_LIST_DB_MB_MC_F", "Item") { vueRouteName = "menu-PTN_LIST_DB_MB_MC_F" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MC_R = new NavigationLocation("ARTICLES59822", "PTN_Menu_LIST_DB_MC_R", "Item") { vueRouteName = "menu-PTN_LIST_DB_MC_R" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_MC_R = new NavigationLocation("ARTICLES59822", "PTN_Menu_LIST_DB_MB_MC_R", "Item") { vueRouteName = "menu-PTN_LIST_DB_MB_MC_R" };
        #endregion

        #region Menus


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
        // GET: /Item/GQT_Menu_UNUSED_ITEMS
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_UNUSED_ITEMS")]
        public ActionResult GQT_Menu_UNUSED_ITEMS(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_UNUSED_ITEMS_ViewModel model = new GQT_Menu_UNUSED_ITEMS_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_UNUSED_ITEMS");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_UNUSED_ITEMS.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_UNUSED_ITEMS);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_UNUSED_ITEMS.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_UNUSED_ITEMS, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_UNUSED_ITEMS.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("item.valid", "0");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET UNUSED_ITEMS]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_UNUSED_ITEMS_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
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
// USE /[MANUAL GQT OVERRQEXPORT UNUSED_ITEMS]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_UNUSED_ITEMS.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_UNUSED_ITEMS", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_UNUSED_ITEMS_Partial", model);
        }



        //
        // GET: /Item/PTN_Menu_121
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_121")]
        public ActionResult PTN_Menu_121(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_121_ViewModel model = new PTN_Menu_121_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_121");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_121.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_121);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_121.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_121, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_121.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 121]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "PTN_Menu_121_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
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
// USE /[MANUAL PTN OVERRQEXPORT 121]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_PTN_MENU_121.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_121", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_121_Partial", model);
        }



        //
        // GET: /Item/PTN_Menu_LIST_DB_MC_F
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MC_F")]
        public ActionResult PTN_Menu_LIST_DB_MC_F(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MC_F_ViewModel model = new PTN_Menu_LIST_DB_MC_F_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MC_F");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MC_F.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_F);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MC_F.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_F, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MC_F.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MC_F]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MC_F", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MC_F_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_LIST_DB_MC_F
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_LIST_DB_MC_F(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "MLLIST_DB_MC_F");
            Navigation.SetValue("item", id);
            if(item != null && (((Logical)item.ValValid)==0))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artigval_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && (((Logical)item.ValValid)==1))
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
        // GET: /Item/PTN_Menu_LIST_DB_MB_MC_F
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MB_MC_F")]
        public ActionResult PTN_Menu_LIST_DB_MB_MC_F(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MB_MC_F_ViewModel model = new PTN_Menu_LIST_DB_MB_MC_F_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_MC_F");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_MC_F.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_F);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_MC_F.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_F, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_MC_F.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MB_MC_F]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MB_MC_F", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MB_MC_F_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_3811
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_3811(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "MLLIST_DB_MB_MC_F");
            Navigation.SetValue("item", id);
            if(item != null && (((Logical)item.ValValid)==0))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Artigval_" + formMode, "Item", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && (((Logical)item.ValValid)==1))
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
        // GET: /Item/PTN_Menu_LIST_DB_MC_R
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MC_R")]
        public ActionResult PTN_Menu_LIST_DB_MC_R(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MC_R_ViewModel model = new PTN_Menu_LIST_DB_MC_R_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MC_R");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MC_R.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_R);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MC_R.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_R, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MC_R.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MC_R]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MC_R", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MC_R_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_LIST_DB_MC_R
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_LIST_DB_MC_R(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "MLLIST_DB_MC_R");
            Navigation.SetValue("item", id);
            if(item != null && (((Logical)item.ValValid)==0))
            {
                return RedirectToAction("PTN_Menu_LIST_DB_MC_R_MenuR_OPENARTIGVAL", "Item", new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && (((Logical)item.ValValid)==1))
            {
                return RedirectToAction("PTN_Menu_LIST_DB_MC_R_MenuR_OPENARTIGINV", "Item", new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                return new EmptyResult();
            }
        }



        //
        // GET: /Item/PTN_Menu_LIST_DB_MB_MC_R
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MB_MC_R")]
        public ActionResult PTN_Menu_LIST_DB_MB_MC_R(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MB_MC_R_ViewModel model = new PTN_Menu_LIST_DB_MB_MC_R_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_MC_R");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_MC_R.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_R);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_MC_R.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_R, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_MC_R.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MB_MC_R]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MB_MC_R", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MB_MC_R_Partial", model);
        }

        //
        // GET: /Item/PTN_MenuMC_3A11
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_3A11(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Item item = Models.Item.Find(id, "MLLIST_DB_MB_MC_R");
            Navigation.SetValue("item", id);
            if(item != null && (((Logical)item.ValValid)==0))
            {
                return RedirectToAction("PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGVAL", "Item", new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(item != null && (((Logical)item.ValValid)==1))
            {
                return RedirectToAction("PTN_Menu_LIST_DB_MB_MC_R_MenuR_OPENARTIGINV", "Item", new { id = item.ValCoditem, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                return new EmptyResult();
            }
        }




		#endregion



    }
}