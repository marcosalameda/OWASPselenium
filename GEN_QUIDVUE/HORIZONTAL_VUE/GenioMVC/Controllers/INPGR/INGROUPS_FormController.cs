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
using GenioMVC.ViewModels.Inpgr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER INPGR]/

namespace GenioMVC.Controllers
{
	public partial class InpgrController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_INGROUPS_CANCEL = new("INPUT_GROUP17182", "Ingroups_Cancel", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_INGROUPS_SHOW = new("INPUT_GROUP17182", "Ingroups_Show", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_INGROUPS_NEW = new("INPUT_GROUP17182", "Ingroups_New", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_INGROUPS_EDIT = new("INPUT_GROUP17182", "Ingroups_Edit", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_INGROUPS_DUPLICATE = new("INPUT_GROUP17182", "Ingroups_Duplicate", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_INGROUPS_DELETE = new("INPUT_GROUP17182", "Ingroups_Delete", "Inpgr") { vueRouteName = "form-INGROUPS", mode = "DELETE" };

		#endregion

		#region Ingroups private

		private void FormHistoryLimits_Ingroups()
		{

		}

		#endregion

		#region Ingroups_Show

// USE /[MANUAL GQT CONTROLLER_SHOW INGROUPS]/

		[HttpPost]
		public ActionResult Ingroups_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ingroups_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Show_GET",
				AreaName = "inpgr",
				Location = ACTION_INGROUPS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ingroups();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW INGROUPS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ingroups_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Ingroups_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_New_GET",
				AreaName = "inpgr",
				FormName = "INGROUPS",
				Location = ACTION_INGROUPS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ingroups();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW INGROUPS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Inpgr/Ingroups_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_New([FromBody]Ingroups_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_New",
				ViewName = "Ingroups",
				AreaName = "inpgr",
				Location = ACTION_INGROUPS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW INGROUPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX INGROUPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX INGROUPS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ingroups_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ingroups_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Edit_GET",
				AreaName = "inpgr",
				FormName = "INGROUPS",
				Location = ACTION_INGROUPS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ingroups();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT INGROUPS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Inpgr/Ingroups_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_Edit([FromBody]Ingroups_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Edit",
				ViewName = "Ingroups",
				AreaName = "inpgr",
				Location = ACTION_INGROUPS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT INGROUPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX INGROUPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX INGROUPS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ingroups_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ingroups_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Delete_GET",
				AreaName = "inpgr",
				FormName = "INGROUPS",
				Location = ACTION_INGROUPS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ingroups();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE INGROUPS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Inpgr/Ingroups_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Ingroups_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Delete",
				ViewName = "Ingroups",
				AreaName = "inpgr",
				Location = ACTION_INGROUPS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE INGROUPS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ingroups_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("INGROUPS");
		}

		#endregion

		#region Ingroups_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET INGROUPS]/

		[HttpPost]
		public ActionResult Ingroups_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Ingroups_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Duplicate_GET",
				AreaName = "inpgr",
				FormName = "INGROUPS",
				Location = ACTION_INGROUPS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE INGROUPS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Inpgr/Ingroups_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST INGROUPS]/
		[HttpPost]
		public ActionResult Ingroups_Duplicate([FromBody]Ingroups_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_Duplicate",
				ViewName = "Ingroups",
				AreaName = "inpgr",
				Location = ACTION_INGROUPS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE INGROUPS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX INGROUPS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX INGROUPS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ingroups_Cancel

		//
		// GET: /Inpgr/Ingroups_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET INGROUPS]/
		public ActionResult Ingroups_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Inpgr model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("inpgr");

// USE /[MANUAL GQT BEFORE_CANCEL INGROUPS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL INGROUPS]/

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

				Navigation.SetValue("ForcePrimaryRead_inpgr", "true", true);
			}

			Navigation.ClearValue("inpgr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Inpgr/Ingroups_SaveEdit
		[HttpPost]
		public ActionResult Ingroups_SaveEdit([FromBody] Ingroups_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Ingroups_SaveEdit",
				ViewName = "Ingroups",
				AreaName = "inpgr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT INGROUPS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT INGROUPS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class IngroupsDocumValidateTickets : RequestDocumValidateTickets
		{
			public Ingroups_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsIngroups([FromBody] IngroupsDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
