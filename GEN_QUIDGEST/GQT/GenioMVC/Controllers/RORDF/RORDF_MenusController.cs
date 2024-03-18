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
using GenioMVC.ViewModels.Rordf;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RORDF]/

namespace GenioMVC.Controllers
{
    public partial class RordfController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_1511 = new NavigationLocation("ORDERS___FLOAT_FIELD11291", "PTN_Menu_1511", "Rordf") { vueRouteName = "menu-PTN_1511" };
        #endregion

        #region Menus


        //
        // GET: /Rordf/PTN_Menu_1511
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_1511")]
        public ActionResult PTN_Menu_1511(bool allSelected = false)
        {
			int perPage = -1;

            PTN_Menu_1511_ViewModel model = new PTN_Menu_1511_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_1511");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rordf")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rordf");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_1511.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_1511);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_1511.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_1511, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_1511.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL PTN MENU_GET 1511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_1511", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_1511_Partial", model);
        }




		#endregion


        #region Reorder code...
        [AuthorizeForUsers]
        public ActionResult ReorderPTN_Menu_1511(string id, string position,string partialView)
        {
            PTN_Menu_1511_ViewModel model = new PTN_Menu_1511_ViewModel(Navigation);
            model.ReorderPTN_Menu_1511(id,position);
            model.Load(-1);

            if (Request.IsAjaxRequest())
                return Json(new { Sucess = "OK" }, "application/json",  JsonRequestBehavior.AllowGet);
            return PartialView(partialView, model);
        }

        #endregion

    }
}