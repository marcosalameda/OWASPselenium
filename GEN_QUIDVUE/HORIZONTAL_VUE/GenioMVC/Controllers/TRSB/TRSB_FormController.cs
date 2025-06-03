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
using GenioMVC.ViewModels.Trsb;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TRSB]/

namespace GenioMVC.Controllers
{
	public partial class TrsbController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TRSB_CANCEL = new("RELATED_TABLE__BASIC33628", "Trsb_Cancel", "Trsb") { vueRouteName = "form-TRSB", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TRSB_SHOW = new("RELATED_TABLE__BASIC33628", "Trsb_Show", "Trsb") { vueRouteName = "form-TRSB", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TRSB_NEW = new("RELATED_TABLE__BASIC33628", "Trsb_New", "Trsb") { vueRouteName = "form-TRSB", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TRSB_EDIT = new("RELATED_TABLE__BASIC33628", "Trsb_Edit", "Trsb") { vueRouteName = "form-TRSB", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TRSB_DUPLICATE = new("RELATED_TABLE__BASIC33628", "Trsb_Duplicate", "Trsb") { vueRouteName = "form-TRSB", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TRSB_DELETE = new("RELATED_TABLE__BASIC33628", "Trsb_Delete", "Trsb") { vueRouteName = "form-TRSB", mode = "DELETE" };

		#endregion

		#region Trsb private

		private void FormHistoryLimits_Trsb()
		{

		}

		#endregion

		#region Trsb_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TRSB]/

		[HttpPost]
		public ActionResult Trsb_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Trsb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Show_GET",
				AreaName = "trsb",
				Location = ACTION_TRSB_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Trsb();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TRSB]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Trsb_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TRSB]/
		[HttpPost]
		public ActionResult Trsb_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Trsb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_New_GET",
				AreaName = "trsb",
				FormName = "TRSB",
				Location = ACTION_TRSB_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Trsb();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TRSB]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Trsb/Trsb_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TRSB]/
		[HttpPost]
		public ActionResult Trsb_New([FromBody]Trsb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_New",
				ViewName = "Trsb",
				AreaName = "trsb",
				Location = ACTION_TRSB_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TRSB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TRSB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TRSB]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Trsb_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TRSB]/
		[HttpPost]
		public ActionResult Trsb_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Trsb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Edit_GET",
				AreaName = "trsb",
				FormName = "TRSB",
				Location = ACTION_TRSB_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Trsb();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TRSB]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Trsb/Trsb_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TRSB]/
		[HttpPost]
		public ActionResult Trsb_Edit([FromBody]Trsb_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Edit",
				ViewName = "Trsb",
				AreaName = "trsb",
				Location = ACTION_TRSB_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TRSB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TRSB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TRSB]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Trsb_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TRSB]/
		[HttpPost]
		public ActionResult Trsb_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Trsb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Delete_GET",
				AreaName = "trsb",
				FormName = "TRSB",
				Location = ACTION_TRSB_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Trsb();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TRSB]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Trsb/Trsb_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TRSB]/
		[HttpPost]
		public ActionResult Trsb_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Trsb_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Delete",
				ViewName = "Trsb",
				AreaName = "trsb",
				Location = ACTION_TRSB_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TRSB]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Trsb_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TRSB");
		}

		#endregion

		#region Trsb_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TRSB]/

		[HttpPost]
		public ActionResult Trsb_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Trsb_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Duplicate_GET",
				AreaName = "trsb",
				FormName = "TRSB",
				Location = ACTION_TRSB_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TRSB]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Trsb/Trsb_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TRSB]/
		[HttpPost]
		public ActionResult Trsb_Duplicate([FromBody]Trsb_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_Duplicate",
				ViewName = "Trsb",
				AreaName = "trsb",
				Location = ACTION_TRSB_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TRSB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TRSB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TRSB]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Trsb_Cancel

		//
		// GET: /Trsb/Trsb_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TRSB]/
		public ActionResult Trsb_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Trsb(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("trsb");

// USE /[MANUAL GQT BEFORE_CANCEL TRSB]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TRSB]/

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

				Navigation.SetValue("ForcePrimaryRead_trsb", "true", true);
			}

			Navigation.ClearValue("trsb");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Trsb/Trsb_SaveEdit
		[HttpPost]
		public ActionResult Trsb_SaveEdit([FromBody]Trsb_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Trsb_SaveEdit",
				ViewName = "Trsb",
				AreaName = "trsb",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TRSB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TRSB]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
