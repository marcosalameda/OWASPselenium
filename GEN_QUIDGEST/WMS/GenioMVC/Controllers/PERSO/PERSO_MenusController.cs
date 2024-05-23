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
using GenioMVC.ViewModels.Perso;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PERSO]/

namespace GenioMVC.Controllers
{
    public partial class PersoController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_WMS_MENU_4311 = new NavigationLocation("PERSONS18356", "WMS_Menu_4311", "Perso") { vueRouteName = "menu-WMS_4311" };
		private static readonly NavigationLocation ACTION_WMS_MENU_4321 = new NavigationLocation("SELECAO_DE_ARRAY26939", "WMS_Menu_4321", "Perso") { vueRouteName = "menu-WMS_4321" };
		private static readonly NavigationLocation ACTION_WMS_MENU_43211 = new NavigationLocation("PERSONS18356", "WMS_Menu_43211", "Perso") { vueRouteName = "menu-WMS_43211" };
        #endregion

        #region Menus


        //
        // GET: /Perso/WMS_Menu_4311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_4311")]
        public ActionResult WMS_Menu_4311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_4311_ViewModel model = new WMS_Menu_4311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_4311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_4311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_4311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_4311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_4311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_4311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 4311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_4311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_4311_Partial", model);
        }



        //
        // GET: /Perso/WMS_Menu_4321
        [AuthorizeForUsers]
        public ActionResult WMS_Menu_4321()
        {
            if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_4321.IsSameAction(Navigation.CurrentLevel.Location))
                Navigation.AddHistoryLevel(ACTION_WMS_MENU_4321, FormMode.List);

            WMS_Menu_4321_ViewModel model = new WMS_Menu_4321_ViewModel(Navigation);
            return View(model);
        }



        //
        // GET: /Perso/WMS_Menu_43211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_43211")]
        public ActionResult WMS_Menu_43211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_43211_ViewModel model = new WMS_Menu_43211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_43211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_43211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_43211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_43211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_43211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_43211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (querystring["perso_gender"] != null)
                Navigation.SetValue("perso.gender", querystring["perso_gender"]);

			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET 43211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_43211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_43211_Partial", model);
        }




		#endregion



    }
}