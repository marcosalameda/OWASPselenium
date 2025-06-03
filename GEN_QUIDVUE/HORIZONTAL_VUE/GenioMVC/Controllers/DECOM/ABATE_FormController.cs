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
using GenioMVC.ViewModels.Decom;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DECOM]/

namespace GenioMVC.Controllers
{
	public partial class DecomController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ABATE_CANCEL = new("EQUIPMENT_DECOMMISSI11875", "Abate_Cancel", "Decom") { vueRouteName = "form-ABATE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ABATE_SHOW = new("EQUIPMENT_DECOMMISSI11875", "Abate_Show", "Decom") { vueRouteName = "form-ABATE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ABATE_NEW = new("EQUIPMENT_DECOMMISSI11875", "Abate_New", "Decom") { vueRouteName = "form-ABATE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ABATE_EDIT = new("EQUIPMENT_DECOMMISSI11875", "Abate_Edit", "Decom") { vueRouteName = "form-ABATE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ABATE_DUPLICATE = new("EQUIPMENT_DECOMMISSI11875", "Abate_Duplicate", "Decom") { vueRouteName = "form-ABATE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ABATE_DELETE = new("EQUIPMENT_DECOMMISSI11875", "Abate_Delete", "Decom") { vueRouteName = "form-ABATE", mode = "DELETE" };

		#endregion

		#region Abate private

		private void FormHistoryLimits_Abate()
		{

		}

		#endregion

		#region Abate_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ABATE]/

		[HttpPost]
		public ActionResult Abate_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Abate_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Show_GET",
				AreaName = "decom",
				Location = ACTION_ABATE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abate();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ABATE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Abate_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ABATE]/
		[HttpPost]
		public ActionResult Abate_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Abate_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Abate_New_GET",
				AreaName = "decom",
				FormName = "ABATE",
				Location = ACTION_ABATE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Abate();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ABATE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Decom/Abate_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ABATE]/
		[HttpPost]
		public ActionResult Abate_New([FromBody]Abate_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Abate_New",
				ViewName = "Abate",
				AreaName = "decom",
				Location = ACTION_ABATE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ABATE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ABATE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ABATE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Abate_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ABATE]/
		[HttpPost]
		public ActionResult Abate_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Abate_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Edit_GET",
				AreaName = "decom",
				FormName = "ABATE",
				Location = ACTION_ABATE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abate();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ABATE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Decom/Abate_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ABATE]/
		[HttpPost]
		public ActionResult Abate_Edit([FromBody]Abate_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Edit",
				ViewName = "Abate",
				AreaName = "decom",
				Location = ACTION_ABATE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ABATE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ABATE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ABATE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Abate_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ABATE]/
		[HttpPost]
		public ActionResult Abate_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Abate_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Delete_GET",
				AreaName = "decom",
				FormName = "ABATE",
				Location = ACTION_ABATE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Abate();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ABATE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Decom/Abate_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ABATE]/
		[HttpPost]
		public ActionResult Abate_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Abate_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Abate_Delete",
				ViewName = "Abate",
				AreaName = "decom",
				Location = ACTION_ABATE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ABATE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Abate_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ABATE");
		}

		#endregion

		#region Abate_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ABATE]/

		[HttpPost]
		public ActionResult Abate_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Abate_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Duplicate_GET",
				AreaName = "decom",
				FormName = "ABATE",
				Location = ACTION_ABATE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ABATE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Decom/Abate_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ABATE]/
		[HttpPost]
		public ActionResult Abate_Duplicate([FromBody]Abate_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Abate_Duplicate",
				ViewName = "Abate",
				AreaName = "decom",
				Location = ACTION_ABATE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ABATE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ABATE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ABATE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Abate_Cancel

		//
		// GET: /Decom/Abate_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ABATE]/
		public ActionResult Abate_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Decom(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("decom");

// USE /[MANUAL GQT BEFORE_CANCEL ABATE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ABATE]/

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

				Navigation.SetValue("ForcePrimaryRead_decom", "true", true);
			}

			Navigation.ClearValue("decom");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Decom/Abate_SaveEdit
		[HttpPost]
		public ActionResult Abate_SaveEdit([FromBody]Abate_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Abate_SaveEdit",
				ViewName = "Abate",
				AreaName = "decom",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ABATE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ABATE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
