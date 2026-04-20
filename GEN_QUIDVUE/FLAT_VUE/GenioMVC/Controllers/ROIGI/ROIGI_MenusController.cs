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
using GenioMVC.ViewModels.Roigi;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGI]/

namespace GenioMVC.Controllers
{
	public partial class RoigiController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_4411 = new NavigationLocation("ORDERS_IN_GROUP___IN07193", "PTN_Menu_4411", "Roigi") { vueRouteName = "menu-PTN_4411" };


		//
		// GET: /Roigi/PTN_Menu_4411
		[ActionName("PTN_Menu_4411")]
		[HttpPost]
		public ActionResult PTN_Menu_4411([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_4411_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(-1, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_4411");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_roigi")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_roigi");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_4411.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_4411.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_4411.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}


			if (!String.IsNullOrEmpty(querystring["rogl1"]))
				Navigation.SetValue("rogl1", querystring["rogl1"]);


// USE /[MANUAL PTN MENU_GET 4411]/

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



		public ActionResult ReorderPTN_Menu_4411([FromBody]RequestReorderModel requestModel)
		{
			var id = requestModel.Id;
			var position = requestModel.Position.ToString();

			PTN_Menu_4411_ViewModel model = new PTN_Menu_4411_ViewModel(UserContext.Current);
			model.ReorderPTN_Menu_4411(id,position);
			model.Load(-1);

			return JsonOK(model);
		}

	}
}
