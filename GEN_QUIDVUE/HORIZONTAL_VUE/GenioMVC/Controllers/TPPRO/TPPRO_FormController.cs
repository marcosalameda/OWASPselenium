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
using GenioMVC.ViewModels.Tppro;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPPRO]/

namespace GenioMVC.Controllers
{
	public partial class TpproController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPPRO_CANCEL = new("PROPERTY_TYPE51419", "Tppro_Cancel", "Tppro") { vueRouteName = "form-TPPRO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPPRO_SHOW = new("PROPERTY_TYPE51419", "Tppro_Show", "Tppro") { vueRouteName = "form-TPPRO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPPRO_NEW = new("PROPERTY_TYPE51419", "Tppro_New", "Tppro") { vueRouteName = "form-TPPRO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPPRO_EDIT = new("PROPERTY_TYPE51419", "Tppro_Edit", "Tppro") { vueRouteName = "form-TPPRO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPPRO_DUPLICATE = new("PROPERTY_TYPE51419", "Tppro_Duplicate", "Tppro") { vueRouteName = "form-TPPRO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPPRO_DELETE = new("PROPERTY_TYPE51419", "Tppro_Delete", "Tppro") { vueRouteName = "form-TPPRO", mode = "DELETE" };

		#endregion

		#region Tppro private

		private void FormHistoryLimits_Tppro()
		{

		}

		#endregion

		#region Tppro_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPPRO]/

		[HttpPost]
		public ActionResult Tppro_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tppro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Show_GET",
				AreaName = "tppro",
				Location = ACTION_TPPRO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tppro();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPPRO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tppro_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPPRO]/
		[HttpPost]
		public ActionResult Tppro_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Tppro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_New_GET",
				AreaName = "tppro",
				FormName = "TPPRO",
				Location = ACTION_TPPRO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tppro();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPPRO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tppro/Tppro_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPPRO]/
		[HttpPost]
		public ActionResult Tppro_New([FromBody]Tppro_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_New",
				ViewName = "Tppro",
				AreaName = "tppro",
				Location = ACTION_TPPRO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TPPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPPRO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tppro_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPPRO]/
		[HttpPost]
		public ActionResult Tppro_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tppro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Edit_GET",
				AreaName = "tppro",
				FormName = "TPPRO",
				Location = ACTION_TPPRO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tppro();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPPRO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tppro/Tppro_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPPRO]/
		[HttpPost]
		public ActionResult Tppro_Edit([FromBody]Tppro_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Edit",
				ViewName = "Tppro",
				AreaName = "tppro",
				Location = ACTION_TPPRO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPPRO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tppro_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPPRO]/
		[HttpPost]
		public ActionResult Tppro_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tppro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Delete_GET",
				AreaName = "tppro",
				FormName = "TPPRO",
				Location = ACTION_TPPRO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tppro();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPPRO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tppro/Tppro_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPPRO]/
		[HttpPost]
		public ActionResult Tppro_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Tppro_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Delete",
				ViewName = "Tppro",
				AreaName = "tppro",
				Location = ACTION_TPPRO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPPRO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tppro_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPPRO");
		}

		#endregion

		#region Tppro_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPPRO]/

		[HttpPost]
		public ActionResult Tppro_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Tppro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Duplicate_GET",
				AreaName = "tppro",
				FormName = "TPPRO",
				Location = ACTION_TPPRO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPPRO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tppro/Tppro_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPPRO]/
		[HttpPost]
		public ActionResult Tppro_Duplicate([FromBody]Tppro_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Tppro_Duplicate",
				ViewName = "Tppro",
				AreaName = "tppro",
				Location = ACTION_TPPRO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPPRO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tppro_Cancel

		//
		// GET: /Tppro/Tppro_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPPRO]/
		public ActionResult Tppro_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Tppro(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("tppro");

// USE /[MANUAL GQT BEFORE_CANCEL TPPRO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPPRO]/

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

				Navigation.SetValue("ForcePrimaryRead_tppro", "true", true);
			}

			Navigation.ClearValue("tppro");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Tppro/Tppro_SaveEdit
		[HttpPost]
		public ActionResult Tppro_SaveEdit([FromBody] Tppro_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tppro_SaveEdit",
				ViewName = "Tppro",
				AreaName = "tppro",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPPRO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TpproDocumValidateTickets : RequestDocumValidateTickets
		{
			public Tppro_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTppro([FromBody] TpproDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
