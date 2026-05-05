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
using GenioMVC.ViewModels.Attac;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ATTAC]/

namespace GenioMVC.Controllers
{
	public partial class AttacController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ATTAC_CANCEL = new("ATTACHMENT29376", "Attac_Cancel", "Attac") { vueRouteName = "form-ATTAC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ATTAC_SHOW = new("ATTACHMENT29376", "Attac_Show", "Attac") { vueRouteName = "form-ATTAC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ATTAC_NEW = new("ATTACHMENT29376", "Attac_New", "Attac") { vueRouteName = "form-ATTAC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ATTAC_EDIT = new("ATTACHMENT29376", "Attac_Edit", "Attac") { vueRouteName = "form-ATTAC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ATTAC_DUPLICATE = new("ATTACHMENT29376", "Attac_Duplicate", "Attac") { vueRouteName = "form-ATTAC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ATTAC_DELETE = new("ATTACHMENT29376", "Attac_Delete", "Attac") { vueRouteName = "form-ATTAC", mode = "DELETE" };

		#endregion

		#region Attac private

		private void FormHistoryLimits_Attac()
		{

		}

		#endregion

		#region Attac_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ATTAC]/

		[HttpPost]
		public ActionResult Attac_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Show_GET",
				AreaName = "attac",
				Location = ACTION_ATTAC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Attac_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_New_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Attac/Attac_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_New([FromBody]Attac_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_New",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Attac_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Edit_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Attac/Attac_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Edit([FromBody]Attac_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Edit",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Attac_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ATTAC]/
		[HttpPost]
		public ActionResult Attac_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Delete_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Attac();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Attac/Attac_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Attac_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Attac_Delete",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Attac_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ATTAC");
		}

		#endregion

		#region Attac_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ATTAC]/

		[HttpPost]
		public ActionResult Attac_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Attac_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Duplicate_GET",
				AreaName = "attac",
				FormName = "ATTAC",
				Location = ACTION_ATTAC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Attac/Attac_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ATTAC]/
		[HttpPost]
		public ActionResult Attac_Duplicate([FromBody]Attac_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Attac_Duplicate",
				ViewName = "Attac",
				AreaName = "attac",
				Location = ACTION_ATTAC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ATTAC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ATTAC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ATTAC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "ATTAC.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Attac_Cancel

		//
		// GET: /Attac/Attac_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ATTAC]/
		public ActionResult Attac_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Attac(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("attac");

// USE /[MANUAL GQT BEFORE_CANCEL ATTAC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ATTAC]/

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

				Navigation.SetValue("ForcePrimaryRead_attac", "true", true);
			}

			Navigation.ClearValue("attac");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Attac_AssetValNameModel : RequestLookupModel
		{
			public Attac_ViewModel Model { get; set; }
		}

		//
		// GET: /Attac/Attac_AssetValName
		// POST: /Attac/Attac_AssetValName
		[ActionName("Attac_AssetValName")]
		public ActionResult Attac_AssetValName([FromBody] Attac_AssetValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asset");
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

			Models.Attac parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Attac_AssetValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Attac/Attac_SaveEdit
		[HttpPost]
		public ActionResult Attac_SaveEdit([FromBody] Attac_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Attac_SaveEdit",
				ViewName = "Attac",
				AreaName = "attac",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ATTAC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ATTAC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AttacDocumValidateTickets : RequestDocumValidateTickets
		{
			public Attac_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAttac([FromBody] AttacDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
