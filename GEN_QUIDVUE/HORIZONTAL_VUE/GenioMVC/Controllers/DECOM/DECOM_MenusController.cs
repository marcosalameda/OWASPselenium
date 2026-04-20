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
using GenioMVC.ViewModels.Decom;
using Quidgest.Persistence.GenericQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DECOM]/

namespace GenioMVC.Controllers
{
	public partial class DecomController : ControllerBase
	{
		private static readonly NavigationLocation ACTION_PTN_MENU_111 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "PTN_Menu_111", "Decom") { vueRouteName = "menu-PTN_111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C111 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "GQT_Menu_2C111", "Decom") { vueRouteName = "menu-GQT_2C111" };
		private static readonly NavigationLocation ACTION_GQT_MENU_2C31 = new NavigationLocation("EQUIPMENT_DECOMISSIO62648", "GQT_Menu_2C31", "Decom") { vueRouteName = "menu-GQT_2C31" };


		//
		// GET: /Decom/PTN_Menu_111
		[ActionName("PTN_Menu_111")]
		[HttpPost]
		public ActionResult PTN_Menu_111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			PTN_Menu_111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "PTN_Menu_111");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_decom");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_PTN_MENU_111.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_PTN_MENU_111.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_PTN_MENU_111.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL PTN MENU_GET 111]/

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
		// GET: /Decom/GQT_Menu_2C111
		[ActionName("GQT_Menu_2C111")]
		[HttpPost]
		public ActionResult GQT_Menu_2C111([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2C111_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2C111");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_decom");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C111.ShortDescription());


// USE /[MANUAL GQT MENU_GET 2C111]/

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
		// GET: /Decom/GQT_Menu_2C31
		[ActionName("GQT_Menu_2C31")]
		[HttpPost]
		public ActionResult GQT_Menu_2C31([FromBody] RequestMenuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			GQT_Menu_2C31_ViewModel model = new(m_userContext);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			bool isHomePage = RouteData.Values.ContainsKey("isHomePage") ? (bool)RouteData.Values["isHomePage"] : false;
			if (isHomePage)
				Navigation.SetValue("HomePage", "GQT_Menu_2C31");

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_decom")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_decom");
				UserContext.Current.SetPersistenceReadOnly(false);
			}
			CSGenio.framework.StatusMessage result = model.CheckPermissions(FormMode.List);
			if (result.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(result.Message);

			NameValueCollection querystring = [];
			if (queryParams != null && queryParams.Count > 0)
				querystring.AddRange(queryParams);

			if (!isHomePage &&
				(Navigation.CurrentLevel == null || !ACTION_GQT_MENU_2C31.IsSameAction(Navigation.CurrentLevel.Location)) &&
				Navigation.CurrentLevel.Location.Action != ACTION_GQT_MENU_2C31.Action)
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + Navigation.CurrentLevel.Location.ShortDescription());
			else if (isHomePage)
			{
				CSGenio.framework.Audit.registAction(UserContext.Current.User, Resources.Resources.MENU01948 + " " + ACTION_GQT_MENU_2C31.ShortDescription());
				Navigation.SetValue("HomePageContainsList", true);
			}



// USE /[MANUAL GQT MENU_GET 2C31]/

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
		/// GET/POST: /Decom/GQT_Menu_2C31
		/// </summary>
		/// <param name="selected_ids"></param>
		/// <returns></returns>
		public JsonResult GQT_Menu_2C31_Execute([FromBody]RequestMenuMultiSelectRemoveModel requestModel)
		{
			string[] selected_ids = requestModel?.SelectedIds;
			
			GQT_Menu_2C31_ViewModel menuViewModel = new GQT_Menu_2C31_ViewModel(UserContext.Current);
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
// USE /[MANUAL GQT BEFORE_EXECUTE GQT_Menu_2C31]/
				foreach (string selectedId in selected_ids)
				{
					Models.Equip model = Models.Equip.Find(selectedId, UserContext.Current, "MGQT_Menu_2C31");
// USE /[MANUAL GQT ON_EXECUTE GQT_Menu_2C31]/
					model.ValCoddeco = null;
					model.Save();
				}
// USE /[MANUAL GQT AFTER_EXECUTE GQT_Menu_2C31]/
				sp.closeTransaction();
				Navigation.ClearValue("decom");
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



	}
}
