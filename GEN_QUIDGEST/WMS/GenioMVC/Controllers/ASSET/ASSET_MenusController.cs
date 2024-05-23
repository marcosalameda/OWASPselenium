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
using GenioMVC.ViewModels.Asset;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSET]/

namespace GenioMVC.Controllers
{
    public partial class AssetController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_WMS_MENU_ASSET_CARD = new NavigationLocation("EQUIPMENTS06276", "WMS_Menu_ASSET_CARD", "Asset") { vueRouteName = "menu-WMS_ASSET_CARD" };
        #endregion

        #region Menus


        //
        // GET: /Asset/WMS_Menu_ASSET_CARD
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("WMS_Menu_ASSET_CARD")]
        public ActionResult WMS_Menu_ASSET_CARD(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            WMS_Menu_ASSET_CARD_ViewModel model = new WMS_Menu_ASSET_CARD_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "WMS_Menu_ASSET_CARD");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_asset");
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
                if (Navigation.CurrentLevel == null || !ACTION_WMS_MENU_ASSET_CARD.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_WMS_MENU_ASSET_CARD);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_ASSET_CARD.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_WMS_MENU_ASSET_CARD, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_ASSET_CARD.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("asset.assettyp", "E");

			model.Navigation = Navigation;

// USE /[MANUAL WMS MENU_GET ASSET_CARD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("WMS_Menu_ASSET_CARD", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("WMS_Menu_ASSET_CARD_Partial", model);
        }




		#endregion



    }
}