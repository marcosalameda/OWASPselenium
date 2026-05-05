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
using GenioMVC.ViewModels.Menuc;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MENUC]/

namespace GenioMVC.Controllers
{
	public partial class MenucController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_MENUC_CANCEL = new("MENU_CLASSES17951", "F_menuc_Cancel", "Menuc") { vueRouteName = "form-F_MENUC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_MENUC_SHOW = new("MENU_CLASSES17951", "F_menuc_Show", "Menuc") { vueRouteName = "form-F_MENUC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_MENUC_NEW = new("MENU_CLASSES17951", "F_menuc_New", "Menuc") { vueRouteName = "form-F_MENUC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_MENUC_EDIT = new("MENU_CLASSES17951", "F_menuc_Edit", "Menuc") { vueRouteName = "form-F_MENUC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_MENUC_DUPLICATE = new("MENU_CLASSES17951", "F_menuc_Duplicate", "Menuc") { vueRouteName = "form-F_MENUC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_MENUC_DELETE = new("MENU_CLASSES17951", "F_menuc_Delete", "Menuc") { vueRouteName = "form-F_MENUC", mode = "DELETE" };

		#endregion

		#region F_menuc private

		private void FormHistoryLimits_F_menuc()
		{

		}

		#endregion

		#region F_menuc_Show

// USE /[MANUAL GQT CONTROLLER_SHOW F_MENUC]/

		[HttpPost]
		public ActionResult F_menuc_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuc_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Show_GET",
				AreaName = "menuc",
				Location = ACTION_F_MENUC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuc();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region F_menuc_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_menuc_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_New_GET",
				AreaName = "menuc",
				FormName = "F_MENUC",
				Location = ACTION_F_MENUC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_menuc();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Menuc/F_menuc_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_New([FromBody]F_menuc_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_New",
				ViewName = "F_menuc",
				AreaName = "menuc",
				Location = ACTION_F_MENUC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW F_MENUC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX F_MENUC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region F_menuc_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuc_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Edit_GET",
				AreaName = "menuc",
				FormName = "F_MENUC",
				Location = ACTION_F_MENUC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuc();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Menuc/F_menuc_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_Edit([FromBody]F_menuc_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Edit",
				ViewName = "F_menuc",
				AreaName = "menuc",
				Location = ACTION_F_MENUC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT F_MENUC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX F_MENUC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region F_menuc_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuc_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Delete_GET",
				AreaName = "menuc",
				FormName = "F_MENUC",
				Location = ACTION_F_MENUC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_menuc();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Menuc/F_menuc_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_menuc_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Delete",
				ViewName = "F_menuc",
				AreaName = "menuc",
				Location = ACTION_F_MENUC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult F_menuc_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_MENUC");
		}

		#endregion

		#region F_menuc_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET F_MENUC]/

		[HttpPost]
		public ActionResult F_menuc_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_menuc_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Duplicate_GET",
				AreaName = "menuc",
				FormName = "F_MENUC",
				Location = ACTION_F_MENUC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Menuc/F_menuc_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST F_MENUC]/
		[HttpPost]
		public ActionResult F_menuc_Duplicate([FromBody]F_menuc_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_menuc_Duplicate",
				ViewName = "F_menuc",
				AreaName = "menuc",
				Location = ACTION_F_MENUC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE F_MENUC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX F_MENUC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX F_MENUC]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "F_MENUC.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region F_menuc_Cancel

		//
		// GET: /Menuc/F_menuc_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET F_MENUC]/
		public ActionResult F_menuc_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Menuc(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("menuc");

// USE /[MANUAL GQT BEFORE_CANCEL F_MENUC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL F_MENUC]/

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

				Navigation.SetValue("ForcePrimaryRead_menuc", "true", true);
			}

			Navigation.ClearValue("menuc");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Menuc/F_menuc_SaveEdit
		[HttpPost]
		public ActionResult F_menuc_SaveEdit([FromBody] F_menuc_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "F_menuc_SaveEdit",
				ViewName = "F_menuc",
				AreaName = "menuc",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT F_MENUC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT F_MENUC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_menucDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_menuc_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_menuc([FromBody] F_menucDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
