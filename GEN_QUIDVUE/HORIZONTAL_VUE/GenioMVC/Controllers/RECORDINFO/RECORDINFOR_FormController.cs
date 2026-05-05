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
using GenioMVC.ViewModels.Recordinfo;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RECORDINFO]/

namespace GenioMVC.Controllers
{
	public partial class RecordinfoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_RECORDINFOR_CANCEL = new("RECORD_INFORMATION_O48675", "Recordinfor_Cancel", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_RECORDINFOR_SHOW = new("RECORD_INFORMATION_O48675", "Recordinfor_Show", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_RECORDINFOR_NEW = new("RECORD_INFORMATION_O48675", "Recordinfor_New", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_RECORDINFOR_EDIT = new("RECORD_INFORMATION_O48675", "Recordinfor_Edit", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_RECORDINFOR_DUPLICATE = new("RECORD_INFORMATION_O48675", "Recordinfor_Duplicate", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_RECORDINFOR_DELETE = new("RECORD_INFORMATION_O48675", "Recordinfor_Delete", "Recordinfo") { vueRouteName = "form-RECORDINFOR", mode = "DELETE" };

		#endregion

		#region Recordinfor private

		private void FormHistoryLimits_Recordinfor()
		{

		}

		#endregion

		#region Recordinfor_Show

// USE /[MANUAL GQT CONTROLLER_SHOW RECORDINFOR]/

		[HttpPost]
		public ActionResult Recordinfor_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recordinfor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Show_GET",
				AreaName = "recordinfo",
				Location = ACTION_RECORDINFOR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recordinfor();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Recordinfor_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Recordinfor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_New_GET",
				AreaName = "recordinfo",
				FormName = "RECORDINFOR",
				Location = ACTION_RECORDINFOR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Recordinfor();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Recordinfo/Recordinfor_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_New([FromBody]Recordinfor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_New",
				ViewName = "Recordinfor",
				AreaName = "recordinfo",
				Location = ACTION_RECORDINFOR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW RECORDINFOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX RECORDINFOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Recordinfor_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recordinfor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Edit_GET",
				AreaName = "recordinfo",
				FormName = "RECORDINFOR",
				Location = ACTION_RECORDINFOR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recordinfor();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Recordinfo/Recordinfor_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_Edit([FromBody]Recordinfor_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Edit",
				ViewName = "Recordinfor",
				AreaName = "recordinfo",
				Location = ACTION_RECORDINFOR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT RECORDINFOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX RECORDINFOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Recordinfor_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recordinfor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Delete_GET",
				AreaName = "recordinfo",
				FormName = "RECORDINFOR",
				Location = ACTION_RECORDINFOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Recordinfor();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Recordinfo/Recordinfor_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Recordinfor_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Delete",
				ViewName = "Recordinfor",
				AreaName = "recordinfo",
				Location = ACTION_RECORDINFOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Recordinfor_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("RECORDINFOR");
		}

		#endregion

		#region Recordinfor_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET RECORDINFOR]/

		[HttpPost]
		public ActionResult Recordinfor_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Recordinfor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Duplicate_GET",
				AreaName = "recordinfo",
				FormName = "RECORDINFOR",
				Location = ACTION_RECORDINFOR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Recordinfo/Recordinfor_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST RECORDINFOR]/
		[HttpPost]
		public ActionResult Recordinfor_Duplicate([FromBody]Recordinfor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Recordinfor_Duplicate",
				ViewName = "Recordinfor",
				AreaName = "recordinfo",
				Location = ACTION_RECORDINFOR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE RECORDINFOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX RECORDINFOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX RECORDINFOR]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "RECORDINFOR.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Recordinfor_Cancel

		//
		// GET: /Recordinfo/Recordinfor_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET RECORDINFOR]/
		public ActionResult Recordinfor_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Recordinfo(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("recordinfo");

// USE /[MANUAL GQT BEFORE_CANCEL RECORDINFOR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL RECORDINFOR]/

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

				Navigation.SetValue("ForcePrimaryRead_recordinfo", "true", true);
			}

			Navigation.ClearValue("recordinfo");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Recordinfo/Recordinfor_SaveEdit
		[HttpPost]
		public ActionResult Recordinfor_SaveEdit([FromBody] Recordinfor_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Recordinfor_SaveEdit",
				ViewName = "Recordinfor",
				AreaName = "recordinfo",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT RECORDINFOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT RECORDINFOR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RecordinforDocumValidateTickets : RequestDocumValidateTickets
		{
			public Recordinfor_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRecordinfor([FromBody] RecordinforDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
