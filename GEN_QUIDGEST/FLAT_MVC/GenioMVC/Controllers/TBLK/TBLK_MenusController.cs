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
using GenioMVC.ViewModels.Tblk;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLK]/

namespace GenioMVC.Controllers
{
    public partial class TblkController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_3151 = new NavigationLocation("TABLES__FOREIGN_KEYS59930", "PTN_Menu_3151", "Tblk") { vueRouteName = "menu-PTN_3151" };
        #endregion

        #region Menus


        //
        // GET: /Tblk/PTN_Menu_3151
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3151")]
        public ActionResult PTN_Menu_3151(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3151_ViewModel model = new PTN_Menu_3151_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3151");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tblk")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_tblk");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3151.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3151);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3151.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3151, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3151.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3151]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3151", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3151_Partial", model);
        }




		#endregion



    }
}