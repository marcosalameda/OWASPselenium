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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FLDSCOND_CANCEL = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_Cancel", "Flds") { vueRouteName = "form-FLDSCOND", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FLDSCOND_SHOW = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_Show", "Flds") { vueRouteName = "form-FLDSCOND", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FLDSCOND_NEW = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_New", "Flds") { vueRouteName = "form-FLDSCOND", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FLDSCOND_EDIT = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_Edit", "Flds") { vueRouteName = "form-FLDSCOND", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FLDSCOND_DUPLICATE = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_Duplicate", "Flds") { vueRouteName = "form-FLDSCOND", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FLDSCOND_DELETE = new("CONDICOES_DE_MOSTRA_10663", "Fldscond_Delete", "Flds") { vueRouteName = "form-FLDSCOND", mode = "DELETE" };

		#endregion

		#region Fldscond private

		private void FormHistoryLimits_Fldscond()
		{

		}

		#endregion

		#region Fldscond_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FLDSCOND]/

		[HttpPost]
		public ActionResult Fldscond_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscond_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Show_GET",
				AreaName = "flds",
				Location = ACTION_FLDSCOND_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscond();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Fldscond_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Fldscond_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_New_GET",
				AreaName = "flds",
				FormName = "FLDSCOND",
				Location = ACTION_FLDSCOND_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fldscond();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Flds/Fldscond_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_New([FromBody]Fldscond_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_New",
				ViewName = "Fldscond",
				AreaName = "flds",
				Location = ACTION_FLDSCOND_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FLDSCOND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FLDSCOND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Fldscond_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscond_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Edit_GET",
				AreaName = "flds",
				FormName = "FLDSCOND",
				Location = ACTION_FLDSCOND_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscond();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Flds/Fldscond_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_Edit([FromBody]Fldscond_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Edit",
				ViewName = "Fldscond",
				AreaName = "flds",
				Location = ACTION_FLDSCOND_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FLDSCOND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FLDSCOND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Fldscond_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscond_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Delete_GET",
				AreaName = "flds",
				FormName = "FLDSCOND",
				Location = ACTION_FLDSCOND_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fldscond();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Flds/Fldscond_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Fldscond_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Delete",
				ViewName = "Fldscond",
				AreaName = "flds",
				Location = ACTION_FLDSCOND_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Fldscond_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FLDSCOND");
		}

		#endregion

		#region Fldscond_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FLDSCOND]/

		[HttpPost]
		public ActionResult Fldscond_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Fldscond_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Duplicate_GET",
				AreaName = "flds",
				FormName = "FLDSCOND",
				Location = ACTION_FLDSCOND_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Flds/Fldscond_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FLDSCOND]/
		[HttpPost]
		public ActionResult Fldscond_Duplicate([FromBody]Fldscond_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Fldscond_Duplicate",
				ViewName = "Fldscond",
				AreaName = "flds",
				Location = ACTION_FLDSCOND_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FLDSCOND]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FLDSCOND]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FLDSCOND]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FLDSCOND.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Fldscond_Cancel

		//
		// GET: /Flds/Fldscond_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FLDSCOND]/
		public ActionResult Fldscond_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Flds(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("flds");

// USE /[MANUAL GQT BEFORE_CANCEL FLDSCOND]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FLDSCOND]/

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

				Navigation.SetValue("ForcePrimaryRead_flds", "true", true);
			}

			Navigation.ClearValue("flds");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Fldscond_ValGridtblModel : RequestLookupModel
		{
			public Fldscond_ViewModel Model { get; set; }
		}

		//
		// GET: /Flds/Fldscond_ValGridtbl
		// POST: /Flds/Fldscond_ValGridtbl
		[ActionName("Fldscond_ValGridtbl")]
		public ActionResult Fldscond_ValGridtbl([FromBody] Fldscond_ValGridtblModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = -1;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_feeca")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_feeca");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Flds parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Fldscond_ValGridtbl_ViewModel model = new(UserContext.Current, parentCtx);

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

			return JsonOK(model.Menu);
		}

		public class Fldscond_ValListtblModel : RequestLookupModel
		{
			public Fldscond_ViewModel Model { get; set; }
		}

		//
		// GET: /Flds/Fldscond_ValListtbl
		// POST: /Flds/Fldscond_ValListtbl
		[ActionName("Fldscond_ValListtbl")]
		public ActionResult Fldscond_ValListtbl([FromBody] Fldscond_ValListtblModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_feeca")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_feeca");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Flds parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Fldscond_ValListtbl_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Flds/Fldscond_SaveEdit
		[HttpPost]
		public ActionResult Fldscond_SaveEdit([FromBody] Fldscond_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fldscond_SaveEdit",
				ViewName = "Fldscond",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FLDSCOND]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FLDSCOND]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class FldscondDocumValidateTickets : RequestDocumValidateTickets
		{
			public Fldscond_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFldscond([FromBody] FldscondDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
