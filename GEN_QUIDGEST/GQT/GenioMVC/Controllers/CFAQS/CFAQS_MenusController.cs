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
using GenioMVC.ViewModels.Cfaqs;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CFAQS]/

namespace GenioMVC.Controllers
{
    public partial class CfaqsController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_GQT_MENU_B1 = new NavigationLocation("CATEGORY_FAQS42471", "GQT_Menu_B1", "Cfaqs") { vueRouteName = "menu-GQT_B1" };
		private static readonly NavigationLocation ACTION_STY_MENU_3591 = new NavigationLocation("CATEGORY_FAQS42471", "STY_Menu_3591", "Cfaqs") { vueRouteName = "menu-STY_3591" };
        #endregion

        #region Menus


        //
        // GET: /Cfaqs/GQT_Menu_B1
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_B1")]
        public ActionResult GQT_Menu_B1(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_B1_ViewModel model = new GQT_Menu_B1_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_B1");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cfaqs")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cfaqs");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_B1.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_B1);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_B1.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_B1, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_B1.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL GQT MENU_GET B1]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_B1", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_B1_Partial", model);
        }



        //
        // GET: /Cfaqs/STY_Menu_3591
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_3591")]
        public ActionResult STY_Menu_3591(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            STY_Menu_3591_ViewModel model = new STY_Menu_3591_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_3591");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cfaqs")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cfaqs");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_3591.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_STY_MENU_3591);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_3591.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_3591, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_3591.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL STY MENU_GET 3591]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("STY_Menu_3591", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_3591_Partial", model);
        }




		#endregion



    }
}