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
using GenioMVC.ViewModels.Movim;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MOVIM]/

namespace GenioMVC.Controllers
{
	public partial class MovimController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MOVIM_CANCEL = new NavigationLocation("DRIVE03517", "Movim_Cancel", "Movim") { vueRouteName = "form-MOVIM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MOVIM_SHOW = new NavigationLocation("DRIVE03517", "Movim_Show", "Movim") { vueRouteName = "form-MOVIM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MOVIM_NEW = new NavigationLocation("DRIVE03517", "Movim_New", "Movim") { vueRouteName = "form-MOVIM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MOVIM_EDIT = new NavigationLocation("DRIVE03517", "Movim_Edit", "Movim") { vueRouteName = "form-MOVIM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MOVIM_DUPLICATE = new NavigationLocation("DRIVE03517", "Movim_Duplicate", "Movim") { vueRouteName = "form-MOVIM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MOVIM_DELETE = new NavigationLocation("DRIVE03517", "Movim_Delete", "Movim") { vueRouteName = "form-MOVIM", mode = "DELETE" };

		#endregion

		#region Movim private

		private void FormHistoryLimits_Movim()
		{

		}

		#endregion

		public ActionResult Movim_ModalDBEdit()
		{
			Movim_ViewModel model = new Movim_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Movim_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MOVIM]/

		[HttpPost]
		public ActionResult Movim_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Show_GET",
				AreaName = "movim",
				Location = ACTION_MOVIM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW MOVIM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Movim_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_New_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW MOVIM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Movim/Movim_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_New([FromBody]Movim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_New",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MOVIM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Movim_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Edit_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT MOVIM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Movim/Movim_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Edit([FromBody]Movim_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Edit",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MOVIM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Movim_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Delete_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE MOVIM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Movim/Movim_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Movim_Delete",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MOVIM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Movim_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MOVIM");
		}

		#endregion

		#region Movim_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MOVIM]/

		[HttpPost]
		public ActionResult Movim_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Duplicate_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MOVIM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Movim/Movim_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Duplicate([FromBody]Movim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Duplicate",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MOVIM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Movim_Cancel

		//
		// GET: /Movim/Movim_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MOVIM]/
		public ActionResult Movim_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Movim(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("movim");

// USE /[MANUAL GQT BEFORE_CANCEL MOVIM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MOVIM]/

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

				Navigation.SetValue("ForcePrimaryRead_movim", "true", true);
			}

			Navigation.ClearValue("movim");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Movim Multiform actions

		//
		// GET /Movim/MFMovim_New
		[HttpGet]
		[ActionName("MFMovim_New")]
		public ActionResult MFMovim_New()
		{
			var model = new Movim_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_MOVIM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("movim", model.ValCodmovim);

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
		public ActionResult MFMovim_New_GET()
		{
			return MFMovim_New();
		}

		//
		// GET /Movim/MFMovim_Edit
		[HttpGet]
		[ActionName("MFMovim_Edit")]
		public ActionResult MFMovim_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("MOVIM", "EDIT", new { id = id, partialView = "MFMovim", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFMovim_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFMovim_Edit(requestModel);
		}

		//
		// GET /Movim/MFMovim_Cancel
		[ActionName("MFMovim_Cancel")]
		public ActionResult MFMovim_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Movim(UserContext.Current);
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
		// POST /Movim/MFMovim_Save
		[HttpPost]
		[ActionName("MFMovim_Save")]
		public JsonResult MFMovim_Save(Movim_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFMovim_Save",
				ViewName = "MFMovim",
				AreaName = "movim"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Movim/MFMovim_Delete
		[HttpPost]
		[ActionName("MFMovim_Delete")]
		public JsonResult MFMovim_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFMovim_Delete",
				ViewName = "MFMovim",
				AreaName = "movim",
				Location = ACTION_MOVIM_EDIT
			};

			var model = new Movim_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Movim/Movim_EquipValRegistnr
		// POST: /Movim/Movim_EquipValRegistnr
		[ActionName("Movim_EquipValRegistnr")]
		public ActionResult Movim_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Movim_EquipValRegistnr_ViewModel model = new Movim_EquipValRegistnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodmovim = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Movim/Movim_RoomsValRoomnr
		// POST: /Movim/Movim_RoomsValRoomnr
		[ActionName("Movim_RoomsValRoomnr")]
		public ActionResult Movim_RoomsValRoomnr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Set configuration name to use in view model
				if (queryParams.ContainsKey("UserTableConfigName"))
				{
					if (!string.IsNullOrEmpty(queryParams["UserTableConfigName"]))
						Navigation.SetValue("UserTableConfigName", queryParams["UserTableConfigName"]);
					else
						Navigation.SetValue("UserTableConfigName", "");
				}
				else
					Navigation.SetValue("UserTableConfigName", "");

				// Set rows per page
				if (queryParams.ContainsKey("perPage") && !string.IsNullOrEmpty(queryParams["perPage"]))
					perPage = Convert.ToInt32(queryParams["perPage"]);

				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Movim_RoomsValRoomnr_ViewModel model = new Movim_RoomsValRoomnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodmovim = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Movim/Movim_SaveEdit
		[HttpPost]
		public ActionResult Movim_SaveEdit([FromBody]Movim_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_SaveEdit",
				ViewName = "Movim",
				AreaName = "movim",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MOVIM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
