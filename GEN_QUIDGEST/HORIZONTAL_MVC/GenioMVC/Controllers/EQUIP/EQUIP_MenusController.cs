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
using GenioMVC.ViewModels.Equip;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
    public partial class EquipController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_STY_MENU_ACCORD = new NavigationLocation("EQUIPMENT03632", "STY_Menu_ACCORD", "Equip") { vueRouteName = "menu-STY_ACCORD" };
		private static readonly NavigationLocation ACTION_STY_MENU_GROUPBOX = new NavigationLocation("GROUPBOX00384", "STY_Menu_GROUPBOX", "Equip") { vueRouteName = "menu-STY_GROUPBOX" };
		private static readonly NavigationLocation ACTION_STY_MENU_TABLE = new NavigationLocation("TABLE15475", "STY_Menu_TABLE", "Equip") { vueRouteName = "menu-STY_TABLE" };
		private static readonly NavigationLocation ACTION_STY_MENU_FULLCALENDAR = new NavigationLocation("EQUIPMENT03632", "STY_Menu_FULLCALENDAR", "Equip") { vueRouteName = "menu-STY_FULLCALENDAR" };
		private static readonly NavigationLocation ACTION_STY_MENU_GOOGLEMAPS = new NavigationLocation("LISTAGEM45924", "STY_Menu_GOOGLEMAPS", "Equip") { vueRouteName = "menu-STY_GOOGLEMAPS" };
		private static readonly NavigationLocation ACTION_PTN_MENU_441 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_441", "Equip") { vueRouteName = "menu-PTN_441" };
		private static readonly NavigationLocation ACTION_PTN_MENU_451 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_451", "Equip") { vueRouteName = "menu-PTN_451" };
		private static readonly NavigationLocation ACTION_PTN_MENU_521 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_521", "Equip") { vueRouteName = "menu-PTN_521" };
		private static readonly NavigationLocation ACTION_GQT_MENU_171 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_171", "Equip") { vueRouteName = "menu-GQT_171" };
		private static readonly NavigationLocation ACTION_GQT_MENU_211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_211", "Equip") { vueRouteName = "menu-GQT_211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2211", "Equip") { vueRouteName = "menu-GQT_2211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_231 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_231", "Equip") { vueRouteName = "menu-GQT_231" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2411 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2411", "Equip") { vueRouteName = "menu-GQT_2411" };
		private static readonly NavigationLocation ACTION_GQT_MENU_251 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_251", "Equip") { vueRouteName = "menu-GQT_251" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C11 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C11", "Equip") { vueRouteName = "menu-GQT_2C11" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C211", "Equip") { vueRouteName = "menu-GQT_2C211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C311 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C311", "Equip") { vueRouteName = "menu-GQT_2C311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D111 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2D111", "Equip") { vueRouteName = "menu-GQT_2D111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D2111 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2D2111", "Equip") { vueRouteName = "menu-GQT_2D2111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_6211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_6211", "Equip") { vueRouteName = "menu-GQT_6211" };
        #endregion

        #region Menus


        //
        // GET: /Equip/STY_Menu_ACCORD
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_ACCORD")]
        public ActionResult STY_Menu_ACCORD(bool allSelected = false)
        {
			int perPage = 10;

            STY_Menu_ACCORD_ViewModel model = new STY_Menu_ACCORD_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_ACCORD");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_ACCORD.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_ACCORD);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_ACCORD.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_ACCORD, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_ACCORD.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.showrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET ACCORD]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "STY_Menu_ACCORD_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAequip> listing = null;
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
// USE /[MANUAL STY OVERRQEXPORT ACCORD]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_STY_MENU_ACCORD.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("ACCORDI"))
                Navigation.GoBack.Remove("ACCORDI");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("ACCORDI"))
                Navigation.OverrideSkipIfJustOne.Remove("ACCORDI");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Accordi_Show", "Equip", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_ACCORD", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_ACCORD_Partial", model);
        }



        //
        // GET: /Equip/STY_Menu_GROUPBOX
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_GROUPBOX")]
        public ActionResult STY_Menu_GROUPBOX(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            STY_Menu_GROUPBOX_ViewModel model = new STY_Menu_GROUPBOX_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_GROUPBOX");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_GROUPBOX.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_GROUPBOX);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_GROUPBOX.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_GROUPBOX, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_GROUPBOX.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.showrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET GROUPBOX]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("GROUPBX"))
                Navigation.GoBack.Remove("GROUPBX");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GROUPBX"))
                Navigation.OverrideSkipIfJustOne.Remove("GROUPBX");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Groupbx_Show", "Equip", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_GROUPBOX", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_GROUPBOX_Partial", model);
        }



        //
        // GET: /Equip/STY_Menu_TABLE
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_TABLE")]
        public ActionResult STY_Menu_TABLE(bool allSelected = false)
        {
			int perPage = 10;

            STY_Menu_TABLE_ViewModel model = new STY_Menu_TABLE_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_TABLE");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_TABLE.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_TABLE);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_TABLE.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_TABLE, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_TABLE.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET TABLE]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("STY_Menu_TABLE", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_TABLE_Partial", model);
        }



        //
        // GET: /Equip/STY_Menu_FULLCALENDAR
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_FULLCALENDAR")]
        public ActionResult STY_Menu_FULLCALENDAR(bool allSelected = false)
        {
			int perPage = 10;

            STY_Menu_FULLCALENDAR_ViewModel model = new STY_Menu_FULLCALENDAR_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_FULLCALENDAR");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_FULLCALENDAR.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_FULLCALENDAR);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_FULLCALENDAR.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_FULLCALENDAR, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_FULLCALENDAR.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.showrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET FULLCALENDAR]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "STY_Menu_FULLCALENDAR_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAequip> listing = null;
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
// USE /[MANUAL STY OVERRQEXPORT FULLCALENDAR]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_STY_MENU_FULLCALENDAR.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("FULLCALE"))
                Navigation.GoBack.Remove("FULLCALE");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("FULLCALE"))
                Navigation.OverrideSkipIfJustOne.Remove("FULLCALE");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Fullcale_Edit", "Equip", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_FULLCALENDAR", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_FULLCALENDAR_Partial", model);
        }



        //
        // GET: /Equip/STY_Menu_GOOGLEMAPS
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_GOOGLEMAPS")]
        public ActionResult STY_Menu_GOOGLEMAPS(bool allSelected = false)
        {
			int perPage = 10;

            STY_Menu_GOOGLEMAPS_ViewModel model = new STY_Menu_GOOGLEMAPS_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_GOOGLEMAPS");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_GOOGLEMAPS.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_GOOGLEMAPS);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_GOOGLEMAPS.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_GOOGLEMAPS, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_GOOGLEMAPS.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.showrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET GOOGLEMAPS]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("GMAPS"))
                Navigation.GoBack.Remove("GMAPS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GMAPS"))
                Navigation.OverrideSkipIfJustOne.Remove("GMAPS");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Gmaps_Show", "Equip", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_GOOGLEMAPS", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_GOOGLEMAPS_Partial", model);
        }



        //
        // GET: /Equip/PTN_Menu_441
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_441")]
        public ActionResult PTN_Menu_441(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_441_ViewModel model = new PTN_Menu_441_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_441");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_441.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_441);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_441.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_441, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_441.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 441]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_441", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_441_Partial", model);
        }



        //
        // GET: /Equip/PTN_Menu_451
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_451")]
        public ActionResult PTN_Menu_451(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_451_ViewModel model = new PTN_Menu_451_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_451");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_451.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_451);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_451.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_451, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_451.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 451]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_451", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_451_Partial", model);
        }



        //
        // GET: /Equip/PTN_Menu_521
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_521")]
        public ActionResult PTN_Menu_521(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_521_ViewModel model = new PTN_Menu_521_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_521");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_521.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_521);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_521.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_521, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_521.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 521]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_521", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_521_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_171
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_171")]
        public ActionResult GQT_Menu_171(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_171_ViewModel model = new GQT_Menu_171_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_171");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_171.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_171);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_171.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_171, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_171.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 171]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_171_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAequip> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 171]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_171.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_171", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_171_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_211")]
        public ActionResult GQT_Menu_211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_211_ViewModel model = new GQT_Menu_211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 211]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAequip> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 211]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_211.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_211_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_2211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2211")]
        public ActionResult GQT_Menu_2211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2211_ViewModel model = new GQT_Menu_2211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.bought", "1");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2211]/

            // Table List Export - check if user is exporting the Qlisting
            if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
            {
				string exportType = querystring["ExportType"];
                string file = "GQT_Menu_2211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
                ListingMVC<CSGenioAequip> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 2211]/
                fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_2211.Name);

                QCache.Instance.ExportFiles.Put(file, fileBytes);
                return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]), JsonRequestBehavior.AllowGet);
            }

			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2211_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_231
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_231")]
        public ActionResult GQT_Menu_231(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_231_ViewModel model = new GQT_Menu_231_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_231");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_231.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_231);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_231.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_231, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_231.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 231]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_231", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_231_Partial", model);
        }
        /// <summary>
        /// GET/POST: /Equip/GQT_Menu_231
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <param name="dest_id"></param>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_231_Execute(string[] selected_ids, string dest_id, Dictionary<string, string> queryParams, bool allSelected = false)
        {
            GQT_Menu_231_ViewModel menuViewModel = new GQT_Menu_231_ViewModel(Navigation);
            CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);

            if (result.Status.Equals(CSGenio.framework.Status.E))
                return Json(new { Success = false,  Message = result.Message });

            if((selected_ids == null && !allSelected) || string.IsNullOrEmpty(dest_id))
            {
                return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });
            }

            var alternativeRedirect = string.Empty;

            //Create progress object
            this.Navigation.SetValue("ProgressReport_ML231", new ProgressReport());

            //Reference it so it can be used in the thread below
            ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML231");
            try
            {
                NavigationContext navCtx = Navigation.Clone(); //Clone Navigation
                NameValueCollection parameters;

                //Fetch and format the parameters
				if (queryParams != null && queryParams.Count() > 0)
					parameters = FormatQueryString(queryParams);
				else
					parameters = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_231");

                //Get CriteriaSet
				CriteriaSet crs = menuViewModel.BuildCriteriaSet(parameters, out bool hasAllRequiredLimits);

                UserContext userCtx = UserContext.Current;
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    PersistentSupport sp = PersistentSupport.getPersistentSupport(userCtx.User.Year, userCtx.User.Name);
                    try
                    {
                        sp.openTransaction();

                        progress.Report("GQT_Menu_231", 0);
                        SelectQuery query;
                        if (allSelected)
                        {
                            /* Build subquery with custom CriteriaSet */
                            SelectQuery allIds = new SelectQuery()
                            .Select(CSGenioAequip.FldCodequip)
                            .From(CSGenio.business.Area.AreaEQUIP);

                            //Fetch Current Area
                            CSGenio.business.Area area = CSGenio.business.Area.createArea("equip", userCtx.User, userCtx.User.CurrentModule);

                            //Add Related Areas to Query Joins
                            QueryUtils.SetInnerJoins(new[] { "EQUIP.FldCodequip" }, crs, area, allIds);
                            allIds.Where(crs);
                            /* -------------------------------------- */

                            //Replace the selected rows array
                            DataMatrix dm = sp.Execute(allIds);
                            selected_ids = new string[dm.NumRows];
                            for (int i = 0; i < dm.NumRows; i++)
                            {
                                if(!string.IsNullOrEmpty(dm.GetKey(i, 0).ToString()))
                                    selected_ids[i] = dm.GetKey(i, 0).ToString();
                            }

                            //Run the main query
                            query = new SelectQuery()
                            .Select(CSGenioAmovim.FldCodequip)
                            .From(CSGenio.business.Area.AreaMOVIM)
                            .Where(CriteriaSet.And()
                                .Equal(CSGenioAmovim.FldCodrooms, dest_id)
                                .In(CSGenioAmovim.FldCodequip, allIds)
                                .Equal(CSGenioAmovim.FldZzstate, 0));
                        }
                        else{
                            query = new SelectQuery()
                            .Select(CSGenioAmovim.FldCodequip)
                            .From(CSGenio.business.Area.AreaMOVIM)
                            .Where(CriteriaSet.And()
                                .Equal(CSGenioAmovim.FldCodrooms, dest_id)
                                .In(CSGenioAmovim.FldCodequip, selected_ids)
                                .Equal(CSGenioAmovim.FldZzstate, 0));
                        }

                        int cnt = 0;
                        List<string> cods = new List<string>();
                        DataMatrix cod = sp.Execute(query);
                        for (int i = 0; i < cod.NumRows; i++)
                            cods.Add(cod.GetString(i, 0));
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_231]/
                        foreach(string selectedId in selected_ids)
                        {
                            //Update Progress
                            progress.Report("GQT_Menu_231", (cnt * 100.0) / selected_ids.Length);

                            if (cods.Contains(selectedId))
                                continue;
                            Models.Movim model = new Models.Movim(userCtx.User);
                            model.LoadKeysFormHistory(navCtx, navCtx.CurrentLevel.Level);
                            model.New(sp, userCtx, "MGQT_Menu_231");
                            // Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
                            model.LoadKeysFormHistory(navCtx, navCtx.CurrentLevel.Level, false);
                            // Preencher as chaves selecionadas
                            model.ValCodequip = selectedId;
                            model.ValCodrooms = dest_id;
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_231]/
                            model.Save(sp);
                            cnt++;
                        }
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_231]/
                        sp.closeTransaction();

                        //Update to 100% Progress
                        progress.Report("GQT_Menu_231", 100);
                        progress.Finished = true;
                    }
                    catch(Exception e)
                    {
                        //Revert changes
                        sp.rollbackTransaction();
                        sp.closeTransaction();

                        //Show error
                        CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                        if (e is GenioException && (e as GenioException).UserMessage != null)
                            error.ErrorResponse = (e as GenioException).UserMessage;
                        else
                            error.ErrorResponse = e.Message;
                        progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
                        progress.Finished = true;
                    }
                });
            }
            catch (ModelNotFoundException e)
            {
                //Show error
                CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                error.ErrorResponse = e.Message;
                progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
                progress.Finished = true;

                return Json(new { Success = false, Message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 });
            }
            catch (Exception e)
            {
                //Show error
                CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                error.ErrorResponse = e.Message;
                progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
                progress.Finished = true;

                return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language) });
            }

            return Json(new { Success = true, RedirectURL = alternativeRedirect });
        }

        /// <summary>
        /// GET/POST: /Equip/GQT_Menu_231
        /// </summary>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_231_Progress()
        {
            ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML231");

            if (progress == null)
                return Json(new { Success = true, percent = 0, message = Resources.Resources.THERE_IS_NO_TASK_RUN02354, finished = false, ongoing = false});

            if(progress.Finished) {
                if(progress.Percent == 100) {
                    return Json(new { Success = true, percent = 100, message = Resources.Resources.ALTERACOES_EFECTUADA64514, finished = true, ongoing = false });
                }
                else {
                    if(progress.Errors != null){
                        if(!string.IsNullOrEmpty(progress.Errors.ErrorResponse)){
                            return Json(new { Success = false, percent = progress.Percent,
                            message = progress.Errors.ErrorResponse,
                            finished = false, ongoing = false });
                        }
                        else if(progress.Errors.ErrorLog.Count() > 0) {
                            string messageBuilder = "";
                            foreach(string err in progress.Errors.ErrorLog){
                                messageBuilder += err + "<br />";
                            }

                            return Json(new { Success = false, percent = progress.Percent,
                            message = messageBuilder,
                            finished = false, ongoing = false });
                        }
                    }
                    return Json(new { Success = false, percent = progress.Percent,
                    message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091,
                    finished = true, ongoing = false });
                }
            }
            else{
                return Json(new { Success = true, percent = progress.Percent, message = "", finished = false, ongoing = true});
            }
        }


        //
        // GET: /Equip/GQT_Menu_2411
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2411")]
        public ActionResult GQT_Menu_2411(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2411_ViewModel model = new GQT_Menu_2411_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2411");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2411.ShortDescription());

            if (!String.IsNullOrEmpty(querystring["rooms"]))
                Navigation.SetValue("rooms", querystring["rooms"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("GQT_Menu_2411", model);
        }



        //
        // GET: /Equip/GQT_Menu_251
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_251")]
        public ActionResult GQT_Menu_251(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_251_ViewModel model = new GQT_Menu_251_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_251");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_251.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_251);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_251.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_251, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_251.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 251]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_251", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_251_Partial", model);
        }
        /// <summary>
        /// GET/POST: /Equip/GQT_Menu_251
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_251_Execute(string[] selected_ids)
        {
            GQT_Menu_251_ViewModel menuViewModel = new GQT_Menu_251_ViewModel(Navigation);
            CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);
            if (result.Status.Equals(CSGenio.framework.Status.E))
                return Json(new { Success = false,  Message = result.Message });

            if(selected_ids == null)
            {
                return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });
            }

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            var alternativeRedirect = string.Empty;
            try
            {
                sp.openTransaction();
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_251]/
                foreach(string selectedId in selected_ids)
                {
                    SelectQuery query = new SelectQuery()
                        .Select(CSGenioAmovim.FldCodmovim)
                        .From(Area.AreaMOVIM)
                        .Where(CriteriaSet.And()
                            .Equal(CSGenioAmovim.FldCodequip,  Navigation.GetValue("equip"))
                            .In(CSGenioAmovim.FldCodrooms, selectedId)
                            .Equal(CSGenioAmovim.FldZzstate, 0));

                    DataMatrix mx = sp.Execute(query);
                    for (int i = 0; i < mx.NumRows; i++)
                    {
                        var area = new CSGenioAmovim(UserContext.Current.User);
                        area.insertNameValueField(query.SelectFields[0].Alias, mx.GetDirect(i, 0));
                        area.eliminate(sp);
                    }
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_251]/
                }
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_251]/
                sp.closeTransaction();
                Navigation.ClearValue("equip");
            }
            catch (ModelNotFoundException)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                return Json(new { Success = false, Message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 });
            }
            catch (Exception e) {
                sp.rollbackTransaction();
                sp.closeConnection();
                var errorMessage = e.Message;
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    errorMessage = (e as GenioException).UserMessage;

                return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(errorMessage, UserContext.Current.User.Language) });
            }

            return Json(new { Success = true, Message = Resources.Resources.ALTERACOES_EFECTUADA64514, RedirectURL = alternativeRedirect });
        }



        //
        // GET: /Equip/GQT_Menu_2C11
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2C11")]
        public ActionResult GQT_Menu_2C11(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2C11_ViewModel model = new GQT_Menu_2C11_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2C11");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C11.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2C11);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C11.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2C11, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C11.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2C11]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2C11", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2C11_Partial", model);
        }
        /// <summary>
        /// GET/POST: /Equip/GQT_Menu_2C11
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <param name="dest_id"></param>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_2C11_Execute(string[] selected_ids, string dest_id, Dictionary<string, string> queryParams, bool allSelected = false)
        {
            GQT_Menu_2C11_ViewModel menuViewModel = new GQT_Menu_2C11_ViewModel(Navigation);
            CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);

            if (result.Status.Equals(CSGenio.framework.Status.E))
                return Json(new { Success = false,  Message = result.Message });

            if((selected_ids == null && !allSelected) || string.IsNullOrEmpty(dest_id))
            {
                return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });
            }

            var alternativeRedirect = string.Empty;

            //Create progress object
            this.Navigation.SetValue("ProgressReport_ML2C11", new ProgressReport());

            //Reference it so it can be used in the thread below
            ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML2C11");
            try
            {
                NavigationContext navCtx = Navigation.Clone(); //Clone Navigation
                NameValueCollection parameters;

                //Fetch and format the parameters
				if (queryParams != null && queryParams.Count() > 0)
					parameters = FormatQueryString(queryParams);
				else
					parameters = this.Navigation.GetValue<NameValueCollection>("requestValues" + "GQT_Menu_2C11");

                //Get CriteriaSet
				CriteriaSet crs = menuViewModel.BuildCriteriaSet(parameters, out bool hasAllRequiredLimits);

                UserContext userCtx = UserContext.Current;
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    PersistentSupport sp = PersistentSupport.getPersistentSupport(userCtx.User.Year, userCtx.User.Name);
                    try
                    {
                        sp.openTransaction();

                        progress.Report("GQT_Menu_2C11", 0);
                        if (allSelected)
                        {
                            /* Build subquery with custom CriteriaSet */
                            SelectQuery allIds = new SelectQuery()
                            .Select(CSGenioAequip.FldCodequip)
                            .From(CSGenio.business.Area.AreaEQUIP);

                            //Fetch Current Area
                            CSGenio.business.Area area = CSGenio.business.Area.createArea("equip", userCtx.User, userCtx.User.CurrentModule);

                            //Add Related Areas to Query Joins
                            QueryUtils.SetInnerJoins(new[] { "EQUIP.FldCodequip" }, crs, area, allIds);
                            allIds.Where(crs);
                            /* -------------------------------------- */

                            //Replace the selected rows array
                            DataMatrix dm = sp.Execute(allIds);
                            selected_ids = new string[dm.NumRows];
                            for (int i = 0; i < dm.NumRows; i++)
                            {
                                if(!string.IsNullOrEmpty(dm.GetKey(i, 0).ToString()))
                                    selected_ids[i] = dm.GetKey(i, 0).ToString();
                            }
                        }

                        int cnt = 0;
                        foreach (string selectedId in selected_ids)
                        {
                            //Update Progress
                            progress.Report("GQT_Menu_2C11", (cnt * 100) / selected_ids.Length);

                            CSGenioAequip model = CSGenioAequip.search(sp, selectedId, userCtx.User);
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_2C11]/
                            if (model == null) //In theory, this should never happen
                                throw new BusinessException("Could not find record with ID " + selectedId.ToString(), "GQT_Menu_2C11_Execute", "The record with the ID " + selectedId.ToString() + " returned null");

                            model.ValCoddeco = dest_id;
                            model.update(sp);
                            cnt++;
                        }
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_2C11]/
                        sp.closeTransaction();

                        //Update to 100% Progress
                        progress.Report("GQT_Menu_2C11", 100);
                        progress.Finished = true;
                    }
                    catch(Exception e)
                    {
                        //Revert changes
                        sp.rollbackTransaction();
                        sp.closeTransaction();

                        //Show error
                        CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                        if (e is GenioException && (e as GenioException).UserMessage != null)
                            error.ErrorResponse = (e as GenioException).UserMessage;
                        else
                            error.ErrorResponse = e.Message;
                        progress.Report("GQT_Menu_2C11", -1, true, null, null, error, null);
                        progress.Finished = true;
                    }
                });
            }
            catch (ModelNotFoundException e)
            {
                //Show error
                CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                error.ErrorResponse = e.Message;
                progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
                progress.Finished = true;

                return Json(new { Success = false, Message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 });
            }
            catch (Exception e)
            {
                //Show error
                CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
                error.ErrorResponse = e.Message;
                progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
                progress.Finished = true;

                return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language) });
            }

            return Json(new { Success = true, RedirectURL = alternativeRedirect });
        }

        /// <summary>
        /// GET/POST: /Equip/GQT_Menu_2C11
        /// </summary>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_2C11_Progress()
        {
            ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML2C11");

            if (progress == null)
                return Json(new { Success = true, percent = 0, message = Resources.Resources.THERE_IS_NO_TASK_RUN02354, finished = false, ongoing = false});

            if(progress.Finished) {
                if(progress.Percent == 100) {
                    return Json(new { Success = true, percent = 100, message = Resources.Resources.ALTERACOES_EFECTUADA64514, finished = true, ongoing = false });
                }
                else {
                    if(progress.Errors != null){
                        if(!string.IsNullOrEmpty(progress.Errors.ErrorResponse)){
                            return Json(new { Success = false, percent = progress.Percent,
                            message = progress.Errors.ErrorResponse,
                            finished = false, ongoing = false });
                        }
                        else if(progress.Errors.ErrorLog.Count() > 0) {
                            string messageBuilder = "";
                            foreach(string err in progress.Errors.ErrorLog){
                                messageBuilder += err + "<br />";
                            }

                            return Json(new { Success = false, percent = progress.Percent,
                            message = messageBuilder,
                            finished = false, ongoing = false });
                        }
                    }
                    return Json(new { Success = false, percent = progress.Percent,
                    message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091,
                    finished = true, ongoing = false });
                }
            }
            else{
                return Json(new { Success = true, percent = progress.Percent, message = "", finished = false, ongoing = true});
            }
        }


        //
        // GET: /Equip/GQT_Menu_2C211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2C211")]
        public ActionResult GQT_Menu_2C211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2C211_ViewModel model = new GQT_Menu_2C211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2C211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2C211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2C211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("equip.ifabatif", "1");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2C211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2C211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2C211_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_2C311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2C311")]
        public ActionResult GQT_Menu_2C311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2C311_ViewModel model = new GQT_Menu_2C311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2C311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C311.ShortDescription());

            if (!String.IsNullOrEmpty(querystring["decom"]))
                Navigation.SetValue("decom", querystring["decom"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2C311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("GQT_Menu_2C311", model);
        }



        //
        // GET: /Equip/GQT_Menu_2D111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2D111")]
        public ActionResult GQT_Menu_2D111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2D111_ViewModel model = new GQT_Menu_2D111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2D111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

            /*
             * If all the records on the previous DM were selected, this means we do not need
             * to filter, since having them all checked = having no filters at all
             */
            if(allSelected)
            {
                Navigation.DestroyEntry("tpequ_Selections");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_2D111))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2D111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2D111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2D111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2D111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2D111_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_2D2111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2D2111")]
        public ActionResult GQT_Menu_2D2111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2D2111_ViewModel model = new GQT_Menu_2D2111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2D2111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

            /*
             * If all the records on the previous DM were selected, this means we do not need
             * to filter, since having them all checked = having no filters at all
             */
            if(allSelected)
            {
                Navigation.DestroyEntry("tpequ_Selections");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D2111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_2D2111))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2D2111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D2111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2D2111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D2111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2D2111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2D2111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2D2111_Partial", model);
        }



        //
        // GET: /Equip/GQT_Menu_6211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_6211")]
        public ActionResult GQT_Menu_6211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_6211_ViewModel model = new GQT_Menu_6211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_6211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_equip");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_6211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_6211))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_6211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_6211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_6211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_6211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cmpny"]))
                Navigation.SetValue("cmpny", querystring["cmpny"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 6211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_6211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_6211_Partial", model);
        }




		#endregion



    }
}