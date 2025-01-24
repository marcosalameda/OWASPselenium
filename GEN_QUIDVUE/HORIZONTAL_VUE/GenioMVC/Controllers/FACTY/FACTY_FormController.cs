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
using GenioMVC.ViewModels.Facty;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FACTY]/

namespace GenioMVC.Controllers
{
	public partial class FactyController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FACTY_CANCEL = new("FACILITY_TYPE44577", "Facty_Cancel", "Facty") { vueRouteName = "form-FACTY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FACTY_SHOW = new("FACILITY_TYPE44577", "Facty_Show", "Facty") { vueRouteName = "form-FACTY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FACTY_NEW = new("FACILITY_TYPE44577", "Facty_New", "Facty") { vueRouteName = "form-FACTY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FACTY_EDIT = new("FACILITY_TYPE44577", "Facty_Edit", "Facty") { vueRouteName = "form-FACTY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FACTY_DUPLICATE = new("FACILITY_TYPE44577", "Facty_Duplicate", "Facty") { vueRouteName = "form-FACTY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FACTY_DELETE = new("FACILITY_TYPE44577", "Facty_Delete", "Facty") { vueRouteName = "form-FACTY", mode = "DELETE" };

		#endregion

		#region Facty private

		private void FormHistoryLimits_Facty()
		{

		}

		#endregion

		#region Facty_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FACTY]/

		[HttpPost]
		public ActionResult Facty_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facty_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Show_GET",
				AreaName = "facty",
				Location = ACTION_FACTY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facty();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FACTY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Facty_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FACTY]/
		[HttpPost]
		public ActionResult Facty_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Facty_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facty_New_GET",
				AreaName = "facty",
				FormName = "FACTY",
				Location = ACTION_FACTY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Facty();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FACTY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Facty/Facty_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FACTY]/
		[HttpPost]
		public ActionResult Facty_New([FromBody]Facty_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facty_New",
				ViewName = "Facty",
				AreaName = "facty",
				Location = ACTION_FACTY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FACTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FACTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FACTY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Facty_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FACTY]/
		[HttpPost]
		public ActionResult Facty_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facty_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Edit_GET",
				AreaName = "facty",
				FormName = "FACTY",
				Location = ACTION_FACTY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facty();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FACTY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Facty/Facty_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FACTY]/
		[HttpPost]
		public ActionResult Facty_Edit([FromBody]Facty_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Edit",
				ViewName = "Facty",
				AreaName = "facty",
				Location = ACTION_FACTY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FACTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FACTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FACTY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Facty_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FACTY]/
		[HttpPost]
		public ActionResult Facty_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facty_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Delete_GET",
				AreaName = "facty",
				FormName = "FACTY",
				Location = ACTION_FACTY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Facty();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FACTY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Facty/Facty_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FACTY]/
		[HttpPost]
		public ActionResult Facty_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Facty_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Facty_Delete",
				ViewName = "Facty",
				AreaName = "facty",
				Location = ACTION_FACTY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FACTY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Facty_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FACTY");
		}

		#endregion

		#region Facty_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FACTY]/

		[HttpPost]
		public ActionResult Facty_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Facty_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Duplicate_GET",
				AreaName = "facty",
				FormName = "FACTY",
				Location = ACTION_FACTY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FACTY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Facty/Facty_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FACTY]/
		[HttpPost]
		public ActionResult Facty_Duplicate([FromBody]Facty_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facty_Duplicate",
				ViewName = "Facty",
				AreaName = "facty",
				Location = ACTION_FACTY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FACTY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FACTY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FACTY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Facty_Cancel

		//
		// GET: /Facty/Facty_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FACTY]/
		public ActionResult Facty_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Facty(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("facty");

// USE /[MANUAL GQT BEFORE_CANCEL FACTY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FACTY]/

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

				Navigation.SetValue("ForcePrimaryRead_facty", "true", true);
			}

			Navigation.ClearValue("facty");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Facty/Facty_SaveEdit
		[HttpPost]
		public ActionResult Facty_SaveEdit([FromBody]Facty_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Facty_SaveEdit",
				ViewName = "Facty",
				AreaName = "facty",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FACTY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FACTY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
