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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GROUPBX_CANCEL = new NavigationLocation("GROUPBOX00384", "Groupbx_Cancel", "Equip") { vueRouteName = "form-GROUPBX", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GROUPBX_SHOW = new NavigationLocation("GROUPBOX00384", "Groupbx_Show", "Equip") { vueRouteName = "form-GROUPBX", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GROUPBX_NEW = new NavigationLocation("GROUPBOX00384", "Groupbx_New", "Equip") { vueRouteName = "form-GROUPBX", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GROUPBX_EDIT = new NavigationLocation("GROUPBOX00384", "Groupbx_Edit", "Equip") { vueRouteName = "form-GROUPBX", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GROUPBX_DUPLICATE = new NavigationLocation("GROUPBOX00384", "Groupbx_Duplicate", "Equip") { vueRouteName = "form-GROUPBX", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GROUPBX_DELETE = new NavigationLocation("GROUPBOX00384", "Groupbx_Delete", "Equip") { vueRouteName = "form-GROUPBX", mode = "DELETE" };

		#endregion

		#region Groupbx private

		private void FormHistoryLimits_Groupbx()
		{

		}

		#endregion

		public ActionResult Groupbx_ModalDBEdit()
		{
			Groupbx_ViewModel model = new Groupbx_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Groupbx_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GROUPBX]/

		[HttpPost]
		public ActionResult Groupbx_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Show_GET",
				AreaName = "equip",
				Location = ACTION_GROUPBX_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GROUPBX]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Groupbx_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_New_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GROUPBX]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Groupbx_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_New([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_New",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Groupbx_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Edit_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GROUPBX]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Groupbx_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Edit([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Edit",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Groupbx_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Delete_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GROUPBX]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Groupbx_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Delete",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GROUPBX]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Groupbx_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GROUPBX");
		}

		#endregion

		#region Groupbx_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GROUPBX]/

		[HttpPost]
		public ActionResult Groupbx_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Duplicate_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GROUPBX]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Groupbx_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Duplicate([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Duplicate",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Groupbx_Cancel

		//
		// GET: /Equip/Groupbx_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GROUPBX]/
		public ActionResult Groupbx_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL GROUPBX]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GROUPBX]/

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

				Navigation.SetValue("ForcePrimaryRead_equip", "true", true);
			}

			Navigation.ClearValue("equip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Groupbx Multiform actions

		//
		// GET /Equip/MFGroupbx_New
		[HttpGet]
		[ActionName("MFGroupbx_New")]
		public ActionResult MFGroupbx_New()
		{
			var model = new Groupbx_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_GROUPBX_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("equip", model.ValCodequip);

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
		public ActionResult MFGroupbx_New_GET()
		{
			return MFGroupbx_New();
		}

		//
		// GET /Equip/MFGroupbx_Edit
		[HttpGet]
		[ActionName("MFGroupbx_Edit")]
		public ActionResult MFGroupbx_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("GROUPBX", "EDIT", new { id = id, partialView = "MFGroupbx", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFGroupbx_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFGroupbx_Edit(requestModel);
		}

		//
		// GET /Equip/MFGroupbx_Cancel
		[ActionName("MFGroupbx_Cancel")]
		public ActionResult MFGroupbx_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Equip(UserContext.Current);
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
		// POST /Equip/MFGroupbx_Save
		[HttpPost]
		[ActionName("MFGroupbx_Save")]
		public JsonResult MFGroupbx_Save(Groupbx_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFGroupbx_Save",
				ViewName = "MFGroupbx",
				AreaName = "equip"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Equip/MFGroupbx_Delete
		[HttpPost]
		[ActionName("MFGroupbx_Delete")]
		public JsonResult MFGroupbx_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFGroupbx_Delete",
				ViewName = "MFGroupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_EDIT
			};

			var model = new Groupbx_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Equip/Groupbx_TpequValTipoequi
		// POST: /Equip/Groupbx_TpequValTipoequi
		[ActionName("Groupbx_TpequValTipoequi")]
		public ActionResult Groupbx_TpequValTipoequi([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
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
			Groupbx_TpequValTipoequi_ViewModel model = new Groupbx_TpequValTipoequi_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodequip = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Equip/Groupbx_WarehValWarehdes
		// POST: /Equip/Groupbx_WarehValWarehdes
		[ActionName("Groupbx_WarehValWarehdes")]
		public ActionResult Groupbx_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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
			Groupbx_WarehValWarehdes_ViewModel model = new Groupbx_WarehValWarehdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodequip = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Equip/Groupbx_ItemValItemdes
		// POST: /Equip/Groupbx_ItemValItemdes
		[ActionName("Groupbx_ItemValItemdes")]
		public ActionResult Groupbx_ItemValItemdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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
			Groupbx_ItemValItemdes_ViewModel model = new Groupbx_ItemValItemdes_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodequip = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Equip/Groupbx_SaveEdit
		[HttpPost]
		public ActionResult Groupbx_SaveEdit([FromBody]Groupbx_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_SaveEdit",
				ViewName = "Groupbx",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GROUPBX]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
