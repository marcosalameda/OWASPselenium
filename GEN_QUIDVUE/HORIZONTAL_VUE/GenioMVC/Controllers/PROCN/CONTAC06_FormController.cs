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
using GenioMVC.ViewModels.Procn;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROCN]/

namespace GenioMVC.Controllers
{
	public partial class ProcnController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONTAC06_CANCEL = new("CONTACT59247", "Contac06_Cancel", "Procn") { vueRouteName = "form-CONTAC06", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONTAC06_SHOW = new("CONTACT59247", "Contac06_Show", "Procn") { vueRouteName = "form-CONTAC06", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONTAC06_NEW = new("CONTACT59247", "Contac06_New", "Procn") { vueRouteName = "form-CONTAC06", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONTAC06_EDIT = new("CONTACT59247", "Contac06_Edit", "Procn") { vueRouteName = "form-CONTAC06", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONTAC06_DUPLICATE = new("CONTACT59247", "Contac06_Duplicate", "Procn") { vueRouteName = "form-CONTAC06", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONTAC06_DELETE = new("CONTACT59247", "Contac06_Delete", "Procn") { vueRouteName = "form-CONTAC06", mode = "DELETE" };

		#endregion

		#region Contac06 private

		private void FormHistoryLimits_Contac06()
		{

		}

		#endregion

		#region Contac06_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CONTAC06]/

		[HttpPost]
		public ActionResult Contac06_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Show_GET",
				AreaName = "procn",
				Location = ACTION_CONTAC06_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac06();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Contac06_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Contac06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_New_GET",
				AreaName = "procn",
				FormName = "CONTAC06",
				Location = ACTION_CONTAC06_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Contac06();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Procn/Contac06_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_New([FromBody]Contac06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_New",
				ViewName = "Contac06",
				AreaName = "procn",
				Location = ACTION_CONTAC06_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CONTAC06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CONTAC06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Contac06_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Edit_GET",
				AreaName = "procn",
				FormName = "CONTAC06",
				Location = ACTION_CONTAC06_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac06();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Procn/Contac06_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_Edit([FromBody]Contac06_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Edit",
				ViewName = "Contac06",
				AreaName = "procn",
				Location = ACTION_CONTAC06_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CONTAC06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CONTAC06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Contac06_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Delete_GET",
				AreaName = "procn",
				FormName = "CONTAC06",
				Location = ACTION_CONTAC06_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac06();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Procn/Contac06_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac06_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Delete",
				ViewName = "Contac06",
				AreaName = "procn",
				Location = ACTION_CONTAC06_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Contac06_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONTAC06");
		}

		#endregion

		#region Contac06_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CONTAC06]/

		[HttpPost]
		public ActionResult Contac06_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Contac06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Duplicate_GET",
				AreaName = "procn",
				FormName = "CONTAC06",
				Location = ACTION_CONTAC06_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Procn/Contac06_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CONTAC06]/
		[HttpPost]
		public ActionResult Contac06_Duplicate([FromBody]Contac06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac06_Duplicate",
				ViewName = "Contac06",
				AreaName = "procn",
				Location = ACTION_CONTAC06_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CONTAC06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CONTAC06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CONTAC06]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CONTAC06.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Contac06_Cancel

		//
		// GET: /Procn/Contac06_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CONTAC06]/
		public ActionResult Contac06_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Procn(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("procn");

// USE /[MANUAL GQT BEFORE_CANCEL CONTAC06]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CONTAC06]/

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

				Navigation.SetValue("ForcePrimaryRead_procn", "true", true);
			}

			Navigation.ClearValue("procn");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Contac06_PropeValTitleModel : RequestLookupModel
		{
			public Contac06_ViewModel Model { get; set; }
		}

		//
		// GET: /Procn/Contac06_PropeValTitle
		// POST: /Procn/Contac06_PropeValTitle
		[ActionName("Contac06_PropeValTitle")]
		public ActionResult Contac06_PropeValTitle([FromBody] Contac06_PropeValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_prope")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_prope");
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

			Models.Procn parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Contac06_PropeValTitle_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Procn/Contac06_SaveEdit
		[HttpPost]
		public ActionResult Contac06_SaveEdit([FromBody] Contac06_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Contac06_SaveEdit",
				ViewName = "Contac06",
				AreaName = "procn",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CONTAC06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CONTAC06]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Contac06DocumValidateTickets : RequestDocumValidateTickets
		{
			public Contac06_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsContac06([FromBody] Contac06DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
