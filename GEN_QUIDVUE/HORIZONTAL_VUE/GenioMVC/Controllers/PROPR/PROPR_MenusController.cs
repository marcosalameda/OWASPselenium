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
using GenioMVC.ViewModels.Propr;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPR]/

namespace GenioMVC.Controllers
{
	public partial class ProprController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_IMO_MENU_111 = new NavigationLocation("REAL_ESTATE24996", "IMO_Menu_111", "Propr") { vueRouteName = "menu-IMO_111" };
		private static readonly NavigationLocation ACTION_IMO_MENU_1311 = new NavigationLocation("REAL_ESTATE24996", "IMO_Menu_1311", "Propr") { vueRouteName = "menu-IMO_1311" };


		//
		// GET: /Propr/IMO_Menu_111
		[ActionName("IMO_Menu_111")]
		[HttpPost]
		public ActionResult IMO_Menu_111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			IMO_Menu_111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "IMO_Menu_111");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_IMO_MENU_111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL IMO MENU_GET 111]/

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
		// GET: /Propr/IMO_Menu_1311
		[ActionName("IMO_Menu_1311")]
		[HttpPost]
		public ActionResult IMO_Menu_1311([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			IMO_Menu_1311_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "IMO_Menu_1311");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_IMO_MENU_1311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_IMO_MENU_1311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_IMO_MENU_1311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["cntry"]))
				Navigation.SetValue("cntry", querystring["cntry"]);


// USE /[MANUAL IMO MENU_GET 1311]/

			try
			{
				model.Load(tableConfig, querystring, Request.IsAjaxRequest());
			}
			catch (Exception e)
			{
				return JsonERROR(HandleException(e), model);
			}

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("PROPR00"))
				Navigation.GoBack.Remove("PROPR00");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("PROPR00"))
				Navigation.OverrideSkipIfJustOne.Remove("PROPR00");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.Filters.Count == 0;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.NoRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodpropr;
				var navKey = "propr";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("PROPR00", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, propr = primaryKey }, model);
			}

			return JsonOK(model);
		}



	}
}
