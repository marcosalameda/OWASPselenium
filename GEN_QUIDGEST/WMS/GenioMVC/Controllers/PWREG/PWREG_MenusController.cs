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
using GenioMVC.ViewModels.Pwreg;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWREG]/

namespace GenioMVC.Controllers
{
    public partial class PwregController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_IMO_MENU_LISTA_REGIAO = new NavigationLocation("ACESSOS_REGIAO58658", "IMO_Menu_LISTA_REGIAO", "Pwreg") { vueRouteName = "menu-IMO_LISTA_REGIAO" };
        #endregion

        #region Menus


        //
        // GET: /Pwreg/IMO_Menu_LISTA_REGIAO
        [AuthorizeForUsers]
        [ActionName("IMO_Menu_LISTA_REGIAO_Selections")]
        [HttpPost]
        public ActionResult IMO_Menu_LISTA_REGIAO_Selections(string[] ids)
        {
            Navigation.ClearValue("pwreg_Selections");
            if(ids != null && ids.Length != 0)
                Navigation.SetValue("pwreg_Selections", ids);
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

		[AuthorizeForUsers]
        [ActionName("IMO_Menu_LISTA_REGIAO")]
        public ActionResult IMO_Menu_LISTA_REGIAO(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            IMO_Menu_LISTA_REGIAO_ViewModel model = new IMO_Menu_LISTA_REGIAO_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "IMO_Menu_LISTA_REGIAO");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pwreg")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pwreg");
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
                if (Navigation.CurrentLevel == null || !ACTION_IMO_MENU_LISTA_REGIAO.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_IMO_MENU_LISTA_REGIAO);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_LISTA_REGIAO.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_IMO_MENU_LISTA_REGIAO, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_LISTA_REGIAO.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL IMO MENU_GET LISTA_REGIAO]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("IMO_Menu_LISTA_REGIAO", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("IMO_Menu_LISTA_REGIAO_Partial", model);
        }




		#endregion



    }
}