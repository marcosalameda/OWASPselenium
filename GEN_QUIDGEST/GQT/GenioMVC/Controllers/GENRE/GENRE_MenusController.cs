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
using GenioMVC.ViewModels.Genre;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GENRE]/

namespace GenioMVC.Controllers
{
    public partial class GenreController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_TBS_MENU_161 = new NavigationLocation("CONTACT_GENRES29532", "TBS_Menu_161", "Genre") { vueRouteName = "menu-TBS_161" };
        #endregion

        #region Menus


        //
        // GET: /Genre/TBS_Menu_161
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("TBS_Menu_161")]
        public ActionResult TBS_Menu_161(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            TBS_Menu_161_ViewModel model = new TBS_Menu_161_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "TBS_Menu_161");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_genre")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_genre");
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
                if (Navigation.CurrentLevel == null || !ACTION_TBS_MENU_161.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_TBS_MENU_161);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_TBS_MENU_161.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_TBS_MENU_161, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_TBS_MENU_161.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL TBS MENU_GET 161]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("TBS_Menu_161", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("TBS_Menu_161_Partial", model);
        }




		#endregion



    }
}