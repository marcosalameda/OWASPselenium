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

		private static readonly NavigationLocation ACTION_VENDAW04_CANCEL = new("ABORDAGEM05839", "Vendaw04_Cancel", "Sale") { vueRouteName = "form-VENDAW04", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW04_SHOW = new("ABORDAGEM05839", "Vendaw04_Show", "Sale") { vueRouteName = "form-VENDAW04", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW04_NEW = new("ABORDAGEM05839", "Vendaw04_New", "Sale") { vueRouteName = "form-VENDAW04", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW04_EDIT = new("ABORDAGEM05839", "Vendaw04_Edit", "Sale") { vueRouteName = "form-VENDAW04", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW04_DUPLICATE = new("ABORDAGEM05839", "Vendaw04_Duplicate", "Sale") { vueRouteName = "form-VENDAW04", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW04_DELETE = new("ABORDAGEM05839", "Vendaw04_Delete", "Sale") { vueRouteName = "form-VENDAW04", mode = "DELETE" };

		#endregion

		#region Vendaw04 private

		private void FormHistoryLimits_Vendaw04()
		{

		}

		#endregion

		#region Vendaw04_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW04]/

		[HttpPost]
		public ActionResult Vendaw04_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw04_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW04_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw04();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW04]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw04_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw04_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_New_GET",
				AreaName = "sale",
				FormName = "VENDAW04",
				Location = ACTION_VENDAW04_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw04();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW04]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw04_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_New([FromBody]Vendaw04_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_New",
				ViewName = "Vendaw04",
				AreaName = "sale",
				Location = ACTION_VENDAW04_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW04]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW04]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW04]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw04_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw04_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW04",
				Location = ACTION_VENDAW04_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw04();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW04]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw04_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_Edit([FromBody]Vendaw04_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Edit",
				ViewName = "Vendaw04",
				AreaName = "sale",
				Location = ACTION_VENDAW04_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW04]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW04]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW04]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw04_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw04_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW04",
				Location = ACTION_VENDAW04_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw04();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW04]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw04_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw04_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Delete",
				ViewName = "Vendaw04",
				AreaName = "sale",
				Location = ACTION_VENDAW04_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW04]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw04_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW04");
		}

		#endregion

		#region Vendaw04_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW04]/

		[HttpPost]
		public ActionResult Vendaw04_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw04_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW04",
				Location = ACTION_VENDAW04_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW04]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw04_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW04]/
		[HttpPost]
		public ActionResult Vendaw04_Duplicate([FromBody]Vendaw04_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_Duplicate",
				ViewName = "Vendaw04",
				AreaName = "sale",
				Location = ACTION_VENDAW04_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW04]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW04]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW04]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw04_Cancel

		//
		// GET: /Sale/Vendaw04_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW04]/
		public ActionResult Vendaw04_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW04]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW04]/

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



		// POST: /Sale/Vendaw04_SaveEdit
		[HttpPost]
		public ActionResult Vendaw04_SaveEdit([FromBody]Vendaw04_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw04_SaveEdit",
				ViewName = "Vendaw04",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW04]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW04]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
