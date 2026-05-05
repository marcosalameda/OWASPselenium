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
using GenioMVC.ViewModels.Tblb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLB]/

namespace GenioMVC.Controllers
{
	public partial class TblbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TBLB_CANCEL = new("TABLE__BASIC_TYPES_42027", "Tblb_Cancel", "Tblb") { vueRouteName = "form-TBLB", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TBLB_SHOW = new("TABLE__BASIC_TYPES_42027", "Tblb_Show", "Tblb") { vueRouteName = "form-TBLB", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TBLB_NEW = new("TABLE__BASIC_TYPES_42027", "Tblb_New", "Tblb") { vueRouteName = "form-TBLB", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TBLB_EDIT = new("TABLE__BASIC_TYPES_42027", "Tblb_Edit", "Tblb") { vueRouteName = "form-TBLB", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TBLB_DUPLICATE = new("TABLE__BASIC_TYPES_42027", "Tblb_Duplicate", "Tblb") { vueRouteName = "form-TBLB", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TBLB_DELETE = new("TABLE__BASIC_TYPES_42027", "Tblb_Delete", "Tblb") { vueRouteName = "form-TBLB", mode = "DELETE" };

		#endregion

		#region Tblb private

		private void FormHistoryLimits_Tblb()
		{

		}

		#endregion

		#region Tblb_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TBLB]/

		[HttpPost]
		public ActionResult Tblb_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Show_GET",
				AreaName = "tblb",
				Location = ACTION_TBLB_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblb();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Tblb_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TBLB]/
		[HttpPost]
		public ActionResult Tblb_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tblb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_New_GET",
				AreaName = "tblb",
				FormName = "TBLB",
				Location = ACTION_TBLB_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tblb();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Tblb/Tblb_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TBLB]/
		[HttpPost]
		public ActionResult Tblb_New([FromBody]Tblb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_New",
				ViewName = "Tblb",
				AreaName = "tblb",
				Location = ACTION_TBLB_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TBLB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TBLB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Tblb_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TBLB]/
		[HttpPost]
		public ActionResult Tblb_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Edit_GET",
				AreaName = "tblb",
				FormName = "TBLB",
				Location = ACTION_TBLB_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblb();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Tblb/Tblb_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TBLB]/
		[HttpPost]
		public ActionResult Tblb_Edit([FromBody]Tblb_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Edit",
				ViewName = "Tblb",
				AreaName = "tblb",
				Location = ACTION_TBLB_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TBLB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TBLB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Tblb_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TBLB]/
		[HttpPost]
		public ActionResult Tblb_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Delete_GET",
				AreaName = "tblb",
				FormName = "TBLB",
				Location = ACTION_TBLB_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tblb();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Tblb/Tblb_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TBLB]/
		[HttpPost]
		public ActionResult Tblb_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tblb_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Delete",
				ViewName = "Tblb",
				AreaName = "tblb",
				Location = ACTION_TBLB_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Tblb_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TBLB");
		}

		#endregion

		#region Tblb_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TBLB]/

		[HttpPost]
		public ActionResult Tblb_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tblb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Duplicate_GET",
				AreaName = "tblb",
				FormName = "TBLB",
				Location = ACTION_TBLB_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Tblb/Tblb_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TBLB]/
		[HttpPost]
		public ActionResult Tblb_Duplicate([FromBody]Tblb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tblb_Duplicate",
				ViewName = "Tblb",
				AreaName = "tblb",
				Location = ACTION_TBLB_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TBLB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TBLB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TBLB]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "TBLB.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Tblb_Cancel

		//
		// GET: /Tblb/Tblb_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TBLB]/
		public ActionResult Tblb_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tblb(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tblb");

// USE /[MANUAL GQT BEFORE_CANCEL TBLB]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TBLB]/

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

				Navigation.SetValue("ForcePrimaryRead_tblb", "true", true);
			}

			Navigation.ClearValue("tblb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Tblb/Tblb_SaveEdit
		[HttpPost]
		public ActionResult Tblb_SaveEdit([FromBody] Tblb_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tblb_SaveEdit",
				ViewName = "Tblb",
				AreaName = "tblb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TBLB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TBLB]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TblbDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tblb_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTblb([FromBody] TblbDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
