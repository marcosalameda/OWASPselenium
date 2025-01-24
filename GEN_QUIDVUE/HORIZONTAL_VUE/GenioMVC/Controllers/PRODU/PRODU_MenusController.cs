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
using GenioMVC.ViewModels.Produ;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PRODU]/

namespace GenioMVC.Controllers
{
	public partial class ProduController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_WMS_MENU_311 = new NavigationLocation("PRODUCTS34689", "WMS_Menu_311", "Produ") { vueRouteName = "menu-WMS_311" };
		private static readonly NavigationLocation ACTION_WMS_MENU_321 = new NavigationLocation("PRODUCTS34689", "WMS_Menu_321", "Produ") { vueRouteName = "menu-WMS_321" };


		//
		// GET: /Produ/WMS_Menu_311
		[ActionName("WMS_Menu_311")]
		[HttpPost]
		public ActionResult WMS_Menu_311([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_311_ViewModel model = new WMS_Menu_311_ViewModel(UserContext.Current);
			
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
				Navigation.SetValue("HomePage", "WMS_Menu_311");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_produ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_produ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL WMS MENU_GET 311]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "WMS_Menu_311_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAprodu> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format
				if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}

				byte[] fileBytes = null;
// USE /[MANUAL WMS OVERRQEXPORT 311]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_WMS_MENU_311.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(tableConfig, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Produ/WMS_Menu_321
		[ActionName("WMS_Menu_321")]
		[HttpPost]
		public ActionResult WMS_Menu_321([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			WMS_Menu_321_ViewModel model = new WMS_Menu_321_ViewModel(UserContext.Current);
			
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
				Navigation.SetValue("HomePage", "WMS_Menu_321");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_produ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_produ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_WMS_MENU_321.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_WMS_MENU_321.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_WMS_MENU_321.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL WMS MENU_GET 321]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "WMS_Menu_321_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAprodu> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, querystring, Request.IsAjaxRequest());

				// Validate export format
				if (querystring["ExportValidate"] == "true")
				{
					bool isValidExport = new CSGenio.framework.Exports(UserContext.Current.User).ExportListValidation(listing, conditions, columns, exportType);
					return Json(new { ValidFormat = isValidExport });
				}

				byte[] fileBytes = null;
// USE /[MANUAL WMS OVERRQEXPORT 321]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_WMS_MENU_321.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}
			if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
			{
				string importType =  querystring["ImportType"];
				string file = "WMS_Menu_321_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_WMS_MENU_321.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, importType));
			}

			model.Load(tableConfig, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// POST: /Produ/WMS_Menu_321_UploadFile
		[HttpPost]
		public ActionResult WMS_Menu_321_UploadFile(string importType, string qqfile) {
			WMS_Menu_321_ViewModel model = new WMS_Menu_321_ViewModel(UserContext.Current);

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			List<CSGenioAprodu> rows = new List<CSGenioAprodu>();
			List<String> results = new List<String>();

			try
			{
				var file = Request.Form.Files[0];
				byte[] fileBytes = new byte[file.Length];
				var mem = new MemoryStream(fileBytes);
				file.CopyTo(mem);

				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);

				rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAprodu>(columns, importType, fileBytes);

				sp.openTransaction();
				int lineNumber = 0;
				foreach (CSGenioAprodu importRow in rows)
				{
					try
					{
						lineNumber++;
						importRow.ValidateIfIsNull = true;
						importRow.insertPseud(UserContext.Current.PersistentSupport);
						importRow.change(UserContext.Current.PersistentSupport, (CriteriaSet)null);
					}
					catch (GenioException ex)
					{
						string lineNumberMsg = String.Format(Resources.Resources.ERROR_IN_LINE__0__45377 + " ", lineNumber);
						ex.UserMessage = lineNumberMsg + ex.UserMessage;
						throw;
					}
				}
				sp.closeTransaction();

				results.Add(string.Format(Resources.Resources._0__LINHAS_IMPORTADA15937, rows.Count));

				return Json(new { success = true, lines = results, msg = Resources.Resources.FICHEIRO_IMPORTADO_C51013 });
			}
			catch (GenioException e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				CSGenio.framework.Log.Error(e.Message);
				results.Add(e.UserMessage);

				return Json(new { success = false, errors = results, msg = Resources.Resources.ERROR_IMPORTING_FILE09339 });
			}
		}



	}
}
