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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_WARE_WS_CANCEL = new("WAREHOUSE51864", "Ware_ws_Cancel", "Wareh") { vueRouteName = "form-WARE_WS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WARE_WS_SHOW = new("WAREHOUSE51864", "Ware_ws_Show", "Wareh") { vueRouteName = "form-WARE_WS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WARE_WS_NEW = new("WAREHOUSE51864", "Ware_ws_New", "Wareh") { vueRouteName = "form-WARE_WS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WARE_WS_EDIT = new("WAREHOUSE51864", "Ware_ws_Edit", "Wareh") { vueRouteName = "form-WARE_WS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WARE_WS_DUPLICATE = new("WAREHOUSE51864", "Ware_ws_Duplicate", "Wareh") { vueRouteName = "form-WARE_WS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WARE_WS_DELETE = new("WAREHOUSE51864", "Ware_ws_Delete", "Wareh") { vueRouteName = "form-WARE_WS", mode = "DELETE" };

		#endregion

		#region Ware_ws private

		private void FormHistoryLimits_Ware_ws()
		{

		}

		#endregion

		#region Ware_ws_Show

// USE /[MANUAL GQT CONTROLLER_SHOW WARE_WS]/

		[HttpPost]
		public ActionResult Ware_ws_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ware_ws_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Show_GET",
				AreaName = "wareh",
				Location = ACTION_WARE_WS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ware_ws();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW WARE_WS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ware_ws_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Ware_ws_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_New_GET",
				AreaName = "wareh",
				FormName = "WARE_WS",
				Location = ACTION_WARE_WS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ware_ws();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW WARE_WS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Ware_ws_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_New([FromBody]Ware_ws_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_New",
				ViewName = "Ware_ws",
				AreaName = "wareh",
				Location = ACTION_WARE_WS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW WARE_WS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX WARE_WS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX WARE_WS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ware_ws_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ware_ws_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Edit_GET",
				AreaName = "wareh",
				FormName = "WARE_WS",
				Location = ACTION_WARE_WS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ware_ws();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT WARE_WS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Ware_ws_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_Edit([FromBody]Ware_ws_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Edit",
				ViewName = "Ware_ws",
				AreaName = "wareh",
				Location = ACTION_WARE_WS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT WARE_WS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX WARE_WS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX WARE_WS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ware_ws_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ware_ws_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Delete_GET",
				AreaName = "wareh",
				FormName = "WARE_WS",
				Location = ACTION_WARE_WS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ware_ws();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE WARE_WS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Ware_ws_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ware_ws_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Delete",
				ViewName = "Ware_ws",
				AreaName = "wareh",
				Location = ACTION_WARE_WS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE WARE_WS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ware_ws_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WARE_WS");
		}

		#endregion

		#region Ware_ws_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET WARE_WS]/

		[HttpPost]
		public ActionResult Ware_ws_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Ware_ws_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Duplicate_GET",
				AreaName = "wareh",
				FormName = "WARE_WS",
				Location = ACTION_WARE_WS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE WARE_WS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Ware_ws_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST WARE_WS]/
		[HttpPost]
		public ActionResult Ware_ws_Duplicate([FromBody]Ware_ws_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_Duplicate",
				ViewName = "Ware_ws",
				AreaName = "wareh",
				Location = ACTION_WARE_WS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE WARE_WS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX WARE_WS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX WARE_WS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ware_ws_Cancel

		//
		// GET: /Wareh/Ware_ws_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET WARE_WS]/
		public ActionResult Ware_ws_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Wareh model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL WARE_WS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL WARE_WS]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Ware_ws_ValXitemModel : RequestLookupModel
		{
			public Ware_ws_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Ware_ws_ValXitem
		// POST: /Wareh/Ware_ws_ValXitem
		[ActionName("Ware_ws_ValXitem")]
		public ActionResult Ware_ws_ValXitem([FromBody] Ware_ws_ValXitemModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Wareh parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Ware_ws_ValXitem_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Wareh/Ware_ws_SaveEdit
		[HttpPost]
		public ActionResult Ware_ws_SaveEdit([FromBody] Ware_ws_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ware_ws_SaveEdit",
				ViewName = "Ware_ws",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT WARE_WS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT WARE_WS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Ware_wsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Ware_ws_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsWare_ws([FromBody] Ware_wsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
