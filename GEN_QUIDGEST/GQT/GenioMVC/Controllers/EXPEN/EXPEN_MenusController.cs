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
using GenioMVC.ViewModels.Expen;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EXPEN]/

namespace GenioMVC.Controllers
{
    public partial class ExpenController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_GQT_MENU_A21 = new NavigationLocation("DESPESAS23133", "GQT_Menu_A21", "Expen") { vueRouteName = "menu-GQT_A21" };
		private static readonly NavigationLocation ACTION_PTN_MENU_361 = new NavigationLocation("DESPESAS23133", "PTN_Menu_361", "Expen") { vueRouteName = "menu-PTN_361" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MC_T = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MC_T", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MC_T" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_MC_T = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MB_MC_T", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MB_MC_T" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_TR = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MB_TR", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MB_TR" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_TR_F = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_TR_F", "Expen") { vueRouteName = "menu-PTN_LIST_DB_TR_F" };
        #endregion

        #region Menus


        //
        // GET: /Expen/GQT_Menu_A21
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_A21")]
        public ActionResult GQT_Menu_A21(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_A21_ViewModel model = new GQT_Menu_A21_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_A21");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_A21.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_A21);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_A21.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_A21, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_A21.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET A21]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_A21", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_A21_Partial", model);
        }



        //
        // GET: /Expen/PTN_Menu_361
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_361")]
        public ActionResult PTN_Menu_361(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_361_ViewModel model = new PTN_Menu_361_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_361");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_361.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_361);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_361.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_361, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_361.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 361]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_361", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_361_Partial", model);
        }



        //
        // GET: /Expen/PTN_Menu_LIST_DB_MC_T
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MC_T")]
        public ActionResult PTN_Menu_LIST_DB_MC_T(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MC_T_ViewModel model = new PTN_Menu_LIST_DB_MC_T_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MC_T");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MC_T.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_T);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MC_T.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MC_T, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MC_T.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MC_T]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MC_T", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MC_T_Partial", model);
        }

        //
        // GET: /Expen/PTN_MenuMC_LIST_DB_MC_T
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_LIST_DB_MC_T(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Expen expen = Models.Expen.Find(id, "MLLIST_DB_MC_T");
            Navigation.SetValue("expen", id);
            if(expen != null && (CSGenio.business.GlobalFunctions.emptyC(expen.ValDescript)==0))
            {
                return RedirectToAction("PTN_MenuTR_3B111", "Expen", new { id = expen.ValCoddespe, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(expen != null && (CSGenio.business.GlobalFunctions.emptyC(expen.ValDescript)==1))
            {
                return RedirectToAction("PTN_MenuTR_3B121", "Expen", new { id = expen.ValCoddespe, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                if (string.IsNullOrEmpty(formMode))
                    formMode = "Show";
                return RedirectToAction("Despe_" + formMode, "Expen", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId } : new { id = id, nav = Navigation.NavigationId });
            }
        }



        //
        // GET: /Expen/PTN_Menu_LIST_DB_MB_MC_T
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MB_MC_T")]
        public ActionResult PTN_Menu_LIST_DB_MB_MC_T(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MB_MC_T_ViewModel model = new PTN_Menu_LIST_DB_MB_MC_T_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_MC_T");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_MC_T.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_T);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_MC_T.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_MC_T, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_MC_T.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MB_MC_T]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MB_MC_T", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MB_MC_T_Partial", model);
        }

        //
        // GET: /Expen/PTN_MenuMC_BUTTONTRIGGERTEST2
        [AuthorizeForUsers]
        public ActionResult PTN_MenuMC_BUTTONTRIGGERTEST2(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Expen expen = Models.Expen.Find(id, "MLLIST_DB_MB_MC_T");
            Navigation.SetValue("expen", id);
            if(expen != null && (CSGenio.business.GlobalFunctions.emptyC(expen.ValDescript)==0))
            {
                return RedirectToAction("PTN_MenuTR_3C1111", "Expen", new { id = expen.ValCoddespe, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(expen != null && (CSGenio.business.GlobalFunctions.emptyC(expen.ValDescript)==1))
            {
                return RedirectToAction("PTN_MenuTR_3C1121", "Expen", new { id = expen.ValCoddespe, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                if (string.IsNullOrEmpty(formMode))
                    formMode = "Show";
                return RedirectToAction("Despe_" + formMode, "Expen", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId } : new { id = id, nav = Navigation.NavigationId });
            }
        }



        //
        // GET: /Expen/PTN_Menu_LIST_DB_MB_TR
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_MB_TR")]
        public ActionResult PTN_Menu_LIST_DB_MB_TR(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_MB_TR_ViewModel model = new PTN_Menu_LIST_DB_MB_TR_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_TR");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_TR.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_TR);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_TR.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_MB_TR, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_TR.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_MB_TR]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_MB_TR", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_MB_TR_Partial", model);
        }



        //
        // GET: /Expen/PTN_Menu_LIST_DB_TR_F
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_LIST_DB_TR_F")]
        public ActionResult PTN_Menu_LIST_DB_TR_F(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_LIST_DB_TR_F_ViewModel model = new PTN_Menu_LIST_DB_TR_F_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_TR_F");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_expen");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_TR_F.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_LIST_DB_TR_F);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_TR_F.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_LIST_DB_TR_F, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_TR_F.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET LIST_DB_TR_F]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_LIST_DB_TR_F", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_LIST_DB_TR_F_Partial", model);
        }




		#endregion



    }
}