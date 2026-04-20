using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Prope;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPE]/

namespace GenioMVC.Controllers
{
	public partial class PropeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROPE06_CANCEL = new("PROPERTY43977", "Prope06_Cancel", "Prope") { vueRouteName = "form-PROPE06", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE06_SHOW = new("PROPERTY43977", "Prope06_Show", "Prope") { vueRouteName = "form-PROPE06", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE06_NEW = new("PROPERTY43977", "Prope06_New", "Prope") { vueRouteName = "form-PROPE06", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE06_EDIT = new("PROPERTY43977", "Prope06_Edit", "Prope") { vueRouteName = "form-PROPE06", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE06_DUPLICATE = new("PROPERTY43977", "Prope06_Duplicate", "Prope") { vueRouteName = "form-PROPE06", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE06_DELETE = new("PROPERTY43977", "Prope06_Delete", "Prope") { vueRouteName = "form-PROPE06", mode = "DELETE" };

		#endregion

		#region Prope06 private

		private void FormHistoryLimits_Prope06()
		{

		}

		#endregion

		#region Prope06_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE06]/

		[HttpPost]
		public ActionResult Prope06_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope06_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE06_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope06();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE06]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope06_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE06]/
		[HttpPost]
		public ActionResult Prope06_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Prope06_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope06_New_GET",
				AreaName = "prope",
				FormName = "PROPE06",
				Location = ACTION_PROPE06_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope06();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE06]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope06_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE06]/
		[HttpPost]
		public ActionResult Prope06_New([FromBody]Prope06_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope06_New",
				ViewName = "Prope06",
				AreaName = "prope",
				Location = ACTION_PROPE06_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE06]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope06_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE06]/
		[HttpPost]
		public ActionResult Prope06_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope06_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE06",
				Location = ACTION_PROPE06_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope06();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE06]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope06_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE06]/
		[HttpPost]
		public ActionResult Prope06_Edit([FromBody]Prope06_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Edit",
				ViewName = "Prope06",
				AreaName = "prope",
				Location = ACTION_PROPE06_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE06]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope06_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE06]/
		[HttpPost]
		public ActionResult Prope06_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope06_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE06",
				Location = ACTION_PROPE06_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope06();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE06]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope06_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE06]/
		[HttpPost]
		public ActionResult Prope06_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope06_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Prope06_Delete",
				ViewName = "Prope06",
				AreaName = "prope",
				Location = ACTION_PROPE06_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE06]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope06_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE06");
		}

		#endregion

		#region Prope06_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE06]/

		[HttpPost]
		public ActionResult Prope06_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Prope06_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE06",
				Location = ACTION_PROPE06_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE06]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope06_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE06]/
		[HttpPost]
		public ActionResult Prope06_Duplicate([FromBody]Prope06_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope06_Duplicate",
				ViewName = "Prope06",
				AreaName = "prope",
				Location = ACTION_PROPE06_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE06]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope06_Cancel

		//
		// GET: /Prope/Prope06_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE06]/
		public ActionResult Prope06_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("prope");
					var model = GenioMVC.Models.Prope.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("prope");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL PROPE06]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE06]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_prope", "true", true);
			}

			Navigation.ClearValue("prope");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Prope06_CityValCityModel : RequestLookupModel
		{
			public Prope06_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope06_CityValCity
		// POST: /Prope/Prope06_CityValCity
		[ActionName("Prope06_CityValCity")]
		public ActionResult Prope06_CityValCity([FromBody] Prope06_CityValCityModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_city")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_city");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Prope parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Prope06_CityValCity_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope06_AgentValNameModel : RequestLookupModel
		{
			public Prope06_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope06_AgentValName
		// POST: /Prope/Prope06_AgentValName
		[ActionName("Prope06_AgentValName")]
		public ActionResult Prope06_AgentValName([FromBody] Prope06_AgentValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agent");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Prope parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Prope06_AgentValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope06_ValPropcontModel : RequestLookupModel
		{
			public Prope06_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope06_ValPropcont
		// POST: /Prope/Prope06_ValPropcont
		[ActionName("Prope06_ValPropcont")]
		public ActionResult Prope06_ValPropcont([FromBody] Prope06_ValPropcontModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_procn")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_procn");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Prope parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Prope06_ValPropcont_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Prope/Prope06_SaveEdit
		[HttpPost]
		public ActionResult Prope06_SaveEdit([FromBody] Prope06_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope06_SaveEdit",
				ViewName = "Prope06",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE06]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope06DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope06_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope06([FromBody] Prope06DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
