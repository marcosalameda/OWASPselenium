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
using GenioMVC.ViewModels.Ctry;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CTRY]/

namespace GenioMVC.Controllers
{
	public partial class CtryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CTRY03_CANCEL = new("COUNTRY64133", "Ctry03_Cancel", "Ctry") { vueRouteName = "form-CTRY03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CTRY03_SHOW = new("COUNTRY64133", "Ctry03_Show", "Ctry") { vueRouteName = "form-CTRY03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CTRY03_NEW = new("COUNTRY64133", "Ctry03_New", "Ctry") { vueRouteName = "form-CTRY03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CTRY03_EDIT = new("COUNTRY64133", "Ctry03_Edit", "Ctry") { vueRouteName = "form-CTRY03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CTRY03_DUPLICATE = new("COUNTRY64133", "Ctry03_Duplicate", "Ctry") { vueRouteName = "form-CTRY03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CTRY03_DELETE = new("COUNTRY64133", "Ctry03_Delete", "Ctry") { vueRouteName = "form-CTRY03", mode = "DELETE" };

		#endregion

		#region Ctry03 private

		private void FormHistoryLimits_Ctry03()
		{

		}

		#endregion

		#region Ctry03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CTRY03]/

		[HttpPost]
		public ActionResult Ctry03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ctry03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Show_GET",
				AreaName = "ctry",
				Location = ACTION_CTRY03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ctry03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CTRY03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ctry03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ctry03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_New_GET",
				AreaName = "ctry",
				FormName = "CTRY03",
				Location = ACTION_CTRY03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ctry03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CTRY03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Ctry/Ctry03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_New([FromBody]Ctry03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_New",
				ViewName = "Ctry03",
				AreaName = "ctry",
				Location = ACTION_CTRY03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CTRY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CTRY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CTRY03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ctry03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ctry03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Edit_GET",
				AreaName = "ctry",
				FormName = "CTRY03",
				Location = ACTION_CTRY03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ctry03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CTRY03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Ctry/Ctry03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_Edit([FromBody]Ctry03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Edit",
				ViewName = "Ctry03",
				AreaName = "ctry",
				Location = ACTION_CTRY03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CTRY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CTRY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CTRY03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ctry03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ctry03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Delete_GET",
				AreaName = "ctry",
				FormName = "CTRY03",
				Location = ACTION_CTRY03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ctry03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CTRY03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Ctry/Ctry03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ctry03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Delete",
				ViewName = "Ctry03",
				AreaName = "ctry",
				Location = ACTION_CTRY03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CTRY03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ctry03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CTRY03");
		}

		#endregion

		#region Ctry03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CTRY03]/

		[HttpPost]
		public ActionResult Ctry03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ctry03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Duplicate_GET",
				AreaName = "ctry",
				FormName = "CTRY03",
				Location = ACTION_CTRY03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CTRY03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Ctry/Ctry03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CTRY03]/
		[HttpPost]
		public ActionResult Ctry03_Duplicate([FromBody]Ctry03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_Duplicate",
				ViewName = "Ctry03",
				AreaName = "ctry",
				Location = ACTION_CTRY03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CTRY03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CTRY03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CTRY03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ctry03_Cancel

		//
		// GET: /Ctry/Ctry03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CTRY03]/
		public ActionResult Ctry03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ctry(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ctry");

// USE /[MANUAL GQT BEFORE_CANCEL CTRY03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CTRY03]/

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

				Navigation.SetValue("ForcePrimaryRead_ctry", "true", true);
			}

			Navigation.ClearValue("ctry");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Ctry/Ctry03_SaveEdit
		[HttpPost]
		public ActionResult Ctry03_SaveEdit([FromBody] Ctry03_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ctry03_SaveEdit",
				ViewName = "Ctry03",
				AreaName = "ctry",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CTRY03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CTRY03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Ctry03DocumValidateTickets : RequestDocumValidateTickets
		{
			public Ctry03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCtry03([FromBody] Ctry03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
