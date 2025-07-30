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
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VENDAW03_CANCEL = new("PRE_ABORDAGEM30870", "Vendaw03_Cancel", "Sale") { vueRouteName = "form-VENDAW03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW03_SHOW = new("PRE_ABORDAGEM30870", "Vendaw03_Show", "Sale") { vueRouteName = "form-VENDAW03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW03_NEW = new("PRE_ABORDAGEM30870", "Vendaw03_New", "Sale") { vueRouteName = "form-VENDAW03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW03_EDIT = new("PRE_ABORDAGEM30870", "Vendaw03_Edit", "Sale") { vueRouteName = "form-VENDAW03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW03_DUPLICATE = new("PRE_ABORDAGEM30870", "Vendaw03_Duplicate", "Sale") { vueRouteName = "form-VENDAW03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW03_DELETE = new("PRE_ABORDAGEM30870", "Vendaw03_Delete", "Sale") { vueRouteName = "form-VENDAW03", mode = "DELETE" };

		#endregion

		#region Vendaw03 private

		private void FormHistoryLimits_Vendaw03()
		{

		}

		#endregion

		#region Vendaw03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW03]/

		[HttpPost]
		public ActionResult Vendaw03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_New_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_New([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_New",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Edit([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Edit",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Delete",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW03");
		}

		#endregion

		#region Vendaw03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW03]/

		[HttpPost]
		public ActionResult Vendaw03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW03",
				Location = ACTION_VENDAW03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW03]/
		[HttpPost]
		public ActionResult Vendaw03_Duplicate([FromBody]Vendaw03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw03_Duplicate",
				ViewName = "Vendaw03",
				AreaName = "sale",
				Location = ACTION_VENDAW03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw03_Cancel

		//
		// GET: /Sale/Vendaw03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW03]/
		public ActionResult Vendaw03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW03]/

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


		// POST: /Sale/Vendaw03_SaveEdit
		[HttpPost]
		public ActionResult Vendaw03_SaveEdit([FromBody] Vendaw03_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw03_SaveEdit",
				ViewName = "Vendaw03",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Vendaw03DocumValidateTickets : RequestDocumValidateTickets
		{
			public Vendaw03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsVendaw03([FromBody] Vendaw03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
