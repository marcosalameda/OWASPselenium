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
using GenioMVC.ViewModels.Glob;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GLOB]/

namespace GenioMVC.Controllers
{
	public partial class GlobController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_TBS_MENU_171 = new NavigationLocation("OPCOES_GLOBAIS50596", "TBS_Menu_171", "Glob") { vueRouteName = "menu-TBS_171" };
		private static readonly NavigationLocation ACTION_WMS_MENU_4241 = new NavigationLocation("GLOBAL_PARAMETERS41637", "WMS_Menu_4241", "Glob") { vueRouteName = "menu-WMS_4241" };


		//
		// GET: /Glob/TBS_Menu_171
		[ActionName("TBS_Menu_171")]
		[HttpPost]
		public ActionResult TBS_Menu_171([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			TBS_Menu_171_ViewModel model = new TBS_Menu_171_ViewModel(UserContext.Current);
			
			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();
			
 
			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "TBS_Menu_171");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_glob")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_glob");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_TBS_MENU_171.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_TBS_MENU_171.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_TBS_MENU_171.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL TBS MENU_GET 171]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("GLOB"))
				Navigation.GoBack.Remove("GLOB");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GLOB"))
				Navigation.OverrideSkipIfJustOne.Remove("GLOB");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.SearchFilters.Count == 0 && tableConfig.StaticFilters.Count == 0 && tableConfig.ActiveFilter == null;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodglob;
				var navKey = "glob";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("GLOB", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, glob = primaryKey }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Glob/WMS_Menu_4241
		[ActionName("WMS_Menu_4241")]
		[HttpPost]
		public ActionResult WMS_Menu_4241([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_4241_ViewModel model = new WMS_Menu_4241_ViewModel(UserContext.Current);
			
			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();
			
 
			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "WMS_Menu_4241");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_glob")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_glob");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_4241.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_4241.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_4241.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL WMS MENU_GET 4241]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("GLOBFACT"))
				Navigation.GoBack.Remove("GLOBFACT");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GLOBFACT"))
				Navigation.OverrideSkipIfJustOne.Remove("GLOBFACT");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.SearchFilters.Count == 0 && tableConfig.StaticFilters.Count == 0 && tableConfig.ActiveFilter == null;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodglob;
				var navKey = "glob";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("GLOBFACT", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, glob = primaryKey }, model);
			}

			return JsonOK(model);
		}



	}
}
