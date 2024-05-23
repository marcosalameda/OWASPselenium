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
using GenioMVC.ViewModels.Flds;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
    public partial class FldsController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_STY_MENU_TABS = new NavigationLocation("FIELD_TYPES49172", "STY_Menu_TABS", "Flds") { vueRouteName = "menu-STY_TABS" };
		private static readonly NavigationLocation ACTION_STY_MENU_INPTFIELD = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_INPTFIELD", "Flds") { vueRouteName = "menu-STY_INPTFIELD" };
		private static readonly NavigationLocation ACTION_STY_MENU_358111 = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_358111", "Flds") { vueRouteName = "menu-STY_358111" };
		private static readonly NavigationLocation ACTION_STY_MENU_358211 = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_358211", "Flds") { vueRouteName = "menu-STY_358211" };
		private static readonly NavigationLocation ACTION_PTN_MENU_511 = new NavigationLocation("FIELD_TYPES49172", "PTN_Menu_511", "Flds") { vueRouteName = "menu-PTN_511" };
        #endregion

        #region Menus


        //
        // GET: /Flds/STY_Menu_TABS
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_TABS")]
        public ActionResult STY_Menu_TABS(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            STY_Menu_TABS_ViewModel model = new STY_Menu_TABS_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_TABS");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_flds");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_TABS.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_TABS);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_TABS.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_TABS, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_TABS.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("flds.shwrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET TABS]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("LISTACAM"))
                Navigation.GoBack.Remove("LISTACAM");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("LISTACAM"))
                Navigation.OverrideSkipIfJustOne.Remove("LISTACAM");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Listacam_Edit", "Flds", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_TABS", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_TABS_Partial", model);
        }



        //
        // GET: /Flds/STY_Menu_INPTFIELD
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_INPTFIELD")]
        public ActionResult STY_Menu_INPTFIELD(bool allSelected = false)
        {
			int perPage = 6;

            STY_Menu_INPTFIELD_ViewModel model = new STY_Menu_INPTFIELD_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_INPTFIELD");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_flds");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_INPTFIELD.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_INPTFIELD);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_INPTFIELD.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_INPTFIELD, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_INPTFIELD.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("flds.shwrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET INPTFIELD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
                Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
                Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Infields_Show", "Flds", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_INPTFIELD", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_INPTFIELD_Partial", model);
        }



        //
        // GET: /Flds/STY_Menu_358111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_358111")]
        public ActionResult STY_Menu_358111(bool allSelected = false)
        {
			int perPage = 6;

            STY_Menu_358111_ViewModel model = new STY_Menu_358111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_358111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_flds");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_358111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_358111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_358111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_358111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_358111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("flds.shwrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET 358111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
                Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
                Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Infields_Edit", "Flds", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_358111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_358111_Partial", model);
        }



        //
        // GET: /Flds/STY_Menu_358211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_358211")]
        public ActionResult STY_Menu_358211(bool allSelected = false)
        {
			int perPage = 6;

            STY_Menu_358211_ViewModel model = new STY_Menu_358211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_358211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_flds");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_358211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_358211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_358211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_358211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_358211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("flds.shwrc", "1");

			model.Navigation = Navigation;

// USE /[MANUAL STY MENU_GET 358211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
                Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
                Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Infields_Show", "Flds", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("STY_Menu_358211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_358211_Partial", model);
        }



        //
        // GET: /Flds/PTN_Menu_511
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_511")]
        public ActionResult PTN_Menu_511(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_511_ViewModel model = new PTN_Menu_511_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_511");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_flds");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_511.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_511);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_511.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_511, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_511.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_511", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_511_Partial", model);
        }




		#endregion



    }
}