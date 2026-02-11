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
using System.Dynamic;

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
using GenioMVC.ViewModels.Fami1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FAMI1]/

namespace GenioMVC.Controllers
{
	public partial class Fami1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FAMI1_CANCEL = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_Cancel", "Fami1") { vueRouteName = "form-FAMI1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FAMI1_SHOW = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_Show", "Fami1") { vueRouteName = "form-FAMI1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FAMI1_NEW = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_New", "Fami1") { vueRouteName = "form-FAMI1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FAMI1_EDIT = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_Edit", "Fami1") { vueRouteName = "form-FAMI1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FAMI1_DUPLICATE = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_Duplicate", "Fami1") { vueRouteName = "form-FAMI1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FAMI1_DELETE = new("FAMILIA_DE_EQUIPAMEN28756", "Fami1_Delete", "Fami1") { vueRouteName = "form-FAMI1", mode = "DELETE" };

		#endregion

		#region Fami1 private

		private void FormHistoryLimits_Fami1()
		{

		}

		#endregion

		#region Fami1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FAMI1]/

		[HttpPost]
		public ActionResult Fami1_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fami1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Show_GET",
				AreaName = "fami1",
				Location = ACTION_FAMI1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fami1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FAMI1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Fami1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FAMI1]/
		[HttpPost]
		public ActionResult Fami1_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Fami1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fami1_New_GET",
				AreaName = "fami1",
				FormName = "FAMI1",
				Location = ACTION_FAMI1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Fami1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FAMI1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Fami1/Fami1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FAMI1]/
		[HttpPost]
		public ActionResult Fami1_New([FromBody]Fami1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fami1_New",
				ViewName = "Fami1",
				AreaName = "fami1",
				Location = ACTION_FAMI1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FAMI1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FAMI1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FAMI1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Fami1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FAMI1]/
		[HttpPost]
		public ActionResult Fami1_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fami1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Edit_GET",
				AreaName = "fami1",
				FormName = "FAMI1",
				Location = ACTION_FAMI1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fami1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FAMI1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Fami1/Fami1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FAMI1]/
		[HttpPost]
		public ActionResult Fami1_Edit([FromBody]Fami1_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Edit",
				ViewName = "Fami1",
				AreaName = "fami1",
				Location = ACTION_FAMI1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FAMI1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FAMI1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FAMI1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Fami1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FAMI1]/
		[HttpPost]
		public ActionResult Fami1_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fami1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Delete_GET",
				AreaName = "fami1",
				FormName = "FAMI1",
				Location = ACTION_FAMI1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Fami1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FAMI1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Fami1/Fami1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FAMI1]/
		[HttpPost]
		public ActionResult Fami1_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Fami1_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Fami1_Delete",
				ViewName = "Fami1",
				AreaName = "fami1",
				Location = ACTION_FAMI1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FAMI1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Fami1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FAMI1");
		}

		#endregion

		#region Fami1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FAMI1]/

		[HttpPost]
		public ActionResult Fami1_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Fami1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Duplicate_GET",
				AreaName = "fami1",
				FormName = "FAMI1",
				Location = ACTION_FAMI1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FAMI1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Fami1/Fami1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FAMI1]/
		[HttpPost]
		public ActionResult Fami1_Duplicate([FromBody]Fami1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fami1_Duplicate",
				ViewName = "Fami1",
				AreaName = "fami1",
				Location = ACTION_FAMI1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FAMI1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FAMI1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FAMI1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Fami1_Cancel

		//
		// GET: /Fami1/Fami1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FAMI1]/
		public ActionResult Fami1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Fami1 model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("fami1");

// USE /[MANUAL GQT BEFORE_CANCEL FAMI1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FAMI1]/

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

				Navigation.SetValue("ForcePrimaryRead_fami1", "true", true);
			}

			Navigation.ClearValue("fami1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Fami1_ValTiposequModel : RequestLookupModel
		{
			public Fami1_ViewModel Model { get; set; }
		}

		//
		// GET: /Fami1/Fami1_ValTiposequ
		// POST: /Fami1/Fami1_ValTiposequ
		[ActionName("Fami1_ValTiposequ")]
		public ActionResult Fami1_ValTiposequ([FromBody] Fami1_ValTiposequModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpeq1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpeq1");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Fami1 parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Fami1_ValTiposequ_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		[ActionName("Fami1_ValTiposeq1")]
		public ActionResult Fami1_ValTiposeq1([FromBody] RequestLookupModel requestModel, [FromQuery] string partialView)
		{
			var queryParams = requestModel.QueryParams;
			Fami1_ValTiposeq1_ViewModel model = new Fami1_ValTiposeq1_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			CSGenio.framework.StatusMessage permission = model.CheckPermissions(Navigation.CurrentLevel.FormMode);
			if (permission.Status.Equals(CSGenio.framework.Status.E))
				return PermissionError(permission.Message);

			NameValueCollection requestValues = [];
			if (queryParams != null)
				requestValues.AddRange(queryParams);

			model.Load(requestValues);
			return JsonOK(model);
		}

		// POST: /Fami1/Fami1_SaveEdit
		[HttpPost]
		public ActionResult Fami1_SaveEdit([FromBody] Fami1_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Fami1_SaveEdit",
				ViewName = "Fami1",
				AreaName = "fami1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FAMI1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FAMI1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Fami1DocumValidateTickets : RequestDocumValidateTickets
		{
			public Fami1_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFami1([FromBody] Fami1DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
