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
using GenioMVC.ViewModels.Expen;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EXPEN]/

namespace GenioMVC.Controllers
{
	public partial class ExpenController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DESPE_CANCEL = new("DESPESA07561", "Despe_Cancel", "Expen") { vueRouteName = "form-DESPE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DESPE_SHOW = new("DESPESA07561", "Despe_Show", "Expen") { vueRouteName = "form-DESPE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DESPE_NEW = new("DESPESA07561", "Despe_New", "Expen") { vueRouteName = "form-DESPE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DESPE_EDIT = new("DESPESA07561", "Despe_Edit", "Expen") { vueRouteName = "form-DESPE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DESPE_DUPLICATE = new("DESPESA07561", "Despe_Duplicate", "Expen") { vueRouteName = "form-DESPE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DESPE_DELETE = new("DESPESA07561", "Despe_Delete", "Expen") { vueRouteName = "form-DESPE", mode = "DELETE" };

		#endregion

		#region Despe private

		private void FormHistoryLimits_Despe()
		{

		}

		#endregion

		#region Despe_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DESPE]/

		[HttpPost]
		public ActionResult Despe_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Despe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Show_GET",
				AreaName = "expen",
				Location = ACTION_DESPE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Despe();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DESPE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Despe_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DESPE]/
		[HttpPost]
		public ActionResult Despe_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Despe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Despe_New_GET",
				AreaName = "expen",
				FormName = "DESPE",
				Location = ACTION_DESPE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Despe();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DESPE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Expen/Despe_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DESPE]/
		[HttpPost]
		public ActionResult Despe_New([FromBody]Despe_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Despe_New",
				ViewName = "Despe",
				AreaName = "expen",
				Location = ACTION_DESPE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DESPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DESPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DESPE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Despe_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DESPE]/
		[HttpPost]
		public ActionResult Despe_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Despe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Edit_GET",
				AreaName = "expen",
				FormName = "DESPE",
				Location = ACTION_DESPE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Despe();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DESPE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Expen/Despe_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DESPE]/
		[HttpPost]
		public ActionResult Despe_Edit([FromBody]Despe_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Edit",
				ViewName = "Despe",
				AreaName = "expen",
				Location = ACTION_DESPE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DESPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DESPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DESPE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Despe_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DESPE]/
		[HttpPost]
		public ActionResult Despe_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Despe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Delete_GET",
				AreaName = "expen",
				FormName = "DESPE",
				Location = ACTION_DESPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Despe();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DESPE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Expen/Despe_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DESPE]/
		[HttpPost]
		public ActionResult Despe_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Despe_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Despe_Delete",
				ViewName = "Despe",
				AreaName = "expen",
				Location = ACTION_DESPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DESPE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Despe_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DESPE");
		}

		#endregion

		#region Despe_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DESPE]/

		[HttpPost]
		public ActionResult Despe_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Despe_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Duplicate_GET",
				AreaName = "expen",
				FormName = "DESPE",
				Location = ACTION_DESPE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DESPE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Expen/Despe_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DESPE]/
		[HttpPost]
		public ActionResult Despe_Duplicate([FromBody]Despe_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Despe_Duplicate",
				ViewName = "Despe",
				AreaName = "expen",
				Location = ACTION_DESPE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DESPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DESPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DESPE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Despe_Cancel

		//
		// GET: /Expen/Despe_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DESPE]/
		public ActionResult Despe_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Expen(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("expen");

// USE /[MANUAL GQT BEFORE_CANCEL DESPE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DESPE]/

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

				Navigation.SetValue("ForcePrimaryRead_expen", "true", true);
			}

			Navigation.ClearValue("expen");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Despe_ProjeValProjectoModel : RequestLookupModel
		{
			public Despe_ViewModel Model { get; set; }
		}

		//
		// GET: /Expen/Despe_ProjeValProjecto
		// POST: /Expen/Despe_ProjeValProjecto
		[ActionName("Despe_ProjeValProjecto")]
		public ActionResult Despe_ProjeValProjecto([FromBody] Despe_ProjeValProjectoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_proje")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_proje");
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

			Models.Expen parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Despe_ProjeValProjecto_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Despe_YearValYearModel : RequestLookupModel
		{
			public Despe_ViewModel Model { get; set; }
		}

		//
		// GET: /Expen/Despe_YearValYear
		// POST: /Expen/Despe_YearValYear
		[ActionName("Despe_YearValYear")]
		public ActionResult Despe_YearValYear([FromBody] Despe_YearValYearModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_year")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_year");
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

			Models.Expen parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Despe_YearValYear_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Despe_AgregValValueModel : RequestLookupModel
		{
			public Despe_ViewModel Model { get; set; }
		}

		//
		// GET: /Expen/Despe_AgregValValue
		// POST: /Expen/Despe_AgregValValue
		[ActionName("Despe_AgregValValue")]
		public ActionResult Despe_AgregValValue([FromBody] Despe_AgregValValueModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agreg")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agreg");
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

			Models.Expen parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Despe_AgregValValue_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Expen/Despe_SaveEdit
		[HttpPost]
		public ActionResult Despe_SaveEdit([FromBody] Despe_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Despe_SaveEdit",
				ViewName = "Despe",
				AreaName = "expen",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DESPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DESPE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DespeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Despe_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDespe([FromBody] DespeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
