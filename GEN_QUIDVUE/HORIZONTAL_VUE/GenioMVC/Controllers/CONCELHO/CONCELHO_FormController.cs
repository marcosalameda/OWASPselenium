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
using GenioMVC.ViewModels.Concelho;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CONCELHO]/

namespace GenioMVC.Controllers
{
	public partial class ConcelhoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONCELHO_CANCEL = new("CONCELHO13174", "Concelho_Cancel", "Concelho") { vueRouteName = "form-CONCELHO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONCELHO_SHOW = new("CONCELHO13174", "Concelho_Show", "Concelho") { vueRouteName = "form-CONCELHO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONCELHO_NEW = new("CONCELHO13174", "Concelho_New", "Concelho") { vueRouteName = "form-CONCELHO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONCELHO_EDIT = new("CONCELHO13174", "Concelho_Edit", "Concelho") { vueRouteName = "form-CONCELHO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONCELHO_DUPLICATE = new("CONCELHO13174", "Concelho_Duplicate", "Concelho") { vueRouteName = "form-CONCELHO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONCELHO_DELETE = new("CONCELHO13174", "Concelho_Delete", "Concelho") { vueRouteName = "form-CONCELHO", mode = "DELETE" };

		#endregion

		#region Concelho private

		private void FormHistoryLimits_Concelho()
		{

		}

		#endregion

		#region Concelho_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CONCELHO]/

		[HttpPost]
		public ActionResult Concelho_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Concelho_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Show_GET",
				AreaName = "concelho",
				Location = ACTION_CONCELHO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Concelho();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CONCELHO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Concelho_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Concelho_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Concelho_New_GET",
				AreaName = "concelho",
				FormName = "CONCELHO",
				Location = ACTION_CONCELHO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Concelho();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CONCELHO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Concelho/Concelho_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_New([FromBody]Concelho_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Concelho_New",
				ViewName = "Concelho",
				AreaName = "concelho",
				Location = ACTION_CONCELHO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CONCELHO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CONCELHO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CONCELHO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Concelho_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Concelho_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Edit_GET",
				AreaName = "concelho",
				FormName = "CONCELHO",
				Location = ACTION_CONCELHO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Concelho();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CONCELHO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Concelho/Concelho_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_Edit([FromBody]Concelho_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Edit",
				ViewName = "Concelho",
				AreaName = "concelho",
				Location = ACTION_CONCELHO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CONCELHO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CONCELHO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CONCELHO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Concelho_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Concelho_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Delete_GET",
				AreaName = "concelho",
				FormName = "CONCELHO",
				Location = ACTION_CONCELHO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Concelho();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CONCELHO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Concelho/Concelho_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Concelho_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Concelho_Delete",
				ViewName = "Concelho",
				AreaName = "concelho",
				Location = ACTION_CONCELHO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CONCELHO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Concelho_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONCELHO");
		}

		#endregion

		#region Concelho_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CONCELHO]/

		[HttpPost]
		public ActionResult Concelho_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Concelho_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Duplicate_GET",
				AreaName = "concelho",
				FormName = "CONCELHO",
				Location = ACTION_CONCELHO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CONCELHO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Concelho/Concelho_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CONCELHO]/
		[HttpPost]
		public ActionResult Concelho_Duplicate([FromBody]Concelho_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Concelho_Duplicate",
				ViewName = "Concelho",
				AreaName = "concelho",
				Location = ACTION_CONCELHO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CONCELHO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CONCELHO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CONCELHO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Concelho_Cancel

		//
		// GET: /Concelho/Concelho_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CONCELHO]/
		public ActionResult Concelho_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Concelho model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("concelho");

// USE /[MANUAL GQT BEFORE_CANCEL CONCELHO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CONCELHO]/

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

				Navigation.SetValue("ForcePrimaryRead_concelho", "true", true);
			}

			Navigation.ClearValue("concelho");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Concelho_ValEntidadesModel : RequestLookupModel
		{
			public Concelho_ViewModel Model { get; set; }
		}

		//
		// GET: /Concelho/Concelho_ValEntidades
		// POST: /Concelho/Concelho_ValEntidades
		[ActionName("Concelho_ValEntidades")]
		public ActionResult Concelho_ValEntidades([FromBody] Concelho_ValEntidadesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entidade")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entidade");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Concelho parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Concelho_ValEntidades_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Concelho/Concelho_SaveEdit
		[HttpPost]
		public ActionResult Concelho_SaveEdit([FromBody] Concelho_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Concelho_SaveEdit",
				ViewName = "Concelho",
				AreaName = "concelho",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CONCELHO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CONCELHO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ConcelhoDocumValidateTickets : RequestDocumValidateTickets
		{
			public Concelho_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsConcelho([FromBody] ConcelhoDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
