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
using GenioMVC.ViewModels.Atags;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ATAGS]/

namespace GenioMVC.Controllers
{
	public partial class AtagsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___CANCEL = new("ASSET_TAGS23725", "Equipm__pseuda_tags___Cancel", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___SHOW = new("ASSET_TAGS23725", "Equipm__pseuda_tags___Show", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___NEW = new("ASSET_TAGS23725", "Equipm__pseuda_tags___New", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___EDIT = new("ASSET_TAGS23725", "Equipm__pseuda_tags___Edit", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___DUPLICATE = new("ASSET_TAGS23725", "Equipm__pseuda_tags___Duplicate", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EQUIPM__PSEUDA_TAGS___DELETE = new("ASSET_TAGS23725", "Equipm__pseuda_tags___Delete", "Atags") { vueRouteName = "form-EQUIPM__PSEUDA_TAGS__", mode = "DELETE" };

		#endregion

		#region Equipm__pseuda_tags__ private

		private void FormHistoryLimits_Equipm__pseuda_tags__()
		{

		}

		#endregion

		#region Equipm__pseuda_tags___Show

// USE /[MANUAL GQT CONTROLLER_SHOW EQUIPM__PSEUDA_TAGS__]/

		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm__pseuda_tags___ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Show_GET",
				AreaName = "atags",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm__pseuda_tags__();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Equipm__pseuda_tags___New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Equipm__pseuda_tags___ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___New_GET",
				AreaName = "atags",
				FormName = "EQUIPM__PSEUDA_TAGS__",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Equipm__pseuda_tags__();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Atags/Equipm__pseuda_tags___New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___New([FromBody]Equipm__pseuda_tags___ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___New",
				ViewName = "Equipm__pseuda_tags__",
				AreaName = "atags",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EQUIPM__PSEUDA_TAGS__]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EQUIPM__PSEUDA_TAGS__]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Equipm__pseuda_tags___Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm__pseuda_tags___ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Edit_GET",
				AreaName = "atags",
				FormName = "EQUIPM__PSEUDA_TAGS__",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm__pseuda_tags__();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Atags/Equipm__pseuda_tags___Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Edit([FromBody]Equipm__pseuda_tags___ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Edit",
				ViewName = "Equipm__pseuda_tags__",
				AreaName = "atags",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EQUIPM__PSEUDA_TAGS__]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EQUIPM__PSEUDA_TAGS__]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Equipm__pseuda_tags___Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm__pseuda_tags___ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Delete_GET",
				AreaName = "atags",
				FormName = "EQUIPM__PSEUDA_TAGS__",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equipm__pseuda_tags__();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Atags/Equipm__pseuda_tags___Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Equipm__pseuda_tags___ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Delete",
				ViewName = "Equipm__pseuda_tags__",
				AreaName = "atags",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Equipm__pseuda_tags___Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EQUIPM__PSEUDA_TAGS__");
		}

		#endregion

		#region Equipm__pseuda_tags___Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EQUIPM__PSEUDA_TAGS__]/

		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Equipm__pseuda_tags___ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Duplicate_GET",
				AreaName = "atags",
				FormName = "EQUIPM__PSEUDA_TAGS__",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Atags/Equipm__pseuda_tags___Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EQUIPM__PSEUDA_TAGS__]/
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___Duplicate([FromBody]Equipm__pseuda_tags___ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Equipm__pseuda_tags___Duplicate",
				ViewName = "Equipm__pseuda_tags__",
				AreaName = "atags",
				Location = ACTION_EQUIPM__PSEUDA_TAGS___DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EQUIPM__PSEUDA_TAGS__]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EQUIPM__PSEUDA_TAGS__]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EQUIPM__PSEUDA_TAGS__]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "EQUIPM__PSEUDA_TAGS__.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Equipm__pseuda_tags___Cancel

		//
		// GET: /Atags/Equipm__pseuda_tags___Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EQUIPM__PSEUDA_TAGS__]/
		public ActionResult Equipm__pseuda_tags___Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Atags(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("atags");

// USE /[MANUAL GQT BEFORE_CANCEL EQUIPM__PSEUDA_TAGS__]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EQUIPM__PSEUDA_TAGS__]/

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

				Navigation.SetValue("ForcePrimaryRead_atags", "true", true);
			}

			Navigation.ClearValue("atags");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Atags/Equipm__pseuda_tags___SaveEdit
		[HttpPost]
		public ActionResult Equipm__pseuda_tags___SaveEdit([FromBody] Equipm__pseuda_tags___ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equipm__pseuda_tags___SaveEdit",
				ViewName = "Equipm__pseuda_tags__",
				AreaName = "atags",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EQUIPM__PSEUDA_TAGS__]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EQUIPM__PSEUDA_TAGS__]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Equipm__pseuda_tags__DocumValidateTickets : RequestDocumValidateTickets
		{
			public Equipm__pseuda_tags___ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEquipm__pseuda_tags__([FromBody] Equipm__pseuda_tags__DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
