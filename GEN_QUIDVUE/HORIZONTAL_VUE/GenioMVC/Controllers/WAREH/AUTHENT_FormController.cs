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

		private static readonly NavigationLocation ACTION_AUTHENT_CANCEL = new("WAREHOUSE51864", "Authent_Cancel", "Wareh") { vueRouteName = "form-AUTHENT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AUTHENT_SHOW = new("WAREHOUSE51864", "Authent_Show", "Wareh") { vueRouteName = "form-AUTHENT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AUTHENT_NEW = new("WAREHOUSE51864", "Authent_New", "Wareh") { vueRouteName = "form-AUTHENT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AUTHENT_EDIT = new("WAREHOUSE51864", "Authent_Edit", "Wareh") { vueRouteName = "form-AUTHENT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AUTHENT_DUPLICATE = new("WAREHOUSE51864", "Authent_Duplicate", "Wareh") { vueRouteName = "form-AUTHENT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AUTHENT_DELETE = new("WAREHOUSE51864", "Authent_Delete", "Wareh") { vueRouteName = "form-AUTHENT", mode = "DELETE" };

		#endregion

		#region Authent private

		private void FormHistoryLimits_Authent()
		{

		}

		#endregion

		#region Authent_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AUTHENT]/

		[HttpPost]
		public ActionResult Authent_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Show_GET",
				AreaName = "wareh",
				Location = ACTION_AUTHENT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authent();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AUTHENT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Authent_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AUTHENT]/
		[HttpPost]
		public ActionResult Authent_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Authent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authent_New_GET",
				AreaName = "wareh",
				FormName = "AUTHENT",
				Location = ACTION_AUTHENT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Authent();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AUTHENT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Authent_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AUTHENT]/
		[HttpPost]
		public ActionResult Authent_New([FromBody]Authent_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authent_New",
				ViewName = "Authent",
				AreaName = "wareh",
				Location = ACTION_AUTHENT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AUTHENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AUTHENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AUTHENT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Authent_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AUTHENT]/
		[HttpPost]
		public ActionResult Authent_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Edit_GET",
				AreaName = "wareh",
				FormName = "AUTHENT",
				Location = ACTION_AUTHENT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authent();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AUTHENT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Authent_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AUTHENT]/
		[HttpPost]
		public ActionResult Authent_Edit([FromBody]Authent_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Edit",
				ViewName = "Authent",
				AreaName = "wareh",
				Location = ACTION_AUTHENT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AUTHENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AUTHENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AUTHENT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Authent_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AUTHENT]/
		[HttpPost]
		public ActionResult Authent_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Delete_GET",
				AreaName = "wareh",
				FormName = "AUTHENT",
				Location = ACTION_AUTHENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Authent();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AUTHENT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Authent_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AUTHENT]/
		[HttpPost]
		public ActionResult Authent_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Authent_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Authent_Delete",
				ViewName = "Authent",
				AreaName = "wareh",
				Location = ACTION_AUTHENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AUTHENT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Authent_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AUTHENT");
		}

		#endregion

		#region Authent_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AUTHENT]/

		[HttpPost]
		public ActionResult Authent_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Authent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Duplicate_GET",
				AreaName = "wareh",
				FormName = "AUTHENT",
				Location = ACTION_AUTHENT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AUTHENT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Authent_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AUTHENT]/
		[HttpPost]
		public ActionResult Authent_Duplicate([FromBody]Authent_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Authent_Duplicate",
				ViewName = "Authent",
				AreaName = "wareh",
				Location = ACTION_AUTHENT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AUTHENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AUTHENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AUTHENT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Authent_Cancel

		//
		// GET: /Wareh/Authent_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AUTHENT]/
		public ActionResult Authent_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Wareh(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL AUTHENT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AUTHENT]/

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


		// POST: /Wareh/Authent_SaveEdit
		[HttpPost]
		public ActionResult Authent_SaveEdit([FromBody] Authent_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Authent_SaveEdit",
				ViewName = "Authent",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AUTHENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AUTHENT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AuthentDocumValidateTickets : RequestDocumValidateTickets
		{
			public Authent_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAuthent([FromBody] AuthentDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
