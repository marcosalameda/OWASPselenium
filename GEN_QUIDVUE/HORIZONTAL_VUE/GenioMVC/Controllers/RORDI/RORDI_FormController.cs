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
using GenioMVC.ViewModels.Rordi;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER RORDI]/

namespace GenioMVC.Controllers
{
	public partial class RordiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_RORDI_CANCEL = new("ORDER__INTEGER_FIELD38959", "Rordi_Cancel", "Rordi") { vueRouteName = "form-RORDI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_RORDI_SHOW = new("ORDER__INTEGER_FIELD38959", "Rordi_Show", "Rordi") { vueRouteName = "form-RORDI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_RORDI_NEW = new("ORDER__INTEGER_FIELD38959", "Rordi_New", "Rordi") { vueRouteName = "form-RORDI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_RORDI_EDIT = new("ORDER__INTEGER_FIELD38959", "Rordi_Edit", "Rordi") { vueRouteName = "form-RORDI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_RORDI_DUPLICATE = new("ORDER__INTEGER_FIELD38959", "Rordi_Duplicate", "Rordi") { vueRouteName = "form-RORDI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_RORDI_DELETE = new("ORDER__INTEGER_FIELD38959", "Rordi_Delete", "Rordi") { vueRouteName = "form-RORDI", mode = "DELETE" };

		#endregion

		#region Rordi private

		private void FormHistoryLimits_Rordi()
		{

		}

		#endregion

		#region Rordi_Show

// USE /[MANUAL GQT CONTROLLER_SHOW RORDI]/

		[HttpPost]
		public ActionResult Rordi_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Show_GET",
				AreaName = "rordi",
				Location = ACTION_RORDI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordi();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW RORDI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Rordi_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET RORDI]/
		[HttpPost]
		public ActionResult Rordi_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Rordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_New_GET",
				AreaName = "rordi",
				FormName = "RORDI",
				Location = ACTION_RORDI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Rordi();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW RORDI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Rordi/Rordi_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST RORDI]/
		[HttpPost]
		public ActionResult Rordi_New([FromBody]Rordi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_New",
				ViewName = "Rordi",
				AreaName = "rordi",
				Location = ACTION_RORDI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW RORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX RORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX RORDI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Rordi_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET RORDI]/
		[HttpPost]
		public ActionResult Rordi_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Edit_GET",
				AreaName = "rordi",
				FormName = "RORDI",
				Location = ACTION_RORDI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordi();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT RORDI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Rordi/Rordi_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST RORDI]/
		[HttpPost]
		public ActionResult Rordi_Edit([FromBody]Rordi_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Edit",
				ViewName = "Rordi",
				AreaName = "rordi",
				Location = ACTION_RORDI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT RORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX RORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX RORDI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Rordi_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET RORDI]/
		[HttpPost]
		public ActionResult Rordi_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Delete_GET",
				AreaName = "rordi",
				FormName = "RORDI",
				Location = ACTION_RORDI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Rordi();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE RORDI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Rordi/Rordi_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST RORDI]/
		[HttpPost]
		public ActionResult Rordi_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Rordi_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Delete",
				ViewName = "Rordi",
				AreaName = "rordi",
				Location = ACTION_RORDI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE RORDI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Rordi_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("RORDI");
		}

		#endregion

		#region Rordi_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET RORDI]/

		[HttpPost]
		public ActionResult Rordi_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Rordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Duplicate_GET",
				AreaName = "rordi",
				FormName = "RORDI",
				Location = ACTION_RORDI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE RORDI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Rordi/Rordi_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST RORDI]/
		[HttpPost]
		public ActionResult Rordi_Duplicate([FromBody]Rordi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_Duplicate",
				ViewName = "Rordi",
				AreaName = "rordi",
				Location = ACTION_RORDI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE RORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX RORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX RORDI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Rordi_Cancel

		//
		// GET: /Rordi/Rordi_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET RORDI]/
		public ActionResult Rordi_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Rordi(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("rordi");

// USE /[MANUAL GQT BEFORE_CANCEL RORDI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL RORDI]/

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

				Navigation.SetValue("ForcePrimaryRead_rordi", "true", true);
			}

			Navigation.ClearValue("rordi");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Rordi/Rordi_SaveEdit
		[HttpPost]
		public ActionResult Rordi_SaveEdit([FromBody]Rordi_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Rordi_SaveEdit",
				ViewName = "Rordi",
				AreaName = "rordi",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT RORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT RORDI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
