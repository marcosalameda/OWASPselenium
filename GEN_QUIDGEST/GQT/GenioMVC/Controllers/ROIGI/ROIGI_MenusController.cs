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
using GenioMVC.ViewModels.Roigi;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGI]/

namespace GenioMVC.Controllers
{
    public partial class RoigiController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_4411 = new NavigationLocation("ORDERS_IN_GROUP___IN07193", "PTN_Menu_4411", "Roigi") { vueRouteName = "menu-PTN_4411" };
        #endregion

        #region Menus


        //
        // GET: /Roigi/PTN_Menu_4411
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_4411")]
        public ActionResult PTN_Menu_4411(bool allSelected = false)
        {
			int perPage = -1;

            PTN_Menu_4411_ViewModel model = new PTN_Menu_4411_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_4411");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_roigi")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_roigi");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_4411.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_PTN_MENU_4411))
                        Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_4411);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_4411.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_4411, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_4411.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["rogl1"]))
                Navigation.SetValue("rogl1", querystring["rogl1"]);


			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 4411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_4411", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_4411_Partial", model);
        }




		#endregion


        #region Reorder code...
        [AuthorizeForUsers]
        public ActionResult ReorderPTN_Menu_4411(string id, string position,string partialView)
        {
            PTN_Menu_4411_ViewModel model = new PTN_Menu_4411_ViewModel(Navigation);
            model.ReorderPTN_Menu_4411(id,position);
            model.Load(-1);

            if (Request.IsAjaxRequest())
                return Json(new { Sucess = "OK" }, "application/json",  JsonRequestBehavior.AllowGet);
            return PartialView(partialView, model);
        }

        #endregion

    }
}