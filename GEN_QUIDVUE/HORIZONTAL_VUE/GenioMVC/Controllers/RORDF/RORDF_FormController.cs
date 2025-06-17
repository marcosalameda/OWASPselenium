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
using GenioMVC.ViewModels.Rordf;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RORDF]/

namespace GenioMVC.Controllers
{
	public partial class RordfController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_RORDF_CANCEL = new("ORDER__FLOAT_FIELD_21693", "Rordf_Cancel", "Rordf") { vueRouteName = "form-RORDF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_RORDF_SHOW = new("ORDER__FLOAT_FIELD_21693", "Rordf_Show", "Rordf") { vueRouteName = "form-RORDF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_RORDF_NEW = new("ORDER__FLOAT_FIELD_21693", "Rordf_New", "Rordf") { vueRouteName = "form-RORDF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_RORDF_EDIT = new("ORDER__FLOAT_FIELD_21693", "Rordf_Edit", "Rordf") { vueRouteName = "form-RORDF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_RORDF_DUPLICATE = new("ORDER__FLOAT_FIELD_21693", "Rordf_Duplicate", "Rordf") { vueRouteName = "form-RORDF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_RORDF_DELETE = new("ORDER__FLOAT_FIELD_21693", "Rordf_Delete", "Rordf") { vueRouteName = "form-RORDF", mode = "DELETE" };

		#endregion

		#region Rordf private

		private void FormHistoryLimits_Rordf()
		{

		}

		#endregion

		#region Rordf_Show

// USE /[MANUAL GQT CONTROLLER_SHOW RORDF]/

		[HttpPost]
		public ActionResult Rordf_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Show_GET",
				AreaName = "rordf",
				Location = ACTION_RORDF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordf();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW RORDF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Rordf_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET RORDF]/
		[HttpPost]
		public ActionResult Rordf_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Rordf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_New_GET",
				AreaName = "rordf",
				FormName = "RORDF",
				Location = ACTION_RORDF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Rordf();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW RORDF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rordf/Rordf_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST RORDF]/
		[HttpPost]
		public ActionResult Rordf_New([FromBody]Rordf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_New",
				ViewName = "Rordf",
				AreaName = "rordf",
				Location = ACTION_RORDF_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW RORDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX RORDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX RORDF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Rordf_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET RORDF]/
		[HttpPost]
		public ActionResult Rordf_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Edit_GET",
				AreaName = "rordf",
				FormName = "RORDF",
				Location = ACTION_RORDF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordf();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT RORDF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rordf/Rordf_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST RORDF]/
		[HttpPost]
		public ActionResult Rordf_Edit([FromBody]Rordf_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Edit",
				ViewName = "Rordf",
				AreaName = "rordf",
				Location = ACTION_RORDF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT RORDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX RORDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX RORDF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Rordf_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET RORDF]/
		[HttpPost]
		public ActionResult Rordf_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Delete_GET",
				AreaName = "rordf",
				FormName = "RORDF",
				Location = ACTION_RORDF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordf();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE RORDF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rordf/Rordf_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST RORDF]/
		[HttpPost]
		public ActionResult Rordf_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordf_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Delete",
				ViewName = "Rordf",
				AreaName = "rordf",
				Location = ACTION_RORDF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE RORDF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Rordf_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("RORDF");
		}

		#endregion

		#region Rordf_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET RORDF]/

		[HttpPost]
		public ActionResult Rordf_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Rordf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Duplicate_GET",
				AreaName = "rordf",
				FormName = "RORDF",
				Location = ACTION_RORDF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE RORDF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rordf/Rordf_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST RORDF]/
		[HttpPost]
		public ActionResult Rordf_Duplicate([FromBody]Rordf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_Duplicate",
				ViewName = "Rordf",
				AreaName = "rordf",
				Location = ACTION_RORDF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE RORDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX RORDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX RORDF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Rordf_Cancel

		//
		// GET: /Rordf/Rordf_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET RORDF]/
		public ActionResult Rordf_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Rordf(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rordf");

// USE /[MANUAL GQT BEFORE_CANCEL RORDF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL RORDF]/

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

				Navigation.SetValue("ForcePrimaryRead_rordf", "true", true);
			}

			Navigation.ClearValue("rordf");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Rordf/Rordf_SaveEdit
		[HttpPost]
		public ActionResult Rordf_SaveEdit([FromBody] Rordf_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordf_SaveEdit",
				ViewName = "Rordf",
				AreaName = "rordf",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT RORDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT RORDF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RordfDocumValidateTickets : RequestDocumValidateTickets
		{
			public Rordf_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRordf([FromBody] RordfDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
