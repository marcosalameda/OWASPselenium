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
using GenioMVC.ViewModels.Menuit;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MENUIT]/

namespace GenioMVC.Controllers
{
	public partial class MenuitController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_MENUIT_CANCEL = new("MENU_ITEM_TYPES39545", "F_menuit_Cancel", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_MENUIT_SHOW = new("MENU_ITEM_TYPES39545", "F_menuit_Show", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_MENUIT_NEW = new("MENU_ITEM_TYPES39545", "F_menuit_New", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_MENUIT_EDIT = new("MENU_ITEM_TYPES39545", "F_menuit_Edit", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_MENUIT_DUPLICATE = new("MENU_ITEM_TYPES39545", "F_menuit_Duplicate", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_MENUIT_DELETE = new("MENU_ITEM_TYPES39545", "F_menuit_Delete", "Menuit") { vueRouteName = "form-F_MENUIT", mode = "DELETE" };

		#endregion

		#region F_menuit private

		private void FormHistoryLimits_F_menuit()
		{

		}

		#endregion

		#region F_menuit_Show

// USE /[MANUAL GQT CONTROLLER_SHOW F_MENUIT]/

		[HttpPost]
		public ActionResult F_menuit_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Show_GET",
				AreaName = "menuit",
				Location = ACTION_F_MENUIT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuit();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region F_menuit_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_menuit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_New_GET",
				AreaName = "menuit",
				FormName = "F_MENUIT",
				Location = ACTION_F_MENUIT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_menuit();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Menuit/F_menuit_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_New([FromBody]F_menuit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_New",
				ViewName = "F_menuit",
				AreaName = "menuit",
				Location = ACTION_F_MENUIT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW F_MENUIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX F_MENUIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region F_menuit_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Edit_GET",
				AreaName = "menuit",
				FormName = "F_MENUIT",
				Location = ACTION_F_MENUIT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuit();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Menuit/F_menuit_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_Edit([FromBody]F_menuit_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Edit",
				ViewName = "F_menuit",
				AreaName = "menuit",
				Location = ACTION_F_MENUIT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT F_MENUIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX F_MENUIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region F_menuit_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Delete_GET",
				AreaName = "menuit",
				FormName = "F_MENUIT",
				Location = ACTION_F_MENUIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuit();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Menuit/F_menuit_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuit_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Delete",
				ViewName = "F_menuit",
				AreaName = "menuit",
				Location = ACTION_F_MENUIT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult F_menuit_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_MENUIT");
		}

		#endregion

		#region F_menuit_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET F_MENUIT]/

		[HttpPost]
		public ActionResult F_menuit_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_menuit_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Duplicate_GET",
				AreaName = "menuit",
				FormName = "F_MENUIT",
				Location = ACTION_F_MENUIT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Menuit/F_menuit_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST F_MENUIT]/
		[HttpPost]
		public ActionResult F_menuit_Duplicate([FromBody]F_menuit_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuit_Duplicate",
				ViewName = "F_menuit",
				AreaName = "menuit",
				Location = ACTION_F_MENUIT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE F_MENUIT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX F_MENUIT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX F_MENUIT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUIT.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region F_menuit_Cancel

		//
		// GET: /Menuit/F_menuit_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET F_MENUIT]/
		public ActionResult F_menuit_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Menuit(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("menuit");

// USE /[MANUAL GQT BEFORE_CANCEL F_MENUIT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL F_MENUIT]/

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

				Navigation.SetValue("ForcePrimaryRead_menuit", "true", true);
			}

			Navigation.ClearValue("menuit");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_menuit_MenucValMenuclModel : RequestLookupModel
		{
			public F_menuit_ViewModel Model { get; set; }
		}

		//
		// GET: /Menuit/F_menuit_MenucValMenucl
		// POST: /Menuit/F_menuit_MenucValMenucl
		[ActionName("F_menuit_MenucValMenucl")]
		public ActionResult F_menuit_MenucValMenucl([FromBody] F_menuit_MenucValMenuclModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_menuc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_menuc");
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

			Models.Menuit parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			F_menuit_MenucValMenucl_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Menuit/F_menuit_SaveEdit
		[HttpPost]
		public ActionResult F_menuit_SaveEdit([FromBody] F_menuit_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_menuit_SaveEdit",
				ViewName = "F_menuit",
				AreaName = "menuit",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT F_MENUIT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT F_MENUIT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_menuitDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_menuit_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_menuit([FromBody] F_menuitDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
