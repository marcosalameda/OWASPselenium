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
using GenioMVC.ViewModels.Cmpki;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPKI]/

namespace GenioMVC.Controllers
{
    public partial class CmpkiController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_GQT_MENU_2A11 = new NavigationLocation("KIT_COMPONENTS50945", "GQT_Menu_2A11", "Cmpki") { vueRouteName = "menu-GQT_2A11" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2B1 = new NavigationLocation("KIT_COMPONENTS50945", "GQT_Menu_2B1", "Cmpki") { vueRouteName = "menu-GQT_2B1" };
        #endregion

        #region Menus


        //
        // GET: /Cmpki/GQT_Menu_2A11
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2A11")]
        public ActionResult GQT_Menu_2A11(bool allSelected = false)
        {
			int perPage = -1;

            GQT_Menu_2A11_ViewModel model = new GQT_Menu_2A11_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2A11");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpki")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cmpki");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2A11.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_2A11))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2A11);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2A11.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2A11, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2A11.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["tpequ"]))
                Navigation.SetValue("tpequ", querystring["tpequ"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2A11]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2A11", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2A11_Partial", model);
        }



        //
        // GET: /Cmpki/GQT_Menu_2B1
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2B1")]
        public ActionResult GQT_Menu_2B1(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2B1_ViewModel model = new GQT_Menu_2B1_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2B1");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpki")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_cmpki");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2B1.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2B1);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2B1.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2B1, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2B1.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2B1]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2B1", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2B1_Partial", model);
        }




		#endregion


        #region Reorder code...
        [AuthorizeForUsers]
        public ActionResult ReorderGQT_Menu_2A11(string id, string position,string partialView)
        {
            GQT_Menu_2A11_ViewModel model = new GQT_Menu_2A11_ViewModel(Navigation);
            model.ReorderGQT_Menu_2A11(id,position);
            model.Load(-1);

            if (Request.IsAjaxRequest())
                return Json(new { Sucess = "OK" }, "application/json",  JsonRequestBehavior.AllowGet);
            return PartialView(partialView, model);
        }

        #endregion

    }
}