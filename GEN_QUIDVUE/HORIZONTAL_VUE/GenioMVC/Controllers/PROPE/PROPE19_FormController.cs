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

		private static readonly NavigationLocation ACTION_PROPE19_CANCEL = new("PROPERTY43977", "Prope19_Cancel", "Prope") { vueRouteName = "form-PROPE19", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE19_SHOW = new("PROPERTY43977", "Prope19_Show", "Prope") { vueRouteName = "form-PROPE19", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE19_NEW = new("PROPERTY43977", "Prope19_New", "Prope") { vueRouteName = "form-PROPE19", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE19_EDIT = new("PROPERTY43977", "Prope19_Edit", "Prope") { vueRouteName = "form-PROPE19", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE19_DUPLICATE = new("PROPERTY43977", "Prope19_Duplicate", "Prope") { vueRouteName = "form-PROPE19", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE19_DELETE = new("PROPERTY43977", "Prope19_Delete", "Prope") { vueRouteName = "form-PROPE19", mode = "DELETE" };

		#endregion

		#region Prope19 private

		private void FormHistoryLimits_Prope19()
		{

		}

		#endregion

		#region Prope19_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE19]/

		[HttpPost]
		public ActionResult Prope19_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope19_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE19_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope19();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE19]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope19_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE19]/
		[HttpPost]
		public ActionResult Prope19_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Prope19_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_New_GET",
				AreaName = "prope",
				FormName = "PROPE19",
				Location = ACTION_PROPE19_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope19();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE19]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope19_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE19]/
		[HttpPost]
		public ActionResult Prope19_New([FromBody]Prope19_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_New",
				ViewName = "Prope19",
				AreaName = "prope",
				Location = ACTION_PROPE19_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE19]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE19]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE19]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope19_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE19]/
		[HttpPost]
		public ActionResult Prope19_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope19_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE19",
				Location = ACTION_PROPE19_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope19();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE19]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope19_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE19]/
		[HttpPost]
		public ActionResult Prope19_Edit([FromBody]Prope19_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Edit",
				ViewName = "Prope19",
				AreaName = "prope",
				Location = ACTION_PROPE19_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE19]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE19]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE19]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope19_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE19]/
		[HttpPost]
		public ActionResult Prope19_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope19_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE19",
				Location = ACTION_PROPE19_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope19();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE19]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope19_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE19]/
		[HttpPost]
		public ActionResult Prope19_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope19_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Delete",
				ViewName = "Prope19",
				AreaName = "prope",
				Location = ACTION_PROPE19_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE19]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope19_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE19");
		}

		#endregion

		#region Prope19_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE19]/

		[HttpPost]
		public ActionResult Prope19_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Prope19_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE19",
				Location = ACTION_PROPE19_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE19]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope19_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE19]/
		[HttpPost]
		public ActionResult Prope19_Duplicate([FromBody]Prope19_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope19_Duplicate",
				ViewName = "Prope19",
				AreaName = "prope",
				Location = ACTION_PROPE19_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE19]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE19]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE19]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope19_Cancel

		//
		// GET: /Prope/Prope19_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE19]/
		public ActionResult Prope19_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Prope(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE19]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE19]/

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


		public class Prope19_CityValCityModel : RequestLookupModel
		{
			public Prope19_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope19_CityValCity
		// POST: /Prope/Prope19_CityValCity
		[ActionName("Prope19_CityValCity")]
		public ActionResult Prope19_CityValCity([FromBody] Prope19_CityValCityModel requestModel)
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
			Prope19_CityValCity_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Prope19_AgentValNameModel : RequestLookupModel
		{
			public Prope19_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope19_AgentValName
		// POST: /Prope/Prope19_AgentValName
		[ActionName("Prope19_AgentValName")]
		public ActionResult Prope19_AgentValName([FromBody] Prope19_AgentValNameModel requestModel)
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
			Prope19_AgentValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Prope19_ValProphotoModel : RequestLookupModel
		{
			public Prope19_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope19_ValProphoto
		// POST: /Prope/Prope19_ValProphoto
		[ActionName("Prope19_ValProphoto")]
		public ActionResult Prope19_ValProphoto([FromBody] Prope19_ValProphotoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_proph")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_proph");
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
			Prope19_ValProphoto_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Prope19_ValPropcontModel : RequestLookupModel
		{
			public Prope19_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope19_ValPropcont
		// POST: /Prope/Prope19_ValPropcont
		[ActionName("Prope19_ValPropcont")]
		public ActionResult Prope19_ValPropcont([FromBody] Prope19_ValPropcontModel requestModel)
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
			Prope19_ValPropcont_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Prope/Prope19_SaveEdit
		[HttpPost]
		public ActionResult Prope19_SaveEdit([FromBody] Prope19_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Prope19_SaveEdit",
				ViewName = "Prope19",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE19]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE19]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Prope19DocumValidateTickets : RequestDocumValidateTickets
		{
			public Prope19_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPrope19([FromBody] Prope19DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
