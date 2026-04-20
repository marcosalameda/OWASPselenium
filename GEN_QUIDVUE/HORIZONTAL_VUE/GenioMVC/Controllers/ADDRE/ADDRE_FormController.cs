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
using GenioMVC.ViewModels.Addre;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ADDRE]/

namespace GenioMVC.Controllers
{
	public partial class AddreController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ADDRE_CANCEL = new("ADDRESS04342", "Addre_Cancel", "Addre") { vueRouteName = "form-ADDRE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ADDRE_SHOW = new("ADDRESS04342", "Addre_Show", "Addre") { vueRouteName = "form-ADDRE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ADDRE_NEW = new("ADDRESS04342", "Addre_New", "Addre") { vueRouteName = "form-ADDRE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ADDRE_EDIT = new("ADDRESS04342", "Addre_Edit", "Addre") { vueRouteName = "form-ADDRE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ADDRE_DUPLICATE = new("ADDRESS04342", "Addre_Duplicate", "Addre") { vueRouteName = "form-ADDRE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ADDRE_DELETE = new("ADDRESS04342", "Addre_Delete", "Addre") { vueRouteName = "form-ADDRE", mode = "DELETE" };

		#endregion

		#region Addre private

		private void FormHistoryLimits_Addre()
		{

		}

		#endregion

		#region Addre_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ADDRE]/

		[HttpPost]
		public ActionResult Addre_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Addre_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Addre_Show_GET",
				AreaName = "addre",
				Location = ACTION_ADDRE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ADDRE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Addre_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Addre_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Addre_New_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ADDRE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Addre/Addre_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_New([FromBody]Addre_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Addre_New",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ADDRE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Addre_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Addre_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Addre_Edit_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ADDRE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Addre/Addre_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Edit([FromBody]Addre_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Addre_Edit",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ADDRE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Addre_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ADDRE]/
		[HttpPost]
		public ActionResult Addre_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Addre_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Addre_Delete_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Addre();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ADDRE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Addre/Addre_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Addre_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Addre_Delete",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ADDRE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Addre_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ADDRE");
		}

		#endregion

		#region Addre_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ADDRE]/

		[HttpPost]
		public ActionResult Addre_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Addre_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Addre_Duplicate_GET",
				AreaName = "addre",
				FormName = "ADDRE",
				Location = ACTION_ADDRE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ADDRE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Addre/Addre_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ADDRE]/
		[HttpPost]
		public ActionResult Addre_Duplicate([FromBody]Addre_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Addre_Duplicate",
				ViewName = "Addre",
				AreaName = "addre",
				Location = ACTION_ADDRE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ADDRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ADDRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ADDRE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Addre_Cancel

		//
		// GET: /Addre/Addre_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ADDRE]/
		public ActionResult Addre_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("addre");
					var model = GenioMVC.Models.Addre.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("addre");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL ADDRE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ADDRE]/

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

				Navigation.SetValue("ForcePrimaryRead_addre", "true", true);
			}

			Navigation.ClearValue("addre");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Addre/Addre_SaveEdit
		[HttpPost]
		public ActionResult Addre_SaveEdit([FromBody] Addre_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Addre_SaveEdit",
				ViewName = "Addre",
				AreaName = "addre",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ADDRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ADDRE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AddreDocumValidateTickets : RequestDocumValidateTickets
		{
			public Addre_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAddre([FromBody] AddreDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
