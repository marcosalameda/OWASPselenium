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
using GenioMVC.ViewModels.Rooms;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROOMS]/

namespace GenioMVC.Controllers
{
	public partial class RoomsController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_GQT_MENU_2311 = new NavigationLocation("ROOMS06809", "GQT_Menu_2311", "Rooms") { vueRouteName = "menu-GQT_2311" };
		private static readonly NavigationLocation ACTION_GQT_MENU_241 = new NavigationLocation("ROOMS06809", "GQT_Menu_241", "Rooms") { vueRouteName = "menu-GQT_241" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2511 = new NavigationLocation("ROOMS06809", "GQT_Menu_2511", "Rooms") { vueRouteName = "menu-GQT_2511" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3311 = new NavigationLocation("ROOMS06809", "PTN_Menu_3311", "Rooms") { vueRouteName = "menu-PTN_3311" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3411 = new NavigationLocation("ROOMS06809", "PTN_Menu_3411", "Rooms") { vueRouteName = "menu-PTN_3411" };
		private static readonly NavigationLocation ACTION_PTN_MENU_3511 = new NavigationLocation("ROOMS06809", "PTN_Menu_3511", "Rooms") { vueRouteName = "menu-PTN_3511" };


		//
		// GET: /Rooms/GQT_Menu_2311
		[ActionName("GQT_Menu_2311")]
		[HttpPost]
		public ActionResult GQT_Menu_2311([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2311_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2311");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2311.ShortDescription());


// USE /[MANUAL GQT MENU_GET 2311]/

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
		// GET: /Rooms/GQT_Menu_241
		[ActionName("GQT_Menu_241")]
		[HttpPost]
		public ActionResult GQT_Menu_241([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_241_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_241");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_241.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_241.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_241.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 241]/

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
		/// GET/POST: /Rooms/GQT_Menu_241
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <returns></returns>
		public JsonResult GQT_Menu_241_Execute([FromBody]RequestMenuMultiSelectRemoveModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			
			GQT_Menu_241_ViewModel menuViewModel = new GQT_Menu_241_ViewModel(UserContext.Current);
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
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_241]/
				foreach (string selectedId in selected_ids)
				{
					SelectQuery query = new SelectQuery()
						.Select(CSGenioAmovim.FldCodmovim)
						.From(CSGenio.business.Area.AreaMOVIM)
						.Where(CriteriaSet.And()
							.Equal(CSGenioAmovim.FldCodrooms,  Navigation.GetValue("rooms"))
							.In(CSGenioAmovim.FldCodequip, selectedId)
							.Equal(CSGenioAmovim.FldZzstate, 0));

					DataMatrix mx = sp.Execute(query);
					for (int i = 0; i < mx.NumRows; i++)
					{
						var area = new CSGenioAmovim(UserContext.Current.User);
						area.insertNameValueField(query.SelectFields[0].Alias, mx.GetDirect(i, 0));
						area.eliminate(sp);
					}
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_241]/
				}
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_241]/
				sp.closeTransaction();
				Navigation.ClearValue("rooms");
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
		// GET: /Rooms/GQT_Menu_2511
		[ActionName("GQT_Menu_2511")]
		[HttpPost]
		public ActionResult GQT_Menu_2511([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2511_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2511");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2511.ShortDescription());

			if (!String.IsNullOrEmpty(querystring["equip"]))
				Navigation.SetValue("equip", querystring["equip"]);


// USE /[MANUAL GQT MENU_GET 2511]/

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
		// GET: /Rooms/PTN_Menu_3311
		[ActionName("PTN_Menu_3311")]
		[HttpPost]
		public ActionResult PTN_Menu_3311([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_3311_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3311");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3311.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3311.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3311.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 3311]/

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
		// GET: /Rooms/PTN_Menu_3411
		[ActionName("PTN_Menu_3411")]
		[HttpPost]
		public ActionResult PTN_Menu_3411([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_3411_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3411");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3411.ShortDescription());


// USE /[MANUAL PTN MENU_GET 3411]/

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
		// GET: /Rooms/PTN_Menu_3511
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

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_3511");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_3511.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_3511.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_3511.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



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



	}
}
