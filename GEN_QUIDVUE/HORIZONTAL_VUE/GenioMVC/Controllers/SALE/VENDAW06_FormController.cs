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

		private static readonly NavigationLocation ACTION_VENDAW06_CANCEL = new("SUPERAR_OBJECOES02243", "Vendaw06_Cancel", "Sale") { vueRouteName = "form-VENDAW06", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDAW06_SHOW = new("SUPERAR_OBJECOES02243", "Vendaw06_Show", "Sale") { vueRouteName = "form-VENDAW06", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDAW06_NEW = new("SUPERAR_OBJECOES02243", "Vendaw06_New", "Sale") { vueRouteName = "form-VENDAW06", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDAW06_EDIT = new("SUPERAR_OBJECOES02243", "Vendaw06_Edit", "Sale") { vueRouteName = "form-VENDAW06", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDAW06_DUPLICATE = new("SUPERAR_OBJECOES02243", "Vendaw06_Duplicate", "Sale") { vueRouteName = "form-VENDAW06", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDAW06_DELETE = new("SUPERAR_OBJECOES02243", "Vendaw06_Delete", "Sale") { vueRouteName = "form-VENDAW06", mode = "DELETE" };

		#endregion

		#region Vendaw06 private

		private void FormHistoryLimits_Vendaw06()
		{

		}

		#endregion

		#region Vendaw06_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDAW06]/

		[HttpPost]
		public ActionResult Vendaw06_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDAW06_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDAW06]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Vendaw06_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_New_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDAW06]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Vendaw06_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_New([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_New",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Vendaw06_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Edit_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDAW06]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw06_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Edit([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Edit",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Vendaw06_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Delete_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Vendaw06();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDAW06]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Vendaw06_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Vendaw06_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Delete",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDAW06]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Vendaw06_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDAW06");
		}

		#endregion

		#region Vendaw06_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDAW06]/

		[HttpPost]
		public ActionResult Vendaw06_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Vendaw06_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDAW06",
				Location = ACTION_VENDAW06_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDAW06]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Vendaw06_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDAW06]/
		[HttpPost]
		public ActionResult Vendaw06_Duplicate([FromBody]Vendaw06_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_Duplicate",
				ViewName = "Vendaw06",
				AreaName = "sale",
				Location = ACTION_VENDAW06_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDAW06]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDAW06]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDAW06]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Vendaw06_Cancel

		//
		// GET: /Sale/Vendaw06_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDAW06]/
		public ActionResult Vendaw06_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDAW06]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDAW06]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

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



		// POST: /Sale/Vendaw06_SaveEdit
		[HttpPost]
		public ActionResult Vendaw06_SaveEdit([FromBody]Vendaw06_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Vendaw06_SaveEdit",
				ViewName = "Vendaw06",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDAW06]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDAW06]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
