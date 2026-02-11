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
using GenioMVC.ViewModels.Decom;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DECOM]/

namespace GenioMVC.Controllers
{
	public partial class DecomController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ABATEREQ_CANCEL = new("OBRIGATORIO46267", "Abatereq_Cancel", "Decom") { vueRouteName = "form-ABATEREQ", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ABATEREQ_SHOW = new("OBRIGATORIO46267", "Abatereq_Show", "Decom") { vueRouteName = "form-ABATEREQ", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ABATEREQ_NEW = new("OBRIGATORIO46267", "Abatereq_New", "Decom") { vueRouteName = "form-ABATEREQ", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ABATEREQ_EDIT = new("OBRIGATORIO46267", "Abatereq_Edit", "Decom") { vueRouteName = "form-ABATEREQ", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ABATEREQ_DUPLICATE = new("OBRIGATORIO46267", "Abatereq_Duplicate", "Decom") { vueRouteName = "form-ABATEREQ", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ABATEREQ_DELETE = new("OBRIGATORIO46267", "Abatereq_Delete", "Decom") { vueRouteName = "form-ABATEREQ", mode = "DELETE" };

		#endregion

		#region Abatereq private

		private void FormHistoryLimits_Abatereq()
		{

		}

		#endregion

		#region Abatereq_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ABATEREQ]/

		[HttpPost]
		public ActionResult Abatereq_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Abatereq_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Show_GET",
				AreaName = "decom",
				Location = ACTION_ABATEREQ_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abatereq();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ABATEREQ]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Abatereq_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Abatereq_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_New_GET",
				AreaName = "decom",
				FormName = "ABATEREQ",
				Location = ACTION_ABATEREQ_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Abatereq();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ABATEREQ]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Decom/Abatereq_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_New([FromBody]Abatereq_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_New",
				ViewName = "Abatereq",
				AreaName = "decom",
				Location = ACTION_ABATEREQ_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ABATEREQ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ABATEREQ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ABATEREQ]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Abatereq_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Abatereq_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Edit_GET",
				AreaName = "decom",
				FormName = "ABATEREQ",
				Location = ACTION_ABATEREQ_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abatereq();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ABATEREQ]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Decom/Abatereq_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_Edit([FromBody]Abatereq_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Edit",
				ViewName = "Abatereq",
				AreaName = "decom",
				Location = ACTION_ABATEREQ_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ABATEREQ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ABATEREQ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ABATEREQ]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Abatereq_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Abatereq_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Delete_GET",
				AreaName = "decom",
				FormName = "ABATEREQ",
				Location = ACTION_ABATEREQ_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abatereq();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ABATEREQ]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Decom/Abatereq_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Abatereq_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Delete",
				ViewName = "Abatereq",
				AreaName = "decom",
				Location = ACTION_ABATEREQ_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ABATEREQ]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Abatereq_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ABATEREQ");
		}

		#endregion

		#region Abatereq_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ABATEREQ]/

		[HttpPost]
		public ActionResult Abatereq_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Abatereq_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Duplicate_GET",
				AreaName = "decom",
				FormName = "ABATEREQ",
				Location = ACTION_ABATEREQ_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ABATEREQ]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Decom/Abatereq_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ABATEREQ]/
		[HttpPost]
		public ActionResult Abatereq_Duplicate([FromBody]Abatereq_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_Duplicate",
				ViewName = "Abatereq",
				AreaName = "decom",
				Location = ACTION_ABATEREQ_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ABATEREQ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ABATEREQ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ABATEREQ]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Abatereq_Cancel

		//
		// GET: /Decom/Abatereq_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ABATEREQ]/
		public ActionResult Abatereq_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Decom model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("decom");

// USE /[MANUAL GQT BEFORE_CANCEL ABATEREQ]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ABATEREQ]/

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

				Navigation.SetValue("ForcePrimaryRead_decom", "true", true);
			}

			Navigation.ClearValue("decom");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Decom/Abatereq_SaveEdit
		[HttpPost]
		public ActionResult Abatereq_SaveEdit([FromBody] Abatereq_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Abatereq_SaveEdit",
				ViewName = "Abatereq",
				AreaName = "decom",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ABATEREQ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ABATEREQ]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AbatereqDocumValidateTickets : RequestDocumValidateTickets
		{
			public Abatereq_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAbatereq([FromBody] AbatereqDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
