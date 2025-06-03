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
using GenioMVC.ViewModels.Agent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER AGENT]/

namespace GenioMVC.Controllers
{
	public partial class AgentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AGENT01_CANCEL = new("AGENT00994", "Agent01_Cancel", "Agent") { vueRouteName = "form-AGENT01", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AGENT01_SHOW = new("AGENT00994", "Agent01_Show", "Agent") { vueRouteName = "form-AGENT01", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AGENT01_NEW = new("AGENT00994", "Agent01_New", "Agent") { vueRouteName = "form-AGENT01", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AGENT01_EDIT = new("AGENT00994", "Agent01_Edit", "Agent") { vueRouteName = "form-AGENT01", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AGENT01_DUPLICATE = new("AGENT00994", "Agent01_Duplicate", "Agent") { vueRouteName = "form-AGENT01", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AGENT01_DELETE = new("AGENT00994", "Agent01_Delete", "Agent") { vueRouteName = "form-AGENT01", mode = "DELETE" };

		#endregion

		#region Agent01 private

		private void FormHistoryLimits_Agent01()
		{

		}

		#endregion

		#region Agent01_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AGENT01]/

		[HttpPost]
		public ActionResult Agent01_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Show_GET",
				AreaName = "agent",
				Location = ACTION_AGENT01_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent01();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AGENT01]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Agent01_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AGENT01]/
		[HttpPost]
		public ActionResult Agent01_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Agent01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_New_GET",
				AreaName = "agent",
				FormName = "AGENT01",
				Location = ACTION_AGENT01_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Agent01();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AGENT01]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Agent/Agent01_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AGENT01]/
		[HttpPost]
		public ActionResult Agent01_New([FromBody]Agent01_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_New",
				ViewName = "Agent01",
				AreaName = "agent",
				Location = ACTION_AGENT01_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AGENT01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AGENT01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AGENT01]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Agent01_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AGENT01]/
		[HttpPost]
		public ActionResult Agent01_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Edit_GET",
				AreaName = "agent",
				FormName = "AGENT01",
				Location = ACTION_AGENT01_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent01();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AGENT01]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Agent/Agent01_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AGENT01]/
		[HttpPost]
		public ActionResult Agent01_Edit([FromBody]Agent01_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Edit",
				ViewName = "Agent01",
				AreaName = "agent",
				Location = ACTION_AGENT01_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AGENT01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AGENT01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AGENT01]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Agent01_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AGENT01]/
		[HttpPost]
		public ActionResult Agent01_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Delete_GET",
				AreaName = "agent",
				FormName = "AGENT01",
				Location = ACTION_AGENT01_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent01();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AGENT01]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Agent/Agent01_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AGENT01]/
		[HttpPost]
		public ActionResult Agent01_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent01_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Delete",
				ViewName = "Agent01",
				AreaName = "agent",
				Location = ACTION_AGENT01_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AGENT01]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Agent01_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AGENT01");
		}

		#endregion

		#region Agent01_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AGENT01]/

		[HttpPost]
		public ActionResult Agent01_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Agent01_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Duplicate_GET",
				AreaName = "agent",
				FormName = "AGENT01",
				Location = ACTION_AGENT01_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AGENT01]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Agent/Agent01_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AGENT01]/
		[HttpPost]
		public ActionResult Agent01_Duplicate([FromBody]Agent01_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_Duplicate",
				ViewName = "Agent01",
				AreaName = "agent",
				Location = ACTION_AGENT01_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AGENT01]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AGENT01]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AGENT01]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Agent01_Cancel

		//
		// GET: /Agent/Agent01_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AGENT01]/
		public ActionResult Agent01_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Agent(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("agent");

// USE /[MANUAL GQT BEFORE_CANCEL AGENT01]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AGENT01]/

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



		// POST: /Agent/Agent01_SaveEdit
		[HttpPost]
		public ActionResult Agent01_SaveEdit([FromBody]Agent01_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent01_SaveEdit",
				ViewName = "Agent01",
				AreaName = "agent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AGENT01]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AGENT01]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
