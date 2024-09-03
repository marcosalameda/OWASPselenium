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
using GenioMVC.ViewModels.Pesso;
using Microsoft.Reporting.WebForms;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
    public partial class PessoController : ControllerBase
    {
        #region NavigationLocation Names
		private static readonly NavigationLocation ACTION_PTN_MENU_3B111 = new NavigationLocation("PEOPLE34206", "PTN_Menu_3B111", "Pesso") { vueRouteName = "menu-PTN_3B111" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3B211 = new NavigationLocation("PEOPLE34206", "PTN_Menu_3B211", "Pesso") { vueRouteName = "menu-PTN_3B211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_271 = new NavigationLocation("PEOPLE34206", "GQT_Menu_271", "Pesso") { vueRouteName = "menu-GQT_271" };
		private static readonly NavigationLocation ACTION_GQT_MENU_321 = new NavigationLocation("PEOPLE34206", "GQT_Menu_321", "Pesso") { vueRouteName = "menu-GQT_321" };
		private static readonly NavigationLocation ACTION_GQT_MENU_611111 = new NavigationLocation("PEOPLE34206", "GQT_Menu_611111", "Pesso") { vueRouteName = "menu-GQT_611111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_6111211 = new NavigationLocation("PEOPLE34206", "GQT_Menu_6111211", "Pesso") { vueRouteName = "menu-GQT_6111211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_6111311 = new NavigationLocation("PEOPLE34206", "GQT_Menu_6111311", "Pesso") { vueRouteName = "menu-GQT_6111311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_61211 = new NavigationLocation("PEOPLE34206", "GQT_Menu_61211", "Pesso") { vueRouteName = "menu-GQT_61211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_61311 = new NavigationLocation("PEOPLE34206", "GQT_Menu_61311", "Pesso") { vueRouteName = "menu-GQT_61311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_61411 = new NavigationLocation("PEOPLE34206", "GQT_Menu_61411", "Pesso") { vueRouteName = "menu-GQT_61411" };
        #endregion

        #region Menus


        //
        // GET: /Pesso/PTN_Menu_3B111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3B111")]
        public ActionResult PTN_Menu_3B111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3B111_ViewModel model = new PTN_Menu_3B111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3B111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3B111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3B111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3B111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3B111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3B111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("pesso.gender", "F");

			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3B111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3B111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3B111_Partial", model);
        }



        //
        // GET: /Pesso/PTN_Menu_3B211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("PTN_Menu_3B211")]
        public ActionResult PTN_Menu_3B211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            PTN_Menu_3B211_ViewModel model = new PTN_Menu_3B211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "PTN_Menu_3B211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3B211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_PTN_MENU_3B211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3B211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_PTN_MENU_3B211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3B211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("pesso.interna", "1");

			model.Navigation = Navigation;

// USE /[MANUAL PTN MENU_GET 3B211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("PTN_Menu_3B211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("PTN_Menu_3B211_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_271
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_271")]
        public ActionResult GQT_Menu_271(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_271_ViewModel model = new GQT_Menu_271_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_271");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_271.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_271);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_271.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_271, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_271.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 271]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_271", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_271_Partial", model);
        }

        //
        // GET: /Pesso/GQT_MenuMC_271
        [AuthorizeForUsers]
        public ActionResult GQT_MenuMC_271(string id, string formMode)
        {
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}
            Models.Pesso pesso = Models.Pesso.Find(id, "ML271");
            Navigation.SetValue("pesso", id);
            if(pesso != null && ((pesso.ValInterna ? 1 : 0)==1))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Pessosep_" + formMode, "Pesso", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = pesso.ValCodpesso, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            if(pesso != null && ((pesso.ValExterna ? 1 : 0)==1))
            {
                if(String.IsNullOrEmpty(formMode))
                    formMode = "Edit";
                return RedirectToAction("Externo_" + formMode, "Pesso", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] } : new { id = pesso.ValCodpesso, nav = Navigation.NavigationId, niv = (Request.Params["niv"] == null) ? Navigation.CurrentLevel.Level.ToString() : Request.Params["niv"] });
            }
            else
            {
                if (string.IsNullOrEmpty(formMode))
                    formMode = "Show";
                return RedirectToAction("Pesso_" + formMode, "Pesso", formMode.Equals("New") ? (object)new { nav = Navigation.NavigationId } : new { id = id, nav = Navigation.NavigationId });
            }
        }



        //
        // GET: /Pesso/GQT_Menu_321
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_321")]
        public ActionResult GQT_Menu_321(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_321_ViewModel model = new GQT_Menu_321_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_321");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_321.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_321);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_321.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_321, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_321.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }



			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 321]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_321", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_321_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_611111
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_611111")]
        public ActionResult GQT_Menu_611111(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_611111_ViewModel model = new GQT_Menu_611111_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_611111");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_611111.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_611111))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_611111);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_611111.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_611111, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_611111.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cmpny"]))
                Navigation.SetValue("cmpny", querystring["cmpny"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 611111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_611111", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_611111_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_6111211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_6111211")]
        public ActionResult GQT_Menu_6111211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_6111211_ViewModel model = new GQT_Menu_6111211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_6111211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_6111211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_6111211))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_6111211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_6111211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_6111211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_6111211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cmpny"]))
                Navigation.SetValue("cmpny", querystring["cmpny"]);

            Navigation.SetValue("pesso.gender", "M");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 6111211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_6111211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_6111211_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_6111311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_6111311")]
        public ActionResult GQT_Menu_6111311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_6111311_ViewModel model = new GQT_Menu_6111311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_6111311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_6111311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_6111311))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_6111311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_6111311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_6111311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_6111311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cmpny"]))
                Navigation.SetValue("cmpny", querystring["cmpny"]);

            Navigation.SetValue("pesso.gender", "F");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 6111311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_6111311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_6111311_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_61211
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_61211")]
        public ActionResult GQT_Menu_61211(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_61211_ViewModel model = new GQT_Menu_61211_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_61211");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_61211.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_61211);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_61211.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_61211, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_61211.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("pesso.gender", "M");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 61211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_61211", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_61211_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_61311
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_61311")]
        public ActionResult GQT_Menu_61311(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_61311_ViewModel model = new GQT_Menu_61311_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_61311");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_61311.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    // reset the selections for this new navigation flow
                    // TODO: This change still requires more testing
                    Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_61311);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_61311.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_61311, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_61311.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            Navigation.SetValue("pesso.gender", "F");

			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 61311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_61311", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_61311_Partial", model);
        }



        //
        // GET: /Pesso/GQT_Menu_61411
        [AuthorizeForUsers]
		[AuthorizeForUsers]
        [ActionName("GQT_Menu_61411")]
        public ActionResult GQT_Menu_61411(bool allSelected = false)
        {
			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

            GQT_Menu_61411_ViewModel model = new GQT_Menu_61411_ViewModel(Navigation);
            bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
            if (isHomePage)
                Navigation.SetValue("HomePage", "GQT_Menu_61411");
            ViewBag.isHomePage = isHomePage;
            //If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
            if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
                UserContext.Current.SetPersistenceReadOnly(true);
            else
			{
                Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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
                if (Navigation.CurrentLevel == null || !ACTION_GQT_MENU_61411.IsSameAction(Navigation.CurrentLevel.Location))
                {
                    if (Navigation.ContainsAction(ACTION_GQT_MENU_61411))
                        Navigation.RemoveHistoryLevel(ACTION_GQT_MENU_61411);
                    if (Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_61411.Action)
                    {
                        Navigation.AddHistoryLevel(ACTION_GQT_MENU_61411, FormMode.List);
                        CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
                    }
				}
            }
            else if (isHomePage)
            {
                CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_61411.ShortDescription());
                Navigation.SetValue("HomePageContainsList", true);
            }


            if (!String.IsNullOrEmpty(querystring["cate1"]))
                Navigation.SetValue("cate1", querystring["cate1"]);


			model.Navigation = Navigation;

// USE /[MANUAL GQT MENU_GET 61411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

            if(model.CheckForZzstate())
                WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

 
            if(isHomePage)
                return PartialView("GQT_Menu_61411", model);
            else if (!Request.IsAjaxRequest())
                return View(model);
            else
                return PartialView("GQT_Menu_61411_Partial", model);
        }




		#endregion



    }
}