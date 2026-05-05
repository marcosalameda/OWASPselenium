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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARTIGVAL_CANCEL = new("ITEM40802", "Artigval_Cancel", "Item") { vueRouteName = "form-ARTIGVAL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTIGVAL_SHOW = new("ITEM40802", "Artigval_Show", "Item") { vueRouteName = "form-ARTIGVAL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTIGVAL_NEW = new("ITEM40802", "Artigval_New", "Item") { vueRouteName = "form-ARTIGVAL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTIGVAL_EDIT = new("ITEM40802", "Artigval_Edit", "Item") { vueRouteName = "form-ARTIGVAL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTIGVAL_DUPLICATE = new("ITEM40802", "Artigval_Duplicate", "Item") { vueRouteName = "form-ARTIGVAL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTIGVAL_DELETE = new("ITEM40802", "Artigval_Delete", "Item") { vueRouteName = "form-ARTIGVAL", mode = "DELETE" };

		#endregion

		#region Artigval private

		private void FormHistoryLimits_Artigval()
		{

		}

		#endregion

		#region Artigval_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTIGVAL]/

		[HttpPost]
		public ActionResult Artigval_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigval_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Show_GET",
				AreaName = "item",
				Location = ACTION_ARTIGVAL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigval();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Artigval_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artigval_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_New_GET",
				AreaName = "item",
				FormName = "ARTIGVAL",
				Location = ACTION_ARTIGVAL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artigval();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Item/Artigval_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_New([FromBody]Artigval_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_New",
				ViewName = "Artigval",
				AreaName = "item",
				Location = ACTION_ARTIGVAL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTIGVAL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTIGVAL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Artigval_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigval_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Edit_GET",
				AreaName = "item",
				FormName = "ARTIGVAL",
				Location = ACTION_ARTIGVAL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigval();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Item/Artigval_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_Edit([FromBody]Artigval_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Edit",
				ViewName = "Artigval",
				AreaName = "item",
				Location = ACTION_ARTIGVAL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTIGVAL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTIGVAL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Artigval_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigval_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Delete_GET",
				AreaName = "item",
				FormName = "ARTIGVAL",
				Location = ACTION_ARTIGVAL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigval();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Item/Artigval_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigval_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Delete",
				ViewName = "Artigval",
				AreaName = "item",
				Location = ACTION_ARTIGVAL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Artigval_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTIGVAL");
		}

		#endregion

		#region Artigval_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTIGVAL]/

		[HttpPost]
		public ActionResult Artigval_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artigval_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Duplicate_GET",
				AreaName = "item",
				FormName = "ARTIGVAL",
				Location = ACTION_ARTIGVAL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Item/Artigval_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTIGVAL]/
		[HttpPost]
		public ActionResult Artigval_Duplicate([FromBody]Artigval_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigval_Duplicate",
				ViewName = "Artigval",
				AreaName = "item",
				Location = ACTION_ARTIGVAL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTIGVAL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTIGVAL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTIGVAL]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGVAL.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Artigval_Cancel

		//
		// GET: /Item/Artigval_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTIGVAL]/
		public ActionResult Artigval_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ARTIGVAL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTIGVAL]/

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

				Navigation.SetValue("ForcePrimaryRead_item", "true", true);
			}

			Navigation.ClearValue("item");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Artigval_GitemValItemdesModel : RequestLookupModel
		{
			public Artigval_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artigval_GitemValItemdes
		// POST: /Item/Artigval_GitemValItemdes
		[ActionName("Artigval_GitemValItemdes")]
		public ActionResult Artigval_GitemValItemdes([FromBody] Artigval_GitemValItemdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_gitem")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_gitem");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Artigval_GitemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Artigval_WarehValWarehdesModel : RequestLookupModel
		{
			public Artigval_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artigval_WarehValWarehdes
		// POST: /Item/Artigval_WarehValWarehdes
		[ActionName("Artigval_WarehValWarehdes")]
		public ActionResult Artigval_WarehValWarehdes([FromBody] Artigval_WarehValWarehdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Artigval_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Item/Artigval_SaveEdit
		[HttpPost]
		public ActionResult Artigval_SaveEdit([FromBody] Artigval_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Artigval_SaveEdit",
				ViewName = "Artigval",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTIGVAL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTIGVAL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ArtigvalDocumValidateTickets : RequestDocumValidateTickets
		{
			public Artigval_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArtigval([FromBody] ArtigvalDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
