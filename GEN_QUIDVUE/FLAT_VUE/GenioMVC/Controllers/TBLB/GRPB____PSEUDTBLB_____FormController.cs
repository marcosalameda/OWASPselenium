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
using GenioMVC.ViewModels.Tblb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TBLB]/

namespace GenioMVC.Controllers
{
	public partial class TblbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____CANCEL = new("CANCELAR49513", "Grpb____pseudtblb_____Cancel", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____SHOW = new("CONSULTA40695", "Grpb____pseudtblb_____Show", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____NEW = new("INSERIR43365", "Grpb____pseudtblb_____New", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____EDIT = new("EDITAR11616", "Grpb____pseudtblb_____Edit", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DUPLICATE = new("DUPLICAR09748", "Grpb____pseudtblb_____Duplicate", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GRPB____PSEUDTBLB_____DELETE = new("APAGAR04097", "Grpb____pseudtblb_____Delete", "Tblb") { vueRouteName = "form-GRPB____PSEUDTBLB____", mode = "DELETE" };

		#endregion

		#region Grpb____pseudtblb____ private

		private void FormHistoryLimits_Grpb____pseudtblb____()
		{

		}

		#endregion

		#region Grpb____pseudtblb_____Show

// USE /[MANUAL GQT CONTROLLER_SHOW GRPB____PSEUDTBLB____]/

		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Show_GET",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Grpb____pseudtblb_____New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____New_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____New([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____New",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Edit_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Edit([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Edit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Delete_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Grpb____pseudtblb____();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Delete",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Grpb____pseudtblb_____Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GRPB____PSEUDTBLB____");
		}

		#endregion

		#region Grpb____pseudtblb_____Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GRPB____PSEUDTBLB____]/

		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Grpb____pseudtblb_____ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Duplicate_GET",
				AreaName = "tblb",
				FormName = "GRPB____PSEUDTBLB____",
				Location = ACTION_GRPB____PSEUDTBLB_____DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tblb/Grpb____pseudtblb_____Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GRPB____PSEUDTBLB____]/
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____Duplicate([FromBody]Grpb____pseudtblb_____ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____Duplicate",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				Location = ACTION_GRPB____PSEUDTBLB_____DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GRPB____PSEUDTBLB____]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Grpb____pseudtblb_____Cancel

		//
		// GET: /Tblb/Grpb____pseudtblb_____Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GRPB____PSEUDTBLB____]/
		public ActionResult Grpb____pseudtblb_____Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("tblb");
					var model = GenioMVC.Models.Tblb.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("tblb");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL GRPB____PSEUDTBLB____]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GRPB____PSEUDTBLB____]/

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

				Navigation.SetValue("ForcePrimaryRead_tblb", "true", true);
			}

			Navigation.ClearValue("tblb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Tblb/Grpb____pseudtblb_____SaveEdit
		[HttpPost]
		public ActionResult Grpb____pseudtblb_____SaveEdit([FromBody] Grpb____pseudtblb_____ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Grpb____pseudtblb_____SaveEdit",
				ViewName = "Grpb____pseudtblb____",
				AreaName = "tblb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GRPB____PSEUDTBLB____]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GRPB____PSEUDTBLB____]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Grpb____pseudtblb____DocumValidateTickets : RequestDocumValidateTickets
		{
			public Grpb____pseudtblb_____ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGrpb____pseudtblb____([FromBody] Grpb____pseudtblb____DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
