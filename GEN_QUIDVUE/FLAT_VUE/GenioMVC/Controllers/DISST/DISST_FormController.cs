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
using GenioMVC.ViewModels.Disst;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISST]/

namespace GenioMVC.Controllers
{
	public partial class DisstController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DISST_CANCEL = new("DISPATCHMENT_STATUS18877", "Disst_Cancel", "Disst") { vueRouteName = "form-DISST", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DISST_SHOW = new("DISPATCHMENT_STATUS18877", "Disst_Show", "Disst") { vueRouteName = "form-DISST", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DISST_NEW = new("DISPATCHMENT_STATUS18877", "Disst_New", "Disst") { vueRouteName = "form-DISST", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DISST_EDIT = new("DISPATCHMENT_STATUS18877", "Disst_Edit", "Disst") { vueRouteName = "form-DISST", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DISST_DUPLICATE = new("DISPATCHMENT_STATUS18877", "Disst_Duplicate", "Disst") { vueRouteName = "form-DISST", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DISST_DELETE = new("DISPATCHMENT_STATUS18877", "Disst_Delete", "Disst") { vueRouteName = "form-DISST", mode = "DELETE" };

		#endregion

		#region Disst private

		private void FormHistoryLimits_Disst()
		{

		}

		#endregion

		#region Disst_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DISST]/

		[HttpPost]
		public ActionResult Disst_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Disst_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Show_GET",
				AreaName = "disst",
				Location = ACTION_DISST_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Disst();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DISST]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Disst_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DISST]/
		[HttpPost]
		public ActionResult Disst_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Disst_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Disst_New_GET",
				AreaName = "disst",
				FormName = "DISST",
				Location = ACTION_DISST_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Disst();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DISST]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Disst/Disst_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DISST]/
		[HttpPost]
		public ActionResult Disst_New([FromBody]Disst_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Disst_New",
				ViewName = "Disst",
				AreaName = "disst",
				Location = ACTION_DISST_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DISST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DISST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DISST]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Disst_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DISST]/
		[HttpPost]
		public ActionResult Disst_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Disst_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Edit_GET",
				AreaName = "disst",
				FormName = "DISST",
				Location = ACTION_DISST_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Disst();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DISST]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Disst/Disst_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DISST]/
		[HttpPost]
		public ActionResult Disst_Edit([FromBody]Disst_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Edit",
				ViewName = "Disst",
				AreaName = "disst",
				Location = ACTION_DISST_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DISST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DISST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DISST]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Disst_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DISST]/
		[HttpPost]
		public ActionResult Disst_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Disst_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Delete_GET",
				AreaName = "disst",
				FormName = "DISST",
				Location = ACTION_DISST_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Disst();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DISST]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Disst/Disst_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DISST]/
		[HttpPost]
		public ActionResult Disst_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Disst_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Disst_Delete",
				ViewName = "Disst",
				AreaName = "disst",
				Location = ACTION_DISST_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DISST]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Disst_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DISST");
		}

		#endregion

		#region Disst_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DISST]/

		[HttpPost]
		public ActionResult Disst_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Disst_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Duplicate_GET",
				AreaName = "disst",
				FormName = "DISST",
				Location = ACTION_DISST_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DISST]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Disst/Disst_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DISST]/
		[HttpPost]
		public ActionResult Disst_Duplicate([FromBody]Disst_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Disst_Duplicate",
				ViewName = "Disst",
				AreaName = "disst",
				Location = ACTION_DISST_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DISST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DISST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DISST]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Disst_Cancel

		//
		// GET: /Disst/Disst_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DISST]/
		public ActionResult Disst_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Disst(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("disst");

// USE /[MANUAL GQT BEFORE_CANCEL DISST]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DISST]/

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

				Navigation.SetValue("ForcePrimaryRead_disst", "true", true);
			}

			Navigation.ClearValue("disst");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Disst/Disst_SaveEdit
		[HttpPost]
		public ActionResult Disst_SaveEdit([FromBody] Disst_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Disst_SaveEdit",
				ViewName = "Disst",
				AreaName = "disst",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DISST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DISST]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DisstDocumValidateTickets : RequestDocumValidateTickets
		{
			public Disst_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDisst([FromBody] DisstDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
