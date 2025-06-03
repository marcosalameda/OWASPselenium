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
		private static readonly NavigationLocation ACTION_WMS_MENU_211 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_211", "Dispa") { vueRouteName = "menu-WMS_211" };
		private static readonly NavigationLocation ACTION_WMS_MENU_2211 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2211", "Dispa") { vueRouteName = "menu-WMS_2211" };
		private static readonly NavigationLocation ACTION_WMS_MENU_2311 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_2311", "Dispa") { vueRouteName = "menu-WMS_2311" };
		private static readonly NavigationLocation ACTION_WMS_MENU_241 = new NavigationLocation("DISPATCHES13773", "WMS_Menu_241", "Dispa") { vueRouteName = "menu-WMS_241" };


		//
		// GET: /Dispa/WMS_Menu_211
		[ActionName("WMS_Menu_211")]
		[HttpPost]
		public ActionResult WMS_Menu_211([FromBody]RequestMenuModel requestModel)
		{
			WMS_Menu_211_ViewModel model = new(UserContext.Current);

			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_211.ShortDescription());

// USE /[MANUAL WMS MENU_GET 211]/

			model.Load();

			return JsonOK(model);
		}

		[ActionName("WMS_Menu_211_EventHandler")]
		[HttpPost]
		public ActionResult WMS_Menu_211_EventHandler([FromBody]RequestKanbanModel requestModel)
		{
			WMS_Menu_211_ViewModel model = new(UserContext.Current);

			CSGenio.framework.StatusMessage permissionResult = model.CheckPermissions(FormMode.Edit);
			if (permissionResult.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permissionResult.Message);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_211.ShortDescription() + " Event Handler");

			try
			{
				var result = model.EventHandler(requestModel);
				return JsonOK(result);
			}
			catch(Exception e)
			{
				var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
				if (e is GenioException && (e as GenioException).UserMessage != null)
					exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
				return JsonERROR(exceptionUserMessage);
			}
		}

		//
		// GET: /Dispa/WMS_Menu_2211
		[ActionName("WMS_Menu_2211")]
		[HttpPost]
		public ActionResult WMS_Menu_2211([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_2211_ViewModel model = new WMS_Menu_2211_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "WMS_Menu_2211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
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

			NameValueCollection querystring = new NameValueCollection();
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


			Navigation.SetValue("dispa.isprepar", "0");

// USE /[MANUAL WMS MENU_GET 2211]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Dispa/WMS_Menu_2311
		[ActionName("WMS_Menu_2311")]
		[HttpPost]
		public ActionResult WMS_Menu_2311([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_2311_ViewModel model = new WMS_Menu_2311_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "WMS_Menu_2311");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
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

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_2311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_2311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_2311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("dispa.isprepar", "1");

// USE /[MANUAL WMS MENU_GET 2311]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Dispa/WMS_Menu_241
		[ActionName("WMS_Menu_241")]
		[HttpPost]
		public ActionResult WMS_Menu_241([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_241_ViewModel model = new WMS_Menu_241_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "WMS_Menu_241");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
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

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_241.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_241.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_241.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL WMS MENU_GET 241]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}



	}
}
