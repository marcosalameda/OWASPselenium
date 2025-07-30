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
using GenioMVC.ViewModels.Lendi;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
	public partial class LendiController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_3111 = new NavigationLocation("LENDING18782", "PTN_Menu_3111", "Lendi") { vueRouteName = "menu-PTN_3111" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3121 = new NavigationLocation("LENDING18782", "PTN_Menu_3121", "Lendi") { vueRouteName = "menu-PTN_3121" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3171 = new NavigationLocation("LENDING18782", "PTN_Menu_3171", "Lendi") { vueRouteName = "menu-PTN_3171" };
		private static readonly NavigationLocation ACTION_PTN_MENU_LIST_DM_MB_R = new NavigationLocation("LENDING18782", "PTN_Menu_LIST_DM_MB_R", "Lendi") { vueRouteName = "menu-PTN_LIST_DM_MB_R" };
		private static readonly NavigationLocation ACTION_GQT_MENU_111 = new NavigationLocation("LENDING18782", "GQT_Menu_111", "Lendi") { vueRouteName = "menu-GQT_111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1211 = new NavigationLocation("LENDING18782", "GQT_Menu_1211", "Lendi") { vueRouteName = "menu-GQT_1211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1311 = new NavigationLocation("LENDING18782", "GQT_Menu_1311", "Lendi") { vueRouteName = "menu-GQT_1311" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_141 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_141", "Lendi") { vueRouteName = "menu-GQT_141" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1411 = new NavigationLocation("LENDING18782", "GQT_Menu_1411", "Lendi") { vueRouteName = "menu-GQT_1411" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_151 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_151", "Lendi") { vueRouteName = "menu-GQT_151" };
		private static readonly NavigationLocation ACTION_GQT_MENU_DEVOL = new NavigationLocation("OUT_OF_DATE_LENDINGS05506", "GQT_Menu_DEVOL", "Lendi") { vueRouteName = "menu-GQT_DEVOL" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1711 = new NavigationLocation("LENDINGS_OF__EQUIP__22198", "GQT_Menu_1711", "Lendi") { vueRouteName = "menu-GQT_1711" };
		private static readonly NavigationLocation ACTION_GQT_MENU_DEVOLOBS = new NavigationLocation("OUT_OF_DATE_LENDINGS05506", "GQT_Menu_DEVOLOBS", "Lendi") { vueRouteName = "menu-GQT_DEVOLOBS" };


		//
		// GET: /Lendi/PTN_Menu_3111
		[ActionName("PTN_Menu_3111")]
		[HttpPost]
		public ActionResult PTN_Menu_3111([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_3111_ViewModel model = new PTN_Menu_3111_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "PTN_Menu_3111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 3111]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_3121
		[ActionName("PTN_Menu_3121")]
		[HttpPost]
		public ActionResult PTN_Menu_3121([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_3121_ViewModel model = new PTN_Menu_3121_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "PTN_Menu_3121");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3121.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3121.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3121.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 3121]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_3171
		[ActionName("PTN_Menu_3171")]
		[HttpPost]
		public ActionResult PTN_Menu_3171([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_3171_ViewModel model = new PTN_Menu_3171_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "PTN_Menu_3171");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3171.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3171.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3171.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 3171]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_LIST_DM_MB_R
		[ActionName("PTN_Menu_LIST_DM_MB_R_Selections")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DM_MB_R_Selections([FromBody] RequestSelectionsModel requestModel)
		{
			var ids = requestModel.Ids.ToArray();

			Navigation.ClearValue("lendi_Selections");
			if (ids != null && ids.Length != 0)
				Navigation.SetValue("lendi_Selections", ids);
			return Json(new { Success = true });
		}

		[ActionName("PTN_Menu_LIST_DM_MB_R")]
		[HttpPost]
		public ActionResult PTN_Menu_LIST_DM_MB_R([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			PTN_Menu_LIST_DM_MB_R_ViewModel model = new PTN_Menu_LIST_DM_MB_R_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "PTN_Menu_LIST_DM_MB_R");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_LIST_DM_MB_R.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_LIST_DM_MB_R.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_LIST_DM_MB_R.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET LIST_DM_MB_R]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_111
		[ActionName("GQT_Menu_111")]
		[HttpPost]
		public ActionResult GQT_Menu_111([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_111_ViewModel model = new GQT_Menu_111_ViewModel(UserContext.Current);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Static filter "order" fields that have changed
			tableConfigOptions.StaticFiltersKeyShiftValues = new Dictionary<string, int>
			{
				{ "filter_GQT_Menu_111_DEVOLUCAO", 1 }
			};

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
				Navigation.SetValue("HomePage", "GQT_Menu_111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 111]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_111_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 111]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_111.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}
			if (querystring["ImportList"] != null && Convert.ToBoolean(querystring["ImportList"]) && querystring["ImportType"] != null)
			{
				string importType =  querystring["ImportType"];
				string file = "GQT_Menu_111_Template" + "." + importType;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);
				byte[] fileBytes = null;

				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportTemplate(columns, importType, file,ACTION_GQT_MENU_111.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, importType));
			}

            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// POST: /Lendi/GQT_Menu_111_UploadFile
		[HttpPost]
		public ActionResult GQT_Menu_111_UploadFile(string importType, string qqfile) {
			GQT_Menu_111_ViewModel model = new GQT_Menu_111_ViewModel(UserContext.Current);

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			List<CSGenioAlendi> rows = new List<CSGenioAlendi>();
			List<String> results = new List<String>();

			try
			{
				var file = Request.Form.Files[0];
				byte[] fileBytes = new byte[file.Length];
				var mem = new MemoryStream(fileBytes);
				file.CopyTo(mem);

				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExportTemplate(out columns);

				rows = new CSGenio.framework.Exports( UserContext.Current.User).ImportList<CSGenioAlendi>(columns, importType, fileBytes);

				sp.openTransaction();
				int lineNumber = 0;
				foreach (CSGenioAlendi importRow in rows)
				{
					try
					{
						lineNumber++;
						importRow.ValidateIfIsNull = true;
						importRow.insertPseud(UserContext.Current.PersistentSupport);
						importRow.change(UserContext.Current.PersistentSupport, (CriteriaSet)null);
					}
					catch (GenioException e)
					{
						string lineNumberMsg = String.Format(Resources.Resources.ERROR_IN_LINE__0__45377 + " ", lineNumber);
						e.UserMessage = lineNumberMsg + e.UserMessage;
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

		//
		// GET: /Lendi/GQT_Menu_1211
		[ActionName("GQT_Menu_1211")]
		[HttpPost]
		public ActionResult GQT_Menu_1211([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_1211_ViewModel model = new GQT_Menu_1211_ViewModel(UserContext.Current);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Static filter "order" fields that have changed
			tableConfigOptions.StaticFiltersKeyShiftValues = new Dictionary<string, int>
			{
				{ "filter_GQT_Menu_1211_DEVOLUCAO", 1 }
			};

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
				Navigation.SetValue("HomePage", "GQT_Menu_1211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 1211]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_1211_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 1211]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_1211.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_1311
		[ActionName("GQT_Menu_1311")]
		[HttpPost]
		public ActionResult GQT_Menu_1311([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_1311_ViewModel model = new GQT_Menu_1311_ViewModel(UserContext.Current);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Static filter "order" fields that have changed
			tableConfigOptions.StaticFiltersKeyShiftValues = new Dictionary<string, int>
			{
				{ "filter_GQT_Menu_1311_DEVOLUCAO", 1 }
			};

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
				Navigation.SetValue("HomePage", "GQT_Menu_1311");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



			//History Limit
			if ("" != null)
				Navigation.SetValue("pess1", "");

// USE /[MANUAL GQT MENU_GET 1311]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_1311_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 1311]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_1311.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_1411
		[ActionName("GQT_Menu_1411")]
		[HttpPost]
		public ActionResult GQT_Menu_1411([FromBody]RequestRangeLimitModel<DateTime?> requestModel)
		{
			var minLendiValStart = requestModel.MinLimit;
			var maxLendiValStart = requestModel.MaxLimit;
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			if (GenFunctions.emptyD(minLendiValStart) == 1 && Navigation.GetValue("minLendiValStart") != null)
				minLendiValStart = Navigation.GetDateValue("minLendiValStart").GetValueOrDefault();

			if (GenFunctions.emptyD(maxLendiValStart) == 1 && Navigation.GetValue("maxLendiValStart") != null)
				maxLendiValStart = Navigation.GetDateValue("maxLendiValStart").GetValueOrDefault();
			GQT_Menu_1411_ViewModel model = new GQT_Menu_1411_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_1411");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1411.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1411.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1411.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			// SE / SU Limitations
			Navigation.SetValue("minLendiValStart", minLendiValStart);
			Navigation.SetValue("maxLendiValStart", maxLendiValStart);

// USE /[MANUAL GQT MENU_GET 1411]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_DEVOL
		[ActionName("GQT_Menu_DEVOL")]
		[HttpPost]
		public ActionResult GQT_Menu_DEVOL([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_DEVOL_ViewModel model = new GQT_Menu_DEVOL_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_DEVOL");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_DEVOL.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_DEVOL.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_DEVOL.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("lendi.returned", "0");
			Navigation.SetValue("lendi.ifoutdt", "1");

// USE /[MANUAL GQT MENU_GET DEVOL]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_DEVOL_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT DEVOL]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_DEVOL.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_1711
		[ActionName("GQT_Menu_1711")]
		[HttpPost]
		public ActionResult GQT_Menu_1711([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_1711_ViewModel model = new GQT_Menu_1711_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_1711");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_1711.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_1711.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_1711.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["equip"]))
				Navigation.SetValue("equip", querystring["equip"]);


// USE /[MANUAL GQT MENU_GET 1711]/


            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_DEVOLOBS
		[ActionName("GQT_Menu_DEVOLOBS")]
		[HttpPost]
		public ActionResult GQT_Menu_DEVOLOBS([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			GQT_Menu_DEVOLOBS_ViewModel model = new GQT_Menu_DEVOLOBS_ViewModel(UserContext.Current);

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
				Navigation.SetValue("HomePage", "GQT_Menu_DEVOLOBS");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lendi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lendi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_DEVOLOBS.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_DEVOLOBS.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_DEVOLOBS.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("lendi.returned", "0");
			Navigation.SetValue("lendi.ifoutdt", "1");

// USE /[MANUAL GQT MENU_GET DEVOLOBS]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_DEVOLOBS_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAlendi> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT DEVOLOBS]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_DEVOLOBS.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

            try
            {
			    model.Load(tableConfig, querystring, Request.IsAjaxRequest());
            }
            catch(Exception e)
            {
                return JsonERROR(HandleException(e), model);
            }


			return JsonOK(model);
		}


		//
		// GET: /Lendi/GQT_MenuSE_141
		public ActionResult GQT_MenuSE_141()
		{
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			GQT_MenuSE_141_ViewModel model = new GQT_MenuSE_141_ViewModel(UserContext.Current);


			return JsonOK(model);
		}
		//
		// GET: /Lendi/GQT_MenuSE_151
		public ActionResult GQT_MenuSE_151()
		{
			if (Navigation.CurrentLevel != null)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			}

			GQT_MenuSE_151_ViewModel model = new GQT_MenuSE_151_ViewModel(UserContext.Current);


			return JsonOK(model);
		}


	}
}
