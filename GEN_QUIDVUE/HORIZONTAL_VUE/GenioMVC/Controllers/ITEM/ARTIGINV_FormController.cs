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

		private static readonly NavigationLocation ACTION_ARTIGINV_CANCEL = new("ITEM40802", "Artiginv_Cancel", "Item") { vueRouteName = "form-ARTIGINV", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTIGINV_SHOW = new("ITEM40802", "Artiginv_Show", "Item") { vueRouteName = "form-ARTIGINV", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTIGINV_NEW = new("ITEM40802", "Artiginv_New", "Item") { vueRouteName = "form-ARTIGINV", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTIGINV_EDIT = new("ITEM40802", "Artiginv_Edit", "Item") { vueRouteName = "form-ARTIGINV", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTIGINV_DUPLICATE = new("ITEM40802", "Artiginv_Duplicate", "Item") { vueRouteName = "form-ARTIGINV", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTIGINV_DELETE = new("ITEM40802", "Artiginv_Delete", "Item") { vueRouteName = "form-ARTIGINV", mode = "DELETE" };

		#endregion

		#region Artiginv private

		private void FormHistoryLimits_Artiginv()
		{

		}

		#endregion

		#region Artiginv_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTIGINV]/

		[HttpPost]
		public ActionResult Artiginv_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Show_GET",
				AreaName = "item",
				Location = ACTION_ARTIGINV_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Artiginv_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_New_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Item/Artiginv_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_New([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_New",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Artiginv_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Edit_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Item/Artiginv_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Edit([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Edit",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Artiginv_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Delete_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artiginv();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Item/Artiginv_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artiginv_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Delete",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Artiginv_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTIGINV");
		}

		#endregion

		#region Artiginv_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTIGINV]/

		[HttpPost]
		public ActionResult Artiginv_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artiginv_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Duplicate_GET",
				AreaName = "item",
				FormName = "ARTIGINV",
				Location = ACTION_ARTIGINV_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Item/Artiginv_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTIGINV]/
		[HttpPost]
		public ActionResult Artiginv_Duplicate([FromBody]Artiginv_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artiginv_Duplicate",
				ViewName = "Artiginv",
				AreaName = "item",
				Location = ACTION_ARTIGINV_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTIGINV]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTIGINV]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTIGINV]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ARTIGINV.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Artiginv_Cancel

		//
		// GET: /Item/Artiginv_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTIGINV]/
		public ActionResult Artiginv_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ARTIGINV]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTIGINV]/

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


		public class Artiginv_GitemValItemdesModel : RequestLookupModel
		{
			public Artiginv_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artiginv_GitemValItemdes
		// POST: /Item/Artiginv_GitemValItemdes
		[ActionName("Artiginv_GitemValItemdes")]
		public ActionResult Artiginv_GitemValItemdes([FromBody] Artiginv_GitemValItemdesModel requestModel)
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
			Artiginv_GitemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Artiginv_WarehValWarehdesModel : RequestLookupModel
		{
			public Artiginv_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artiginv_WarehValWarehdes
		// POST: /Item/Artiginv_WarehValWarehdes
		[ActionName("Artiginv_WarehValWarehdes")]
		public ActionResult Artiginv_WarehValWarehdes([FromBody] Artiginv_WarehValWarehdesModel requestModel)
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
			Artiginv_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Item/Artiginv_SaveEdit
		[HttpPost]
		public ActionResult Artiginv_SaveEdit([FromBody] Artiginv_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Artiginv_SaveEdit",
				ViewName = "Artiginv",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTIGINV]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTIGINV]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ArtiginvDocumValidateTickets : RequestDocumValidateTickets
		{
			public Artiginv_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArtiginv([FromBody] ArtiginvDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
