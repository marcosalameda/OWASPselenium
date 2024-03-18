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
using GenioMVC.ViewModels.Decom;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DECOM]/

namespace GenioMVC.Controllers
{
    public partial class DecomController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_211 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "PTN_Menu_211", "Decom") { vueRouteName = "menu-PTN_211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C111 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "GQT_Menu_2C111", "Decom") { vueRouteName = "menu-GQT_2C111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C31 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "GQT_Menu_2C31", "Decom") { vueRouteName = "menu-GQT_2C31" };
        #endregion

        #region Menus


        //
        // GET: /Decom/PTN_Menu_211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_211")]
        public ActionResult PTN_Menu_211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_211_ViewModel model = new PTN_Menu_211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_decom");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL PTN MENU_GET 211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_211_Partial", model);
        }



        //
        // GET: /Decom/GQT_Menu_2C111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2C111")]
        public ActionResult GQT_Menu_2C111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2C111_ViewModel model = new GQT_Menu_2C111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2C111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_decom");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C111.ShortDescription());


			model.Navigation = Navigation;

            // USE /[MANUAL GQT MENU_GET 2C111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("GQT_Menu_2C111", model);
        }



        //
        // GET: /Decom/GQT_Menu_2C31
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2C31")]
        public ActionResult GQT_Menu_2C31(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2C31_ViewModel model = new GQT_Menu_2C31_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2C31");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_decom");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C31.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_2C31);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C31.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_2C31, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C31.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

            // USE /[MANUAL GQT MENU_GET 2C31]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_2C31", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_2C31_Partial", model);
        }
        /// <summary>
        /// GET/POST: /Decom/GQT_Menu_2C31
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_2C31_Execute(string[] selected_ids)
        {
            GQT_Menu_2C31_ViewModel menuViewModel = new GQT_Menu_2C31_ViewModel(Navigation);
            CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);
            if (result.Status.Equals(CSGenio.framework.Status.E))
                return Json(new { Success = false,  Message = result.Message });

            if(selected_ids == null)
            {
                return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });
            }

            PersistentSupport sp = UserContext.Current.PersistentSupport;
            var alternativeRedirect = string.Empty;
            try
            {
                sp.openTransaction();
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_2C31]/
                foreach(string selectedId in selected_ids)
                {
                    Models.Equip model = Models.Equip.Find(selectedId, "MGQT_Menu_2C31");
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_2C31]/
                    model.ValCoddeco = null;
                    model.Save();
                }
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_2C31]/
                sp.closeTransaction();
                Navigation.ClearValue("decom");
            }
            catch (ModelNotFoundException)
            {
                sp.rollbackTransaction();
                sp.closeConnection();
                return Json(new { Success = false, Message = Resources.Resources.O_REGISTO_PEDIDO_NAO63869 });
            }
            catch (Exception e) {
                sp.rollbackTransaction();
                sp.closeConnection();
                var errorMessage = e.Message;
                if (e is GenioException && (e as GenioException).UserMessage != null)
                    errorMessage = (e as GenioException).UserMessage;

                return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(errorMessage, UserContext.Current.User.Language) });
            }

            return Json(new { Success = true, Message = Resources.Resources.ALTERACOES_EFECTUADA64514, RedirectURL = alternativeRedirect });
        }




		#endregion



    }
}