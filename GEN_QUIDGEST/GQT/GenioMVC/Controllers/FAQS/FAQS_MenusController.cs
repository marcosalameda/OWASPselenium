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
using GenioMVC.ViewModels.Faqs;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FAQS]/

namespace GenioMVC.Controllers
{
    public partial class FaqsController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_STY_MENU_35911 = new NavigationLocation("FAQS53959", "STY_Menu_35911", "Faqs") { vueRouteName = "menu-STY_35911" };
        #endregion

        #region Menus


        //
        // GET: /Faqs/STY_Menu_35911
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("STY_Menu_35911")]
        public ActionResult STY_Menu_35911(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            STY_Menu_35911_ViewModel model = new STY_Menu_35911_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "STY_Menu_35911");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_faqs")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_faqs");
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
                if (Navigation.CurrentLevel == null || !ACTION_STY_MENU_35911.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_STY_MENU_35911))
                        Navigation.RemoveHistoryLevel(ACTION_STY_MENU_35911);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_35911.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_STY_MENU_35911, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_35911.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cfaqs"]))
                Navigation.SetValue("cfaqs", querystring["cfaqs"]);


			model.Navigation = Navigation;

            // USE /[MANUAL STY MENU_GET 35911]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("STY_Menu_35911", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("STY_Menu_35911_Partial", model);
        }




		#endregion



    }
}