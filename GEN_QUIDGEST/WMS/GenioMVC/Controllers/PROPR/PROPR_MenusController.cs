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
using GenioMVC.ViewModels.Propr;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPR]/

namespace GenioMVC.Controllers
{
    public partial class ProprController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_IMO_MENU_111 = new NavigationLocation("REAL_ESTATE24996", "IMO_Menu_111", "Propr") { vueRouteName = "menu-IMO_111" };
		private static readonly NavigationLocation ACTION_IMO_MENU_1311 = new NavigationLocation("REAL_ESTATE24996", "IMO_Menu_1311", "Propr") { vueRouteName = "menu-IMO_1311" };
        #endregion

        #region Menus


        //
        // GET: /Propr/IMO_Menu_111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_111")]
        public ActionResult IMO_Menu_111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_111_ViewModel model = new IMO_Menu_111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_propr");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_111_Partial", model);
        }



        //
        // GET: /Propr/IMO_Menu_1311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("IMO_Menu_1311")]
        public ActionResult IMO_Menu_1311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_1311_ViewModel model = new IMO_Menu_1311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_1311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_propr");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_1311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_IMO_MENU_1311))
                        Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_1311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_1311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_1311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_1311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cntry"]))
                Navigation.SetValue("cntry", querystring["cntry"]);


			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET 1311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("PROPR00"))
                Navigation.GoBack.Remove("PROPR00");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("PROPR00"))
                Navigation.OverrideSkipIfJustOne.Remove("PROPR00");
            // jumps if only one
            var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			if (!Request.IsAjaxRequest() && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodpropr;
				var navKey = "propr";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
                return RedirectToAction("Propr00_Edit", "Propr", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage });
            }
  
            if(isHomePage)
                return PartialView("IMO_Menu_1311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_1311_Partial", model);
        }




		#endregion



    }
}