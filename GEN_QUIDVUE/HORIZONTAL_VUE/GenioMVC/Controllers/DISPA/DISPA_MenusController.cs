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
using GenioMVC.ViewModels.Dispa;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISPA]/

namespace GenioMVC.Controllers
{
	public partial class DispaController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_WMS_MENU_2111 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2111", "Dispa") { vueRouteName = "menu-WMS_2111" };
		private static readonly NavigationLocation ACTION_WMS_MENU_2211 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2211", "Dispa") { vueRouteName = "menu-WMS_2211" };
		private static readonly NavigationLocation ACTION_WMS_MENU_231 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_231", "Dispa") { vueRouteName = "menu-WMS_231" };


		//
		// GET: /Dispa/WMS_Menu_2111
		[ActionName("WMS_Menu_2111")]
		[HttpPost]
		public ActionResult WMS_Menu_2111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			WMS_Menu_2111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "WMS_Menu_2111");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dispa");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_2111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_2111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_2111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("dispa.isprepar", "0");

// USE /[MANUAL WMS MENU_GET 2111]/

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
		// GET: /Dispa/WMS_Menu_2211
		[ActionName("WMS_Menu_2211")]
		[HttpPost]
		public ActionResult WMS_Menu_2211([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			WMS_Menu_2211_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "WMS_Menu_2211");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dispa");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_2211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_2211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_2211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("dispa.isprepar", "1");

// USE /[MANUAL WMS MENU_GET 2211]/

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
		// GET: /Dispa/WMS_Menu_231
		[ActionName("WMS_Menu_231")]
		[HttpPost]
		public ActionResult WMS_Menu_231([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			WMS_Menu_231_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "WMS_Menu_231");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dispa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dispa");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_231.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_231.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_231.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL WMS MENU_GET 231]/

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
