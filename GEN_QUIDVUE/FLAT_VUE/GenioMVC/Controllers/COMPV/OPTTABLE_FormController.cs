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
using GenioMVC.ViewModels.Compv;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER COMPV]/

namespace GenioMVC.Controllers
{
	public partial class CompvController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_OPTTABLE_CANCEL = new("VARIANTS_OPTIONS40793", "Opttable_Cancel", "Compv") { vueRouteName = "form-OPTTABLE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_OPTTABLE_SHOW = new("VARIANTS_OPTIONS40793", "Opttable_Show", "Compv") { vueRouteName = "form-OPTTABLE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_OPTTABLE_NEW = new("VARIANTS_OPTIONS40793", "Opttable_New", "Compv") { vueRouteName = "form-OPTTABLE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_OPTTABLE_EDIT = new("VARIANTS_OPTIONS40793", "Opttable_Edit", "Compv") { vueRouteName = "form-OPTTABLE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_OPTTABLE_DUPLICATE = new("VARIANTS_OPTIONS40793", "Opttable_Duplicate", "Compv") { vueRouteName = "form-OPTTABLE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_OPTTABLE_DELETE = new("VARIANTS_OPTIONS40793", "Opttable_Delete", "Compv") { vueRouteName = "form-OPTTABLE", mode = "DELETE" };

		#endregion

		#region Opttable private

		private void FormHistoryLimits_Opttable()
		{

		}

		#endregion

		#region Opttable_Show

// USE /[MANUAL GQT CONTROLLER_SHOW OPTTABLE]/

		[HttpPost]
		public ActionResult Opttable_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Opttable_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Show_GET",
				AreaName = "compv",
				Location = ACTION_OPTTABLE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Opttable();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW OPTTABLE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Opttable_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Opttable_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Opttable_New_GET",
				AreaName = "compv",
				FormName = "OPTTABLE",
				Location = ACTION_OPTTABLE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Opttable();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW OPTTABLE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Compv/Opttable_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_New([FromBody]Opttable_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Opttable_New",
				ViewName = "Opttable",
				AreaName = "compv",
				Location = ACTION_OPTTABLE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW OPTTABLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX OPTTABLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX OPTTABLE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Opttable_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Opttable_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Edit_GET",
				AreaName = "compv",
				FormName = "OPTTABLE",
				Location = ACTION_OPTTABLE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Opttable();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT OPTTABLE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Compv/Opttable_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_Edit([FromBody]Opttable_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Edit",
				ViewName = "Opttable",
				AreaName = "compv",
				Location = ACTION_OPTTABLE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT OPTTABLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX OPTTABLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX OPTTABLE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Opttable_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Opttable_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Delete_GET",
				AreaName = "compv",
				FormName = "OPTTABLE",
				Location = ACTION_OPTTABLE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Opttable();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE OPTTABLE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Compv/Opttable_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Opttable_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Opttable_Delete",
				ViewName = "Opttable",
				AreaName = "compv",
				Location = ACTION_OPTTABLE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE OPTTABLE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Opttable_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("OPTTABLE");
		}

		#endregion

		#region Opttable_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET OPTTABLE]/

		[HttpPost]
		public ActionResult Opttable_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Opttable_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Duplicate_GET",
				AreaName = "compv",
				FormName = "OPTTABLE",
				Location = ACTION_OPTTABLE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE OPTTABLE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Compv/Opttable_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST OPTTABLE]/
		[HttpPost]
		public ActionResult Opttable_Duplicate([FromBody]Opttable_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Opttable_Duplicate",
				ViewName = "Opttable",
				AreaName = "compv",
				Location = ACTION_OPTTABLE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE OPTTABLE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX OPTTABLE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX OPTTABLE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Opttable_Cancel

		//
		// GET: /Compv/Opttable_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET OPTTABLE]/
		public ActionResult Opttable_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Compv model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("compv");

// USE /[MANUAL GQT BEFORE_CANCEL OPTTABLE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL OPTTABLE]/

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

				Navigation.SetValue("ForcePrimaryRead_compv", "true", true);
			}

			Navigation.ClearValue("compv");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Compv/Opttable_SaveEdit
		[HttpPost]
		public ActionResult Opttable_SaveEdit([FromBody] Opttable_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Opttable_SaveEdit",
				ViewName = "Opttable",
				AreaName = "compv",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT OPTTABLE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT OPTTABLE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class OpttableDocumValidateTickets : RequestDocumValidateTickets
		{
			public Opttable_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsOpttable([FromBody] OpttableDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
