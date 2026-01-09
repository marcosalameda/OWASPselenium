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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_STY_MENU_ACCORD = new NavigationLocation("EQUIPMENT03632", "STY_Menu_ACCORD", "Equip") { vueRouteName = "menu-STY_ACCORD" };
		private static readonly NavigationLocation ACTION_STY_MENU_GROUPBOX = new NavigationLocation("GROUPBOX00384", "STY_Menu_GROUPBOX", "Equip") { vueRouteName = "menu-STY_GROUPBOX" };
		private static readonly NavigationLocation ACTION_STY_MENU_TABLE = new NavigationLocation("TABLE15475", "STY_Menu_TABLE", "Equip") { vueRouteName = "menu-STY_TABLE" };
		private static readonly NavigationLocation ACTION_STY_MENU_FULLCALENDAR = new NavigationLocation("EQUIPMENT03632", "STY_Menu_FULLCALENDAR", "Equip") { vueRouteName = "menu-STY_FULLCALENDAR" };
		private static readonly NavigationLocation ACTION_STY_MENU_GOOGLEMAPS = new NavigationLocation("LISTAGEM45924", "STY_Menu_GOOGLEMAPS", "Equip") { vueRouteName = "menu-STY_GOOGLEMAPS" };
		private static readonly NavigationLocation ACTION_STY_MENU_371 = new NavigationLocation("EQUIPMENT03632", "STY_Menu_371", "Equip") { vueRouteName = "menu-STY_371" };
		private static readonly NavigationLocation ACTION_GQT_MENU_171 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_171", "Equip") { vueRouteName = "menu-GQT_171" };
		private static readonly NavigationLocation ACTION_GQT_MENU_211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_211", "Equip") { vueRouteName = "menu-GQT_211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2211", "Equip") { vueRouteName = "menu-GQT_2211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_231 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_231", "Equip") { vueRouteName = "menu-GQT_231" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2411 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2411", "Equip") { vueRouteName = "menu-GQT_2411" };
		private static readonly NavigationLocation ACTION_GQT_MENU_251 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_251", "Equip") { vueRouteName = "menu-GQT_251" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C11 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C11", "Equip") { vueRouteName = "menu-GQT_2C11" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C211", "Equip") { vueRouteName = "menu-GQT_2C211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C311 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2C311", "Equip") { vueRouteName = "menu-GQT_2C311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D111 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2D111", "Equip") { vueRouteName = "menu-GQT_2D111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2D2111 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_2D2111", "Equip") { vueRouteName = "menu-GQT_2D2111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_6211 = new NavigationLocation("EQUIPMENT03632", "GQT_Menu_6211", "Equip") { vueRouteName = "menu-GQT_6211" };
		private static readonly NavigationLocation ACTION_PTN_MENU_241 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_241", "Equip") { vueRouteName = "menu-PTN_241" };
		private static readonly NavigationLocation ACTION_PTN_MENU_251 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_251", "Equip") { vueRouteName = "menu-PTN_251" };
		private static readonly NavigationLocation ACTION_PTN_MENU_331 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_331", "Equip") { vueRouteName = "menu-PTN_331" };
		private static readonly NavigationLocation ACTION_PTN_MENU_341 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_341", "Equip") { vueRouteName = "menu-PTN_341" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3511 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_3511", "Equip") { vueRouteName = "menu-PTN_3511" };
		private static readonly NavigationLocation ACTION_PTN_MENUSE_3G1 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "PTN_MenuSE_3G1", "Equip") { vueRouteName = "menu-PTN_3G1" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3G11 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_3G11", "Equip") { vueRouteName = "menu-PTN_3G11" };
		private static readonly NavigationLocation ACTION_PTN_MENU_621 = new NavigationLocation("EQUIPMENT03632", "PTN_Menu_621", "Equip") { vueRouteName = "menu-PTN_621" };


		//
		// GET: /Equip/STY_Menu_ACCORD
		[ActionName("STY_Menu_ACCORD")]
		[HttpPost]
		public ActionResult STY_Menu_ACCORD([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_ACCORD_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(10, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_ACCORD");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_ACCORD.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_ACCORD.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_ACCORD.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.showrc", "1");

// USE /[MANUAL STY MENU_GET ACCORD]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "STY_Menu_ACCORD_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAequip> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format (Currently, this functionality is only implemented in MVC Razor)
				/*if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}*/

				byte[] fileBytes = null;
// USE /[MANUAL STY OVERRQEXPORT ACCORD]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_STY_MENU_ACCORD.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

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
			if (Navigation.GoBack.ContainsKey("ACCORDI"))
				Navigation.GoBack.Remove("ACCORDI");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("ACCORDI"))
				Navigation.OverrideSkipIfJustOne.Remove("ACCORDI");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.Filters.Count == 0;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("ACCORDI", "SHOW", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, equip = primaryKey }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Equip/STY_Menu_GROUPBOX
		[ActionName("STY_Menu_GROUPBOX")]
		[HttpPost]
		public ActionResult STY_Menu_GROUPBOX([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_GROUPBOX_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_GROUPBOX");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_GROUPBOX.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_GROUPBOX.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_GROUPBOX.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.showrc", "1");

// USE /[MANUAL STY MENU_GET GROUPBOX]/

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
			if (Navigation.GoBack.ContainsKey("GROUPBX"))
				Navigation.GoBack.Remove("GROUPBX");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GROUPBX"))
				Navigation.OverrideSkipIfJustOne.Remove("GROUPBX");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.Filters.Count == 0;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("GROUPBX", "SHOW", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, equip = primaryKey }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Equip/STY_Menu_TABLE
		[ActionName("STY_Menu_TABLE")]
		[HttpPost]
		public ActionResult STY_Menu_TABLE([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_TABLE_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(10, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_TABLE");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_TABLE.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_TABLE.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_TABLE.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL STY MENU_GET TABLE]/

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
		// GET: /Equip/STY_Menu_FULLCALENDAR
		[ActionName("STY_Menu_FULLCALENDAR")]
		[HttpPost]
		public ActionResult STY_Menu_FULLCALENDAR([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_FULLCALENDAR_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(10, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_FULLCALENDAR");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_FULLCALENDAR.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_FULLCALENDAR.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_FULLCALENDAR.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.showrc", "1");

// USE /[MANUAL STY MENU_GET FULLCALENDAR]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "STY_Menu_FULLCALENDAR_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAequip> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format (Currently, this functionality is only implemented in MVC Razor)
				/*if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}*/

				byte[] fileBytes = null;
// USE /[MANUAL STY OVERRQEXPORT FULLCALENDAR]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_STY_MENU_FULLCALENDAR.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

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
			if (Navigation.GoBack.ContainsKey("FULLCALE"))
				Navigation.GoBack.Remove("FULLCALE");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("FULLCALE"))
				Navigation.OverrideSkipIfJustOne.Remove("FULLCALE");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.Filters.Count == 0;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("FULLCALE", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, equip = primaryKey }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Equip/STY_Menu_GOOGLEMAPS
		[ActionName("STY_Menu_GOOGLEMAPS")]
		[HttpPost]
		public ActionResult STY_Menu_GOOGLEMAPS([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_GOOGLEMAPS_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(10, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_GOOGLEMAPS");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_GOOGLEMAPS.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_GOOGLEMAPS.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_GOOGLEMAPS.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.showrc", "1");

// USE /[MANUAL STY MENU_GET GOOGLEMAPS]/

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
			if (Navigation.GoBack.ContainsKey("GMAPS"))
				Navigation.GoBack.Remove("GMAPS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("GMAPS"))
				Navigation.OverrideSkipIfJustOne.Remove("GMAPS");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			// only allow the jump if there are no filters
			bool hasNoFilters = tableConfig.Filters.Count == 0;
			bool isFirstDataLoad = (bool)requestModel?.IsFirstLoad;
			bool isNoRedirect = (bool)requestModel?.noRedirect;

			if (isFirstDataLoad && curRowsCount == 1 && hasNoFilters && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodequip;
				var navKey = "equip";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = isNoRedirect;

				return RedirectToFormAction("GMAPS", "SHOW", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true, equip = primaryKey }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Equip/STY_Menu_371
		[ActionName("STY_Menu_371")]
		[HttpPost]
		public ActionResult STY_Menu_371([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			STY_Menu_371_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_371");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_371.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_371.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_371.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL STY MENU_GET 371]/

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
		// GET: /Equip/GQT_Menu_171
		[ActionName("GQT_Menu_171")]
		[HttpPost]
		public ActionResult GQT_Menu_171([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_171_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_171");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_171.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_171.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_171.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 171]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_171_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAequip> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format (Currently, this functionality is only implemented in MVC Razor)
				/*if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}*/

				byte[] fileBytes = null;
// USE /[MANUAL GQT OVERRQEXPORT 171]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_171.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

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
		// GET: /Equip/GQT_Menu_211
		[ActionName("GQT_Menu_211")]
		[HttpPost]
		public ActionResult GQT_Menu_211([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_211_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 211]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAequip> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format (Currently, this functionality is only implemented in MVC Razor)
				/*if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}*/

				byte[] fileBytes = null;
// USE /[MANUAL GQT OVERRQEXPORT 211]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_211.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

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
		// GET: /Equip/GQT_Menu_2211
		[ActionName("GQT_Menu_2211")]
		[HttpPost]
		public ActionResult GQT_Menu_2211([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2211_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.bought", "1");

// USE /[MANUAL GQT MENU_GET 2211]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_2211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAequip> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format (Currently, this functionality is only implemented in MVC Razor)
				/*if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}*/

				byte[] fileBytes = null;
// USE /[MANUAL GQT OVERRQEXPORT 2211]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_2211.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

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
		// GET: /Equip/GQT_Menu_231
		[ActionName("GQT_Menu_231")]
		[HttpPost]
		public ActionResult GQT_Menu_231([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_231_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.legacy.v1.TableConfigurationUpdate.SetFilterShiftValue(model.Uuid, "filter_GQT_Menu_231_ACTIVO", 0);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_231");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_231.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_231.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_231.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 231]/

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
		/// <summary>
		/// GET/POST: /Equip/GQT_Menu_231
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <param name="dest_id"></param>
		/// <returns></returns>
		public JsonResult GQT_Menu_231_Execute([FromBody]RequestMenuMultiSelectAddModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			string dest_id = requestModel?.DestinationId;
			bool allSelected = (bool)(requestModel?.AllSelected);
			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel?.TableConfiguration;

			GQT_Menu_231_ViewModel menuViewModel = new GQT_Menu_231_ViewModel(UserContext.Current);
			CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);

			if (result.Status.Equals(CSGenio.framework.Status.E))
				return Json(new { Success = false,  Message = result.Message });

			if ((selected_ids == null && !allSelected) || string.IsNullOrEmpty(dest_id))
				return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });

			var alternativeRedirect = string.Empty;

			//Create progress object
			this.Navigation.SetValue("ProgressReport_ML231", new ProgressReport());

			//Reference it so it can be used in the thread below
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML231");
			PersistentSupport sp = m_userContext.PersistentSupport;
			try
			{
				NavigationContext navCtx = Navigation.Clone(); //Clone Navigation
				NameValueCollection parameters = new NameValueCollection();

				//Get CriteriaSet
				CriteriaSet crs = menuViewModel.BuildCriteriaSet(tableConfig, parameters, out bool hasAllRequiredLimits);

				UserContext userCtx = UserContext.Current;
				sp.openTransaction();

				progress.Report("GQT_Menu_231", 0);
				SelectQuery query;
				if (allSelected)
				{
					/* Build subquery with custom CriteriaSet */
					SelectQuery allIds = new SelectQuery()
						.Select(CSGenioAequip.FldCodequip)
						.From(CSGenio.business.Area.AreaEQUIP);

					//Fetch Current Area
					CSGenio.business.Area area = CSGenio.business.Area.createArea("equip", userCtx.User, userCtx.User.CurrentModule);

					//Add Related Areas to Query Joins
					QueryUtils.SetInnerJoins(new[] { "EQUIP.FldCodequip" }, crs, area, allIds);
					allIds.Where(crs);
					/* -------------------------------------- */

					//Replace the selected rows array
					DataMatrix dm = sp.Execute(allIds);
					selected_ids = new string[dm.NumRows];
					for (int i = 0; i < dm.NumRows; i++)
						if (!string.IsNullOrEmpty(dm.GetKey(i, 0).ToString()))
							selected_ids[i] = dm.GetKey(i, 0).ToString();

					//Run the main query
					query = new SelectQuery()
					.Select(CSGenioAmovim.FldCodequip)
					.From(CSGenio.business.Area.AreaMOVIM)
					.Where(CriteriaSet.And()
						.Equal(CSGenioAmovim.FldCodrooms, dest_id)
						.In(CSGenioAmovim.FldCodequip, allIds)
						.Equal(CSGenioAmovim.FldZzstate, 0));
				}
				else
				{
					query = new SelectQuery()
					.Select(CSGenioAmovim.FldCodequip)
					.From(CSGenio.business.Area.AreaMOVIM)
					.Where(CriteriaSet.And()
						.Equal(CSGenioAmovim.FldCodrooms, dest_id)
						.In(CSGenioAmovim.FldCodequip, selected_ids)
						.Equal(CSGenioAmovim.FldZzstate, 0));
				}

				int cnt = 0;
				List<string> cods = new List<string>();
				DataMatrix cod = sp.Execute(query);
				for (int i = 0; i < cod.NumRows; i++)
					cods.Add(cod.GetString(i, 0));
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_231]/
				foreach (string selectedId in selected_ids)
				{
					//Update Progress
					progress.Report("GQT_Menu_231", (cnt * 100.0) / selected_ids.Length);

					if (cods.Contains(selectedId))
						continue;
					Models.Movim model = new Models.Movim(userCtx);
					model.LoadKeysFromHistory(navCtx, navCtx.CurrentLevel.Level);
					model.New("MGQT_Menu_231");
					// Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
					model.LoadKeysFromHistory(navCtx, navCtx.CurrentLevel.Level, false);
					// Preencher as chaves selecionadas
					model.ValCodequip = selectedId;
					model.ValCodrooms = dest_id;
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_231]/
					model.Save(sp);
					cnt++;
				}
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_231]/
				sp.closeTransaction();

				// Update to 100% Progress
				progress.Report("GQT_Menu_231", 100);
				progress.Finished = true;
			}
			catch (ModelNotFoundException e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				//Show error
				Log.Error(e.Message);
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
				progress.Finished = true;

				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				// Show error
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				if (e is GenioException && (e as GenioException).UserMessage != null)
					Log.Error((e as GenioException).UserMessage);
				else
					Log.Error(e.Message);
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("GQT_Menu_231", -1, true, null, null, error, null);
				progress.Finished = true;

				return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language) });
			}

			return Json(new { Success = true, RedirectURL = alternativeRedirect });
		}

		/// <summary>
		/// GET/POST: /Equip/GQT_Menu_231
		/// </summary>
		/// <returns></returns>
		public JsonResult GQT_Menu_231_Progress()
		{
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML231");

			if (progress == null)
				return Json(new { Success = true, percent = 0, message = Resources.Resources.THERE_IS_NO_TASK_RUN02354, finished = false, ongoing = false});

			if (progress.Finished)
			{
				if (progress.Percent == 100)
					return Json(new { Success = true, percent = 100, message = Resources.Resources.ALTERACOES_EFETUADAS10166, finished = true, ongoing = false });
				else
				{
					if (progress.Errors != null)
					{
						if (!string.IsNullOrEmpty(progress.Errors.ErrorResponse))
						{
							return Json(new { Success = false, percent = progress.Percent,
							message = progress.Errors.ErrorResponse,
							finished = false, ongoing = false });
						}
						else if (progress.Errors.ErrorLog.Count() > 0)
						{
							string messageBuilder = "";
							foreach (string err in progress.Errors.ErrorLog)
								messageBuilder += err + "<br />";

							return Json(new { Success = false, percent = progress.Percent,
							message = messageBuilder,
							finished = false, ongoing = false });
						}
					}

					return Json(new { Success = false, percent = progress.Percent,
						message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091,
						finished = true, ongoing = false });
				}
			}
			else
				return Json(new { Success = true, percent = progress.Percent, message = "", finished = false, ongoing = true });
		}

		//
		// GET: /Equip/GQT_Menu_2411
		[ActionName("GQT_Menu_2411")]
		[HttpPost]
		public ActionResult GQT_Menu_2411([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2411_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2411");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2411.ShortDescription());

			if (!String.IsNullOrEmpty(querystring["rooms"]))
				Navigation.SetValue("rooms", querystring["rooms"]);


// USE /[MANUAL GQT MENU_GET 2411]/

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
		// GET: /Equip/GQT_Menu_251
		[ActionName("GQT_Menu_251")]
		[HttpPost]
		public ActionResult GQT_Menu_251([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_251_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_251");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_251.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_251.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_251.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 251]/

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
		/// <summary>
		/// GET/POST: /Equip/GQT_Menu_251
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <returns></returns>
		public JsonResult GQT_Menu_251_Execute([FromBody]RequestMenuMultiSelectRemoveModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			
			GQT_Menu_251_ViewModel menuViewModel = new GQT_Menu_251_ViewModel(UserContext.Current);
			CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return Json(new { Success = false,  Message = result.Message });

			if (selected_ids == null)
				return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var alternativeRedirect = string.Empty;

			try
			{
				sp.openTransaction();
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_251]/
				foreach (string selectedId in selected_ids)
				{
					SelectQuery query = new SelectQuery()
						.Select(CSGenioAmovim.FldCodmovim)
						.From(CSGenio.business.Area.AreaMOVIM)
						.Where(CriteriaSet.And()
							.Equal(CSGenioAmovim.FldCodequip,  Navigation.GetValue("equip"))
							.In(CSGenioAmovim.FldCodrooms, selectedId)
							.Equal(CSGenioAmovim.FldZzstate, 0));

					DataMatrix mx = sp.Execute(query);
					for (int i = 0; i < mx.NumRows; i++)
					{
						var area = new CSGenioAmovim(UserContext.Current.User);
						area.insertNameValueField(query.SelectFields[0].Alias, mx.GetDirect(i, 0));
						area.eliminate(sp);
					}
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_251]/
				}
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_251]/
				sp.closeTransaction();
				Navigation.ClearValue("equip");
			}
			catch (ModelNotFoundException)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
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
		// GET: /Equip/GQT_Menu_2C11
		[ActionName("GQT_Menu_2C11")]
		[HttpPost]
		public ActionResult GQT_Menu_2C11([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2C11_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2C11");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C11.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C11.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C11.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2C11]/

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
		/// <summary>
		/// GET/POST: /Equip/GQT_Menu_2C11
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <param name="dest_id"></param>
		/// <returns></returns>
		public JsonResult GQT_Menu_2C11_Execute([FromBody]RequestMenuMultiSelectAddModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			string dest_id = requestModel?.DestinationId;
			bool allSelected = (bool)(requestModel?.AllSelected);
			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel?.TableConfiguration;

			GQT_Menu_2C11_ViewModel menuViewModel = new GQT_Menu_2C11_ViewModel(UserContext.Current);
			CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);

			if (result.Status.Equals(CSGenio.framework.Status.E))
				return Json(new { Success = false,  Message = result.Message });

			if ((selected_ids == null && !allSelected) || string.IsNullOrEmpty(dest_id))
				return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });

			var alternativeRedirect = string.Empty;

			//Create progress object
			this.Navigation.SetValue("ProgressReport_ML2C11", new ProgressReport());

			//Reference it so it can be used in the thread below
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML2C11");
			PersistentSupport sp = m_userContext.PersistentSupport;
			try
			{
				NavigationContext navCtx = Navigation.Clone(); //Clone Navigation
				NameValueCollection parameters = new NameValueCollection();

				//Get CriteriaSet
				CriteriaSet crs = menuViewModel.BuildCriteriaSet(tableConfig, parameters, out bool hasAllRequiredLimits);

				UserContext userCtx = UserContext.Current;
				sp.openTransaction();

				progress.Report("GQT_Menu_2C11", 0);
				if (allSelected)
				{
					/* Build subquery with custom CriteriaSet */
					SelectQuery allIds = new SelectQuery()
					.Select(CSGenioAequip.FldCodequip)
					.From(CSGenio.business.Area.AreaEQUIP);

					//Fetch Current Area
					CSGenio.business.Area area = CSGenio.business.Area.createArea("equip", userCtx.User, userCtx.User.CurrentModule);

					//Add Related Areas to Query Joins
					QueryUtils.SetInnerJoins(new[] { "EQUIP.FldCodequip" }, crs, area, allIds);
					allIds.Where(crs);
					/* -------------------------------------- */

					//Replace the selected rows array
					DataMatrix dm = sp.Execute(allIds);
					selected_ids = new string[dm.NumRows];
					for (int i = 0; i < dm.NumRows; i++)
						if (!string.IsNullOrEmpty(dm.GetKey(i, 0).ToString()))
							selected_ids[i] = dm.GetKey(i, 0).ToString();
				}

				int cnt = 0;
				foreach (string selectedId in selected_ids)
				{
					//Update Progress
					progress.Report("GQT_Menu_2C11", (cnt * 100) / selected_ids.Length);

					CSGenioAequip model = CSGenioAequip.search(sp, selectedId, userCtx.User);
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_2C11]/
					if (model == null) //In theory, this should never happen
						throw new BusinessException("Could not find record with ID " + selectedId.ToString(), "GQT_Menu_2C11_Execute", "The record with the ID " + selectedId.ToString() + " returned null");

					model.ValCoddeco = dest_id;
					model.update(sp);
					cnt++;
				}
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_2C11]/
				sp.closeTransaction();

				// Update to 100% Progress
				progress.Report("GQT_Menu_2C11", 100);
				progress.Finished = true;
			}
			catch (ModelNotFoundException e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				//Show error
				Log.Error(e.Message);
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("GQT_Menu_2C11", -1, true, null, null, error, null);
				progress.Finished = true;

				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				// Show error
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				if (e is GenioException && (e as GenioException).UserMessage != null)
					Log.Error((e as GenioException).UserMessage);
				else
					Log.Error(e.Message);
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("GQT_Menu_2C11", -1, true, null, null, error, null);
				progress.Finished = true;

				return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language) });
			}

			return Json(new { Success = true, RedirectURL = alternativeRedirect });
		}

		/// <summary>
		/// GET/POST: /Equip/GQT_Menu_2C11
		/// </summary>
		/// <returns></returns>
		public JsonResult GQT_Menu_2C11_Progress()
		{
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML2C11");

			if (progress == null)
				return Json(new { Success = true, percent = 0, message = Resources.Resources.THERE_IS_NO_TASK_RUN02354, finished = false, ongoing = false});

			if (progress.Finished)
			{
				if (progress.Percent == 100)
					return Json(new { Success = true, percent = 100, message = Resources.Resources.ALTERACOES_EFETUADAS10166, finished = true, ongoing = false });
				else
				{
					if (progress.Errors != null)
					{
						if (!string.IsNullOrEmpty(progress.Errors.ErrorResponse))
						{
							return Json(new { Success = false, percent = progress.Percent,
							message = progress.Errors.ErrorResponse,
							finished = false, ongoing = false });
						}
						else if (progress.Errors.ErrorLog.Count() > 0)
						{
							string messageBuilder = "";
							foreach (string err in progress.Errors.ErrorLog)
								messageBuilder += err + "<br />";

							return Json(new { Success = false, percent = progress.Percent,
							message = messageBuilder,
							finished = false, ongoing = false });
						}
					}

					return Json(new { Success = false, percent = progress.Percent,
						message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091,
						finished = true, ongoing = false });
				}
			}
			else
				return Json(new { Success = true, percent = progress.Percent, message = "", finished = false, ongoing = true });
		}

		//
		// GET: /Equip/GQT_Menu_2C211
		[ActionName("GQT_Menu_2C211")]
		[HttpPost]
		public ActionResult GQT_Menu_2C211([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2C211_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2C211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("equip.ifabatif", "1");

// USE /[MANUAL GQT MENU_GET 2C211]/

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
		// GET: /Equip/GQT_Menu_2C311
		[ActionName("GQT_Menu_2C311")]
		[HttpPost]
		public ActionResult GQT_Menu_2C311([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2C311_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2C311");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C311.ShortDescription());

			if (!String.IsNullOrEmpty(querystring["decom"]))
				Navigation.SetValue("decom", querystring["decom"]);


// USE /[MANUAL GQT MENU_GET 2C311]/

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
		// GET: /Equip/GQT_Menu_2D111
		[ActionName("GQT_Menu_2D111")]
		[HttpPost]
		public ActionResult GQT_Menu_2D111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2D111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2D111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			/*
			 * If all the records on the previous DM were selected, this means we do not need
			 * to filter, since having them all checked = having no filters at all
			 */
			if (requestModel.AllSelected)
				Navigation.DestroyEntry("tpequ_Selections");

			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2D111]/

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
		// GET: /Equip/GQT_Menu_2D2111
		[ActionName("GQT_Menu_2D2111")]
		[HttpPost]
		public ActionResult GQT_Menu_2D2111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2D2111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2D2111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			/*
			 * If all the records on the previous DM were selected, this means we do not need
			 * to filter, since having them all checked = having no filters at all
			 */
			if (requestModel.AllSelected)
				Navigation.DestroyEntry("tpequ_Selections");

			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2D2111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2D2111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2D2111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2D2111]/

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
		// GET: /Equip/GQT_Menu_6211
		[ActionName("GQT_Menu_6211")]
		[HttpPost]
		public ActionResult GQT_Menu_6211([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_6211_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_6211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_6211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_6211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_6211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["cmpny"]))
				Navigation.SetValue("cmpny", querystring["cmpny"]);


// USE /[MANUAL GQT MENU_GET 6211]/

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
		// GET: /Equip/PTN_Menu_241
		[ActionName("PTN_Menu_241")]
		[HttpPost]
		public ActionResult PTN_Menu_241([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_241_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_241");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_241.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_241.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_241.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 241]/

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
		// GET: /Equip/PTN_Menu_251
		[ActionName("PTN_Menu_251")]
		[HttpPost]
		public ActionResult PTN_Menu_251([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_251_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_251");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_251.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_251.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_251.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 251]/

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
		// GET: /Equip/PTN_Menu_331
		[ActionName("PTN_Menu_331")]
		[HttpPost]
		public ActionResult PTN_Menu_331([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_331_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_331");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_331.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_331.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_331.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 331]/

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
		// GET: /Equip/PTN_Menu_341
		[ActionName("PTN_Menu_341")]
		[HttpPost]
		public ActionResult PTN_Menu_341([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_341_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_341");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_341.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_341.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_341.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 341]/

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
		/// <summary>
		/// GET/POST: /Equip/PTN_Menu_341
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <param name="dest_id"></param>
		/// <returns></returns>
		public JsonResult PTN_Menu_341_Execute([FromBody]RequestMenuMultiSelectAddModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			string dest_id = requestModel?.DestinationId;
			bool allSelected = (bool)(requestModel?.AllSelected);
			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel?.TableConfiguration;

			PTN_Menu_341_ViewModel menuViewModel = new PTN_Menu_341_ViewModel(UserContext.Current);
			CSGenio.framework.StatusMessage result = menuViewModel.CheckPermissions(FormMode.List);

			if (result.Status.Equals(CSGenio.framework.Status.E))
				return Json(new { Success = false,  Message = result.Message });

			if ((selected_ids == null && !allSelected) || string.IsNullOrEmpty(dest_id))
				return Json(new { Success = false, Message = Resources.Resources.NENHUM_REGISTO_FOI_S05034 });

			var alternativeRedirect = string.Empty;

			//Create progress object
			this.Navigation.SetValue("ProgressReport_ML341", new ProgressReport());

			//Reference it so it can be used in the thread below
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML341");
			PersistentSupport sp = m_userContext.PersistentSupport;
			try
			{
				NavigationContext navCtx = Navigation.Clone(); //Clone Navigation
				NameValueCollection parameters = new NameValueCollection();

				//Get CriteriaSet
				CriteriaSet crs = menuViewModel.BuildCriteriaSet(tableConfig, parameters, out bool hasAllRequiredLimits);

				UserContext userCtx = UserContext.Current;
				sp.openTransaction();

				progress.Report("PTN_Menu_341", 0);
				SelectQuery query;
				if (allSelected)
				{
					/* Build subquery with custom CriteriaSet */
					SelectQuery allIds = new SelectQuery()
						.Select(CSGenioAequip.FldCodequip)
						.From(CSGenio.business.Area.AreaEQUIP);

					//Fetch Current Area
					CSGenio.business.Area area = CSGenio.business.Area.createArea("equip", userCtx.User, userCtx.User.CurrentModule);

					//Add Related Areas to Query Joins
					QueryUtils.SetInnerJoins(new[] { "EQUIP.FldCodequip" }, crs, area, allIds);
					allIds.Where(crs);
					/* -------------------------------------- */

					//Replace the selected rows array
					DataMatrix dm = sp.Execute(allIds);
					selected_ids = new string[dm.NumRows];
					for (int i = 0; i < dm.NumRows; i++)
						if (!string.IsNullOrEmpty(dm.GetKey(i, 0).ToString()))
							selected_ids[i] = dm.GetKey(i, 0).ToString();

					//Run the main query
					query = new SelectQuery()
					.Select(CSGenioAmovim.FldCodequip)
					.From(CSGenio.business.Area.AreaMOVIM)
					.Where(CriteriaSet.And()
						.Equal(CSGenioAmovim.FldCodrooms, dest_id)
						.In(CSGenioAmovim.FldCodequip, allIds)
						.Equal(CSGenioAmovim.FldZzstate, 0));
				}
				else
				{
					query = new SelectQuery()
					.Select(CSGenioAmovim.FldCodequip)
					.From(CSGenio.business.Area.AreaMOVIM)
					.Where(CriteriaSet.And()
						.Equal(CSGenioAmovim.FldCodrooms, dest_id)
						.In(CSGenioAmovim.FldCodequip, selected_ids)
						.Equal(CSGenioAmovim.FldZzstate, 0));
				}

				int cnt = 0;
				List<string> cods = new List<string>();
				DataMatrix cod = sp.Execute(query);
				for (int i = 0; i < cod.NumRows; i++)
					cods.Add(cod.GetString(i, 0));
// USE /[MANUAL GQT BEFORE_EXECUTE PTN_Menu_341]/
				foreach (string selectedId in selected_ids)
				{
					//Update Progress
					progress.Report("PTN_Menu_341", (cnt * 100.0) / selected_ids.Length);

					if (cods.Contains(selectedId))
						continue;
					Models.Movim model = new Models.Movim(userCtx);
					model.LoadKeysFromHistory(navCtx, navCtx.CurrentLevel.Level);
					model.New("MPTN_Menu_341");
					// Voltar preencher as chaves a partir do Historial, caso se as replicas preencherem a null
					model.LoadKeysFromHistory(navCtx, navCtx.CurrentLevel.Level, false);
					// Preencher as chaves selecionadas
					model.ValCodequip = selectedId;
					model.ValCodrooms = dest_id;
// USE /[MANUAL GQT ON_EXECUTE PTN_Menu_341]/
					model.Save(sp);
					cnt++;
				}
// USE /[MANUAL GQT AFTER_EXECUTE PTN_Menu_341]/
				sp.closeTransaction();

				// Update to 100% Progress
				progress.Report("PTN_Menu_341", 100);
				progress.Finished = true;
			}
			catch (ModelNotFoundException e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				//Show error
				Log.Error(e.Message);
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("PTN_Menu_341", -1, true, null, null, error, null);
				progress.Finished = true;

				return NotFoundError(Resources.Resources.O_REGISTO_PEDIDO_NAO63869);
			}
			catch (Exception e)
			{
				// Revert changes
				sp.rollbackTransaction();
				sp.closeTransaction();
				// Show error
				CSGenio.framework.ErrorHandling error = new CSGenio.framework.ErrorHandling();
				if (e is GenioException && (e as GenioException).UserMessage != null)
					Log.Error((e as GenioException).UserMessage);
				else
					Log.Error(e.Message);
				error.ErrorResponse = Resources.Resources.OCORREU_UM_ERRO_34773;
				progress.Report("PTN_Menu_341", -1, true, null, null, error, null);
				progress.Finished = true;

				return Json(new { Success = false, Message = CSGenio.framework.Translations.Get(e.Message, UserContext.Current.User.Language) });
			}

			return Json(new { Success = true, RedirectURL = alternativeRedirect });
		}

		/// <summary>
		/// GET/POST: /Equip/PTN_Menu_341
		/// </summary>
		/// <returns></returns>
		public JsonResult PTN_Menu_341_Progress()
		{
			ProgressReport progress = (ProgressReport)this.Navigation.GetValue("ProgressReport_ML341");

			if (progress == null)
				return Json(new { Success = true, percent = 0, message = Resources.Resources.THERE_IS_NO_TASK_RUN02354, finished = false, ongoing = false});

			if (progress.Finished)
			{
				if (progress.Percent == 100)
					return Json(new { Success = true, percent = 100, message = Resources.Resources.ALTERACOES_EFETUADAS10166, finished = true, ongoing = false });
				else
				{
					if (progress.Errors != null)
					{
						if (!string.IsNullOrEmpty(progress.Errors.ErrorResponse))
						{
							return Json(new { Success = false, percent = progress.Percent,
							message = progress.Errors.ErrorResponse,
							finished = false, ongoing = false });
						}
						else if (progress.Errors.ErrorLog.Count() > 0)
						{
							string messageBuilder = "";
							foreach (string err in progress.Errors.ErrorLog)
								messageBuilder += err + "<br />";

							return Json(new { Success = false, percent = progress.Percent,
							message = messageBuilder,
							finished = false, ongoing = false });
						}
					}

					return Json(new { Success = false, percent = progress.Percent,
						message = Resources.Resources.OCORREU_UM_ERRO_AO_P53091,
						finished = true, ongoing = false });
				}
			}
			else
				return Json(new { Success = true, percent = progress.Percent, message = "", finished = false, ongoing = true });
		}

		//
		// GET: /Equip/PTN_Menu_3511
		[ActionName("PTN_Menu_3511")]
		[HttpPost]
		public ActionResult PTN_Menu_3511([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_3511_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3511");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3511.ShortDescription());

			if (!String.IsNullOrEmpty(querystring["rooms"]))
				Navigation.SetValue("rooms", querystring["rooms"]);


// USE /[MANUAL PTN MENU_GET 3511]/

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
		// GET: /Equip/PTN_Menu_3G11
		[ActionName("PTN_Menu_3G11")]
		[HttpPost]
		public ActionResult PTN_Menu_3G11([FromBody] RequestRangeLimitModel<DateTime?> requestModel)
		{
			var minEquipValDtaquisi = requestModel.MinLimit;
			var maxEquipValDtaquisi = requestModel.MaxLimit;
			var queryParams = requestModel.QueryParams;

			if (GenFunctions.emptyD(minEquipValDtaquisi) == 1 && Navigation.GetValue("minEquipValDtaquisi") != null)
				minEquipValDtaquisi = Navigation.GetDateValue("minEquipValDtaquisi").GetValueOrDefault();

			if (GenFunctions.emptyD(maxEquipValDtaquisi) == 1 && Navigation.GetValue("maxEquipValDtaquisi") != null)
				maxEquipValDtaquisi = Navigation.GetDateValue("maxEquipValDtaquisi").GetValueOrDefault();
			PTN_Menu_3G11_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3G11");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3G11.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3G11.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3G11.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			// SE / SU Limitations
			Navigation.SetValue("minEquipValDtaquisi", minEquipValDtaquisi);
			Navigation.SetValue("maxEquipValDtaquisi", maxEquipValDtaquisi);

// USE /[MANUAL PTN MENU_GET 3G11]/

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
		// GET: /Equip/PTN_Menu_621
		[ActionName("PTN_Menu_621")]
		[HttpPost]
		public ActionResult PTN_Menu_621([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_621_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine what columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_621");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_621.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_621.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_621.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 621]/

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
		// GET: /Equip/PTN_MenuSE_3G1
		public ActionResult PTN_MenuSE_3G1()
		{
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			PTN_MenuSE_3G1_ViewModel model = new PTN_MenuSE_3G1_ViewModel(UserContext.Current);


			return JsonOK(model);
		}


	}
}
