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
using System.Dynamic;

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
using GenioMVC.ViewModels.Rooms;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROOMS]/

namespace GenioMVC.Controllers
{
	public partial class RoomsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_SALAS_CANCEL = new("ROOM50867", "Salas_Cancel", "Rooms") { vueRouteName = "form-SALAS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_SALAS_SHOW = new("ROOM50867", "Salas_Show", "Rooms") { vueRouteName = "form-SALAS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_SALAS_NEW = new("ROOM50867", "Salas_New", "Rooms") { vueRouteName = "form-SALAS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_SALAS_EDIT = new("ROOM50867", "Salas_Edit", "Rooms") { vueRouteName = "form-SALAS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_SALAS_DUPLICATE = new("ROOM50867", "Salas_Duplicate", "Rooms") { vueRouteName = "form-SALAS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_SALAS_DELETE = new("ROOM50867", "Salas_Delete", "Rooms") { vueRouteName = "form-SALAS", mode = "DELETE" };

		#endregion

		#region Salas private

		private void FormHistoryLimits_Salas()
		{

		}

		#endregion

		#region Salas_Show

// USE /[MANUAL GQT CONTROLLER_SHOW SALAS]/

		[HttpPost]
		public ActionResult Salas_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Salas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Salas_Show_GET",
				AreaName = "rooms",
				Location = ACTION_SALAS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Salas();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW SALAS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Salas_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET SALAS]/
		[HttpPost]
		public ActionResult Salas_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Salas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Salas_New_GET",
				AreaName = "rooms",
				FormName = "SALAS",
				Location = ACTION_SALAS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Salas();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW SALAS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rooms/Salas_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST SALAS]/
		[HttpPost]
		public ActionResult Salas_New([FromBody]Salas_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Salas_New",
				ViewName = "Salas",
				AreaName = "rooms",
				Location = ACTION_SALAS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW SALAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX SALAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX SALAS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Salas_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET SALAS]/
		[HttpPost]
		public ActionResult Salas_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Salas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Salas_Edit_GET",
				AreaName = "rooms",
				FormName = "SALAS",
				Location = ACTION_SALAS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Salas();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT SALAS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rooms/Salas_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST SALAS]/
		[HttpPost]
		public ActionResult Salas_Edit([FromBody]Salas_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Salas_Edit",
				ViewName = "Salas",
				AreaName = "rooms",
				Location = ACTION_SALAS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT SALAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX SALAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX SALAS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Salas_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET SALAS]/
		[HttpPost]
		public ActionResult Salas_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Salas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Salas_Delete_GET",
				AreaName = "rooms",
				FormName = "SALAS",
				Location = ACTION_SALAS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Salas();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE SALAS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rooms/Salas_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST SALAS]/
		[HttpPost]
		public ActionResult Salas_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Salas_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Salas_Delete",
				ViewName = "Salas",
				AreaName = "rooms",
				Location = ACTION_SALAS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE SALAS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Salas_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("SALAS");
		}

		#endregion

		#region Salas_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET SALAS]/

		[HttpPost]
		public ActionResult Salas_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Salas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Salas_Duplicate_GET",
				AreaName = "rooms",
				FormName = "SALAS",
				Location = ACTION_SALAS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE SALAS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rooms/Salas_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST SALAS]/
		[HttpPost]
		public ActionResult Salas_Duplicate([FromBody]Salas_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Salas_Duplicate",
				ViewName = "Salas",
				AreaName = "rooms",
				Location = ACTION_SALAS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE SALAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX SALAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX SALAS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Salas_Cancel

		//
		// GET: /Rooms/Salas_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET SALAS]/
		public ActionResult Salas_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Rooms model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rooms");

// USE /[MANUAL GQT BEFORE_CANCEL SALAS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL SALAS]/

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

				Navigation.SetValue("ForcePrimaryRead_rooms", "true", true);
			}

			Navigation.ClearValue("rooms");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Rooms/Salas_SaveEdit
		[HttpPost]
		public ActionResult Salas_SaveEdit([FromBody] Salas_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Salas_SaveEdit",
				ViewName = "Salas",
				AreaName = "rooms",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT SALAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT SALAS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class SalasDocumValidateTickets : RequestDocumValidateTickets
		{
			public Salas_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsSalas([FromBody] SalasDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
