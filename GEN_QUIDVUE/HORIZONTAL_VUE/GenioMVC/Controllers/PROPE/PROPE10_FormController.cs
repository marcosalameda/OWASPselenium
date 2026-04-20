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

		private static readonly NavigationLocation ACTION_PROPE10_CANCEL = new("PROPERTY43977", "Prope10_Cancel", "Prope") { vueRouteName = "form-PROPE10", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE10_SHOW = new("PROPERTY43977", "Prope10_Show", "Prope") { vueRouteName = "form-PROPE10", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE10_NEW = new("PROPERTY43977", "Prope10_New", "Prope") { vueRouteName = "form-PROPE10", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE10_EDIT = new("PROPERTY43977", "Prope10_Edit", "Prope") { vueRouteName = "form-PROPE10", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE10_DUPLICATE = new("PROPERTY43977", "Prope10_Duplicate", "Prope") { vueRouteName = "form-PROPE10", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE10_DELETE = new("PROPERTY43977", "Prope10_Delete", "Prope") { vueRouteName = "form-PROPE10", mode = "DELETE" };

		#endregion

		#region Prope10 private

		private void FormHistoryLimits_Prope10()
		{

		}

		#endregion

		#region Prope10_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE10]/

		[HttpPost]
		public ActionResult Prope10_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope10_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE10_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope10();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE10]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope10_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE10]/
		[HttpPost]
		public ActionResult Prope10_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Prope10_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope10_New_GET",
				AreaName = "prope",
				FormName = "PROPE10",
				Location = ACTION_PROPE10_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope10();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE10]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope10_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE10]/
		[HttpPost]
		public ActionResult Prope10_New([FromBody]Prope10_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope10_New",
				ViewName = "Prope10",
				AreaName = "prope",
				Location = ACTION_PROPE10_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE10]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE10]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE10]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope10_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE10]/
		[HttpPost]
		public ActionResult Prope10_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope10_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE10",
				Location = ACTION_PROPE10_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope10();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE10]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope10_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE10]/
		[HttpPost]
		public ActionResult Prope10_Edit([FromBody]Prope10_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Edit",
				ViewName = "Prope10",
				AreaName = "prope",
				Location = ACTION_PROPE10_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE10]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE10]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE10]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope10_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE10]/
		[HttpPost]
		public ActionResult Prope10_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope10_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE10",
				Location = ACTION_PROPE10_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope10();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE10]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope10_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE10]/
		[HttpPost]
		public ActionResult Prope10_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope10_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Prope10_Delete",
				ViewName = "Prope10",
				AreaName = "prope",
				Location = ACTION_PROPE10_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE10]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope10_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE10");
		}

		#endregion

		#region Prope10_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE10]/

		[HttpPost]
		public ActionResult Prope10_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Prope10_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE10",
				Location = ACTION_PROPE10_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE10]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope10_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE10]/
		[HttpPost]
		public ActionResult Prope10_Duplicate([FromBody]Prope10_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope10_Duplicate",
				ViewName = "Prope10",
				AreaName = "prope",
				Location = ACTION_PROPE10_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE10]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE10]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE10]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope10_Cancel

		//
		// GET: /Prope/Prope10_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE10]/
		public ActionResult Prope10_Cancel()
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

// USE /[MANUAL GQT BEFORE_CANCEL PROPE10]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE10]/

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


		public class Prope10_CityValCityModel : RequestLookupModel
		{
			public Prope10_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope10_CityValCity
		// POST: /Prope/Prope10_CityValCity
		[ActionName("Prope10_CityValCity")]
		public ActionResult Prope10_CityValCity([FromBody] Prope10_CityValCityModel requestModel)
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
			Prope10_CityValCity_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope10_AgentValNameModel : RequestLookupModel
		{
			public Prope10_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope10_AgentValName
		// POST: /Prope/Prope10_AgentValName
		[ActionName("Prope10_AgentValName")]
		public ActionResult Prope10_AgentValName([FromBody] Prope10_AgentValNameModel requestModel)
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
			Prope10_AgentValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope10_ValPropcontModel : RequestLookupModel
		{
			public Prope10_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope10_ValPropcont
		// POST: /Prope/Prope10_ValPropcont
		[ActionName("Prope10_ValPropcont")]
		public ActionResult Prope10_ValPropcont([FromBody] Prope10_ValPropcontModel requestModel)
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
			Prope10_ValPropcont_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Prope/Prope10_SaveEdit
		[HttpPost]
		public ActionResult Prope10_SaveEdit([FromBody] Prope10_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope10_SaveEdit",
				ViewName = "Prope10",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE10]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE10]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope10DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope10_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope10([FromBody] Prope10DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
