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
using GenioMVC.ViewModels.Aero;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER AERO]/

namespace GenioMVC.Controllers
{
	public partial class AeroController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_AERO_CANCEL = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_Cancel", "Aero") { vueRouteName = "form-AERO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_AERO_SHOW = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_Show", "Aero") { vueRouteName = "form-AERO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_AERO_NEW = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_New", "Aero") { vueRouteName = "form-AERO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_AERO_EDIT = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_Edit", "Aero") { vueRouteName = "form-AERO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_AERO_DUPLICATE = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_Duplicate", "Aero") { vueRouteName = "form-AERO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_AERO_DELETE = new NavigationLocation("COMPANHIA_AEREA16237", "Aero_Delete", "Aero") { vueRouteName = "form-AERO", mode = "DELETE" };

		#endregion

		#region Aero private

		private void FormHistoryLimits_Aero()
		{

		}

		#endregion

		public ActionResult Aero_ModalDBEdit()
		{
			Aero_ViewModel model = new Aero_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Aero_Show

// USE /[MANUAL GQT CONTROLLER_SHOW AERO]/

		[HttpPost]
		public ActionResult Aero_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Aero_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Show_GET",
				AreaName = "aero",
				Location = ACTION_AERO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Aero();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW AERO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Aero_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET AERO]/
		[HttpPost]
		public ActionResult Aero_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Aero_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Aero_New_GET",
				AreaName = "aero",
				FormName = "AERO",
				Location = ACTION_AERO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Aero();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW AERO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Aero/Aero_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST AERO]/
		[HttpPost]
		public ActionResult Aero_New([FromBody]Aero_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Aero_New",
				ViewName = "Aero",
				AreaName = "aero",
				Location = ACTION_AERO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW AERO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX AERO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX AERO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Aero_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET AERO]/
		[HttpPost]
		public ActionResult Aero_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Aero_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Edit_GET",
				AreaName = "aero",
				FormName = "AERO",
				Location = ACTION_AERO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Aero();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT AERO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Aero/Aero_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST AERO]/
		[HttpPost]
		public ActionResult Aero_Edit([FromBody]Aero_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Edit",
				ViewName = "Aero",
				AreaName = "aero",
				Location = ACTION_AERO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT AERO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX AERO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX AERO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Aero_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET AERO]/
		[HttpPost]
		public ActionResult Aero_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Aero_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Delete_GET",
				AreaName = "aero",
				FormName = "AERO",
				Location = ACTION_AERO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Aero();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE AERO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Aero/Aero_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST AERO]/
		[HttpPost]
		public ActionResult Aero_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Aero_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Aero_Delete",
				ViewName = "Aero",
				AreaName = "aero",
				Location = ACTION_AERO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE AERO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Aero_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("AERO");
		}

		#endregion

		#region Aero_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET AERO]/

		[HttpPost]
		public ActionResult Aero_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Aero_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Duplicate_GET",
				AreaName = "aero",
				FormName = "AERO",
				Location = ACTION_AERO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE AERO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Aero/Aero_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST AERO]/
		[HttpPost]
		public ActionResult Aero_Duplicate([FromBody]Aero_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Aero_Duplicate",
				ViewName = "Aero",
				AreaName = "aero",
				Location = ACTION_AERO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE AERO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX AERO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX AERO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Aero_Cancel

		//
		// GET: /Aero/Aero_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET AERO]/
		public ActionResult Aero_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Aero(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("aero");

// USE /[MANUAL GQT BEFORE_CANCEL AERO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL AERO]/

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

				Navigation.SetValue("ForcePrimaryRead_aero", "true", true);
			}

			Navigation.ClearValue("aero");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Aero Multiform actions

		//
		// GET /Aero/MFAero_New
		[HttpGet]
		[ActionName("MFAero_New")]
		public ActionResult MFAero_New()
		{
			var model = new Aero_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_AERO_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("aero", model.ValCodaero);

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
		public ActionResult MFAero_New_GET()
		{
			return MFAero_New();
		}

		//
		// GET /Aero/MFAero_Edit
		[HttpGet]
		[ActionName("MFAero_Edit")]
		public ActionResult MFAero_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("AERO", "EDIT", new { id = id, partialView = "MFAero", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFAero_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFAero_Edit(requestModel);
		}

		//
		// GET /Aero/MFAero_Cancel
		[ActionName("MFAero_Cancel")]
		public ActionResult MFAero_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Aero(UserContext.Current);
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
		// POST /Aero/MFAero_Save
		[HttpPost]
		[ActionName("MFAero_Save")]
		public JsonResult MFAero_Save(Aero_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFAero_Save",
				ViewName = "MFAero",
				AreaName = "aero"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Aero/MFAero_Delete
		[HttpPost]
		[ActionName("MFAero_Delete")]
		public JsonResult MFAero_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFAero_Delete",
				ViewName = "MFAero",
				AreaName = "aero",
				Location = ACTION_AERO_EDIT
			};

			var model = new Aero_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Aero/Aero_SaveEdit
		[HttpPost]
		public ActionResult Aero_SaveEdit([FromBody]Aero_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Aero_SaveEdit",
				ViewName = "Aero",
				AreaName = "aero",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT AERO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT AERO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
