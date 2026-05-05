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

		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_CANCEL = new("CANCELAR49513", "Usefulfeedback_Cancel", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_SHOW = new("CONSULTA40695", "Usefulfeedback_Show", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_NEW = new("INSERIR43365", "Usefulfeedback_New", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "NEW" };
		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_EDIT = new("EDITAR11616", "Usefulfeedback_Edit", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_DUPLICATE = new("DUPLICAR09748", "Usefulfeedback_Duplicate", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_USEFULFEEDBACK_DELETE = new("APAGAR04097", "Usefulfeedback_Delete", "Ufeedback") { vueRouteName = "form-USEFULFEEDBACK", mode = "DELETE" };

		#endregion

		#region Usefulfeedback private

		private void FormHistoryLimits_Usefulfeedback()
		{

		}

		#endregion

		#region Usefulfeedback_Show

// USE /[MANUAL GQT CONTROLLER_SHOW USEFULFEEDBACK]/

		[HttpPost]
		public ActionResult Usefulfeedback_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Usefulfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Show_GET",
				AreaName = "ufeedback",
				Location = ACTION_USEFULFEEDBACK_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Usefulfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Usefulfeedback_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Usefulfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_New_GET",
				AreaName = "ufeedback",
				FormName = "USEFULFEEDBACK",
				Location = ACTION_USEFULFEEDBACK_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Usefulfeedback();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Ufeedback/Usefulfeedback_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_New([FromBody]Usefulfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_New",
				ViewName = "Usefulfeedback",
				AreaName = "ufeedback",
				Location = ACTION_USEFULFEEDBACK_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW USEFULFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX USEFULFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Usefulfeedback_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Usefulfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Edit_GET",
				AreaName = "ufeedback",
				FormName = "USEFULFEEDBACK",
				Location = ACTION_USEFULFEEDBACK_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Usefulfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Usefulfeedback_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_Edit([FromBody]Usefulfeedback_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Edit",
				ViewName = "Usefulfeedback",
				AreaName = "ufeedback",
				Location = ACTION_USEFULFEEDBACK_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT USEFULFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX USEFULFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Usefulfeedback_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Usefulfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Delete_GET",
				AreaName = "ufeedback",
				FormName = "USEFULFEEDBACK",
				Location = ACTION_USEFULFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Usefulfeedback();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Ufeedback/Usefulfeedback_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Usefulfeedback_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Delete",
				ViewName = "Usefulfeedback",
				AreaName = "ufeedback",
				Location = ACTION_USEFULFEEDBACK_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Usefulfeedback_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("USEFULFEEDBACK");
		}

		#endregion

		#region Usefulfeedback_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET USEFULFEEDBACK]/

		[HttpPost]
		public ActionResult Usefulfeedback_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Usefulfeedback_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Duplicate_GET",
				AreaName = "ufeedback",
				FormName = "USEFULFEEDBACK",
				Location = ACTION_USEFULFEEDBACK_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Ufeedback/Usefulfeedback_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST USEFULFEEDBACK]/
		[HttpPost]
		public ActionResult Usefulfeedback_Duplicate([FromBody]Usefulfeedback_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Usefulfeedback_Duplicate",
				ViewName = "Usefulfeedback",
				AreaName = "ufeedback",
				Location = ACTION_USEFULFEEDBACK_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE USEFULFEEDBACK]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX USEFULFEEDBACK]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX USEFULFEEDBACK]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "USEFULFEEDBACK.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Usefulfeedback_Cancel

		//
		// GET: /Ufeedback/Usefulfeedback_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET USEFULFEEDBACK]/
		public ActionResult Usefulfeedback_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ufeedback(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ufeedback");

// USE /[MANUAL GQT BEFORE_CANCEL USEFULFEEDBACK]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL USEFULFEEDBACK]/

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


		// POST: /Ufeedback/Usefulfeedback_SaveEdit
		[HttpPost]
		public ActionResult Usefulfeedback_SaveEdit([FromBody] Usefulfeedback_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Usefulfeedback_SaveEdit",
				ViewName = "Usefulfeedback",
				AreaName = "ufeedback",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT USEFULFEEDBACK]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT USEFULFEEDBACK]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class UsefulfeedbackDocumValidateTickets : RequestDocumValidateTickets
		{
			public Usefulfeedback_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsUsefulfeedback([FromBody] UsefulfeedbackDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
