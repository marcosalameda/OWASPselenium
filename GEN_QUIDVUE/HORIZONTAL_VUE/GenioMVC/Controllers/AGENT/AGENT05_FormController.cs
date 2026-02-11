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
using GenioMVC.ViewModels.Agent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER AGENT]/

namespace GenioMVC.Controllers
{
	public partial class AgentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AGENT05_CANCEL = new("AGENT00994", "Agent05_Cancel", "Agent") { vueRouteName = "form-AGENT05", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AGENT05_SHOW = new("AGENT00994", "Agent05_Show", "Agent") { vueRouteName = "form-AGENT05", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AGENT05_NEW = new("AGENT00994", "Agent05_New", "Agent") { vueRouteName = "form-AGENT05", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AGENT05_EDIT = new("AGENT00994", "Agent05_Edit", "Agent") { vueRouteName = "form-AGENT05", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AGENT05_DUPLICATE = new("AGENT00994", "Agent05_Duplicate", "Agent") { vueRouteName = "form-AGENT05", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AGENT05_DELETE = new("AGENT00994", "Agent05_Delete", "Agent") { vueRouteName = "form-AGENT05", mode = "DELETE" };

		#endregion

		#region Agent05 private

		private void FormHistoryLimits_Agent05()
		{

		}

		#endregion

		#region Agent05_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AGENT05]/

		[HttpPost]
		public ActionResult Agent05_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Agent05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Show_GET",
				AreaName = "agent",
				Location = ACTION_AGENT05_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent05();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AGENT05]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Agent05_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AGENT05]/
		[HttpPost]
		public ActionResult Agent05_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Agent05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Agent05_New_GET",
				AreaName = "agent",
				FormName = "AGENT05",
				Location = ACTION_AGENT05_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Agent05();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AGENT05]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Agent/Agent05_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AGENT05]/
		[HttpPost]
		public ActionResult Agent05_New([FromBody]Agent05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Agent05_New",
				ViewName = "Agent05",
				AreaName = "agent",
				Location = ACTION_AGENT05_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AGENT05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AGENT05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AGENT05]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Agent05_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AGENT05]/
		[HttpPost]
		public ActionResult Agent05_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Agent05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Edit_GET",
				AreaName = "agent",
				FormName = "AGENT05",
				Location = ACTION_AGENT05_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent05();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AGENT05]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Agent/Agent05_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AGENT05]/
		[HttpPost]
		public ActionResult Agent05_Edit([FromBody]Agent05_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Edit",
				ViewName = "Agent05",
				AreaName = "agent",
				Location = ACTION_AGENT05_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AGENT05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AGENT05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AGENT05]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Agent05_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AGENT05]/
		[HttpPost]
		public ActionResult Agent05_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Agent05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Delete_GET",
				AreaName = "agent",
				FormName = "AGENT05",
				Location = ACTION_AGENT05_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent05();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AGENT05]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Agent/Agent05_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AGENT05]/
		[HttpPost]
		public ActionResult Agent05_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Agent05_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Agent05_Delete",
				ViewName = "Agent05",
				AreaName = "agent",
				Location = ACTION_AGENT05_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AGENT05]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Agent05_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AGENT05");
		}

		#endregion

		#region Agent05_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AGENT05]/

		[HttpPost]
		public ActionResult Agent05_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Agent05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Duplicate_GET",
				AreaName = "agent",
				FormName = "AGENT05",
				Location = ACTION_AGENT05_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AGENT05]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Agent/Agent05_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AGENT05]/
		[HttpPost]
		public ActionResult Agent05_Duplicate([FromBody]Agent05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Agent05_Duplicate",
				ViewName = "Agent05",
				AreaName = "agent",
				Location = ACTION_AGENT05_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AGENT05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AGENT05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AGENT05]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Agent05_Cancel

		//
		// GET: /Agent/Agent05_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AGENT05]/
		public ActionResult Agent05_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Agent model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("agent");

// USE /[MANUAL GQT BEFORE_CANCEL AGENT05]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AGENT05]/

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

				Navigation.SetValue("ForcePrimaryRead_agent", "true", true);
			}

			Navigation.ClearValue("agent");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Agent/Agent05_SaveEdit
		[HttpPost]
		public ActionResult Agent05_SaveEdit([FromBody] Agent05_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Agent05_SaveEdit",
				ViewName = "Agent05",
				AreaName = "agent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AGENT05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AGENT05]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Agent05DocumValidateTickets : RequestDocumValidateTickets
		{
			public Agent05_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAgent05([FromBody] Agent05DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
