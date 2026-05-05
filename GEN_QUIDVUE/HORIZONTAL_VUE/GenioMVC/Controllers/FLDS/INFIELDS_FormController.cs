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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_INFIELDS_CANCEL = new("INPUT_FIELDS51344", "Infields_Cancel", "Flds") { vueRouteName = "form-INFIELDS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_INFIELDS_SHOW = new("INPUT_FIELDS51344", "Infields_Show", "Flds") { vueRouteName = "form-INFIELDS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_INFIELDS_NEW = new("INPUT_FIELDS51344", "Infields_New", "Flds") { vueRouteName = "form-INFIELDS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_INFIELDS_EDIT = new("INPUT_FIELDS51344", "Infields_Edit", "Flds") { vueRouteName = "form-INFIELDS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_INFIELDS_DUPLICATE = new("INPUT_FIELDS51344", "Infields_Duplicate", "Flds") { vueRouteName = "form-INFIELDS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_INFIELDS_DELETE = new("INPUT_FIELDS51344", "Infields_Delete", "Flds") { vueRouteName = "form-INFIELDS", mode = "DELETE" };

		#endregion

		#region Infields private

		private void FormHistoryLimits_Infields()
		{

		}

		#endregion

		#region Infields_Show

// USE /[MANUAL GQT CONTROLLER_SHOW INFIELDS]/

		[HttpPost]
		public ActionResult Infields_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Infields_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Show_GET",
				AreaName = "flds",
				Location = ACTION_INFIELDS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Infields();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Infields_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET INFIELDS]/
		[HttpPost]
		public ActionResult Infields_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Infields_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Infields_New_GET",
				AreaName = "flds",
				FormName = "INFIELDS",
				Location = ACTION_INFIELDS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Infields();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Flds/Infields_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST INFIELDS]/
		[HttpPost]
		public ActionResult Infields_New([FromBody]Infields_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Infields_New",
				ViewName = "Infields",
				AreaName = "flds",
				Location = ACTION_INFIELDS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW INFIELDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX INFIELDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Infields_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET INFIELDS]/
		[HttpPost]
		public ActionResult Infields_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Infields_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Edit_GET",
				AreaName = "flds",
				FormName = "INFIELDS",
				Location = ACTION_INFIELDS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Infields();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Flds/Infields_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST INFIELDS]/
		[HttpPost]
		public ActionResult Infields_Edit([FromBody]Infields_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Edit",
				ViewName = "Infields",
				AreaName = "flds",
				Location = ACTION_INFIELDS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT INFIELDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX INFIELDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Infields_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET INFIELDS]/
		[HttpPost]
		public ActionResult Infields_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Infields_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Delete_GET",
				AreaName = "flds",
				FormName = "INFIELDS",
				Location = ACTION_INFIELDS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Infields();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Flds/Infields_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST INFIELDS]/
		[HttpPost]
		public ActionResult Infields_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Infields_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Infields_Delete",
				ViewName = "Infields",
				AreaName = "flds",
				Location = ACTION_INFIELDS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Infields_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("INFIELDS");
		}

		#endregion

		#region Infields_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET INFIELDS]/

		[HttpPost]
		public ActionResult Infields_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Infields_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Duplicate_GET",
				AreaName = "flds",
				FormName = "INFIELDS",
				Location = ACTION_INFIELDS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Flds/Infields_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST INFIELDS]/
		[HttpPost]
		public ActionResult Infields_Duplicate([FromBody]Infields_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Infields_Duplicate",
				ViewName = "Infields",
				AreaName = "flds",
				Location = ACTION_INFIELDS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE INFIELDS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX INFIELDS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX INFIELDS]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "INFIELDS.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Infields_Cancel

		//
		// GET: /Flds/Infields_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET INFIELDS]/
		public ActionResult Infields_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Flds(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("flds");

// USE /[MANUAL GQT BEFORE_CANCEL INFIELDS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL INFIELDS]/

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

				Navigation.SetValue("ForcePrimaryRead_flds", "true", true);
			}

			Navigation.ClearValue("flds");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Flds/Infields_SaveEdit
		[HttpPost]
		public ActionResult Infields_SaveEdit([FromBody] Infields_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Infields_SaveEdit",
				ViewName = "Infields",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT INFIELDS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT INFIELDS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class InfieldsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Infields_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsInfields([FromBody] InfieldsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
