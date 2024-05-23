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
using GenioMVC.ViewModels.Regio;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REGIO]/

namespace GenioMVC.Controllers
{
    public partial class RegioController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_IMO_MENU_121 = new NavigationLocation("REGIONS31874", "IMO_Menu_121", "Regio") { vueRouteName = "menu-IMO_121" };
		private static readonly NavigationLocation ACTION_IMO_MENU_221 = new NavigationLocation("REGIONS31874", "IMO_Menu_221", "Regio") { vueRouteName = "menu-IMO_221" };
		private static readonly NavigationLocation ACTION_IMO_MENU_2311 = new NavigationLocation("REGIONS31874", "IMO_Menu_2311", "Regio") { vueRouteName = "menu-IMO_2311" };
        #endregion

        #region Menus


        //
        // GET: /Regio/IMO_Menu_121
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_121")]
        public ActionResult IMO_Menu_121(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_121_ViewModel model = new IMO_Menu_121_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_121");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_regio");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_121.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_121);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_121.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_121, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_121.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 121]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_121", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_121_Partial", model);
        }



        //
        // GET: /Regio/IMO_Menu_221
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_221")]
        public ActionResult IMO_Menu_221(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_221_ViewModel model = new IMO_Menu_221_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_221");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_regio");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_221.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_221);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_221.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_221, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_221.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 221]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_221", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_221_Partial", model);
        }



        //
        // GET: /Regio/IMO_Menu_2311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_2311")]
        public ActionResult IMO_Menu_2311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_2311_ViewModel model = new IMO_Menu_2311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_2311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_regio");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_2311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_IMO_MENU_2311))
                        Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_2311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_2311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_2311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_2311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cntry"]))
                Navigation.SetValue("cntry", querystring["cntry"]);


			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 2311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_2311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_2311_Partial", model);
        }




		#endregion



    }
}