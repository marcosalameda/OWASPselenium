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
using GenioMVC.ViewModels.Dispa;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISPA]/

namespace GenioMVC.Controllers
{
    public partial class DispaController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_WMS_MENU_2111 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2111", "Dispa") { vueRouteName = "menu-WMS_2111" };
		private static readonly NavigationLocation ACTION_WMS_MENU_2211 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2211", "Dispa") { vueRouteName = "menu-WMS_2211" };
		private static readonly NavigationLocation ACTION_WMS_MENU_231 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_231", "Dispa") { vueRouteName = "menu-WMS_231" };
        #endregion

        #region Menus


        //
        // GET: /Dispa/WMS_Menu_2111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_2111")]
        public ActionResult WMS_Menu_2111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_2111_ViewModel model = new WMS_Menu_2111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_2111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_dispa");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_2111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_2111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_2111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_2111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_2111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("dispa.isprepar", "0");

			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 2111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_2111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_2111_Partial", model);
        }



        //
        // GET: /Dispa/WMS_Menu_2211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_2211")]
        public ActionResult WMS_Menu_2211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_2211_ViewModel model = new WMS_Menu_2211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_2211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_dispa");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_2211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_2211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_2211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_2211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_2211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("dispa.isprepar", "1");

			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 2211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_2211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_2211_Partial", model);
        }



        //
        // GET: /Dispa/WMS_Menu_231
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_231")]
        public ActionResult WMS_Menu_231(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_231_ViewModel model = new WMS_Menu_231_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_231");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_dispa");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_231.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_231);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_231.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_231, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_231.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 231]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_231", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_231_Partial", model);
        }




		#endregion



    }
}