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
using GenioMVC.ViewModels.Authenticatopt;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER AUTHENTICATOPT]/

namespace GenioMVC.Controllers
{
	public partial class AuthenticatoptController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AUTHENTCOPT_CANCEL = new("AUTHENTICATION__AUTH56640", "Authentcopt_Cancel", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AUTHENTCOPT_SHOW = new("AUTHENTICATION__AUTH56640", "Authentcopt_Show", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AUTHENTCOPT_NEW = new("AUTHENTICATION__AUTH56640", "Authentcopt_New", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AUTHENTCOPT_EDIT = new("AUTHENTICATION__AUTH56640", "Authentcopt_Edit", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AUTHENTCOPT_DUPLICATE = new("AUTHENTICATION__AUTH56640", "Authentcopt_Duplicate", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AUTHENTCOPT_DELETE = new("AUTHENTICATION__AUTH56640", "Authentcopt_Delete", "Authenticatopt") { vueRouteName = "form-AUTHENTCOPT", mode = "DELETE" };

		#endregion

		#region Authentcopt private

		private void FormHistoryLimits_Authentcopt()
		{

		}

		#endregion

		#region Authentcopt_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AUTHENTCOPT]/

		[HttpPost]
		public ActionResult Authentcopt_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authentcopt_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Show_GET",
				AreaName = "authenticatopt",
				Location = ACTION_AUTHENTCOPT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authentcopt();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Authentcopt_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Authentcopt_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_New_GET",
				AreaName = "authenticatopt",
				FormName = "AUTHENTCOPT",
				Location = ACTION_AUTHENTCOPT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Authentcopt();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Authenticatopt/Authentcopt_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_New([FromBody]Authentcopt_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_New",
				ViewName = "Authentcopt",
				AreaName = "authenticatopt",
				Location = ACTION_AUTHENTCOPT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AUTHENTCOPT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AUTHENTCOPT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Authentcopt_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authentcopt_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Edit_GET",
				AreaName = "authenticatopt",
				FormName = "AUTHENTCOPT",
				Location = ACTION_AUTHENTCOPT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authentcopt();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Authenticatopt/Authentcopt_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_Edit([FromBody]Authentcopt_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Edit",
				ViewName = "Authentcopt",
				AreaName = "authenticatopt",
				Location = ACTION_AUTHENTCOPT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AUTHENTCOPT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AUTHENTCOPT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Authentcopt_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authentcopt_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Delete_GET",
				AreaName = "authenticatopt",
				FormName = "AUTHENTCOPT",
				Location = ACTION_AUTHENTCOPT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authentcopt();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Authenticatopt/Authentcopt_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authentcopt_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Delete",
				ViewName = "Authentcopt",
				AreaName = "authenticatopt",
				Location = ACTION_AUTHENTCOPT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Authentcopt_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AUTHENTCOPT");
		}

		#endregion

		#region Authentcopt_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AUTHENTCOPT]/

		[HttpPost]
		public ActionResult Authentcopt_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Authentcopt_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Duplicate_GET",
				AreaName = "authenticatopt",
				FormName = "AUTHENTCOPT",
				Location = ACTION_AUTHENTCOPT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Authenticatopt/Authentcopt_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AUTHENTCOPT]/
		[HttpPost]
		public ActionResult Authentcopt_Duplicate([FromBody]Authentcopt_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authentcopt_Duplicate",
				ViewName = "Authentcopt",
				AreaName = "authenticatopt",
				Location = ACTION_AUTHENTCOPT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AUTHENTCOPT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AUTHENTCOPT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AUTHENTCOPT]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "AUTHENTCOPT.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Authentcopt_Cancel

		//
		// GET: /Authenticatopt/Authentcopt_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AUTHENTCOPT]/
		public ActionResult Authentcopt_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Authenticatopt(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("authenticatopt");

// USE /[MANUAL GQT BEFORE_CANCEL AUTHENTCOPT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AUTHENTCOPT]/

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

				Navigation.SetValue("ForcePrimaryRead_authenticatopt", "true", true);
			}

			Navigation.ClearValue("authenticatopt");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Authenticatopt/Authentcopt_SaveEdit
		[HttpPost]
		public ActionResult Authentcopt_SaveEdit([FromBody] Authentcopt_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Authentcopt_SaveEdit",
				ViewName = "Authentcopt",
				AreaName = "authenticatopt",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AUTHENTCOPT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AUTHENTCOPT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AuthentcoptDocumValidateTickets : RequestDocumValidateTickets
		{
			public Authentcopt_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAuthentcopt([FromBody] AuthentcoptDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
