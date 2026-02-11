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
using GenioMVC.ViewModels.Speci;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SPECI]/

namespace GenioMVC.Controllers
{
	public partial class SpeciController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ESPEC_CANCEL = new("SPECIALTY09304", "Espec_Cancel", "Speci") { vueRouteName = "form-ESPEC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ESPEC_SHOW = new("SPECIALTY09304", "Espec_Show", "Speci") { vueRouteName = "form-ESPEC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ESPEC_NEW = new("SPECIALTY09304", "Espec_New", "Speci") { vueRouteName = "form-ESPEC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ESPEC_EDIT = new("SPECIALTY09304", "Espec_Edit", "Speci") { vueRouteName = "form-ESPEC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ESPEC_DUPLICATE = new("SPECIALTY09304", "Espec_Duplicate", "Speci") { vueRouteName = "form-ESPEC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ESPEC_DELETE = new("SPECIALTY09304", "Espec_Delete", "Speci") { vueRouteName = "form-ESPEC", mode = "DELETE" };

		#endregion

		#region Espec private

		private void FormHistoryLimits_Espec()
		{

		}

		#endregion

		#region Espec_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ESPEC]/

		[HttpPost]
		public ActionResult Espec_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Espec_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Espec_Show_GET",
				AreaName = "speci",
				Location = ACTION_ESPEC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ESPEC]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Espec_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Espec_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Espec_New_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ESPEC]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Speci/Espec_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_New([FromBody]Espec_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Espec_New",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ESPEC]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Espec_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Espec_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Espec_Edit_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ESPEC]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Speci/Espec_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Edit([FromBody]Espec_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Espec_Edit",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ESPEC]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Espec_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Espec_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Espec_Delete_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ESPEC]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Speci/Espec_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Espec_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Espec_Delete",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ESPEC]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Espec_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ESPEC");
		}

		#endregion

		#region Espec_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ESPEC]/

		[HttpPost]
		public ActionResult Espec_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Espec_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Espec_Duplicate_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ESPEC]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Speci/Espec_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Duplicate([FromBody]Espec_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Espec_Duplicate",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ESPEC]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Espec_Cancel

		//
		// GET: /Speci/Espec_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ESPEC]/
		public ActionResult Espec_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Speci model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("speci");

// USE /[MANUAL GQT BEFORE_CANCEL ESPEC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ESPEC]/

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

				Navigation.SetValue("ForcePrimaryRead_speci", "true", true);
			}

			Navigation.ClearValue("speci");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Speci/Espec_SaveEdit
		[HttpPost]
		public ActionResult Espec_SaveEdit([FromBody] Espec_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Espec_SaveEdit",
				ViewName = "Espec",
				AreaName = "speci",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ESPEC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class EspecDocumValidateTickets : RequestDocumValidateTickets
		{
			public Espec_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEspec([FromBody] EspecDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
