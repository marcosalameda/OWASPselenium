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

		private static readonly NavigationLocation ACTION_VENDAW07_CANCEL = new("FECHO_DA_VENDA48081", "Vendaw07_Cancel", "Sale") { vueRouteName = "form-VENDAW07", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW07_SHOW = new("FECHO_DA_VENDA48081", "Vendaw07_Show", "Sale") { vueRouteName = "form-VENDAW07", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW07_NEW = new("FECHO_DA_VENDA48081", "Vendaw07_New", "Sale") { vueRouteName = "form-VENDAW07", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW07_EDIT = new("FECHO_DA_VENDA48081", "Vendaw07_Edit", "Sale") { vueRouteName = "form-VENDAW07", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW07_DUPLICATE = new("FECHO_DA_VENDA48081", "Vendaw07_Duplicate", "Sale") { vueRouteName = "form-VENDAW07", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW07_DELETE = new("FECHO_DA_VENDA48081", "Vendaw07_Delete", "Sale") { vueRouteName = "form-VENDAW07", mode = "DELETE" };

		#endregion

		#region Vendaw07 private

		private void FormHistoryLimits_Vendaw07()
		{

		}

		#endregion

		#region Vendaw07_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW07]/

		[HttpPost]
		public ActionResult Vendaw07_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW07_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW07]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw07_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_New_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW07]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw07_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_New([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_New",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw07_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW07]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw07_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Edit([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Edit",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw07_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw07();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW07]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw07_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw07_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Delete",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW07]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw07_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW07");
		}

		#endregion

		#region Vendaw07_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW07]/

		[HttpPost]
		public ActionResult Vendaw07_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw07_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW07",
				Location = ACTION_VENDAW07_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW07]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw07_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW07]/
		[HttpPost]
		public ActionResult Vendaw07_Duplicate([FromBody]Vendaw07_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_Duplicate",
				ViewName = "Vendaw07",
				AreaName = "sale",
				Location = ACTION_VENDAW07_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW07]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW07]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW07]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw07_Cancel

		//
		// GET: /Sale/Vendaw07_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW07]/
		public ActionResult Vendaw07_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW07]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW07]/

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



		// POST: /Sale/Vendaw07_SaveEdit
		[HttpPost]
		public ActionResult Vendaw07_SaveEdit([FromBody] Vendaw07_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw07_SaveEdit",
				ViewName = "Vendaw07",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW07]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW07]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Vendaw07DocumValidateTickets : RequestDocumValidateTickets
		{
			public Vendaw07_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsVendaw07([FromBody] Vendaw07DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
