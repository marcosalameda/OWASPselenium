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
using GenioMVC.ViewModels.Oudoc;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER OUDOC]/

namespace GenioMVC.Controllers
{
	public partial class OudocController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DOCSD_CANCEL = new("OUTPUT_DOCUMENT44972", "Docsd_Cancel", "Oudoc") { vueRouteName = "form-DOCSD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DOCSD_SHOW = new("OUTPUT_DOCUMENT44972", "Docsd_Show", "Oudoc") { vueRouteName = "form-DOCSD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DOCSD_NEW = new("OUTPUT_DOCUMENT44972", "Docsd_New", "Oudoc") { vueRouteName = "form-DOCSD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DOCSD_EDIT = new("OUTPUT_DOCUMENT44972", "Docsd_Edit", "Oudoc") { vueRouteName = "form-DOCSD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DOCSD_DUPLICATE = new("OUTPUT_DOCUMENT44972", "Docsd_Duplicate", "Oudoc") { vueRouteName = "form-DOCSD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DOCSD_DELETE = new("OUTPUT_DOCUMENT44972", "Docsd_Delete", "Oudoc") { vueRouteName = "form-DOCSD", mode = "DELETE" };

		#endregion

		#region Docsd private

		private void FormHistoryLimits_Docsd()
		{

		}

		#endregion

		#region Docsd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DOCSD]/

		[HttpPost]
		public ActionResult Docsd_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Docsd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Show_GET",
				AreaName = "oudoc",
				Location = ACTION_DOCSD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Docsd();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DOCSD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Docsd_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DOCSD]/
		[HttpPost]
		public ActionResult Docsd_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Docsd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_New_GET",
				AreaName = "oudoc",
				FormName = "DOCSD",
				Location = ACTION_DOCSD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Docsd();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DOCSD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Oudoc/Docsd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DOCSD]/
		[HttpPost]
		public ActionResult Docsd_New([FromBody]Docsd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_New",
				ViewName = "Docsd",
				AreaName = "oudoc",
				Location = ACTION_DOCSD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DOCSD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DOCSD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DOCSD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Docsd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DOCSD]/
		[HttpPost]
		public ActionResult Docsd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Docsd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Edit_GET",
				AreaName = "oudoc",
				FormName = "DOCSD",
				Location = ACTION_DOCSD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Docsd();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DOCSD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Oudoc/Docsd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DOCSD]/
		[HttpPost]
		public ActionResult Docsd_Edit([FromBody]Docsd_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Edit",
				ViewName = "Docsd",
				AreaName = "oudoc",
				Location = ACTION_DOCSD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DOCSD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DOCSD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DOCSD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Docsd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DOCSD]/
		[HttpPost]
		public ActionResult Docsd_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Docsd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Delete_GET",
				AreaName = "oudoc",
				FormName = "DOCSD",
				Location = ACTION_DOCSD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Docsd();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DOCSD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Oudoc/Docsd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DOCSD]/
		[HttpPost]
		public ActionResult Docsd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Docsd_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Delete",
				ViewName = "Docsd",
				AreaName = "oudoc",
				Location = ACTION_DOCSD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DOCSD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Docsd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DOCSD");
		}

		#endregion

		#region Docsd_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DOCSD]/

		[HttpPost]
		public ActionResult Docsd_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Docsd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Duplicate_GET",
				AreaName = "oudoc",
				FormName = "DOCSD",
				Location = ACTION_DOCSD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DOCSD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Oudoc/Docsd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DOCSD]/
		[HttpPost]
		public ActionResult Docsd_Duplicate([FromBody]Docsd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_Duplicate",
				ViewName = "Docsd",
				AreaName = "oudoc",
				Location = ACTION_DOCSD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DOCSD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DOCSD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DOCSD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Docsd_Cancel

		//
		// GET: /Oudoc/Docsd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DOCSD]/
		public ActionResult Docsd_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Oudoc(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("oudoc");

// USE /[MANUAL GQT BEFORE_CANCEL DOCSD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DOCSD]/

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

				Navigation.SetValue("ForcePrimaryRead_oudoc", "true", true);
			}

			Navigation.ClearValue("oudoc");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Oudoc/Docsd_SaveEdit
		[HttpPost]
		public ActionResult Docsd_SaveEdit([FromBody]Docsd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Docsd_SaveEdit",
				ViewName = "Docsd",
				AreaName = "oudoc",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DOCSD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DOCSD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
