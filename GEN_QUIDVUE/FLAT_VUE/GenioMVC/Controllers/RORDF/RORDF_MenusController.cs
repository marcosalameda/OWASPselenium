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
using GenioMVC.ViewModels.Rordf;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RORDF]/

namespace GenioMVC.Controllers
{
	public partial class RordfController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_1511 = new NavigationLocation("ORDERS___FLOAT_FIELD11291", "PTN_Menu_1511", "Rordf") { vueRouteName = "menu-PTN_1511" };


		//
		// GET: /Rordf/PTN_Menu_1511
		[ActionName("PTN_Menu_1511")]
		[HttpPost]
		public ActionResult PTN_Menu_1511([FromBody]RequestMenuModel requestModel)
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

			PTN_Menu_1511_ViewModel model = new PTN_Menu_1511_ViewModel(UserContext.Current);
			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_1511");

			//If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rordf")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rordf");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = new NameValueCollection();
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_1511.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_1511.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_1511.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 1511]/


			model.Load(perPage, querystring, Request.IsAjaxRequest());

			if (model.CheckForZzstate())
				WarningMessage(Resources.Resources.ATENCAO__TEM_FICHAS_40812);


			return JsonOK(model);
		}



		public ActionResult ReorderPTN_Menu_1511([FromBody]RequestReorderModel requestModel)
		{
			var id = requestModel.Id;
			var position = requestModel.Position.ToString();

			PTN_Menu_1511_ViewModel model = new PTN_Menu_1511_ViewModel(UserContext.Current);
			model.ReorderPTN_Menu_1511(id,position);
			model.Load(-1);

			return JsonOK(model);
		}

	}
}
