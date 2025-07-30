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

		private static readonly NavigationLocation ACTION_PROPE03_CANCEL = new("PROPERTY43977", "Prope03_Cancel", "Prope") { vueRouteName = "form-PROPE03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE03_SHOW = new("PROPERTY43977", "Prope03_Show", "Prope") { vueRouteName = "form-PROPE03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE03_NEW = new("PROPERTY43977", "Prope03_New", "Prope") { vueRouteName = "form-PROPE03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE03_EDIT = new("PROPERTY43977", "Prope03_Edit", "Prope") { vueRouteName = "form-PROPE03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE03_DUPLICATE = new("PROPERTY43977", "Prope03_Duplicate", "Prope") { vueRouteName = "form-PROPE03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE03_DELETE = new("PROPERTY43977", "Prope03_Delete", "Prope") { vueRouteName = "form-PROPE03", mode = "DELETE" };

		#endregion

		#region Prope03 private

		private void FormHistoryLimits_Prope03()
		{

		}

		#endregion

		#region Prope03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE03]/

		[HttpPost]
		public ActionResult Prope03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE03]/
		[HttpPost]
		public ActionResult Prope03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Prope03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_New_GET",
				AreaName = "prope",
				FormName = "PROPE03",
				Location = ACTION_PROPE03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE03]/
		[HttpPost]
		public ActionResult Prope03_New([FromBody]Prope03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_New",
				ViewName = "Prope03",
				AreaName = "prope",
				Location = ACTION_PROPE03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE03]/
		[HttpPost]
		public ActionResult Prope03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE03",
				Location = ACTION_PROPE03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE03]/
		[HttpPost]
		public ActionResult Prope03_Edit([FromBody]Prope03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Edit",
				ViewName = "Prope03",
				AreaName = "prope",
				Location = ACTION_PROPE03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE03]/
		[HttpPost]
		public ActionResult Prope03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE03",
				Location = ACTION_PROPE03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE03]/
		[HttpPost]
		public ActionResult Prope03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Delete",
				ViewName = "Prope03",
				AreaName = "prope",
				Location = ACTION_PROPE03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE03");
		}

		#endregion

		#region Prope03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE03]/

		[HttpPost]
		public ActionResult Prope03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Prope03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE03",
				Location = ACTION_PROPE03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE03]/
		[HttpPost]
		public ActionResult Prope03_Duplicate([FromBody]Prope03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope03_Duplicate",
				ViewName = "Prope03",
				AreaName = "prope",
				Location = ACTION_PROPE03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope03_Cancel

		//
		// GET: /Prope/Prope03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE03]/
		public ActionResult Prope03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Prope(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE03]/

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


		public class Prope03_AgentValNameModel : RequestLookupModel
		{
			public Prope03_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope03_AgentValName
		// POST: /Prope/Prope03_AgentValName
		[ActionName("Prope03_AgentValName")]
		public ActionResult Prope03_AgentValName([FromBody] Prope03_AgentValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agent");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope03_AgentValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope03_CityValCityModel : RequestLookupModel
		{
			public Prope03_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope03_CityValCity
		// POST: /Prope/Prope03_CityValCity
		[ActionName("Prope03_CityValCity")]
		public ActionResult Prope03_CityValCity([FromBody] Prope03_CityValCityModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_city")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_city");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope03_CityValCity_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Prope03_ValPropcontModel : RequestLookupModel
		{
			public Prope03_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope03_ValPropcont
		// POST: /Prope/Prope03_ValPropcont
		[ActionName("Prope03_ValPropcont")]
		public ActionResult Prope03_ValPropcont([FromBody] Prope03_ValPropcontModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_procn")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_procn");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope03_ValPropcont_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Prope/Prope03_SaveEdit
		[HttpPost]
		public ActionResult Prope03_SaveEdit([FromBody] Prope03_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope03_SaveEdit",
				ViewName = "Prope03",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope03DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope03([FromBody] Prope03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
