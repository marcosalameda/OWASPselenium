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

		private static readonly NavigationLocation ACTION_AGENT02_CANCEL = new("AGENT00994", "Agent02_Cancel", "Agent") { vueRouteName = "form-AGENT02", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AGENT02_SHOW = new("AGENT00994", "Agent02_Show", "Agent") { vueRouteName = "form-AGENT02", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AGENT02_NEW = new("AGENT00994", "Agent02_New", "Agent") { vueRouteName = "form-AGENT02", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AGENT02_EDIT = new("AGENT00994", "Agent02_Edit", "Agent") { vueRouteName = "form-AGENT02", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AGENT02_DUPLICATE = new("AGENT00994", "Agent02_Duplicate", "Agent") { vueRouteName = "form-AGENT02", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AGENT02_DELETE = new("AGENT00994", "Agent02_Delete", "Agent") { vueRouteName = "form-AGENT02", mode = "DELETE" };

		#endregion

		#region Agent02 private

		private void FormHistoryLimits_Agent02()
		{

		}

		#endregion

		#region Agent02_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AGENT02]/

		[HttpPost]
		public ActionResult Agent02_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Show_GET",
				AreaName = "agent",
				Location = ACTION_AGENT02_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent02();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Agent02_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AGENT02]/
		[HttpPost]
		public ActionResult Agent02_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Agent02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_New_GET",
				AreaName = "agent",
				FormName = "AGENT02",
				Location = ACTION_AGENT02_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Agent02();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Agent/Agent02_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AGENT02]/
		[HttpPost]
		public ActionResult Agent02_New([FromBody]Agent02_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_New",
				ViewName = "Agent02",
				AreaName = "agent",
				Location = ACTION_AGENT02_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AGENT02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AGENT02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Agent02_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AGENT02]/
		[HttpPost]
		public ActionResult Agent02_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Edit_GET",
				AreaName = "agent",
				FormName = "AGENT02",
				Location = ACTION_AGENT02_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent02();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Agent/Agent02_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AGENT02]/
		[HttpPost]
		public ActionResult Agent02_Edit([FromBody]Agent02_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Edit",
				ViewName = "Agent02",
				AreaName = "agent",
				Location = ACTION_AGENT02_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AGENT02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AGENT02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Agent02_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AGENT02]/
		[HttpPost]
		public ActionResult Agent02_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Delete_GET",
				AreaName = "agent",
				FormName = "AGENT02",
				Location = ACTION_AGENT02_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Agent02();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Agent/Agent02_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AGENT02]/
		[HttpPost]
		public ActionResult Agent02_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Agent02_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Delete",
				ViewName = "Agent02",
				AreaName = "agent",
				Location = ACTION_AGENT02_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Agent02_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AGENT02");
		}

		#endregion

		#region Agent02_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AGENT02]/

		[HttpPost]
		public ActionResult Agent02_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Agent02_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Duplicate_GET",
				AreaName = "agent",
				FormName = "AGENT02",
				Location = ACTION_AGENT02_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Agent/Agent02_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AGENT02]/
		[HttpPost]
		public ActionResult Agent02_Duplicate([FromBody]Agent02_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Agent02_Duplicate",
				ViewName = "Agent02",
				AreaName = "agent",
				Location = ACTION_AGENT02_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AGENT02]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AGENT02]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AGENT02]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AGENT02.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Agent02_Cancel

		//
		// GET: /Agent/Agent02_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AGENT02]/
		public ActionResult Agent02_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Agent(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("agent");

// USE /[MANUAL GQT BEFORE_CANCEL AGENT02]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AGENT02]/

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


		// POST: /Agent/Agent02_SaveEdit
		[HttpPost]
		public ActionResult Agent02_SaveEdit([FromBody] Agent02_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Agent02_SaveEdit",
				ViewName = "Agent02",
				AreaName = "agent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AGENT02]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AGENT02]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Agent02DocumValidateTickets : RequestDocumValidateTickets
		{
			public Agent02_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAgent02([FromBody] Agent02DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
