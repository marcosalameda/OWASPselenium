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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_BTNSFORM_CANCEL = new("BUTTONS20612", "Btnsform_Cancel", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_BTNSFORM_SHOW = new("BUTTONS20612", "Btnsform_Show", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_BTNSFORM_NEW = new("BUTTONS20612", "Btnsform_New", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_BTNSFORM_EDIT = new("BUTTONS20612", "Btnsform_Edit", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_BTNSFORM_DUPLICATE = new("BUTTONS20612", "Btnsform_Duplicate", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_BTNSFORM_DELETE = new("BUTTONS20612", "Btnsform_Delete", "Wareh") { vueRouteName = "form-BTNSFORM", mode = "DELETE" };

		#endregion

		#region Btnsform private

		private void FormHistoryLimits_Btnsform()
		{

		}

		#endregion

		#region Btnsform_Show

// USE /[MANUAL GQT CONTROLLER_SHOW BTNSFORM]/

		[HttpPost]
		public ActionResult Btnsform_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Btnsform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Show_GET",
				AreaName = "wareh",
				Location = ACTION_BTNSFORM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Btnsform();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW BTNSFORM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Btnsform_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Btnsform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_New_GET",
				AreaName = "wareh",
				FormName = "BTNSFORM",
				Location = ACTION_BTNSFORM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Btnsform();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW BTNSFORM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Btnsform_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_New([FromBody]Btnsform_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_New",
				ViewName = "Btnsform",
				AreaName = "wareh",
				Location = ACTION_BTNSFORM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW BTNSFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX BTNSFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX BTNSFORM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Btnsform_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Btnsform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Edit_GET",
				AreaName = "wareh",
				FormName = "BTNSFORM",
				Location = ACTION_BTNSFORM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Btnsform();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT BTNSFORM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Btnsform_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_Edit([FromBody]Btnsform_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Edit",
				ViewName = "Btnsform",
				AreaName = "wareh",
				Location = ACTION_BTNSFORM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT BTNSFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX BTNSFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX BTNSFORM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Btnsform_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Btnsform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Delete_GET",
				AreaName = "wareh",
				FormName = "BTNSFORM",
				Location = ACTION_BTNSFORM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Btnsform();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE BTNSFORM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Btnsform_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Btnsform_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Delete",
				ViewName = "Btnsform",
				AreaName = "wareh",
				Location = ACTION_BTNSFORM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE BTNSFORM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Btnsform_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("BTNSFORM");
		}

		#endregion

		#region Btnsform_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET BTNSFORM]/

		[HttpPost]
		public ActionResult Btnsform_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Btnsform_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Duplicate_GET",
				AreaName = "wareh",
				FormName = "BTNSFORM",
				Location = ACTION_BTNSFORM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE BTNSFORM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Btnsform_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST BTNSFORM]/
		[HttpPost]
		public ActionResult Btnsform_Duplicate([FromBody]Btnsform_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Btnsform_Duplicate",
				ViewName = "Btnsform",
				AreaName = "wareh",
				Location = ACTION_BTNSFORM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE BTNSFORM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX BTNSFORM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX BTNSFORM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Btnsform_Cancel

		//
		// GET: /Wareh/Btnsform_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET BTNSFORM]/
		public ActionResult Btnsform_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wareh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL BTNSFORM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL BTNSFORM]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Wareh/Btnsform_SaveEdit
		[HttpPost]
		public ActionResult Btnsform_SaveEdit([FromBody] Btnsform_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Btnsform_SaveEdit",
				ViewName = "Btnsform",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT BTNSFORM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT BTNSFORM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class BtnsformDocumValidateTickets : RequestDocumValidateTickets
		{
			public Btnsform_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsBtnsform([FromBody] BtnsformDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
