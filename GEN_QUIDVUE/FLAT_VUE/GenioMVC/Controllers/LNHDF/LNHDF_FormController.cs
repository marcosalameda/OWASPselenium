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
using GenioMVC.ViewModels.Lnhdf;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHDF]/

namespace GenioMVC.Controllers
{
	public partial class LnhdfController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHDF_CANCEL = new("DISAGGREGATION_LINES45819", "Lnhdf_Cancel", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHDF_SHOW = new("DISAGGREGATION_LINES45819", "Lnhdf_Show", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHDF_NEW = new("DISAGGREGATION_LINES45819", "Lnhdf_New", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHDF_EDIT = new("DISAGGREGATION_LINES45819", "Lnhdf_Edit", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHDF_DUPLICATE = new("DISAGGREGATION_LINES45819", "Lnhdf_Duplicate", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHDF_DELETE = new("DISAGGREGATION_LINES45819", "Lnhdf_Delete", "Lnhdf") { vueRouteName = "form-LNHDF", mode = "DELETE" };

		#endregion

		#region Lnhdf private

		private void FormHistoryLimits_Lnhdf()
		{

		}

		#endregion

		#region Lnhdf_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHDF]/

		[HttpPost]
		public ActionResult Lnhdf_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhdf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Show_GET",
				AreaName = "lnhdf",
				Location = ACTION_LNHDF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhdf();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHDF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lnhdf_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lnhdf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_New_GET",
				AreaName = "lnhdf",
				FormName = "LNHDF",
				Location = ACTION_LNHDF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lnhdf();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHDF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lnhdf/Lnhdf_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_New([FromBody]Lnhdf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_New",
				ViewName = "Lnhdf",
				AreaName = "lnhdf",
				Location = ACTION_LNHDF_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHDF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lnhdf_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhdf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Edit_GET",
				AreaName = "lnhdf",
				FormName = "LNHDF",
				Location = ACTION_LNHDF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhdf();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHDF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lnhdf/Lnhdf_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_Edit([FromBody]Lnhdf_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Edit",
				ViewName = "Lnhdf",
				AreaName = "lnhdf",
				Location = ACTION_LNHDF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHDF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lnhdf_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhdf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Delete_GET",
				AreaName = "lnhdf",
				FormName = "LNHDF",
				Location = ACTION_LNHDF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhdf();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHDF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lnhdf/Lnhdf_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhdf_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Delete",
				ViewName = "Lnhdf",
				AreaName = "lnhdf",
				Location = ACTION_LNHDF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHDF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lnhdf_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHDF");
		}

		#endregion

		#region Lnhdf_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHDF]/

		[HttpPost]
		public ActionResult Lnhdf_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lnhdf_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Duplicate_GET",
				AreaName = "lnhdf",
				FormName = "LNHDF",
				Location = ACTION_LNHDF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHDF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lnhdf/Lnhdf_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHDF]/
		[HttpPost]
		public ActionResult Lnhdf_Duplicate([FromBody]Lnhdf_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_Duplicate",
				ViewName = "Lnhdf",
				AreaName = "lnhdf",
				Location = ACTION_LNHDF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHDF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHDF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHDF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lnhdf_Cancel

		//
		// GET: /Lnhdf/Lnhdf_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHDF]/
		public ActionResult Lnhdf_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhdf(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhdf");

// USE /[MANUAL GQT BEFORE_CANCEL LNHDF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHDF]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhdf", "true", true);
			}

			Navigation.ClearValue("lnhdf");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Lnhdf/Lnhdf_SaveEdit
		[HttpPost]
		public ActionResult Lnhdf_SaveEdit([FromBody]Lnhdf_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhdf_SaveEdit",
				ViewName = "Lnhdf",
				AreaName = "lnhdf",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHDF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHDF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
