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
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VENDAW05_CANCEL = new("APRESENTACAO15975", "Vendaw05_Cancel", "Sale") { vueRouteName = "form-VENDAW05", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW05_SHOW = new("APRESENTACAO15975", "Vendaw05_Show", "Sale") { vueRouteName = "form-VENDAW05", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW05_NEW = new("APRESENTACAO15975", "Vendaw05_New", "Sale") { vueRouteName = "form-VENDAW05", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW05_EDIT = new("APRESENTACAO15975", "Vendaw05_Edit", "Sale") { vueRouteName = "form-VENDAW05", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW05_DUPLICATE = new("APRESENTACAO15975", "Vendaw05_Duplicate", "Sale") { vueRouteName = "form-VENDAW05", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW05_DELETE = new("APRESENTACAO15975", "Vendaw05_Delete", "Sale") { vueRouteName = "form-VENDAW05", mode = "DELETE" };

		#endregion

		#region Vendaw05 private

		private void FormHistoryLimits_Vendaw05()
		{

		}

		#endregion

		#region Vendaw05_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW05]/

		[HttpPost]
		public ActionResult Vendaw05_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW05_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW05]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw05_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Vendaw05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_New_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW05]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw05_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_New([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_New",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw05_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW05]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw05_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Edit([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Edit",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw05_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw05();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW05]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw05_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw05_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Delete",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW05]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw05_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW05");
		}

		#endregion

		#region Vendaw05_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW05]/

		[HttpPost]
		public ActionResult Vendaw05_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Vendaw05_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW05",
				Location = ACTION_VENDAW05_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW05]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw05_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW05]/
		[HttpPost]
		public ActionResult Vendaw05_Duplicate([FromBody]Vendaw05_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_Duplicate",
				ViewName = "Vendaw05",
				AreaName = "sale",
				Location = ACTION_VENDAW05_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW05]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW05]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW05]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw05_Cancel

		//
		// GET: /Sale/Vendaw05_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW05]/
		public ActionResult Vendaw05_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("sale");
					var model = GenioMVC.Models.Sale.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("sale");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW05]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW05]/

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

				Navigation.SetValue("ForcePrimaryRead_sale", "true", true);
			}

			Navigation.ClearValue("sale");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Sale/Vendaw05_SaveEdit
		[HttpPost]
		public ActionResult Vendaw05_SaveEdit([FromBody] Vendaw05_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw05_SaveEdit",
				ViewName = "Vendaw05",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW05]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW05]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Vendaw05DocumValidateTickets : RequestDocumValidateTickets
		{
			public Vendaw05_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsVendaw05([FromBody] Vendaw05DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
