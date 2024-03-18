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
using GenioMVC.ViewModels.Roigf;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGF]/

namespace GenioMVC.Controllers
{
	public partial class RoigfController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_15311 = new NavigationLocation("ORDERS_IN_GROUP___FL17142", "PTN_Menu_15311", "Roigf") { vueRouteName = "menu-PTN_15311" };


		//
		// GET: /Roigf/PTN_Menu_15311
		[ActionName("PTN_Menu_15311")]
		[HttpPost]
		public ActionResult PTN_Menu_15311([FromBody]RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;
			var allSelected = requestModel.AllSelected;

			int perPage = -1;

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

			PTN_Menu_15311_ViewModel model = new PTN_Menu_15311_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_15311");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_roigf")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_roigf");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_15311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_15311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_15311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["rogl1"]))
				Navigation.SetValue("rogl1", querystring["rogl1"]);


// USE /[MANUAL PTN MENU_GET 15311]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}



		public ActionResult ReorderPTN_Menu_15311([FromBody]RequestReorderModel requestModel)
		{
			var id = requestModel.Id;
			var position = requestModel.Position.ToString();

			PTN_Menu_15311_ViewModel model = new PTN_Menu_15311_ViewModel(UserContext.Current);
			model.ReorderPTN_Menu_15311(id,position);
			model.Load(-1);

			return JsonOK(model);
		}

	}
}
