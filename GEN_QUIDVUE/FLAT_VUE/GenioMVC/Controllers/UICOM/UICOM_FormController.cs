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
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels.Uicom;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER UICOM]/

namespace GenioMVC.Controllers
{
	public partial class UicomController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_UICOM_CANCEL = new NavigationLocation("UI_COMPONENT15435", "Uicom_Cancel", "Uicom") { vueRouteName = "form-UICOM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_UICOM_SHOW = new NavigationLocation("UI_COMPONENT15435", "Uicom_Show", "Uicom") { vueRouteName = "form-UICOM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_UICOM_NEW = new NavigationLocation("UI_COMPONENT15435", "Uicom_New", "Uicom") { vueRouteName = "form-UICOM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_UICOM_EDIT = new NavigationLocation("UI_COMPONENT15435", "Uicom_Edit", "Uicom") { vueRouteName = "form-UICOM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_UICOM_DUPLICATE = new NavigationLocation("UI_COMPONENT15435", "Uicom_Duplicate", "Uicom") { vueRouteName = "form-UICOM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_UICOM_DELETE = new NavigationLocation("UI_COMPONENT15435", "Uicom_Delete", "Uicom") { vueRouteName = "form-UICOM", mode = "DELETE" };

		#endregion

		#region Uicom private

		private void FormHistoryLimits_Uicom()
		{

		}

		#endregion

		public ActionResult Uicom_ModalDBEdit()
		{
			Uicom_ViewModel model = new Uicom_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Uicom_Show

// USE /[MANUAL GQT CONTROLLER_SHOW UICOM]/

		[HttpPost]
		public ActionResult Uicom_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Uicom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Show_GET",
				AreaName = "uicom",
				Location = ACTION_UICOM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Uicom();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW UICOM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Uicom_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET UICOM]/
		[HttpPost]
		public ActionResult Uicom_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Uicom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_New_GET",
				AreaName = "uicom",
				FormName = "UICOM",
				Location = ACTION_UICOM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Uicom();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW UICOM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Uicom/Uicom_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST UICOM]/
		[HttpPost]
		public ActionResult Uicom_New([FromBody]Uicom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_New",
				ViewName = "Uicom",
				AreaName = "uicom",
				Location = ACTION_UICOM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW UICOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX UICOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX UICOM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Uicom_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET UICOM]/
		[HttpPost]
		public ActionResult Uicom_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Uicom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Edit_GET",
				AreaName = "uicom",
				FormName = "UICOM",
				Location = ACTION_UICOM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Uicom();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT UICOM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Uicom/Uicom_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST UICOM]/
		[HttpPost]
		public ActionResult Uicom_Edit([FromBody]Uicom_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Edit",
				ViewName = "Uicom",
				AreaName = "uicom",
				Location = ACTION_UICOM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT UICOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX UICOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX UICOM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Uicom_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET UICOM]/
		[HttpPost]
		public ActionResult Uicom_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Uicom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Delete_GET",
				AreaName = "uicom",
				FormName = "UICOM",
				Location = ACTION_UICOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Uicom();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE UICOM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Uicom/Uicom_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST UICOM]/
		[HttpPost]
		public ActionResult Uicom_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Uicom_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Delete",
				ViewName = "Uicom",
				AreaName = "uicom",
				Location = ACTION_UICOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE UICOM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Uicom_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("UICOM");
		}

		#endregion

		#region Uicom_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET UICOM]/

		[HttpPost]
		public ActionResult Uicom_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Uicom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Duplicate_GET",
				AreaName = "uicom",
				FormName = "UICOM",
				Location = ACTION_UICOM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE UICOM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Uicom/Uicom_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST UICOM]/
		[HttpPost]
		public ActionResult Uicom_Duplicate([FromBody]Uicom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_Duplicate",
				ViewName = "Uicom",
				AreaName = "uicom",
				Location = ACTION_UICOM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE UICOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX UICOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX UICOM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Uicom_Cancel

		//
		// GET: /Uicom/Uicom_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET UICOM]/
		public ActionResult Uicom_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Uicom(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("uicom");

// USE /[MANUAL GQT BEFORE_CANCEL UICOM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL UICOM]/

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

				Navigation.SetValue("ForcePrimaryRead_uicom", "true", true);
			}

			Navigation.ClearValue("uicom");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Uicom Multiform actions

		//
		// GET /Uicom/MFUicom_New
		[HttpGet]
		[ActionName("MFUicom_New")]
		public ActionResult MFUicom_New()
		{
			var model = new Uicom_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_UICOM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("uicom", model.ValCoduicom);

				sp.openConnection();
				model.NewLoad();
				sp.closeConnection();
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
			}

			return JsonOK(model);
		}

		[HttpPost]
		public ActionResult MFUicom_New_GET()
		{
			return MFUicom_New();
		}

		//
		// GET /Uicom/MFUicom_Edit
		[HttpGet]
		[ActionName("MFUicom_Edit")]
		public ActionResult MFUicom_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("UICOM", "EDIT", new { id = id, partialView = "MFUicom", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFUicom_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFUicom_Edit(requestModel);
		}

		//
		// GET /Uicom/MFUicom_Cancel
		[ActionName("MFUicom_Cancel")]
		public ActionResult MFUicom_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Uicom(UserContext.Current);
				model.klass.QPrimaryKey = id;

				sp.openTransaction();
				model.Destroy();
				sp.closeTransaction();
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

			return JsonOK(new { Success = true });
		}

		//
		// POST /Uicom/MFUicom_Save
		[HttpPost]
		[ActionName("MFUicom_Save")]
		public JsonResult MFUicom_Save(Uicom_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFUicom_Save",
				ViewName = "MFUicom",
				AreaName = "uicom"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Uicom/MFUicom_Delete
		[HttpPost]
		[ActionName("MFUicom_Delete")]
		public JsonResult MFUicom_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFUicom_Delete",
				ViewName = "MFUicom",
				AreaName = "uicom",
				Location = ACTION_UICOM_EDIT
			};

			var model = new Uicom_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Uicom/Uicom_SaveEdit
		[HttpPost]
		public ActionResult Uicom_SaveEdit([FromBody]Uicom_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Uicom_SaveEdit",
				ViewName = "Uicom",
				AreaName = "uicom",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT UICOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT UICOM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
