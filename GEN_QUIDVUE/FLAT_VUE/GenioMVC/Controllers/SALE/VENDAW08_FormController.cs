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

		private static readonly NavigationLocation ACTION_VENDAW08_CANCEL = new("ACOMPANHAMENTO53507", "Vendaw08_Cancel", "Sale") { vueRouteName = "form-VENDAW08", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW08_SHOW = new("ACOMPANHAMENTO53507", "Vendaw08_Show", "Sale") { vueRouteName = "form-VENDAW08", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW08_NEW = new("ACOMPANHAMENTO53507", "Vendaw08_New", "Sale") { vueRouteName = "form-VENDAW08", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW08_EDIT = new("ACOMPANHAMENTO53507", "Vendaw08_Edit", "Sale") { vueRouteName = "form-VENDAW08", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW08_DUPLICATE = new("ACOMPANHAMENTO53507", "Vendaw08_Duplicate", "Sale") { vueRouteName = "form-VENDAW08", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW08_DELETE = new("ACOMPANHAMENTO53507", "Vendaw08_Delete", "Sale") { vueRouteName = "form-VENDAW08", mode = "DELETE" };

		#endregion

		#region Vendaw08 private

		private void FormHistoryLimits_Vendaw08()
		{

		}

		#endregion

		#region Vendaw08_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW08]/

		[HttpPost]
		public ActionResult Vendaw08_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw08_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW08_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw08();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW08]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw08_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Vendaw08_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_New_GET",
				AreaName = "sale",
				FormName = "VENDAW08",
				Location = ACTION_VENDAW08_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw08();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW08]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw08_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_New([FromBody]Vendaw08_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_New",
				ViewName = "Vendaw08",
				AreaName = "sale",
				Location = ACTION_VENDAW08_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW08]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw08_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw08_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW08",
				Location = ACTION_VENDAW08_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw08();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW08]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw08_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_Edit([FromBody]Vendaw08_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Edit",
				ViewName = "Vendaw08",
				AreaName = "sale",
				Location = ACTION_VENDAW08_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW08]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw08_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw08_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW08",
				Location = ACTION_VENDAW08_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw08();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW08]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw08_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Vendaw08_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Delete",
				ViewName = "Vendaw08",
				AreaName = "sale",
				Location = ACTION_VENDAW08_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW08]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw08_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW08");
		}

		#endregion

		#region Vendaw08_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW08]/

		[HttpPost]
		public ActionResult Vendaw08_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Vendaw08_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW08",
				Location = ACTION_VENDAW08_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW08]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw08_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW08]/
		[HttpPost]
		public ActionResult Vendaw08_Duplicate([FromBody]Vendaw08_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_Duplicate",
				ViewName = "Vendaw08",
				AreaName = "sale",
				Location = ACTION_VENDAW08_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW08]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw08_Cancel

		//
		// GET: /Sale/Vendaw08_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW08]/
		public ActionResult Vendaw08_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Sale model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW08]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW08]/

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


		// POST: /Sale/Vendaw08_SaveEdit
		[HttpPost]
		public ActionResult Vendaw08_SaveEdit([FromBody] Vendaw08_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Vendaw08_SaveEdit",
				ViewName = "Vendaw08",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW08]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Vendaw08DocumValidateTickets : RequestDocumValidateTickets
		{
			public Vendaw08_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsVendaw08([FromBody] Vendaw08DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
