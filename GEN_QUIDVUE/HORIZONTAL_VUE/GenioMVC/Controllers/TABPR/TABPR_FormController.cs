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
using GenioMVC.ViewModels.Tabpr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TABPR]/

namespace GenioMVC.Controllers
{
	public partial class TabprController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TABPR_CANCEL = new("TABLE_PRICE14309", "Tabpr_Cancel", "Tabpr") { vueRouteName = "form-TABPR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TABPR_SHOW = new("TABLE_PRICE14309", "Tabpr_Show", "Tabpr") { vueRouteName = "form-TABPR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TABPR_NEW = new("TABLE_PRICE14309", "Tabpr_New", "Tabpr") { vueRouteName = "form-TABPR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TABPR_EDIT = new("TABLE_PRICE14309", "Tabpr_Edit", "Tabpr") { vueRouteName = "form-TABPR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TABPR_DUPLICATE = new("TABLE_PRICE14309", "Tabpr_Duplicate", "Tabpr") { vueRouteName = "form-TABPR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TABPR_DELETE = new("TABLE_PRICE14309", "Tabpr_Delete", "Tabpr") { vueRouteName = "form-TABPR", mode = "DELETE" };

		#endregion

		#region Tabpr private

		private void FormHistoryLimits_Tabpr()
		{

		}

		#endregion

		#region Tabpr_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TABPR]/

		[HttpPost]
		public ActionResult Tabpr_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tabpr_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Show_GET",
				AreaName = "tabpr",
				Location = ACTION_TABPR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tabpr();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TABPR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tabpr_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TABPR]/
		[HttpPost]
		public ActionResult Tabpr_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Tabpr_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_New_GET",
				AreaName = "tabpr",
				FormName = "TABPR",
				Location = ACTION_TABPR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tabpr();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TABPR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tabpr/Tabpr_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TABPR]/
		[HttpPost]
		public ActionResult Tabpr_New([FromBody]Tabpr_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_New",
				ViewName = "Tabpr",
				AreaName = "tabpr",
				Location = ACTION_TABPR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TABPR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TABPR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TABPR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tabpr_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TABPR]/
		[HttpPost]
		public ActionResult Tabpr_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tabpr_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Edit_GET",
				AreaName = "tabpr",
				FormName = "TABPR",
				Location = ACTION_TABPR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tabpr();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TABPR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tabpr/Tabpr_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TABPR]/
		[HttpPost]
		public ActionResult Tabpr_Edit([FromBody]Tabpr_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Edit",
				ViewName = "Tabpr",
				AreaName = "tabpr",
				Location = ACTION_TABPR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TABPR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TABPR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TABPR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tabpr_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TABPR]/
		[HttpPost]
		public ActionResult Tabpr_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tabpr_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Delete_GET",
				AreaName = "tabpr",
				FormName = "TABPR",
				Location = ACTION_TABPR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tabpr();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TABPR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tabpr/Tabpr_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TABPR]/
		[HttpPost]
		public ActionResult Tabpr_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tabpr_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Delete",
				ViewName = "Tabpr",
				AreaName = "tabpr",
				Location = ACTION_TABPR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TABPR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tabpr_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TABPR");
		}

		#endregion

		#region Tabpr_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TABPR]/

		[HttpPost]
		public ActionResult Tabpr_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Tabpr_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Duplicate_GET",
				AreaName = "tabpr",
				FormName = "TABPR",
				Location = ACTION_TABPR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TABPR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tabpr/Tabpr_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TABPR]/
		[HttpPost]
		public ActionResult Tabpr_Duplicate([FromBody]Tabpr_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_Duplicate",
				ViewName = "Tabpr",
				AreaName = "tabpr",
				Location = ACTION_TABPR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TABPR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TABPR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TABPR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tabpr_Cancel

		//
		// GET: /Tabpr/Tabpr_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TABPR]/
		public ActionResult Tabpr_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Tabpr model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tabpr");

// USE /[MANUAL GQT BEFORE_CANCEL TABPR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TABPR]/

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

				Navigation.SetValue("ForcePrimaryRead_tabpr", "true", true);
			}

			Navigation.ClearValue("tabpr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tabpr_TpequValTipoequiModel : RequestLookupModel
		{
			public Tabpr_ViewModel Model { get; set; }
		}

		//
		// GET: /Tabpr/Tabpr_TpequValTipoequi
		// POST: /Tabpr/Tabpr_TpequValTipoequi
		[ActionName("Tabpr_TpequValTipoequi")]
		public ActionResult Tabpr_TpequValTipoequi([FromBody] Tabpr_TpequValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Tabpr parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tabpr_TpequValTipoequi_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tabpr/Tabpr_SaveEdit
		[HttpPost]
		public ActionResult Tabpr_SaveEdit([FromBody] Tabpr_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tabpr_SaveEdit",
				ViewName = "Tabpr",
				AreaName = "tabpr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TABPR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TABPR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TabprDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tabpr_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTabpr([FromBody] TabprDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
