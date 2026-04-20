using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using CSGenio.core.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Expen;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EXPEN]/

namespace GenioMVC.Controllers
{
	public partial class ExpenController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_361 = new NavigationLocation("DESPESAS23133", "PTN_Menu_361", "Expen") { vueRouteName = "menu-PTN_361" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MC_T = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MC_T", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MC_T" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_MC_T = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MB_MC_T", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MB_MC_T" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_MB_TR = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_MB_TR", "Expen") { vueRouteName = "menu-PTN_LIST_DB_MB_TR" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DB_TR_F = new NavigationLocation("DESPESAS23133", "PTN_Menu_LIST_DB_TR_F", "Expen") { vueRouteName = "menu-PTN_LIST_DB_TR_F" };
		private static readonly NavigationLocation ACTION_GQT_MENU_A21 = new NavigationLocation("DESPESAS23133", "GQT_Menu_A21", "Expen") { vueRouteName = "menu-GQT_A21" };


		//
		// GET: /Expen/PTN_Menu_361
		[ActionName("PTN_Menu_361")]
		[HttpPost]
		public ActionResult PTN_Menu_361([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_361_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_361");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_361.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_361.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_361.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 361]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Expen/PTN_Menu_LIST_DB_MC_T
		[ActionName("PTN_Menu_LIST_DB_MC_T")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DB_MC_T([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_LIST_DB_MC_T_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MC_T");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MC_T.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MC_T.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MC_T.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET LIST_DB_MC_T]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Expen/PTN_MenuMC_LIST_DB_MC_T
		public ActionResult PTN_MenuMC_LIST_DB_MC_T([FromBody]RequestOpenModel requestModel)
		{
			string id = requestModel.Id;
			string formMode = requestModel.FormMode;

			if (Navigation.CurrentLevel != null)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Models.Expen expen = Models.Expen.Find(id, UserContext.Current, "MLLIST_DB_MC_T");
			Navigation.SetValue("expen", id);
			if (expen != null && (CSGenio.framework.GenFunctions.emptyC(((string)expen.ValDescript))==0))
			{
				return JsonOK(new { actionName = "MC_3B11", id = id });
			}
			if (expen != null && (CSGenio.framework.GenFunctions.emptyC(((string)expen.ValDescript))==1))
			{
				return JsonOK(new { actionName = "MC_3B12", id = id });
			}
			else
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Show";
				return RedirectToFormAction("DESPE", formMode.ToUpper(), new { id });
			}
		}

		//
		// GET: /Expen/PTN_Menu_LIST_DB_MB_MC_T
		[ActionName("PTN_Menu_LIST_DB_MB_MC_T")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DB_MB_MC_T([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_LIST_DB_MB_MC_T_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_MC_T");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_MC_T.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_MC_T.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_MC_T.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET LIST_DB_MB_MC_T]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Expen/PTN_MenuMC_BUTTONTRIGGERTEST2
		public ActionResult PTN_MenuMC_BUTTONTRIGGERTEST2([FromBody]RequestOpenModel requestModel)
		{
			string id = requestModel.Id;
			string formMode = requestModel.FormMode;

			if (Navigation.CurrentLevel != null)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Models.Expen expen = Models.Expen.Find(id, UserContext.Current, "MLLIST_DB_MB_MC_T");
			Navigation.SetValue("expen", id);
			if (expen != null && (CSGenio.framework.GenFunctions.emptyC(((string)expen.ValDescript))==0))
			{
				return JsonOK(new { actionName = "MC_3C111", id = id });
			}
			if (expen != null && (CSGenio.framework.GenFunctions.emptyC(((string)expen.ValDescript))==1))
			{
				return JsonOK(new { actionName = "MC_3C112", id = id });
			}
			else
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Show";
				return RedirectToFormAction("DESPE", formMode.ToUpper(), new { id });
			}
		}

		//
		// GET: /Expen/PTN_Menu_LIST_DB_MB_TR
		[ActionName("PTN_Menu_LIST_DB_MB_TR")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DB_MB_TR([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_LIST_DB_MB_TR_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_MB_TR");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_MB_TR.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_MB_TR.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_MB_TR.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET LIST_DB_MB_TR]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Expen/PTN_Menu_LIST_DB_TR_F
		[ActionName("PTN_Menu_LIST_DB_TR_F")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DB_TR_F([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_LIST_DB_TR_F_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_LIST_DB_TR_F");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DB_TR_F.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DB_TR_F.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DB_TR_F.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET LIST_DB_TR_F]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}

		//
		// GET: /Expen/GQT_Menu_A21
		[ActionName("GQT_Menu_A21")]
		[HttpPost]
		public ActionResult GQT_Menu_A21([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_A21_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_A21");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_expen")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_expen");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_A21.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_A21.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_A21.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET A21]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}


			return JsonOK(model);
		}



	}
}
