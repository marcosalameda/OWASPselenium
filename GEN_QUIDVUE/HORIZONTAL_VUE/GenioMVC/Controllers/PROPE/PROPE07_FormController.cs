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

		private static readonly NavigationLocation ACTION_PROPE07_CANCEL = new("PROPERTY43977", "Prope07_Cancel", "Prope") { vueRouteName = "form-PROPE07", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE07_SHOW = new("PROPERTY43977", "Prope07_Show", "Prope") { vueRouteName = "form-PROPE07", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE07_NEW = new("PROPERTY43977", "Prope07_New", "Prope") { vueRouteName = "form-PROPE07", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE07_EDIT = new("PROPERTY43977", "Prope07_Edit", "Prope") { vueRouteName = "form-PROPE07", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE07_DUPLICATE = new("PROPERTY43977", "Prope07_Duplicate", "Prope") { vueRouteName = "form-PROPE07", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE07_DELETE = new("PROPERTY43977", "Prope07_Delete", "Prope") { vueRouteName = "form-PROPE07", mode = "DELETE" };

		#endregion

		#region Prope07 private

		private void FormHistoryLimits_Prope07()
		{

		}

		#endregion

		#region Prope07_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE07]/

		[HttpPost]
		public ActionResult Prope07_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope07_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE07_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope07();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE07]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope07_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE07]/
		[HttpPost]
		public ActionResult Prope07_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Prope07_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope07_New_GET",
				AreaName = "prope",
				FormName = "PROPE07",
				Location = ACTION_PROPE07_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope07();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE07]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope07_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE07]/
		[HttpPost]
		public ActionResult Prope07_New([FromBody]Prope07_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope07_New",
				ViewName = "Prope07",
				AreaName = "prope",
				Location = ACTION_PROPE07_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE07]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope07_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE07]/
		[HttpPost]
		public ActionResult Prope07_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope07_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE07",
				Location = ACTION_PROPE07_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope07();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE07]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope07_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE07]/
		[HttpPost]
		public ActionResult Prope07_Edit([FromBody]Prope07_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Edit",
				ViewName = "Prope07",
				AreaName = "prope",
				Location = ACTION_PROPE07_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE07]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope07_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE07]/
		[HttpPost]
		public ActionResult Prope07_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope07_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE07",
				Location = ACTION_PROPE07_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope07();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE07]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope07_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE07]/
		[HttpPost]
		public ActionResult Prope07_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Prope07_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Prope07_Delete",
				ViewName = "Prope07",
				AreaName = "prope",
				Location = ACTION_PROPE07_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE07]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope07_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE07");
		}

		#endregion

		#region Prope07_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE07]/

		[HttpPost]
		public ActionResult Prope07_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Prope07_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE07",
				Location = ACTION_PROPE07_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE07]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope07_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE07]/
		[HttpPost]
		public ActionResult Prope07_Duplicate([FromBody]Prope07_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope07_Duplicate",
				ViewName = "Prope07",
				AreaName = "prope",
				Location = ACTION_PROPE07_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE07]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope07_Cancel

		//
		// GET: /Prope/Prope07_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE07]/
		public ActionResult Prope07_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Prope model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE07]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE07]/

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


		public class Prope07_CityValCityModel : RequestLookupModel
		{
			public Prope07_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope07_CityValCity
		// POST: /Prope/Prope07_CityValCity
		[ActionName("Prope07_CityValCity")]
		public ActionResult Prope07_CityValCity([FromBody] Prope07_CityValCityModel requestModel)
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
			Prope07_CityValCity_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope07_AgentValNameModel : RequestLookupModel
		{
			public Prope07_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope07_AgentValName
		// POST: /Prope/Prope07_AgentValName
		[ActionName("Prope07_AgentValName")]
		public ActionResult Prope07_AgentValName([FromBody] Prope07_AgentValNameModel requestModel)
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
			Prope07_AgentValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope07_ValPropcontModel : RequestLookupModel
		{
			public Prope07_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope07_ValPropcont
		// POST: /Prope/Prope07_ValPropcont
		[ActionName("Prope07_ValPropcont")]
		public ActionResult Prope07_ValPropcont([FromBody] Prope07_ValPropcontModel requestModel)
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
			Prope07_ValPropcont_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Prope/Prope07_SaveEdit
		[HttpPost]
		public ActionResult Prope07_SaveEdit([FromBody] Prope07_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope07_SaveEdit",
				ViewName = "Prope07",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE07]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope07DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope07_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope07([FromBody] Prope07DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
