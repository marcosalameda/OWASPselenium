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
using GenioMVC.ViewModels.Glob;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GLOB]/

namespace GenioMVC.Controllers
{
	public partial class GlobController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_HOMEG_CANCEL = new("CANCELAR49513", "Homeg_Cancel", "Glob") { vueRouteName = "form-HOMEG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_HOMEG_SHOW = new("CONSULTA40695", "Homeg_Show", "Glob") { vueRouteName = "form-HOMEG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_HOMEG_NEW = new("INSERIR43365", "Homeg_New", "Glob") { vueRouteName = "form-HOMEG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_HOMEG_EDIT = new("EDITAR11616", "Homeg_Edit", "Glob") { vueRouteName = "form-HOMEG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_HOMEG_DUPLICATE = new("DUPLICAR09748", "Homeg_Duplicate", "Glob") { vueRouteName = "form-HOMEG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_HOMEG_DELETE = new("APAGAR04097", "Homeg_Delete", "Glob") { vueRouteName = "form-HOMEG", mode = "DELETE" };

		#endregion

		#region Homeg private

		private void FormHistoryLimits_Homeg()
		{

		}

		#endregion

		#region Homeg_Show

// USE /[MANUAL GQT CONTROLLER_SHOW HOMEG]/

		[HttpPost]
		public ActionResult Homeg_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Homeg_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Show_GET",
				AreaName = "glob",
				Location = ACTION_HOMEG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Homeg();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW HOMEG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Homeg_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET HOMEG]/
		[HttpPost]
		public ActionResult Homeg_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Homeg_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Homeg_New_GET",
				AreaName = "glob",
				FormName = "HOMEG",
				Location = ACTION_HOMEG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Homeg();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW HOMEG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Glob/Homeg_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST HOMEG]/
		[HttpPost]
		public ActionResult Homeg_New([FromBody]Homeg_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Homeg_New",
				ViewName = "Homeg",
				AreaName = "glob",
				Location = ACTION_HOMEG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW HOMEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX HOMEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX HOMEG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Homeg_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET HOMEG]/
		[HttpPost]
		public ActionResult Homeg_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Homeg_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Edit_GET",
				AreaName = "glob",
				FormName = "HOMEG",
				Location = ACTION_HOMEG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Homeg();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT HOMEG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Glob/Homeg_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST HOMEG]/
		[HttpPost]
		public ActionResult Homeg_Edit([FromBody]Homeg_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Edit",
				ViewName = "Homeg",
				AreaName = "glob",
				Location = ACTION_HOMEG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT HOMEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX HOMEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX HOMEG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Homeg_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET HOMEG]/
		[HttpPost]
		public ActionResult Homeg_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Homeg_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Delete_GET",
				AreaName = "glob",
				FormName = "HOMEG",
				Location = ACTION_HOMEG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Homeg();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE HOMEG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Glob/Homeg_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST HOMEG]/
		[HttpPost]
		public ActionResult Homeg_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Homeg_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Homeg_Delete",
				ViewName = "Homeg",
				AreaName = "glob",
				Location = ACTION_HOMEG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE HOMEG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Homeg_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("HOMEG");
		}

		#endregion

		#region Homeg_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET HOMEG]/

		[HttpPost]
		public ActionResult Homeg_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Homeg_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Duplicate_GET",
				AreaName = "glob",
				FormName = "HOMEG",
				Location = ACTION_HOMEG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE HOMEG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Glob/Homeg_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST HOMEG]/
		[HttpPost]
		public ActionResult Homeg_Duplicate([FromBody]Homeg_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Homeg_Duplicate",
				ViewName = "Homeg",
				AreaName = "glob",
				Location = ACTION_HOMEG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE HOMEG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX HOMEG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX HOMEG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Homeg_Cancel

		//
		// GET: /Glob/Homeg_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET HOMEG]/
		public ActionResult Homeg_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("glob");
					var model = GenioMVC.Models.Glob.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("glob");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL HOMEG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL HOMEG]/

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

				Navigation.SetValue("ForcePrimaryRead_glob", "true", true);
			}

			Navigation.ClearValue("glob");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Glob/Homeg_SaveEdit
		[HttpPost]
		public ActionResult Homeg_SaveEdit([FromBody] Homeg_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Homeg_SaveEdit",
				ViewName = "Homeg",
				AreaName = "glob",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT HOMEG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT HOMEG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class HomegDocumValidateTickets : RequestDocumValidateTickets
		{
			public Homeg_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsHomeg([FromBody] HomegDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
