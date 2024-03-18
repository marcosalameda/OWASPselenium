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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_STY_MENU_TABS = new NavigationLocation("FIELD_TYPES49172", "STY_Menu_TABS", "Flds") { vueRouteName = "menu-STY_TABS" };
		private static readonly NavigationLocation ACTION_STY_MENU_INPTFIELD = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_INPTFIELD", "Flds") { vueRouteName = "menu-STY_INPTFIELD" };
		private static readonly NavigationLocation ACTION_STY_MENU_358111 = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_358111", "Flds") { vueRouteName = "menu-STY_358111" };
		private static readonly NavigationLocation ACTION_STY_MENU_358211 = new NavigationLocation("LISTA_DE_CAMPOS37609", "STY_Menu_358211", "Flds") { vueRouteName = "menu-STY_358211" };
		private static readonly NavigationLocation ACTION_PTN_MENU_511 = new NavigationLocation("FIELD_TYPES49172", "PTN_Menu_511", "Flds") { vueRouteName = "menu-PTN_511" };
		private static readonly NavigationLocation ACTION_TBS_MENU_1921 = new NavigationLocation("LISTA_DE_CAMPOS37609", "TBS_Menu_1921", "Flds") { vueRouteName = "menu-TBS_1921" };


		//
		// GET: /Flds/STY_Menu_TABS
		[ActionName("STY_Menu_TABS")]
		[HttpPost]
		public ActionResult STY_Menu_TABS([FromBody]RequestMenuModel requestModel)
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

			STY_Menu_TABS_ViewModel model = new STY_Menu_TABS_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_TABS");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_TABS.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_TABS.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_TABS.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("flds.shwrc", "1");

// USE /[MANUAL STY MENU_GET TABS]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("LISTACAM"))
				Navigation.GoBack.Remove("LISTACAM");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("LISTACAM"))
				Navigation.OverrideSkipIfJustOne.Remove("LISTACAM");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("LISTACAM", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Flds/STY_Menu_INPTFIELD
		[ActionName("STY_Menu_INPTFIELD")]
		[HttpPost]
		public ActionResult STY_Menu_INPTFIELD([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = 6;

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

			STY_Menu_INPTFIELD_ViewModel model = new STY_Menu_INPTFIELD_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_INPTFIELD");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_INPTFIELD.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_INPTFIELD.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_INPTFIELD.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("flds.shwrc", "1");

// USE /[MANUAL STY MENU_GET INPTFIELD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
				Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
				Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("INFIELDS", "SHOW", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Flds/STY_Menu_358111
		[ActionName("STY_Menu_358111")]
		[HttpPost]
		public ActionResult STY_Menu_358111([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = 6;

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

			STY_Menu_358111_ViewModel model = new STY_Menu_358111_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_358111");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_358111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_358111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_358111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("flds.shwrc", "1");

// USE /[MANUAL STY MENU_GET 358111]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
				Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
				Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("INFIELDS", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Flds/STY_Menu_358211
		[ActionName("STY_Menu_358211")]
		[HttpPost]
		public ActionResult STY_Menu_358211([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = 6;

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

			STY_Menu_358211_ViewModel model = new STY_Menu_358211_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_358211");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_358211.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_358211.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_358211.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("flds.shwrc", "1");

// USE /[MANUAL STY MENU_GET 358211]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("INFIELDS"))
				Navigation.GoBack.Remove("INFIELDS");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("INFIELDS"))
				Navigation.OverrideSkipIfJustOne.Remove("INFIELDS");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodflds;
				var navKey = "flds";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("INFIELDS", "SHOW", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Flds/PTN_Menu_511
		[ActionName("PTN_Menu_511")]
		[HttpPost]
		public ActionResult PTN_Menu_511([FromBody]RequestMenuModel requestModel)
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

			PTN_Menu_511_ViewModel model = new PTN_Menu_511_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_511");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_511.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_511.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_511.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Flds/TBS_Menu_1921
		[ActionName("TBS_Menu_1921")]
		[HttpPost]
		public ActionResult TBS_Menu_1921([FromBody]RequestMenuModel requestModel)
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

			TBS_Menu_1921_ViewModel model = new TBS_Menu_1921_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "TBS_Menu_1921");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_TBS_MENU_1921.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_TBS_MENU_1921.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_TBS_MENU_1921.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL TBS MENU_GET 1921]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}



	}
}
