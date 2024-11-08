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
using GenioMVC.ViewModels.Rooms;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROOMS]/

namespace GenioMVC.Controllers
{
    public partial class RoomsController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_GQT_MENU_2311 = new NavigationLocation("ROOMS06809", "GQT_Menu_2311", "Rooms") { vueRouteName = "menu-GQT_2311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_241 = new NavigationLocation("ROOMS06809", "GQT_Menu_241", "Rooms") { vueRouteName = "menu-GQT_241" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2511 = new NavigationLocation("ROOMS06809", "GQT_Menu_2511", "Rooms") { vueRouteName = "menu-GQT_2511" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3311 = new NavigationLocation("ROOMS06809", "PTN_Menu_3311", "Rooms") { vueRouteName = "menu-PTN_3311" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3411 = new NavigationLocation("ROOMS06809", "PTN_Menu_3411", "Rooms") { vueRouteName = "menu-PTN_3411" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3511 = new NavigationLocation("ROOMS06809", "PTN_Menu_3511", "Rooms") { vueRouteName = "menu-PTN_3511" };
        #endregion

        #region Menus


        //
        // GET: /Rooms/GQT_Menu_2311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2311")]
        public ActionResult GQT_Menu_2311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2311_ViewModel model = new GQT_Menu_2311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2311.ShortDescription());


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("GQT_Menu_2311", model);
        }



        //
        // GET: /Rooms/GQT_Menu_241
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_241")]
        public ActionResult GQT_Menu_241(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_241_ViewModel model = new GQT_Menu_241_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_241");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_241.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_241);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_241.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_241, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_241.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 241]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_241", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_241_Partial", model);
        }
        /// <summary>
        /// GET/POST: /Rooms/GQT_Menu_241
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <returns></returns>
        [AuthorizeForUsers]
        public JsonResult GQT_Menu_241_Execute(string[] selected_ids)
        {
            GQT_Menu_241_ViewModel menuViewModel = new GQT_Menu_241_ViewModel(Navigation);
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
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_241]/
                foreach(string selectedId in selected_ids)
                {
                    SelectQuery query = new SelectQuery()
                        .Select(CSGenioAmovim.FldCodmovim)
                        .From(Area.AreaMOVIM)
                        .Where(CriteriaSet.And()
                            .Equal(CSGenioAmovim.FldCodrooms,  Navigation.GetValue("rooms"))
                            .In(CSGenioAmovim.FldCodequip, selectedId)
                            .Equal(CSGenioAmovim.FldZzstate, 0));

                    DataMatrix mx = sp.Execute(query);
                    for (int i = 0; i < mx.NumRows; i++)
                    {
                        var area = new CSGenioAmovim(UserContext.Current.User);
                        area.insertNameValueField(query.SelectFields[0].Alias, mx.GetDirect(i, 0));
                        area.eliminate(sp);
                    }
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_241]/
                }
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_241]/
                sp.closeTransaction();
                Navigation.ClearValue("rooms");
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

            return Json(new { Success = true, Message = Resources.Resources.ALTERACOES_EFETUADAS10166, RedirectURL = alternativeRedirect });
        }



        //
        // GET: /Rooms/GQT_Menu_2511
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_2511")]
        public ActionResult GQT_Menu_2511(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_2511_ViewModel model = new GQT_Menu_2511_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_2511");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2511.ShortDescription());

            if (!String.IsNullOrEmpty(querystring["equip"]))
                Navigation.SetValue("equip", querystring["equip"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 2511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("GQT_Menu_2511", model);
        }



        //
        // GET: /Rooms/PTN_Menu_3311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3311")]
        public ActionResult PTN_Menu_3311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3311_ViewModel model = new PTN_Menu_3311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_PTN_MENU_3311))
                        Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3311_Partial", model);
        }



        //
        // GET: /Rooms/PTN_Menu_3411
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3411")]
        public ActionResult PTN_Menu_3411(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3411_ViewModel model = new PTN_Menu_3411_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3411");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
            CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3411.ShortDescription());


			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            return PartialView("PTN_Menu_3411", model);
        }



        //
        // GET: /Rooms/PTN_Menu_3511
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3511")]
        public ActionResult PTN_Menu_3511(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3511_ViewModel model = new PTN_Menu_3511_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3511");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3511.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3511);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3511.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3511, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3511.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3511", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3511_Partial", model);
        }




		#endregion



    }
}