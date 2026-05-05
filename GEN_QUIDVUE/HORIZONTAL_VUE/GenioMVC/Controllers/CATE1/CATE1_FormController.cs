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
using GenioMVC.ViewModels.Cate1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CATE1]/

namespace GenioMVC.Controllers
{
	public partial class Cate1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CATE1_CANCEL = new("PROFESSIONAL_CATEGOR16809", "Cate1_Cancel", "Cate1") { vueRouteName = "form-CATE1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CATE1_SHOW = new("PROFESSIONAL_CATEGOR16809", "Cate1_Show", "Cate1") { vueRouteName = "form-CATE1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CATE1_NEW = new("PROFESSIONAL_CATEGOR16809", "Cate1_New", "Cate1") { vueRouteName = "form-CATE1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CATE1_EDIT = new("PROFESSIONAL_CATEGOR16809", "Cate1_Edit", "Cate1") { vueRouteName = "form-CATE1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CATE1_DUPLICATE = new("PROFESSIONAL_CATEGOR16809", "Cate1_Duplicate", "Cate1") { vueRouteName = "form-CATE1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CATE1_DELETE = new("PROFESSIONAL_CATEGOR16809", "Cate1_Delete", "Cate1") { vueRouteName = "form-CATE1", mode = "DELETE" };

		#endregion

		#region Cate1 private

		private void FormHistoryLimits_Cate1()
		{

		}

		#endregion

		#region Cate1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CATE1]/

		[HttpPost]
		public ActionResult Cate1_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Show_GET",
				AreaName = "cate1",
				Location = ACTION_CATE1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Cate1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_New_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Cate1/Cate1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_New([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_New",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Cate1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Edit_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Cate1/Cate1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Edit([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Edit",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Cate1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CATE1]/
		[HttpPost]
		public ActionResult Cate1_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Delete_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Cate1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Cate1/Cate1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Cate1_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Delete",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Cate1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CATE1");
		}

		#endregion

		#region Cate1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CATE1]/

		[HttpPost]
		public ActionResult Cate1_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Cate1_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Duplicate_GET",
				AreaName = "cate1",
				FormName = "CATE1",
				Location = ACTION_CATE1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Cate1/Cate1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CATE1]/
		[HttpPost]
		public ActionResult Cate1_Duplicate([FromBody]Cate1_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Cate1_Duplicate",
				ViewName = "Cate1",
				AreaName = "cate1",
				Location = ACTION_CATE1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CATE1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CATE1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CATE1]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "CATE1.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Cate1_Cancel

		//
		// GET: /Cate1/Cate1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CATE1]/
		public ActionResult Cate1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cate1(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cate1");

// USE /[MANUAL GQT BEFORE_CANCEL CATE1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CATE1]/

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

				Navigation.SetValue("ForcePrimaryRead_cate1", "true", true);
			}

			Navigation.ClearValue("cate1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Cate1/Cate1_SaveEdit
		[HttpPost]
		public ActionResult Cate1_SaveEdit([FromBody] Cate1_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Cate1_SaveEdit",
				ViewName = "Cate1",
				AreaName = "cate1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CATE1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CATE1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Cate1DocumValidateTickets : RequestDocumValidateTickets
		{
			public Cate1_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCate1([FromBody] Cate1DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
