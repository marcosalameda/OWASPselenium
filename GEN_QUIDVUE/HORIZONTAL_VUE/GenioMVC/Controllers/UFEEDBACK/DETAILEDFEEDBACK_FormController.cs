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
using GenioMVC.ViewModels.Ufeedback;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER UFEEDBACK]/

namespace GenioMVC.Controllers
{
	public partial class UfeedbackController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_CANCEL = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_Cancel", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_SHOW = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_Show", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_NEW = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_New", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_EDIT = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_Edit", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_DUPLICATE = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_Duplicate", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DETAILEDFEEDBACK_DELETE = new("ANONYMOUS_FEEDBACK19882", "Detailedfeedback_Delete", "Ufeedback") { vueRouteName = "form-DETAILEDFEEDBACK", mode = "DELETE" };

		#endregion

		#region Detailedfeedback private

		private void FormHistoryLimits_Detailedfeedback()
		{

		}

		#endregion

		#region Detailedfeedback_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DETAILEDFEEDBACK]/

		[HttpPost]
		public ActionResult Detailedfeedback_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Detailedfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Show_GET",
				AreaName = "ufeedback",
				Location = ACTION_DETAILEDFEEDBACK_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Detailedfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Detailedfeedback_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Detailedfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_New_GET",
				AreaName = "ufeedback",
				FormName = "DETAILEDFEEDBACK",
				Location = ACTION_DETAILEDFEEDBACK_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Detailedfeedback();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Ufeedback/Detailedfeedback_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_New([FromBody]Detailedfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_New",
				ViewName = "Detailedfeedback",
				AreaName = "ufeedback",
				Location = ACTION_DETAILEDFEEDBACK_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DETAILEDFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DETAILEDFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Detailedfeedback_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Detailedfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Edit_GET",
				AreaName = "ufeedback",
				FormName = "DETAILEDFEEDBACK",
				Location = ACTION_DETAILEDFEEDBACK_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Detailedfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Detailedfeedback_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_Edit([FromBody]Detailedfeedback_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Edit",
				ViewName = "Detailedfeedback",
				AreaName = "ufeedback",
				Location = ACTION_DETAILEDFEEDBACK_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DETAILEDFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DETAILEDFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Detailedfeedback_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Detailedfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Delete_GET",
				AreaName = "ufeedback",
				FormName = "DETAILEDFEEDBACK",
				Location = ACTION_DETAILEDFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Detailedfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Detailedfeedback_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Detailedfeedback_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Delete",
				ViewName = "Detailedfeedback",
				AreaName = "ufeedback",
				Location = ACTION_DETAILEDFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Detailedfeedback_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DETAILEDFEEDBACK");
		}

		#endregion

		#region Detailedfeedback_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DETAILEDFEEDBACK]/

		[HttpPost]
		public ActionResult Detailedfeedback_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Detailedfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Duplicate_GET",
				AreaName = "ufeedback",
				FormName = "DETAILEDFEEDBACK",
				Location = ACTION_DETAILEDFEEDBACK_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Ufeedback/Detailedfeedback_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DETAILEDFEEDBACK]/
		[HttpPost]
		public ActionResult Detailedfeedback_Duplicate([FromBody]Detailedfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Detailedfeedback_Duplicate",
				ViewName = "Detailedfeedback",
				AreaName = "ufeedback",
				Location = ACTION_DETAILEDFEEDBACK_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DETAILEDFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DETAILEDFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DETAILEDFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "DETAILEDFEEDBACK.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Detailedfeedback_Cancel

		//
		// GET: /Ufeedback/Detailedfeedback_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DETAILEDFEEDBACK]/
		public ActionResult Detailedfeedback_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ufeedback(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ufeedback");

// USE /[MANUAL GQT BEFORE_CANCEL DETAILEDFEEDBACK]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DETAILEDFEEDBACK]/

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

				Navigation.SetValue("ForcePrimaryRead_ufeedback", "true", true);
			}

			Navigation.ClearValue("ufeedback");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Ufeedback/Detailedfeedback_SaveEdit
		[HttpPost]
		public ActionResult Detailedfeedback_SaveEdit([FromBody] Detailedfeedback_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Detailedfeedback_SaveEdit",
				ViewName = "Detailedfeedback",
				AreaName = "ufeedback",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DETAILEDFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DETAILEDFEEDBACK]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DetailedfeedbackDocumValidateTickets : RequestDocumValidateTickets
		{
			public Detailedfeedback_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDetailedfeedback([FromBody] DetailedfeedbackDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
