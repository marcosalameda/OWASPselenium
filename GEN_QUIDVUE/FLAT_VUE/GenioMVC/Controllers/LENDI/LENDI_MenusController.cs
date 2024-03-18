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
		private static readonly NavigationLocation ACTION_GQT_MENU_111 = new NavigationLocation("LENDING18782", "GQT_Menu_111", "Lendi") { vueRouteName = "menu-GQT_111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1211 = new NavigationLocation("LENDING18782", "GQT_Menu_1211", "Lendi") { vueRouteName = "menu-GQT_1211" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1311 = new NavigationLocation("LENDING18782", "GQT_Menu_1311", "Lendi") { vueRouteName = "menu-GQT_1311" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_141 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_141", "Lendi") { vueRouteName = "menu-GQT_141" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1411 = new NavigationLocation("LENDING18782", "GQT_Menu_1411", "Lendi") { vueRouteName = "menu-GQT_1411" };
		private static readonly NavigationLocation ACTION_GQT_MENUSE_151 = new NavigationLocation("SELECAO_ENTRE_LIMITE34362", "GQT_MenuSE_151", "Lendi") { vueRouteName = "menu-GQT_151" };
		private static readonly NavigationLocation ACTION_GQT_MENU_DEVOL = new NavigationLocation("OUT_OF_DATE_LENDINGS05506", "GQT_Menu_DEVOL", "Lendi") { vueRouteName = "menu-GQT_DEVOL" };
		private static readonly NavigationLocation ACTION_GQT_MENU_1711 = new NavigationLocation("LENDINGS_OF__EQUIP__22198", "GQT_Menu_1711", "Lendi") { vueRouteName = "menu-GQT_1711" };
		private static readonly NavigationLocation ACTION_PTN_MENU_1111 = new NavigationLocation("LENDING18782", "PTN_Menu_1111", "Lendi") { vueRouteName = "menu-PTN_1111" };
		private static readonly NavigationLocation ACTION_PTN_MENU_1121 = new NavigationLocation("LENDING18782", "PTN_Menu_1121", "Lendi") { vueRouteName = "menu-PTN_1121" };
		private static readonly NavigationLocation ACTION_PTN_MENU_1211 = new NavigationLocation("LENDING18782", "PTN_Menu_1211", "Lendi") { vueRouteName = "menu-PTN_1211" };


		//
		// GET: /Lendi/GQT_Menu_111
		[ActionName("GQT_Menu_111")]
		[HttpPost]
		public ActionResult GQT_Menu_111([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_111_ViewModel model = new GQT_Menu_111_ViewModel(UserContext.Current);
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
				model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

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
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
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
				return Json(getJsonForDownloadExportFile(file, importType));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


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
					catch (GenioException ex)
					{
						string lineNumberMsg = String.Format(Resources.Resources.ERROR_IN_LINE__0__45377 + " ", lineNumber);
						ex.UserMessage = lineNumberMsg + ex.UserMessage;
						throw;
					}
				}
				sp.closeTransaction();

				results.Add(string.Format(Resources.Resources._0__LINHAS_IMPORTADA15937, rows.Count));

				return Json(new { success = true, lines = results, msg = Resources.Resources.FICHEIRO_IMPORTADO_C51013 }, "application/json");
			}
			catch (GenioException e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				CSGenio.framework.Log.Error(e.Message);
				results.Add(e.UserMessage);

				return Json(new { success = false, errors = results, msg = Resources.Resources.ERROR_IMPORTING_FILE09339 }, "application/json");
			}
		}

		//
		// GET: /Lendi/GQT_Menu_1211
		[ActionName("GQT_Menu_1211")]
		[HttpPost]
		public ActionResult GQT_Menu_1211([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_1211_ViewModel model = new GQT_Menu_1211_ViewModel(UserContext.Current);
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
				model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

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
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_1311
		[ActionName("GQT_Menu_1311")]
		[HttpPost]
		public ActionResult GQT_Menu_1311([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_1311_ViewModel model = new GQT_Menu_1311_ViewModel(UserContext.Current);
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
				model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

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
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


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
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (GlobalFunctions.emptyD(minLendiValStart) == 1 && Navigation.GetValue("minLendiValStart") != null)
				minLendiValStart = Navigation.GetDateValue("minLendiValStart").GetValueOrDefault();

			if (GlobalFunctions.emptyD(maxLendiValStart) == 1 && Navigation.GetValue("maxLendiValStart") != null)
				maxLendiValStart = Navigation.GetDateValue("maxLendiValStart").GetValueOrDefault();
			// MH - Compatibilidade com antiga versão dos menus SE / SU
			var ValMinvalue = minLendiValStart;
			var ValMaxvalue = maxLendiValStart;
			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_1411_ViewModel model = new GQT_Menu_1411_ViewModel(UserContext.Current);
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
			// MH - Compatibilidade com antiga versão dos menus SE
			Navigation.SetValue("ValMinvalue", minLendiValStart);
			Navigation.SetValue("ValMaxvalue", maxLendiValStart);

// USE /[MANUAL GQT MENU_GET 1411]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_DEVOL
		[ActionName("GQT_Menu_DEVOL")]
		[HttpPost]
		public ActionResult GQT_Menu_DEVOL([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_DEVOL_ViewModel model = new GQT_Menu_DEVOL_ViewModel(UserContext.Current);
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
				model.LoadToExport(out listing, out conditions, out columns, querystring, Request.IsAjaxRequest());

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
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/GQT_Menu_1711
		[ActionName("GQT_Menu_1711")]
		[HttpPost]
		public ActionResult GQT_Menu_1711([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			GQT_Menu_1711_ViewModel model = new GQT_Menu_1711_ViewModel(UserContext.Current);
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


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_1111
		[ActionName("PTN_Menu_1111")]
		[HttpPost]
		public ActionResult PTN_Menu_1111([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			PTN_Menu_1111_ViewModel model = new PTN_Menu_1111_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_1111");

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
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_1111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_1111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_1111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 1111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_1121
		[ActionName("PTN_Menu_1121")]
		[HttpPost]
		public ActionResult PTN_Menu_1121([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			PTN_Menu_1121_ViewModel model = new PTN_Menu_1121_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_1121");

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
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_1121.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_1121.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_1121.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 1121]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Lendi/PTN_Menu_1211
		[ActionName("PTN_Menu_1211_Selections")]
		[HttpPost]
		public ActionResult PTN_Menu_1211_Selections([FromBody] RequestSelectionsModel requestModel)
		{
			var ids = requestModel.Ids.ToArray();

			Navigation.ClearValue("lendi_Selections");
			if (ids != null && ids.Length != 0)
				Navigation.SetValue("lendi_Selections", ids);
			return Json(new { Success = true });
		}

		[ActionName("PTN_Menu_1211")]
		[HttpPost]
		public ActionResult PTN_Menu_1211([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			if (queryParams != null)
			{
				//Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				//Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);
			}

			PTN_Menu_1211_ViewModel model = new PTN_Menu_1211_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_1211");

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
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_1211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_1211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_1211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 1211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


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
