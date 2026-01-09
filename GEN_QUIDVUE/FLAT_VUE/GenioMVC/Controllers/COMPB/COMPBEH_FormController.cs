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
using GenioMVC.ViewModels.Compb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER COMPB]/

namespace GenioMVC.Controllers
{
	public partial class CompbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_COMPBEH_CANCEL = new("COMPONENT_BEHAVIOR49688", "Compbeh_Cancel", "Compb") { vueRouteName = "form-COMPBEH", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_COMPBEH_SHOW = new("COMPONENT_BEHAVIOR49688", "Compbeh_Show", "Compb") { vueRouteName = "form-COMPBEH", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_COMPBEH_NEW = new("COMPONENT_BEHAVIOR49688", "Compbeh_New", "Compb") { vueRouteName = "form-COMPBEH", mode = "NEW" };
		private static readonly NavigationLocation ACTION_COMPBEH_EDIT = new("COMPONENT_BEHAVIOR49688", "Compbeh_Edit", "Compb") { vueRouteName = "form-COMPBEH", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_COMPBEH_DUPLICATE = new("COMPONENT_BEHAVIOR49688", "Compbeh_Duplicate", "Compb") { vueRouteName = "form-COMPBEH", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_COMPBEH_DELETE = new("COMPONENT_BEHAVIOR49688", "Compbeh_Delete", "Compb") { vueRouteName = "form-COMPBEH", mode = "DELETE" };

		#endregion

		#region Compbeh private

		private void FormHistoryLimits_Compbeh()
		{

		}

		#endregion

		#region Compbeh_Show

// USE /[MANUAL GQT CONTROLLER_SHOW COMPBEH]/

		[HttpPost]
		public ActionResult Compbeh_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compbeh_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Show_GET",
				AreaName = "compb",
				Location = ACTION_COMPBEH_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compbeh();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW COMPBEH]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Compbeh_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Compbeh_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_New_GET",
				AreaName = "compb",
				FormName = "COMPBEH",
				Location = ACTION_COMPBEH_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Compbeh();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW COMPBEH]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Compb/Compbeh_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_New([FromBody]Compbeh_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_New",
				ViewName = "Compbeh",
				AreaName = "compb",
				Location = ACTION_COMPBEH_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW COMPBEH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX COMPBEH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX COMPBEH]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Compbeh_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compbeh_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Edit_GET",
				AreaName = "compb",
				FormName = "COMPBEH",
				Location = ACTION_COMPBEH_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compbeh();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT COMPBEH]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Compb/Compbeh_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_Edit([FromBody]Compbeh_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Edit",
				ViewName = "Compbeh",
				AreaName = "compb",
				Location = ACTION_COMPBEH_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT COMPBEH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX COMPBEH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX COMPBEH]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Compbeh_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compbeh_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Delete_GET",
				AreaName = "compb",
				FormName = "COMPBEH",
				Location = ACTION_COMPBEH_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compbeh();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE COMPBEH]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Compb/Compbeh_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compbeh_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Delete",
				ViewName = "Compbeh",
				AreaName = "compb",
				Location = ACTION_COMPBEH_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE COMPBEH]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Compbeh_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("COMPBEH");
		}

		#endregion

		#region Compbeh_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET COMPBEH]/

		[HttpPost]
		public ActionResult Compbeh_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Compbeh_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Duplicate_GET",
				AreaName = "compb",
				FormName = "COMPBEH",
				Location = ACTION_COMPBEH_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE COMPBEH]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Compb/Compbeh_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST COMPBEH]/
		[HttpPost]
		public ActionResult Compbeh_Duplicate([FromBody]Compbeh_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_Duplicate",
				ViewName = "Compbeh",
				AreaName = "compb",
				Location = ACTION_COMPBEH_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE COMPBEH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX COMPBEH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX COMPBEH]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Compbeh_Cancel

		//
		// GET: /Compb/Compbeh_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET COMPBEH]/
		public ActionResult Compbeh_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Compb model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("compb");

// USE /[MANUAL GQT BEFORE_CANCEL COMPBEH]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL COMPBEH]/

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

				Navigation.SetValue("ForcePrimaryRead_compb", "true", true);
			}

			Navigation.ClearValue("compb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Compb/Compbeh_SaveEdit
		[HttpPost]
		public ActionResult Compbeh_SaveEdit([FromBody] Compbeh_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compbeh_SaveEdit",
				ViewName = "Compbeh",
				AreaName = "compb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT COMPBEH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT COMPBEH]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CompbehDocumValidateTickets : RequestDocumValidateTickets
		{
			public Compbeh_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCompbeh([FromBody] CompbehDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
