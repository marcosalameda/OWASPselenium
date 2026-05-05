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
using GenioMVC.ViewModels.Param;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PARAM]/

namespace GenioMVC.Controllers
{
	public partial class ParamController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PARAM_CANCEL = new("PARAMETER41976", "Param_Cancel", "Param") { vueRouteName = "form-PARAM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PARAM_SHOW = new("PARAMETER41976", "Param_Show", "Param") { vueRouteName = "form-PARAM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PARAM_NEW = new("PARAMETER41976", "Param_New", "Param") { vueRouteName = "form-PARAM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PARAM_EDIT = new("PARAMETER41976", "Param_Edit", "Param") { vueRouteName = "form-PARAM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PARAM_DUPLICATE = new("PARAMETER41976", "Param_Duplicate", "Param") { vueRouteName = "form-PARAM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PARAM_DELETE = new("PARAMETER41976", "Param_Delete", "Param") { vueRouteName = "form-PARAM", mode = "DELETE" };

		#endregion

		#region Param private

		private void FormHistoryLimits_Param()
		{

		}

		#endregion

		#region Param_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PARAM]/

		[HttpPost]
		public ActionResult Param_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Show_GET",
				AreaName = "param",
				Location = ACTION_PARAM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Param_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PARAM]/
		[HttpPost]
		public ActionResult Param_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_New_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Param();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Param/Param_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PARAM]/
		[HttpPost]
		public ActionResult Param_New([FromBody]Param_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_New",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Param_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PARAM]/
		[HttpPost]
		public ActionResult Param_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Edit_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Param/Param_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Edit([FromBody]Param_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_Edit",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Param_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PARAM]/
		[HttpPost]
		public ActionResult Param_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Delete_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Param();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Param/Param_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Param_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Param_Delete",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Param_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PARAM");
		}

		#endregion

		#region Param_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PARAM]/

		[HttpPost]
		public ActionResult Param_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Param_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Param_Duplicate_GET",
				AreaName = "param",
				FormName = "PARAM",
				Location = ACTION_PARAM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Param/Param_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PARAM]/
		[HttpPost]
		public ActionResult Param_Duplicate([FromBody]Param_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Param_Duplicate",
				ViewName = "Param",
				AreaName = "param",
				Location = ACTION_PARAM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PARAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PARAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PARAM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PARAM.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Param_Cancel

		//
		// GET: /Param/Param_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PARAM]/
		public ActionResult Param_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Param(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("param");

// USE /[MANUAL GQT BEFORE_CANCEL PARAM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PARAM]/

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

				Navigation.SetValue("ForcePrimaryRead_param", "true", true);
			}

			Navigation.ClearValue("param");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Param_KindeValDesignatModel : RequestLookupModel
		{
			public Param_ViewModel Model { get; set; }
		}

		//
		// GET: /Param/Param_KindeValDesignat
		// POST: /Param/Param_KindeValDesignat
		[ActionName("Param_KindeValDesignat")]
		public ActionResult Param_KindeValDesignat([FromBody] Param_KindeValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
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

			Models.Param parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Param_KindeValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Param/Param_SaveEdit
		[HttpPost]
		public ActionResult Param_SaveEdit([FromBody] Param_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Param_SaveEdit",
				ViewName = "Param",
				AreaName = "param",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PARAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PARAM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ParamDocumValidateTickets : RequestDocumValidateTickets
		{
			public Param_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsParam([FromBody] ParamDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
