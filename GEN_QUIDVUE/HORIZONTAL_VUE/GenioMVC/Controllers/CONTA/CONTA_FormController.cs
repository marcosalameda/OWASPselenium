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
using GenioMVC.ViewModels.Conta;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CONTA]/

namespace GenioMVC.Controllers
{
	public partial class ContaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONTA_CANCEL = new("CONTACT59247", "Conta_Cancel", "Conta") { vueRouteName = "form-CONTA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONTA_SHOW = new("CONTACT59247", "Conta_Show", "Conta") { vueRouteName = "form-CONTA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONTA_NEW = new("CONTACT59247", "Conta_New", "Conta") { vueRouteName = "form-CONTA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONTA_EDIT = new("CONTACT59247", "Conta_Edit", "Conta") { vueRouteName = "form-CONTA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONTA_DUPLICATE = new("CONTACT59247", "Conta_Duplicate", "Conta") { vueRouteName = "form-CONTA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONTA_DELETE = new("CONTACT59247", "Conta_Delete", "Conta") { vueRouteName = "form-CONTA", mode = "DELETE" };

		#endregion

		#region Conta private

		private void FormHistoryLimits_Conta()
		{

		}

		#endregion

		#region Conta_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CONTA]/

		[HttpPost]
		public ActionResult Conta_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Conta_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Show_GET",
				AreaName = "conta",
				Location = ACTION_CONTA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Conta();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Conta_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CONTA]/
		[HttpPost]
		public ActionResult Conta_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Conta_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Conta_New_GET",
				AreaName = "conta",
				FormName = "CONTA",
				Location = ACTION_CONTA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Conta();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Conta/Conta_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CONTA]/
		[HttpPost]
		public ActionResult Conta_New([FromBody]Conta_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_New",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Conta_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CONTA]/
		[HttpPost]
		public ActionResult Conta_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Conta_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Edit_GET",
				AreaName = "conta",
				FormName = "CONTA",
				Location = ACTION_CONTA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Conta();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Conta/Conta_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CONTA]/
		[HttpPost]
		public ActionResult Conta_Edit([FromBody]Conta_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Edit",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Conta_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CONTA]/
		[HttpPost]
		public ActionResult Conta_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Conta_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Delete_GET",
				AreaName = "conta",
				FormName = "CONTA",
				Location = ACTION_CONTA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Conta();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Conta/Conta_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CONTA]/
		[HttpPost]
		public ActionResult Conta_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Conta_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Conta_Delete",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Conta_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONTA");
		}

		#endregion

		#region Conta_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CONTA]/

		[HttpPost]
		public ActionResult Conta_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Conta_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Duplicate_GET",
				AreaName = "conta",
				FormName = "CONTA",
				Location = ACTION_CONTA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Conta/Conta_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CONTA]/
		[HttpPost]
		public ActionResult Conta_Duplicate([FromBody]Conta_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Conta_Duplicate",
				ViewName = "Conta",
				AreaName = "conta",
				Location = ACTION_CONTA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CONTA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CONTA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CONTA]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTA.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Conta_Cancel

		//
		// GET: /Conta/Conta_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CONTA]/
		public ActionResult Conta_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Conta(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("conta");

// USE /[MANUAL GQT BEFORE_CANCEL CONTA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CONTA]/

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

				Navigation.SetValue("ForcePrimaryRead_conta", "true", true);
			}

			Navigation.ClearValue("conta");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Conta_PessoValNameModel : RequestLookupModel
		{
			public Conta_ViewModel Model { get; set; }
		}

		//
		// GET: /Conta/Conta_PessoValName
		// POST: /Conta/Conta_PessoValName
		[ActionName("Conta_PessoValName")]
		public ActionResult Conta_PessoValName([FromBody] Conta_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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

			Models.Conta parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Conta_PessoValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Conta_GenreValGenderModel : RequestLookupModel
		{
			public Conta_ViewModel Model { get; set; }
		}

		//
		// GET: /Conta/Conta_GenreValGender
		// POST: /Conta/Conta_GenreValGender
		[ActionName("Conta_GenreValGender")]
		public ActionResult Conta_GenreValGender([FromBody] Conta_GenreValGenderModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_genre")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_genre");
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

			Models.Conta parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Conta_GenreValGender_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Conta_TpconValTipocontModel : RequestLookupModel
		{
			public Conta_ViewModel Model { get; set; }
		}

		//
		// GET: /Conta/Conta_TpconValTipocont
		// POST: /Conta/Conta_TpconValTipocont
		[ActionName("Conta_TpconValTipocont")]
		public ActionResult Conta_TpconValTipocont([FromBody] Conta_TpconValTipocontModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpcon")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpcon");
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

			Models.Conta parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Conta_TpconValTipocont_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Conta/Conta_SaveEdit
		[HttpPost]
		public ActionResult Conta_SaveEdit([FromBody] Conta_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Conta_SaveEdit",
				ViewName = "Conta",
				AreaName = "conta",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CONTA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CONTA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ContaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Conta_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsConta([FromBody] ContaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
