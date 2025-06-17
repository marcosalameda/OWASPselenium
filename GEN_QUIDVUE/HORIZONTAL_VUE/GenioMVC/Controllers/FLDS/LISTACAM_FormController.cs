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
using GenioMVC.ViewModels.Flds;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FLDS]/

namespace GenioMVC.Controllers
{
	public partial class FldsController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LISTACAM_CANCEL = new("FIELD_LIST48027", "Listacam_Cancel", "Flds") { vueRouteName = "form-LISTACAM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LISTACAM_SHOW = new("FIELD_LIST48027", "Listacam_Show", "Flds") { vueRouteName = "form-LISTACAM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LISTACAM_NEW = new("FIELD_LIST48027", "Listacam_New", "Flds") { vueRouteName = "form-LISTACAM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LISTACAM_EDIT = new("FIELD_LIST48027", "Listacam_Edit", "Flds") { vueRouteName = "form-LISTACAM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LISTACAM_DUPLICATE = new("FIELD_LIST48027", "Listacam_Duplicate", "Flds") { vueRouteName = "form-LISTACAM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LISTACAM_DELETE = new("FIELD_LIST48027", "Listacam_Delete", "Flds") { vueRouteName = "form-LISTACAM", mode = "DELETE" };

		#endregion

		#region Listacam private

		private void FormHistoryLimits_Listacam()
		{

		}

		#endregion

		#region Listacam_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LISTACAM]/

		[HttpPost]
		public ActionResult Listacam_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Listacam_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Show_GET",
				AreaName = "flds",
				Location = ACTION_LISTACAM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Listacam();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LISTACAM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Listacam_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Listacam_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_New_GET",
				AreaName = "flds",
				FormName = "LISTACAM",
				Location = ACTION_LISTACAM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Listacam();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LISTACAM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Flds/Listacam_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_New([FromBody]Listacam_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_New",
				ViewName = "Listacam",
				AreaName = "flds",
				Location = ACTION_LISTACAM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LISTACAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LISTACAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LISTACAM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Listacam_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Listacam_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Edit_GET",
				AreaName = "flds",
				FormName = "LISTACAM",
				Location = ACTION_LISTACAM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Listacam();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LISTACAM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Flds/Listacam_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_Edit([FromBody]Listacam_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Edit",
				ViewName = "Listacam",
				AreaName = "flds",
				Location = ACTION_LISTACAM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LISTACAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LISTACAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LISTACAM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Listacam_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Listacam_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Delete_GET",
				AreaName = "flds",
				FormName = "LISTACAM",
				Location = ACTION_LISTACAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Listacam();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LISTACAM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Flds/Listacam_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Listacam_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Delete",
				ViewName = "Listacam",
				AreaName = "flds",
				Location = ACTION_LISTACAM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LISTACAM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Listacam_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LISTACAM");
		}

		#endregion

		#region Listacam_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LISTACAM]/

		[HttpPost]
		public ActionResult Listacam_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Listacam_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Duplicate_GET",
				AreaName = "flds",
				FormName = "LISTACAM",
				Location = ACTION_LISTACAM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LISTACAM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Flds/Listacam_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LISTACAM]/
		[HttpPost]
		public ActionResult Listacam_Duplicate([FromBody]Listacam_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_Duplicate",
				ViewName = "Listacam",
				AreaName = "flds",
				Location = ACTION_LISTACAM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LISTACAM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LISTACAM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LISTACAM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Listacam_Cancel

		//
		// GET: /Flds/Listacam_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LISTACAM]/
		public ActionResult Listacam_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Flds(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("flds");

// USE /[MANUAL GQT BEFORE_CANCEL LISTACAM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LISTACAM]/

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

				Navigation.SetValue("ForcePrimaryRead_flds", "true", true);
			}

			Navigation.ClearValue("flds");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Flds/Listacam_SaveEdit
		[HttpPost]
		public ActionResult Listacam_SaveEdit([FromBody] Listacam_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Listacam_SaveEdit",
				ViewName = "Listacam",
				AreaName = "flds",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LISTACAM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LISTACAM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ListacamDocumValidateTickets : RequestDocumValidateTickets
		{
			public Listacam_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsListacam([FromBody] ListacamDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
