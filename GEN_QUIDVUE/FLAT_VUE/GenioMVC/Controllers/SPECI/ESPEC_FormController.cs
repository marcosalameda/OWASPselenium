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
using GenioMVC.ViewModels.Speci;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SPECI]/

namespace GenioMVC.Controllers
{
	public partial class SpeciController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ESPEC_CANCEL = new NavigationLocation("SPECIALTY09304", "Espec_Cancel", "Speci") { vueRouteName = "form-ESPEC", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ESPEC_SHOW = new NavigationLocation("SPECIALTY09304", "Espec_Show", "Speci") { vueRouteName = "form-ESPEC", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ESPEC_NEW = new NavigationLocation("SPECIALTY09304", "Espec_New", "Speci") { vueRouteName = "form-ESPEC", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ESPEC_EDIT = new NavigationLocation("SPECIALTY09304", "Espec_Edit", "Speci") { vueRouteName = "form-ESPEC", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ESPEC_DUPLICATE = new NavigationLocation("SPECIALTY09304", "Espec_Duplicate", "Speci") { vueRouteName = "form-ESPEC", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ESPEC_DELETE = new NavigationLocation("SPECIALTY09304", "Espec_Delete", "Speci") { vueRouteName = "form-ESPEC", mode = "DELETE" };

		#endregion

		#region Espec private

		private void FormHistoryLimits_Espec()
		{

		}

		#endregion

		public ActionResult Espec_ModalDBEdit()
		{
			Espec_ViewModel model = new Espec_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Espec_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ESPEC]/

		[HttpPost]
		public ActionResult Espec_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Espec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Show_GET",
				AreaName = "speci",
				Location = ACTION_ESPEC_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ESPEC]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Espec_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Espec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Espec_New_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ESPEC]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Speci/Espec_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_New([FromBody]Espec_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Espec_New",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ESPEC]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Espec_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Espec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Edit_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ESPEC]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Speci/Espec_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Edit([FromBody]Espec_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Edit",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ESPEC]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Espec_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ESPEC]/
		[HttpPost]
		public ActionResult Espec_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Espec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Delete_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Espec();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ESPEC]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Speci/Espec_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Espec_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Espec_Delete",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ESPEC]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Espec_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ESPEC");
		}

		#endregion

		#region Espec_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ESPEC]/

		[HttpPost]
		public ActionResult Espec_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Espec_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Duplicate_GET",
				AreaName = "speci",
				FormName = "ESPEC",
				Location = ACTION_ESPEC_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ESPEC]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Speci/Espec_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ESPEC]/
		[HttpPost]
		public ActionResult Espec_Duplicate([FromBody]Espec_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Espec_Duplicate",
				ViewName = "Espec",
				AreaName = "speci",
				Location = ACTION_ESPEC_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ESPEC]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ESPEC]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ESPEC]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Espec_Cancel

		//
		// GET: /Speci/Espec_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ESPEC]/
		public ActionResult Espec_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Speci(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("speci");

// USE /[MANUAL GQT BEFORE_CANCEL ESPEC]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ESPEC]/

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

				Navigation.SetValue("ForcePrimaryRead_speci", "true", true);
			}

			Navigation.ClearValue("speci");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Espec Multiform actions

		//
		// GET /Speci/MFEspec_New
		[HttpGet]
		[ActionName("MFEspec_New")]
		public ActionResult MFEspec_New()
		{
			var model = new Espec_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_ESPEC_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("speci", model.ValCodespec);

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
		public ActionResult MFEspec_New_GET()
		{
			return MFEspec_New();
		}

		//
		// GET /Speci/MFEspec_Edit
		[HttpGet]
		[ActionName("MFEspec_Edit")]
		public ActionResult MFEspec_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("ESPEC", "EDIT", new { id = id, partialView = "MFEspec", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFEspec_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFEspec_Edit(requestModel);
		}

		//
		// GET /Speci/MFEspec_Cancel
		[ActionName("MFEspec_Cancel")]
		public ActionResult MFEspec_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Speci(UserContext.Current);
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
		// POST /Speci/MFEspec_Save
		[HttpPost]
		[ActionName("MFEspec_Save")]
		public JsonResult MFEspec_Save(Espec_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFEspec_Save",
				ViewName = "MFEspec",
				AreaName = "speci"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Speci/MFEspec_Delete
		[HttpPost]
		[ActionName("MFEspec_Delete")]
		public JsonResult MFEspec_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFEspec_Delete",
				ViewName = "MFEspec",
				AreaName = "speci",
				Location = ACTION_ESPEC_EDIT
			};

			var model = new Espec_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		// POST: /Speci/Espec_SaveEdit
		[HttpPost]
		public ActionResult Espec_SaveEdit([FromBody]Espec_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Espec_SaveEdit",
				ViewName = "Espec",
				AreaName = "speci",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ESPEC]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ESPEC]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
