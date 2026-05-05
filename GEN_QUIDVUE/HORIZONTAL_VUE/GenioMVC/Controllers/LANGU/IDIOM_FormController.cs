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
using GenioMVC.ViewModels.Langu;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LANGU]/

namespace GenioMVC.Controllers
{
	public partial class LanguController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_IDIOM_CANCEL = new("IDIOMA44057", "Idiom_Cancel", "Langu") { vueRouteName = "form-IDIOM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_IDIOM_SHOW = new("IDIOMA44057", "Idiom_Show", "Langu") { vueRouteName = "form-IDIOM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_IDIOM_NEW = new("IDIOMA44057", "Idiom_New", "Langu") { vueRouteName = "form-IDIOM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_IDIOM_EDIT = new("IDIOMA44057", "Idiom_Edit", "Langu") { vueRouteName = "form-IDIOM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_IDIOM_DUPLICATE = new("IDIOMA44057", "Idiom_Duplicate", "Langu") { vueRouteName = "form-IDIOM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_IDIOM_DELETE = new("IDIOMA44057", "Idiom_Delete", "Langu") { vueRouteName = "form-IDIOM", mode = "DELETE" };

		#endregion

		#region Idiom private

		private void FormHistoryLimits_Idiom()
		{

		}

		#endregion

		#region Idiom_Show

// USE /[MANUAL GQT CONTROLLER_SHOW IDIOM]/

		[HttpPost]
		public ActionResult Idiom_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Idiom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Show_GET",
				AreaName = "langu",
				Location = ACTION_IDIOM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Idiom();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Idiom_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET IDIOM]/
		[HttpPost]
		public ActionResult Idiom_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Idiom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_New_GET",
				AreaName = "langu",
				FormName = "IDIOM",
				Location = ACTION_IDIOM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Idiom();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Langu/Idiom_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST IDIOM]/
		[HttpPost]
		public ActionResult Idiom_New([FromBody]Idiom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_New",
				ViewName = "Idiom",
				AreaName = "langu",
				Location = ACTION_IDIOM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW IDIOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX IDIOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Idiom_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET IDIOM]/
		[HttpPost]
		public ActionResult Idiom_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Idiom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Edit_GET",
				AreaName = "langu",
				FormName = "IDIOM",
				Location = ACTION_IDIOM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Idiom();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Langu/Idiom_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST IDIOM]/
		[HttpPost]
		public ActionResult Idiom_Edit([FromBody]Idiom_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Edit",
				ViewName = "Idiom",
				AreaName = "langu",
				Location = ACTION_IDIOM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT IDIOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX IDIOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Idiom_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET IDIOM]/
		[HttpPost]
		public ActionResult Idiom_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Idiom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Delete_GET",
				AreaName = "langu",
				FormName = "IDIOM",
				Location = ACTION_IDIOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Idiom();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Langu/Idiom_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST IDIOM]/
		[HttpPost]
		public ActionResult Idiom_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Idiom_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Delete",
				ViewName = "Idiom",
				AreaName = "langu",
				Location = ACTION_IDIOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Idiom_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("IDIOM");
		}

		#endregion

		#region Idiom_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET IDIOM]/

		[HttpPost]
		public ActionResult Idiom_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Idiom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Duplicate_GET",
				AreaName = "langu",
				FormName = "IDIOM",
				Location = ACTION_IDIOM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Langu/Idiom_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST IDIOM]/
		[HttpPost]
		public ActionResult Idiom_Duplicate([FromBody]Idiom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Idiom_Duplicate",
				ViewName = "Idiom",
				AreaName = "langu",
				Location = ACTION_IDIOM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE IDIOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX IDIOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX IDIOM]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "IDIOM.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Idiom_Cancel

		//
		// GET: /Langu/Idiom_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET IDIOM]/
		public ActionResult Idiom_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Langu(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("langu");

// USE /[MANUAL GQT BEFORE_CANCEL IDIOM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL IDIOM]/

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

				Navigation.SetValue("ForcePrimaryRead_langu", "true", true);
			}

			Navigation.ClearValue("langu");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Langu/Idiom_SaveEdit
		[HttpPost]
		public ActionResult Idiom_SaveEdit([FromBody] Idiom_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Idiom_SaveEdit",
				ViewName = "Idiom",
				AreaName = "langu",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT IDIOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT IDIOM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class IdiomDocumValidateTickets : RequestDocumValidateTickets
		{
			public Idiom_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsIdiom([FromBody] IdiomDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
