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
using GenioMVC.ViewModels.Grpb;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GRPB]/

namespace GenioMVC.Controllers
{
	public partial class GrpbController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_EDITABLETABLELIST = new NavigationLocation("GROUPS__BASIC_25795", "PTN_Menu_EDITABLETABLELIST", "Grpb") { vueRouteName = "menu-PTN_EDITABLETABLELIST" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3M1 = new NavigationLocation("LIST_WITH_COLUMNS_FR36713", "PTN_Menu_3M1", "Grpb") { vueRouteName = "menu-PTN_3M1" };


		//
		// GET: /Grpb/PTN_Menu_EDITABLETABLELIST
		[ActionName("PTN_Menu_EDITABLETABLELIST")]
		[HttpPost]
		public ActionResult PTN_Menu_EDITABLETABLELIST([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_EDITABLETABLELIST_ViewModel model = new PTN_Menu_EDITABLETABLELIST_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "PTN_Menu_EDITABLETABLELIST");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_grpb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_grpb");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_EDITABLETABLELIST.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_EDITABLETABLELIST.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_EDITABLETABLELIST.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET EDITABLETABLELIST]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}

		//
		// GET: /Grpb/PTN_Menu_3M1
		[ActionName("PTN_Menu_3M1")]
		[HttpPost]
		public ActionResult PTN_Menu_3M1([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_3M1_ViewModel model = new PTN_Menu_3M1_ViewModel(UserContext.Current);

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
				tableConfigOptions,
				new CSGenio.framework.TableConfiguration.TableConfiguration()
				{
					LineBreak = true
				}

			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3M1");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_grpb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_grpb");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3M1.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3M1.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3M1.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 3M1]/


			model.Load(tableConfig, querystring, Request.IsAjaxRequest());


			return JsonOK(model);
		}



	}
}
