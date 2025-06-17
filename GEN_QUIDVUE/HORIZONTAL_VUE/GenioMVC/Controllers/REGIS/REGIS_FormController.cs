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
using GenioMVC.ViewModels.Regis;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REGIS]/

namespace GenioMVC.Controllers
{
	public partial class RegisController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGIS_CANCEL = new("REGISTRATION_ON_THE_28460", "Regis_Cancel", "Regis") { vueRouteName = "form-REGIS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIS_SHOW = new("REGISTRATION_ON_THE_28460", "Regis_Show", "Regis") { vueRouteName = "form-REGIS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIS_NEW = new("REGISTRATION_ON_THE_28460", "Regis_New", "Regis") { vueRouteName = "form-REGIS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIS_EDIT = new("REGISTRATION_ON_THE_28460", "Regis_Edit", "Regis") { vueRouteName = "form-REGIS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIS_DUPLICATE = new("REGISTRATION_ON_THE_28460", "Regis_Duplicate", "Regis") { vueRouteName = "form-REGIS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIS_DELETE = new("REGISTRATION_ON_THE_28460", "Regis_Delete", "Regis") { vueRouteName = "form-REGIS", mode = "DELETE" };

		#endregion

		#region Regis private

		private void FormHistoryLimits_Regis()
		{

		}

		#endregion

		#region Regis_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGIS]/

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Show_GET",
				AreaName = "regis",
				Location = ACTION_REGIS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regis();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGIS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regis_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGIS]/
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regis_New_GET",
				AreaName = "regis",
				FormName = "REGIS",
				Location = ACTION_REGIS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regis();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGIS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Regis/Regis_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGIS]/
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Regis_New([FromBody]Regis_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regis_New",
				ViewName = "Regis",
				AreaName = "regis",
				Location = ACTION_REGIS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGIS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regis_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGIS]/
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Edit_GET",
				AreaName = "regis",
				FormName = "REGIS",
				Location = ACTION_REGIS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regis();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGIS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Regis/Regis_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGIS]/
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Regis_Edit([FromBody]Regis_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Edit",
				ViewName = "Regis",
				AreaName = "regis",
				Location = ACTION_REGIS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGIS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regis_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGIS]/
		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Delete_GET",
				AreaName = "regis",
				FormName = "REGIS",
				Location = ACTION_REGIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regis();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGIS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Regis/Regis_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGIS]/
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Regis_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regis_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regis_Delete",
				ViewName = "Regis",
				AreaName = "regis",
				Location = ACTION_REGIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGIS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regis_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGIS");
		}

		#endregion

		#region Regis_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGIS]/

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Regis_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regis_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Duplicate_GET",
				AreaName = "regis",
				FormName = "REGIS",
				Location = ACTION_REGIS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGIS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Regis/Regis_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGIS]/
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Regis_Duplicate([FromBody]Regis_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regis_Duplicate",
				ViewName = "Regis",
				AreaName = "regis",
				Location = ACTION_REGIS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGIS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regis_Cancel

		//
		// GET: /Regis/Regis_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGIS]/
		[AllowAnonymous]
		public ActionResult Regis_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Regis(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("regis");

// USE /[MANUAL GQT BEFORE_CANCEL REGIS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGIS]/

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

				Navigation.SetValue("ForcePrimaryRead_regis", "true", true);
			}

			Navigation.ClearValue("regis");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Regis/Regis_SaveEdit
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Regis_SaveEdit([FromBody] Regis_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regis_SaveEdit",
				ViewName = "Regis",
				AreaName = "regis",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGIS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RegisDocumValidateTickets : RequestDocumValidateTickets
		{
			public Regis_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRegis([FromBody] RegisDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
