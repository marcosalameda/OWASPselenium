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

		private static readonly NavigationLocation ACTION_PROPE05_CANCEL = new("PROPERTY43977", "Prope05_Cancel", "Prope") { vueRouteName = "form-PROPE05", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE05_SHOW = new("PROPERTY43977", "Prope05_Show", "Prope") { vueRouteName = "form-PROPE05", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE05_NEW = new("PROPERTY43977", "Prope05_New", "Prope") { vueRouteName = "form-PROPE05", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE05_EDIT = new("PROPERTY43977", "Prope05_Edit", "Prope") { vueRouteName = "form-PROPE05", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE05_DUPLICATE = new("PROPERTY43977", "Prope05_Duplicate", "Prope") { vueRouteName = "form-PROPE05", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE05_DELETE = new("PROPERTY43977", "Prope05_Delete", "Prope") { vueRouteName = "form-PROPE05", mode = "DELETE" };

		#endregion

		#region Prope05 private

		private void FormHistoryLimits_Prope05()
		{

		}

		#endregion

		#region Prope05_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE05]/

		[HttpPost]
		public ActionResult Prope05_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE05_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope05();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE05]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope05_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE05]/
		[HttpPost]
		public ActionResult Prope05_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Prope05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope05_New_GET",
				AreaName = "prope",
				FormName = "PROPE05",
				Location = ACTION_PROPE05_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope05();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE05]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope05_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE05]/
		[HttpPost]
		public ActionResult Prope05_New([FromBody]Prope05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope05_New",
				ViewName = "Prope05",
				AreaName = "prope",
				Location = ACTION_PROPE05_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE05]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope05_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE05]/
		[HttpPost]
		public ActionResult Prope05_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE05",
				Location = ACTION_PROPE05_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope05();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE05]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope05_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE05]/
		[HttpPost]
		public ActionResult Prope05_Edit([FromBody]Prope05_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Edit",
				ViewName = "Prope05",
				AreaName = "prope",
				Location = ACTION_PROPE05_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE05]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope05_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE05]/
		[HttpPost]
		public ActionResult Prope05_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE05",
				Location = ACTION_PROPE05_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope05();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE05]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope05_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE05]/
		[HttpPost]
		public ActionResult Prope05_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope05_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Prope05_Delete",
				ViewName = "Prope05",
				AreaName = "prope",
				Location = ACTION_PROPE05_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE05]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope05_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE05");
		}

		#endregion

		#region Prope05_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE05]/

		[HttpPost]
		public ActionResult Prope05_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Prope05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE05",
				Location = ACTION_PROPE05_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE05]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope05_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE05]/
		[HttpPost]
		public ActionResult Prope05_Duplicate([FromBody]Prope05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope05_Duplicate",
				ViewName = "Prope05",
				AreaName = "prope",
				Location = ACTION_PROPE05_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE05]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope05_Cancel

		//
		// GET: /Prope/Prope05_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE05]/
		public ActionResult Prope05_Cancel()
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

// USE /[MANUAL GQT BEFORE_CANCEL PROPE05]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE05]/

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


		public class Prope05_AgentValNameModel : RequestLookupModel
		{
			public Prope05_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope05_AgentValName
		// POST: /Prope/Prope05_AgentValName
		[ActionName("Prope05_AgentValName")]
		public ActionResult Prope05_AgentValName([FromBody] Prope05_AgentValNameModel requestModel)
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
			Prope05_AgentValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope05_CityValCityModel : RequestLookupModel
		{
			public Prope05_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope05_CityValCity
		// POST: /Prope/Prope05_CityValCity
		[ActionName("Prope05_CityValCity")]
		public ActionResult Prope05_CityValCity([FromBody] Prope05_CityValCityModel requestModel)
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
			Prope05_CityValCity_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Prope/Prope05_SaveEdit
		[HttpPost]
		public ActionResult Prope05_SaveEdit([FromBody] Prope05_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope05_SaveEdit",
				ViewName = "Prope05",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE05]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope05DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope05_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope05([FromBody] Prope05DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
