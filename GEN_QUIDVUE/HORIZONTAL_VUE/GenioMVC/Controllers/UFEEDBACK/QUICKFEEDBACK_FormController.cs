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

		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_CANCEL = new("CANCELAR49513", "Quickfeedback_Cancel", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_SHOW = new("CONSULTA40695", "Quickfeedback_Show", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_NEW = new("INSERIR43365", "Quickfeedback_New", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "NEW" };
		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_EDIT = new("EDITAR11616", "Quickfeedback_Edit", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_DUPLICATE = new("DUPLICAR09748", "Quickfeedback_Duplicate", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_QUICKFEEDBACK_DELETE = new("APAGAR04097", "Quickfeedback_Delete", "Ufeedback") { vueRouteName = "form-QUICKFEEDBACK", mode = "DELETE" };

		#endregion

		#region Quickfeedback private

		private void FormHistoryLimits_Quickfeedback()
		{

		}

		#endregion

		#region Quickfeedback_Show

// USE /[MANUAL GQT CONTROLLER_SHOW QUICKFEEDBACK]/

		[HttpPost]
		public ActionResult Quickfeedback_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Quickfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Show_GET",
				AreaName = "ufeedback",
				Location = ACTION_QUICKFEEDBACK_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Quickfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Quickfeedback_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Quickfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_New_GET",
				AreaName = "ufeedback",
				FormName = "QUICKFEEDBACK",
				Location = ACTION_QUICKFEEDBACK_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Quickfeedback();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Ufeedback/Quickfeedback_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_New([FromBody]Quickfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_New",
				ViewName = "Quickfeedback",
				AreaName = "ufeedback",
				Location = ACTION_QUICKFEEDBACK_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW QUICKFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX QUICKFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Quickfeedback_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Quickfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Edit_GET",
				AreaName = "ufeedback",
				FormName = "QUICKFEEDBACK",
				Location = ACTION_QUICKFEEDBACK_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Quickfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Quickfeedback_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_Edit([FromBody]Quickfeedback_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Edit",
				ViewName = "Quickfeedback",
				AreaName = "ufeedback",
				Location = ACTION_QUICKFEEDBACK_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT QUICKFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX QUICKFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Quickfeedback_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Quickfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Delete_GET",
				AreaName = "ufeedback",
				FormName = "QUICKFEEDBACK",
				Location = ACTION_QUICKFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Quickfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Quickfeedback_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Quickfeedback_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Delete",
				ViewName = "Quickfeedback",
				AreaName = "ufeedback",
				Location = ACTION_QUICKFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Quickfeedback_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("QUICKFEEDBACK");
		}

		#endregion

		#region Quickfeedback_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET QUICKFEEDBACK]/

		[HttpPost]
		public ActionResult Quickfeedback_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Quickfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Duplicate_GET",
				AreaName = "ufeedback",
				FormName = "QUICKFEEDBACK",
				Location = ACTION_QUICKFEEDBACK_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Ufeedback/Quickfeedback_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST QUICKFEEDBACK]/
		[HttpPost]
		public ActionResult Quickfeedback_Duplicate([FromBody]Quickfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Quickfeedback_Duplicate",
				ViewName = "Quickfeedback",
				AreaName = "ufeedback",
				Location = ACTION_QUICKFEEDBACK_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE QUICKFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX QUICKFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX QUICKFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "QUICKFEEDBACK.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Quickfeedback_Cancel

		//
		// GET: /Ufeedback/Quickfeedback_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET QUICKFEEDBACK]/
		public ActionResult Quickfeedback_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ufeedback(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ufeedback");

// USE /[MANUAL GQT BEFORE_CANCEL QUICKFEEDBACK]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL QUICKFEEDBACK]/

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


		// POST: /Ufeedback/Quickfeedback_SaveEdit
		[HttpPost]
		public ActionResult Quickfeedback_SaveEdit([FromBody] Quickfeedback_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Quickfeedback_SaveEdit",
				ViewName = "Quickfeedback",
				AreaName = "ufeedback",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT QUICKFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT QUICKFEEDBACK]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class QuickfeedbackDocumValidateTickets : RequestDocumValidateTickets
		{
			public Quickfeedback_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsQuickfeedback([FromBody] QuickfeedbackDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
