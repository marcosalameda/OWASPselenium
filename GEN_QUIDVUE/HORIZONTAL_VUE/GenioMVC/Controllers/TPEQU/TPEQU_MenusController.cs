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
using GenioMVC.ViewModels.Tpequ;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPEQU]/

namespace GenioMVC.Controllers
{
	public partial class TpequController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_GQT_MENU_2911 = new NavigationLocation("TYPES_OF_EQUIPMENT61264", "GQT_Menu_2911", "Tpequ") { vueRouteName = "menu-GQT_2911" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2A1 = new NavigationLocation("TYPES_OF_EQUIPMENT61264", "GQT_Menu_2A1", "Tpequ") { vueRouteName = "menu-GQT_2A1" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D11 = new NavigationLocation("TYPES_OF_EQUIPMENT61264", "GQT_Menu_2D11", "Tpequ") { vueRouteName = "menu-GQT_2D11" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D21 = new NavigationLocation("TYPES_OF_EQUIPMENT61264", "GQT_Menu_2D21", "Tpequ") { vueRouteName = "menu-GQT_2D21" };


		//
		// GET: /Tpequ/GQT_Menu_2911
		[ActionName("GQT_Menu_2911")]
		[HttpPost]
		public ActionResult GQT_Menu_2911([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_2911_ViewModel model = new GQT_Menu_2911_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_2911");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2911.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2911.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2911.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2911]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Tpequ/GQT_Menu_2A1
		[ActionName("GQT_Menu_2A1")]
		[HttpPost]
		public ActionResult GQT_Menu_2A1([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_2A1_ViewModel model = new GQT_Menu_2A1_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_2A1");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2A1.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2A1.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2A1.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2A1]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Tpequ/GQT_Menu_2D11
		[ActionName("GQT_Menu_2D11_Selections")]
		[HttpPost]
		public ActionResult GQT_Menu_2D11_Selections([FromBody] RequestSelectionsModel requestModel)
		{
			var ids = requestModel.Ids.ToArray();

			Navigation.ClearValue("tpequ_Selections");
			if (ids != null && ids.Length != 0)
				Navigation.SetValue("tpequ_Selections", ids);
			return Json(new { Success = true });
		}

		[ActionName("GQT_Menu_2D11")]
		[HttpPost]
		public ActionResult GQT_Menu_2D11([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_2D11_ViewModel model = new GQT_Menu_2D11_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_2D11");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D11.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D11.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D11.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2D11]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Tpequ/GQT_Menu_2D21
		[ActionName("GQT_Menu_2D21_Selections")]
		[HttpPost]
		public ActionResult GQT_Menu_2D21_Selections([FromBody] RequestSelectionsModel requestModel)
		{
			var ids = requestModel.Ids.ToArray();

			Navigation.ClearValue("tpequ_Selections");
			if (ids != null && ids.Length != 0)
				Navigation.SetValue("tpequ_Selections", ids);
			return Json(new { Success = true });
		}

		[ActionName("GQT_Menu_2D21")]
		[HttpPost]
		public ActionResult GQT_Menu_2D21([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_2D21_ViewModel model = new GQT_Menu_2D21_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_2D21");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D21.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D21.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D21.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2D21]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}



	}
}
