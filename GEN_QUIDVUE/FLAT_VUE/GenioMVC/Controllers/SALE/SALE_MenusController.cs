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
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_STY_MENU_HWIZARD = new NavigationLocation("VENDAS00012", "STY_Menu_HWIZARD", "Sale") { vueRouteName = "menu-STY_HWIZARD" };
		private static readonly NavigationLocation ACTION_STY_MENU_VWIZARD = new NavigationLocation("VENDAS00012", "STY_Menu_VWIZARD", "Sale") { vueRouteName = "menu-STY_VWIZARD" };
		private static readonly NavigationLocation ACTION_STY_MENU_PWIZARD = new NavigationLocation("VENDAS00012", "STY_Menu_PWIZARD", "Sale") { vueRouteName = "menu-STY_PWIZARD" };
		private static readonly NavigationLocation ACTION_GQT_MENU_511 = new NavigationLocation("VENDAS00012", "GQT_Menu_511", "Sale") { vueRouteName = "menu-GQT_511" };
		private static readonly NavigationLocation ACTION_GQT_MENU_521 = new NavigationLocation("VENDAS00012", "GQT_Menu_521", "Sale") { vueRouteName = "menu-GQT_521" };
		private static readonly NavigationLocation ACTION_GQT_MENU_531 = new NavigationLocation("VENDAS00012", "GQT_Menu_531", "Sale") { vueRouteName = "menu-GQT_531" };


		//
		// GET: /Sale/STY_Menu_HWIZARD
		[ActionName("STY_Menu_HWIZARD")]
		[HttpPost]
		public ActionResult STY_Menu_HWIZARD([FromBody]RequestMenuModel requestModel)
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

			STY_Menu_HWIZARD_ViewModel model = new STY_Menu_HWIZARD_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_HWIZARD");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_HWIZARD.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_HWIZARD.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_HWIZARD.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("sale.showrcrd", "1");

// USE /[MANUAL STY MENU_GET HWIZARD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("VENDAW"))
				Navigation.GoBack.Remove("VENDAW");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VENDAW"))
				Navigation.OverrideSkipIfJustOne.Remove("VENDAW");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodvenda;
				var navKey = "sale";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("VENDAW", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Sale/STY_Menu_VWIZARD
		[ActionName("STY_Menu_VWIZARD")]
		[HttpPost]
		public ActionResult STY_Menu_VWIZARD([FromBody]RequestMenuModel requestModel)
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

			STY_Menu_VWIZARD_ViewModel model = new STY_Menu_VWIZARD_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_VWIZARD");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_VWIZARD.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_VWIZARD.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_VWIZARD.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("sale.showrcrd", "1");

// USE /[MANUAL STY MENU_GET VWIZARD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("VENDAWV"))
				Navigation.GoBack.Remove("VENDAWV");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VENDAWV"))
				Navigation.OverrideSkipIfJustOne.Remove("VENDAWV");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodvenda;
				var navKey = "sale";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("VENDAWV", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Sale/STY_Menu_PWIZARD
		[ActionName("STY_Menu_PWIZARD")]
		[HttpPost]
		public ActionResult STY_Menu_PWIZARD([FromBody]RequestMenuModel requestModel)
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

			STY_Menu_PWIZARD_ViewModel model = new STY_Menu_PWIZARD_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "STY_Menu_PWIZARD");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_STY_MENU_PWIZARD.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_STY_MENU_PWIZARD.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_STY_MENU_PWIZARD.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			Navigation.SetValue("sale.showrcrd", "1");

// USE /[MANUAL STY MENU_GET PWIZARD]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);

			//FOR: FORM MENU GO BACK, OVERRIDE SKIP IF JUST ONE
			bool AllowSkipIfOnlyOne = true;

			//FOR: FORM MENU GO BACK
			if (Navigation.GoBack.ContainsKey("VENDAWP"))
				Navigation.GoBack.Remove("VENDAWP");

			//FOR: OVERRIDE SKIP IF JUST ONE
			if (Navigation.OverrideSkipIfJustOne.ContainsKey("VENDAWP"))
				Navigation.OverrideSkipIfJustOne.Remove("VENDAWP");
			// jumps if only one
			var curRowsCount = model.Menu.Pagination.HasTotal ? model.Menu.Pagination.TotalRows : model.Menu.Elements.Count();
			var isFirstDataLoad = querystring.AllKeys.Contains("isFirstLoad") && Boolean.Parse(querystring["isFirstLoad"]);

			if (isFirstDataLoad && curRowsCount == 1 && model.Menu.Filters.FiltersValues.Count == 0 && model.Menu.Elements.First().ValZzstate == 0 && AllowSkipIfOnlyOne)
			{
				// needs the routevalue for the primary key, because a get request to a get form action expects so
				var primaryKey = model.Menu.Elements.First().ValCodvenda;
				var navKey = "sale";
				Navigation.SetValue(navKey, primaryKey);
				Navigation.SetValue("SkipIfJustOne", true);
				var isPopup = querystring.Get("isPopup") ?? "false";
				var noRedirect = querystring.Get("noRedirect") ?? "false";

				return RedirectToFormAction("VENDAWP", "EDIT", new { id = primaryKey, nav = Navigation.NavigationId, isHomePage, isPopup, noRedirect, skipLastMenu = true }, model);
			}

			return JsonOK(model);
		}

		//
		// GET: /Sale/GQT_Menu_511
		[ActionName("GQT_Menu_511")]
		[HttpPost]
		public ActionResult GQT_Menu_511([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_511_ViewModel model = new GQT_Menu_511_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_511");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_511.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_511.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_511.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Sale/GQT_Menu_521
		[ActionName("GQT_Menu_521")]
		[HttpPost]
		public ActionResult GQT_Menu_521([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_521_ViewModel model = new GQT_Menu_521_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_521");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_521.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_521.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_521.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 521]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}

		//
		// GET: /Sale/GQT_Menu_531
		[ActionName("GQT_Menu_531")]
		[HttpPost]
		public ActionResult GQT_Menu_531([FromBody]RequestMenuModel requestModel)
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

			GQT_Menu_531_ViewModel model = new GQT_Menu_531_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_531");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_sale")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_sale");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_531.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_531.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_531.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 531]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}



	}
}
