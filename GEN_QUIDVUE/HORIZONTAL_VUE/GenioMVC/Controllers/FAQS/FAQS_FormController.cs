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
using GenioMVC.ViewModels.Faqs;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FAQS]/

namespace GenioMVC.Controllers
{
	public partial class FaqsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FAQS_CANCEL = new("FAQS53959", "Faqs_Cancel", "Faqs") { vueRouteName = "form-FAQS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FAQS_SHOW = new("FAQS53959", "Faqs_Show", "Faqs") { vueRouteName = "form-FAQS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FAQS_NEW = new("FAQS53959", "Faqs_New", "Faqs") { vueRouteName = "form-FAQS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FAQS_EDIT = new("FAQS53959", "Faqs_Edit", "Faqs") { vueRouteName = "form-FAQS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FAQS_DUPLICATE = new("FAQS53959", "Faqs_Duplicate", "Faqs") { vueRouteName = "form-FAQS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FAQS_DELETE = new("FAQS53959", "Faqs_Delete", "Faqs") { vueRouteName = "form-FAQS", mode = "DELETE" };

		#endregion

		#region Faqs private

		private void FormHistoryLimits_Faqs()
		{

		}

		#endregion

		#region Faqs_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FAQS]/

		[HttpPost]
		public ActionResult Faqs_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Faqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Show_GET",
				AreaName = "faqs",
				Location = ACTION_FAQS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Faqs();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Faqs_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FAQS]/
		[HttpPost]
		public ActionResult Faqs_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Faqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_New_GET",
				AreaName = "faqs",
				FormName = "FAQS",
				Location = ACTION_FAQS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Faqs();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Faqs/Faqs_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FAQS]/
		[HttpPost]
		public ActionResult Faqs_New([FromBody]Faqs_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_New",
				ViewName = "Faqs",
				AreaName = "faqs",
				Location = ACTION_FAQS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Faqs_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FAQS]/
		[HttpPost]
		public ActionResult Faqs_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Faqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Edit_GET",
				AreaName = "faqs",
				FormName = "FAQS",
				Location = ACTION_FAQS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Faqs();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Faqs/Faqs_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FAQS]/
		[HttpPost]
		public ActionResult Faqs_Edit([FromBody]Faqs_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Edit",
				ViewName = "Faqs",
				AreaName = "faqs",
				Location = ACTION_FAQS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Faqs_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FAQS]/
		[HttpPost]
		public ActionResult Faqs_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Faqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Delete_GET",
				AreaName = "faqs",
				FormName = "FAQS",
				Location = ACTION_FAQS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Faqs();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Faqs/Faqs_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FAQS]/
		[HttpPost]
		public ActionResult Faqs_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Faqs_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Delete",
				ViewName = "Faqs",
				AreaName = "faqs",
				Location = ACTION_FAQS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Faqs_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FAQS");
		}

		#endregion

		#region Faqs_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FAQS]/

		[HttpPost]
		public ActionResult Faqs_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Faqs_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Duplicate_GET",
				AreaName = "faqs",
				FormName = "FAQS",
				Location = ACTION_FAQS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Faqs/Faqs_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FAQS]/
		[HttpPost]
		public ActionResult Faqs_Duplicate([FromBody]Faqs_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Faqs_Duplicate",
				ViewName = "Faqs",
				AreaName = "faqs",
				Location = ACTION_FAQS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FAQS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FAQS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FAQS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "FAQS.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Faqs_Cancel

		//
		// GET: /Faqs/Faqs_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FAQS]/
		public ActionResult Faqs_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Faqs(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("faqs");

// USE /[MANUAL GQT BEFORE_CANCEL FAQS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FAQS]/

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

				Navigation.SetValue("ForcePrimaryRead_faqs", "true", true);
			}

			Navigation.ClearValue("faqs");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Faqs/Faqs_SaveEdit
		[HttpPost]
		public ActionResult Faqs_SaveEdit([FromBody] Faqs_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Faqs_SaveEdit",
				ViewName = "Faqs",
				AreaName = "faqs",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FAQS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FAQS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class FaqsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Faqs_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFaqs([FromBody] FaqsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
