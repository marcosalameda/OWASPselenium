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
using GenioMVC.ViewModels.C_add;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER C_ADD]/

namespace GenioMVC.Controllers
{
	public partial class C_addController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_C_ADD_CANCEL = new("COUNTRY64133", "C_add_Cancel", "C_add") { vueRouteName = "form-C_ADD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_C_ADD_SHOW = new("COUNTRY64133", "C_add_Show", "C_add") { vueRouteName = "form-C_ADD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_C_ADD_NEW = new("COUNTRY64133", "C_add_New", "C_add") { vueRouteName = "form-C_ADD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_C_ADD_EDIT = new("COUNTRY64133", "C_add_Edit", "C_add") { vueRouteName = "form-C_ADD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_C_ADD_DUPLICATE = new("COUNTRY64133", "C_add_Duplicate", "C_add") { vueRouteName = "form-C_ADD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_C_ADD_DELETE = new("COUNTRY64133", "C_add_Delete", "C_add") { vueRouteName = "form-C_ADD", mode = "DELETE" };

		#endregion

		#region C_add private

		private void FormHistoryLimits_C_add()
		{

		}

		#endregion

		#region C_add_Show

// USE /[MANUAL GQT CONTROLLER_SHOW C_ADD]/

		[HttpPost]
		public ActionResult C_add_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new C_add_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Show_GET",
				AreaName = "c_add",
				Location = ACTION_C_ADD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_C_add();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region C_add_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET C_ADD]/
		[HttpPost]
		public ActionResult C_add_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new C_add_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "C_add_New_GET",
				AreaName = "c_add",
				FormName = "C_ADD",
				Location = ACTION_C_ADD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_C_add();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /C_add/C_add_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST C_ADD]/
		[HttpPost]
		public ActionResult C_add_New([FromBody]C_add_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "C_add_New",
				ViewName = "C_add",
				AreaName = "c_add",
				Location = ACTION_C_ADD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW C_ADD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX C_ADD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region C_add_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET C_ADD]/
		[HttpPost]
		public ActionResult C_add_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new C_add_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Edit_GET",
				AreaName = "c_add",
				FormName = "C_ADD",
				Location = ACTION_C_ADD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_C_add();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /C_add/C_add_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST C_ADD]/
		[HttpPost]
		public ActionResult C_add_Edit([FromBody]C_add_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Edit",
				ViewName = "C_add",
				AreaName = "c_add",
				Location = ACTION_C_ADD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT C_ADD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX C_ADD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region C_add_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET C_ADD]/
		[HttpPost]
		public ActionResult C_add_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new C_add_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Delete_GET",
				AreaName = "c_add",
				FormName = "C_ADD",
				Location = ACTION_C_ADD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_C_add();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /C_add/C_add_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST C_ADD]/
		[HttpPost]
		public ActionResult C_add_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new C_add_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "C_add_Delete",
				ViewName = "C_add",
				AreaName = "c_add",
				Location = ACTION_C_ADD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult C_add_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("C_ADD");
		}

		#endregion

		#region C_add_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET C_ADD]/

		[HttpPost]
		public ActionResult C_add_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new C_add_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Duplicate_GET",
				AreaName = "c_add",
				FormName = "C_ADD",
				Location = ACTION_C_ADD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /C_add/C_add_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST C_ADD]/
		[HttpPost]
		public ActionResult C_add_Duplicate([FromBody]C_add_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "C_add_Duplicate",
				ViewName = "C_add",
				AreaName = "c_add",
				Location = ACTION_C_ADD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE C_ADD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX C_ADD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX C_ADD]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "C_ADD.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region C_add_Cancel

		//
		// GET: /C_add/C_add_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET C_ADD]/
		public ActionResult C_add_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.C_add(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("c_add");

// USE /[MANUAL GQT BEFORE_CANCEL C_ADD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL C_ADD]/

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

				Navigation.SetValue("ForcePrimaryRead_c_add", "true", true);
			}

			Navigation.ClearValue("c_add");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /C_add/C_add_SaveEdit
		[HttpPost]
		public ActionResult C_add_SaveEdit([FromBody] C_add_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "C_add_SaveEdit",
				ViewName = "C_add",
				AreaName = "c_add",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT C_ADD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT C_ADD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class C_addDocumValidateTickets : RequestDocumValidateTickets
		{
			public C_add_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsC_add([FromBody] C_addDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
