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
using GenioMVC.ViewModels.Compc;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER COMPC]/

namespace GenioMVC.Controllers
{
	public partial class CompcController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_COMPCLAS_CANCEL = new("COMPONENTES_CLASS21159", "Compclas_Cancel", "Compc") { vueRouteName = "form-COMPCLAS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_COMPCLAS_SHOW = new("COMPONENTES_CLASS21159", "Compclas_Show", "Compc") { vueRouteName = "form-COMPCLAS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_COMPCLAS_NEW = new("COMPONENTES_CLASS21159", "Compclas_New", "Compc") { vueRouteName = "form-COMPCLAS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_COMPCLAS_EDIT = new("COMPONENTES_CLASS21159", "Compclas_Edit", "Compc") { vueRouteName = "form-COMPCLAS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_COMPCLAS_DUPLICATE = new("COMPONENTES_CLASS21159", "Compclas_Duplicate", "Compc") { vueRouteName = "form-COMPCLAS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_COMPCLAS_DELETE = new("COMPONENTES_CLASS21159", "Compclas_Delete", "Compc") { vueRouteName = "form-COMPCLAS", mode = "DELETE" };

		#endregion

		#region Compclas private

		private void FormHistoryLimits_Compclas()
		{

		}

		#endregion

		#region Compclas_Show

// USE /[MANUAL GQT CONTROLLER_SHOW COMPCLAS]/

		[HttpPost]
		public ActionResult Compclas_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compclas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Show_GET",
				AreaName = "compc",
				Location = ACTION_COMPCLAS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compclas();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW COMPCLAS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Compclas_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Compclas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compclas_New_GET",
				AreaName = "compc",
				FormName = "COMPCLAS",
				Location = ACTION_COMPCLAS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Compclas();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW COMPCLAS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Compc/Compclas_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_New([FromBody]Compclas_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compclas_New",
				ViewName = "Compclas",
				AreaName = "compc",
				Location = ACTION_COMPCLAS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW COMPCLAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX COMPCLAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX COMPCLAS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Compclas_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compclas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Edit_GET",
				AreaName = "compc",
				FormName = "COMPCLAS",
				Location = ACTION_COMPCLAS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compclas();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT COMPCLAS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Compc/Compclas_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_Edit([FromBody]Compclas_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Edit",
				ViewName = "Compclas",
				AreaName = "compc",
				Location = ACTION_COMPCLAS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT COMPCLAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX COMPCLAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX COMPCLAS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Compclas_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compclas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Delete_GET",
				AreaName = "compc",
				FormName = "COMPCLAS",
				Location = ACTION_COMPCLAS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Compclas();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE COMPCLAS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Compc/Compclas_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Compclas_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Compclas_Delete",
				ViewName = "Compclas",
				AreaName = "compc",
				Location = ACTION_COMPCLAS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE COMPCLAS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Compclas_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("COMPCLAS");
		}

		#endregion

		#region Compclas_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET COMPCLAS]/

		[HttpPost]
		public ActionResult Compclas_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Compclas_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Duplicate_GET",
				AreaName = "compc",
				FormName = "COMPCLAS",
				Location = ACTION_COMPCLAS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE COMPCLAS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Compc/Compclas_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST COMPCLAS]/
		[HttpPost]
		public ActionResult Compclas_Duplicate([FromBody]Compclas_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compclas_Duplicate",
				ViewName = "Compclas",
				AreaName = "compc",
				Location = ACTION_COMPCLAS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE COMPCLAS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX COMPCLAS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX COMPCLAS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Compclas_Cancel

		//
		// GET: /Compc/Compclas_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET COMPCLAS]/
		public ActionResult Compclas_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Compc model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("compc");

// USE /[MANUAL GQT BEFORE_CANCEL COMPCLAS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL COMPCLAS]/

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

				Navigation.SetValue("ForcePrimaryRead_compc", "true", true);
			}

			Navigation.ClearValue("compc");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Compc/Compclas_SaveEdit
		[HttpPost]
		public ActionResult Compclas_SaveEdit([FromBody] Compclas_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Compclas_SaveEdit",
				ViewName = "Compclas",
				AreaName = "compc",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT COMPCLAS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT COMPCLAS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class CompclasDocumValidateTickets : RequestDocumValidateTickets
		{
			public Compclas_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsCompclas([FromBody] CompclasDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
