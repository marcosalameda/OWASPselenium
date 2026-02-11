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
using GenioMVC.ViewModels.Dttyp;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DTTYP]/

namespace GenioMVC.Controllers
{
	public partial class DttypController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DTTYP_CANCEL = new("DATA_TYPE47159", "Dttyp_Cancel", "Dttyp") { vueRouteName = "form-DTTYP", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DTTYP_SHOW = new("DATA_TYPE47159", "Dttyp_Show", "Dttyp") { vueRouteName = "form-DTTYP", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DTTYP_NEW = new("DATA_TYPE47159", "Dttyp_New", "Dttyp") { vueRouteName = "form-DTTYP", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DTTYP_EDIT = new("DATA_TYPE47159", "Dttyp_Edit", "Dttyp") { vueRouteName = "form-DTTYP", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DTTYP_DUPLICATE = new("DATA_TYPE47159", "Dttyp_Duplicate", "Dttyp") { vueRouteName = "form-DTTYP", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DTTYP_DELETE = new("DATA_TYPE47159", "Dttyp_Delete", "Dttyp") { vueRouteName = "form-DTTYP", mode = "DELETE" };

		#endregion

		#region Dttyp private

		private void FormHistoryLimits_Dttyp()
		{

		}

		#endregion

		#region Dttyp_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DTTYP]/

		[HttpPost]
		public ActionResult Dttyp_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dttyp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Show_GET",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dttyp();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DTTYP]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dttyp_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Dttyp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_New_GET",
				AreaName = "dttyp",
				FormName = "DTTYP",
				Location = ACTION_DTTYP_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dttyp();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DTTYP]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Dttyp/Dttyp_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_New([FromBody]Dttyp_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_New",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DTTYP]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dttyp_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dttyp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Edit_GET",
				AreaName = "dttyp",
				FormName = "DTTYP",
				Location = ACTION_DTTYP_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dttyp();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DTTYP]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Dttyp/Dttyp_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_Edit([FromBody]Dttyp_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Edit",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DTTYP]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dttyp_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dttyp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Delete_GET",
				AreaName = "dttyp",
				FormName = "DTTYP",
				Location = ACTION_DTTYP_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dttyp();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DTTYP]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Dttyp/Dttyp_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dttyp_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Delete",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DTTYP]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dttyp_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DTTYP");
		}

		#endregion

		#region Dttyp_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DTTYP]/

		[HttpPost]
		public ActionResult Dttyp_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Dttyp_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Duplicate_GET",
				AreaName = "dttyp",
				FormName = "DTTYP",
				Location = ACTION_DTTYP_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DTTYP]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Dttyp/Dttyp_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DTTYP]/
		[HttpPost]
		public ActionResult Dttyp_Duplicate([FromBody]Dttyp_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_Duplicate",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				Location = ACTION_DTTYP_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DTTYP]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DTTYP]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DTTYP]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dttyp_Cancel

		//
		// GET: /Dttyp/Dttyp_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DTTYP]/
		public ActionResult Dttyp_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Dttyp model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("dttyp");

// USE /[MANUAL GQT BEFORE_CANCEL DTTYP]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DTTYP]/

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

				Navigation.SetValue("ForcePrimaryRead_dttyp", "true", true);
			}

			Navigation.ClearValue("dttyp");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Dttyp/Dttyp_SaveEdit
		[HttpPost]
		public ActionResult Dttyp_SaveEdit([FromBody] Dttyp_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dttyp_SaveEdit",
				ViewName = "Dttyp",
				AreaName = "dttyp",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DTTYP]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DTTYP]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DttypDocumValidateTickets : RequestDocumValidateTickets
		{
			public Dttyp_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDttyp([FromBody] DttypDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
