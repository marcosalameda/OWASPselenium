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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_GQT_MENU_451 = new NavigationLocation("ARTICLES59822", "GQT_Menu_451", "Item") { vueRouteName = "menu-GQT_451" };
		private static readonly NavigationLocation ACTION_GQT_MENU_4611 = new NavigationLocation("ARTICLES__WAREH__WAR35760", "GQT_Menu_4611", "Item") { vueRouteName = "menu-GQT_4611" };
		private static readonly NavigationLocation ACTION_GQT_MENU_4A1 = new NavigationLocation("ARTICLES59822", "GQT_Menu_4A1", "Item") { vueRouteName = "menu-GQT_4A1" };
		private static readonly NavigationLocation ACTION_PTN_MENU_131 = new NavigationLocation("ARTICLES59822", "PTN_Menu_131", "Item") { vueRouteName = "menu-PTN_131" };
		private static readonly NavigationLocation ACTION_PTN_MENU_141 = new NavigationLocation("ARTICLES59822", "PTN_Menu_141", "Item") { vueRouteName = "menu-PTN_141" };
		private static readonly NavigationLocation ACTION_PTN_MENU_221 = new NavigationLocation("ARTICLES59822", "PTN_Menu_221", "Item") { vueRouteName = "menu-PTN_221" };


		//
		// GET: /Item/GQT_Menu_451
		[ActionName("GQT_Menu_451")]
		[HttpPost]
		public ActionResult GQT_Menu_451([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_451_ViewModel model = new GQT_Menu_451_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_451");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_451.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_451.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_451.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 451]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_451_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 451]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_451.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Item/GQT_Menu_4611
		[ActionName("GQT_Menu_4611")]
		[HttpPost]
		public ActionResult GQT_Menu_4611([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_4611_ViewModel model = new GQT_Menu_4611_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_4611");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_4611.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_4611.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_4611.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["wareh"]))
				Navigation.SetValue("wareh", querystring["wareh"]);


// USE /[MANUAL GQT MENU_GET 4611]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_4611_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 4611]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_4611.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Item/GQT_Menu_4A1
		[ActionName("GQT_Menu_4A1")]
		[HttpPost]
		public ActionResult GQT_Menu_4A1([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_4A1_ViewModel model = new GQT_Menu_4A1_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_4A1");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_4A1.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_4A1.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_4A1.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 4A1]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "GQT_Menu_4A1_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL GQT OVERRQEXPORT 4A1]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_GQT_MENU_4A1.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Item/PTN_Menu_131
		[ActionName("PTN_Menu_131")]
		[HttpPost]
		public ActionResult PTN_Menu_131([FromBody]RequestMenuModel requestModel)
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

			PTN_Menu_131_ViewModel model = new PTN_Menu_131_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_131");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_131.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_131.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_131.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 131]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Item/PTN_MenuMC_131
		public ActionResult PTN_MenuMC_131([FromBody]RequestOpenModel requestModel)
		{
			string id = requestModel.Id;
			string formMode = requestModel.FormMode;

			if (Navigation.CurrentLevel != null)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Models.Item item = Models.Item.Find(id, UserContext.Current, "ML131");
			Navigation.SetValue("item", id);
			if (item != null && ((item.ValValid ? 1 : 0)==0))
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Edit";
				return JsonOK(new { actionName = "MC_1311", id = id });
			}
			if (item != null && ((item.ValValid ? 1 : 0)==1))
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Edit";
				return JsonOK(new { actionName = "MC_1312", id = id });
			}
			else
			{
				return new EmptyResult();
			}
		}

		//
		// GET: /Item/PTN_Menu_141
		[ActionName("PTN_Menu_141")]
		[HttpPost]
		public ActionResult PTN_Menu_141([FromBody]RequestMenuModel requestModel)
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

			PTN_Menu_141_ViewModel model = new PTN_Menu_141_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_141");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_141.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_141.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_141.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 141]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Item/PTN_MenuMC_1411
		public ActionResult PTN_MenuMC_1411([FromBody]RequestOpenModel requestModel)
		{
			string id = requestModel.Id;
			string formMode = requestModel.FormMode;

			if (Navigation.CurrentLevel != null)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());

			Models.Item item = Models.Item.Find(id, UserContext.Current, "ML141");
			Navigation.SetValue("item", id);
			if (item != null && ((item.ValValid ? 1 : 0)==0))
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Edit";
				return JsonOK(new { actionName = "MC_14111", id = id });
			}
			if (item != null && ((item.ValValid ? 1 : 0)==1))
			{
				if (string.IsNullOrEmpty(formMode))
					formMode = "Edit";
				return JsonOK(new { actionName = "MC_14112", id = id });
			}
			else
			{
				return new EmptyResult();
			}
		}

		//
		// GET: /Item/PTN_Menu_221
		[ActionName("PTN_Menu_221")]
		[HttpPost]
		public ActionResult PTN_Menu_221([FromBody]RequestMenuModel requestModel)
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

			PTN_Menu_221_ViewModel model = new PTN_Menu_221_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_221");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_221.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_221.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_221.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 221]/

			// Table List Export - check if user is exporting the Qlisting
			if (querystring["ExportList"] != null && Convert.ToBoolean(querystring["ExportList"]) && querystring["ExportType"] != null)
			{
				string exportType = querystring["ExportType"];
				string file = "PTN_Menu_221_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + exportType;
				ListingMVC<CSGenioAitem> listing = null;
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
// USE /[MANUAL PTN OVERRQEXPORT 221]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, exportType, file,ACTION_PTN_MENU_221.Name);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(getJsonForDownloadExportFile(file, querystring["ExportType"]));
			}

			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}



	}
}
