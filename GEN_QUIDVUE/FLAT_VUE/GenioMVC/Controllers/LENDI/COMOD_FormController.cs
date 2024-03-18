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
using GenioMVC.ViewModels.Lendi;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LENDI]/

namespace GenioMVC.Controllers
{
	public partial class LendiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_COMOD_CANCEL = new NavigationLocation("CANCELAR49513", "Comod_Cancel", "Lendi") { vueRouteName = "form-COMOD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_COMOD_SHOW = new NavigationLocation("CONSULTA40695", "Comod_Show", "Lendi") { vueRouteName = "form-COMOD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_COMOD_NEW = new NavigationLocation("INSERIR43365", "Comod_New", "Lendi") { vueRouteName = "form-COMOD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_COMOD_EDIT = new NavigationLocation("EDITAR11616", "Comod_Edit", "Lendi") { vueRouteName = "form-COMOD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_COMOD_DUPLICATE = new NavigationLocation("DUPLICAR09748", "Comod_Duplicate", "Lendi") { vueRouteName = "form-COMOD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_COMOD_DELETE = new NavigationLocation("APAGAR04097", "Comod_Delete", "Lendi") { vueRouteName = "form-COMOD", mode = "DELETE" };

		#endregion

		#region Comod private

		private void FormHistoryLimits_Comod()
		{

		}

		#endregion

		public ActionResult Comod_ModalDBEdit()
		{
			Comod_ViewModel model = new Comod_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Comod_Show

// USE /[MANUAL GQT CONTROLLER_SHOW COMOD]/

		[HttpPost]
		public ActionResult Comod_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Comod_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Show_GET",
				AreaName = "lendi",
				Location = ACTION_COMOD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW COMOD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Comod_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Comod_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Comod_New_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW COMOD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lendi/Comod_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_New([FromBody]Comod_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Comod_New",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX COMOD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Comod_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Comod_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Edit_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT COMOD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lendi/Comod_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Edit([FromBody]Comod_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Edit",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX COMOD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Comod_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET COMOD]/
		[HttpPost]
		public ActionResult Comod_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Comod_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Delete_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comod();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE COMOD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lendi/Comod_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Comod_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Comod_Delete",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE COMOD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Comod_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("COMOD");
		}

		#endregion

		#region Comod_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET COMOD]/

		[HttpPost]
		public ActionResult Comod_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Comod_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Duplicate_GET",
				AreaName = "lendi",
				FormName = "COMOD",
				Location = ACTION_COMOD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE COMOD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lendi/Comod_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST COMOD]/
		[HttpPost]
		public ActionResult Comod_Duplicate([FromBody]Comod_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Comod_Duplicate",
				ViewName = "Comod",
				AreaName = "lendi",
				Location = ACTION_COMOD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE COMOD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX COMOD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX COMOD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Comod_Cancel

		//
		// GET: /Lendi/Comod_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET COMOD]/
		public ActionResult Comod_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lendi(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lendi");

// USE /[MANUAL GQT BEFORE_CANCEL COMOD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL COMOD]/

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

				Navigation.SetValue("ForcePrimaryRead_lendi", "true", true);
			}

			Navigation.ClearValue("lendi");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Comod Multiform actions

		//
		// GET /Lendi/MFComod_New
		[HttpGet]
		[ActionName("MFComod_New")]
		public ActionResult MFComod_New()
		{
			var model = new Comod_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_COMOD_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("lendi", model.ValCodlendi);

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
		public ActionResult MFComod_New_GET()
		{
			return MFComod_New();
		}

		//
		// GET /Lendi/MFComod_Edit
		[HttpGet]
		[ActionName("MFComod_Edit")]
		public ActionResult MFComod_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("COMOD", "EDIT", new { id = id, partialView = "MFComod", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFComod_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFComod_Edit(requestModel);
		}

		//
		// GET /Lendi/MFComod_Cancel
		[ActionName("MFComod_Cancel")]
		public ActionResult MFComod_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Lendi(UserContext.Current);
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
		// POST /Lendi/MFComod_Save
		[HttpPost]
		[ActionName("MFComod_Save")]
		public JsonResult MFComod_Save(Comod_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFComod_Save",
				ViewName = "MFComod",
				AreaName = "lendi"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Lendi/MFComod_Delete
		[HttpPost]
		[ActionName("MFComod_Delete")]
		public JsonResult MFComod_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFComod_Delete",
				ViewName = "MFComod",
				AreaName = "lendi",
				Location = ACTION_COMOD_EDIT
			};

			var model = new Comod_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Lendi/Comod_Pess1ValName
		// POST: /Lendi/Comod_Pess1ValName
		[ActionName("Comod_Pess1ValName")]
		public ActionResult Comod_Pess1ValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess1");
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
			Comod_Pess1ValName_ViewModel model = new Comod_Pess1ValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlendi = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Lendi/Comod_Pess2ValName
		// POST: /Lendi/Comod_Pess2ValName
		[ActionName("Comod_Pess2ValName")]
		public ActionResult Comod_Pess2ValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess2")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess2");
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
			Comod_Pess2ValName_ViewModel model = new Comod_Pess2ValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlendi = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Lendi/Comod_EquipValRegistnr
		// POST: /Lendi/Comod_EquipValRegistnr
		[ActionName("Comod_EquipValRegistnr")]
		public ActionResult Comod_EquipValRegistnr([FromBody]RequestLookupModel requestModel)
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
			Comod_EquipValRegistnr_ViewModel model = new Comod_EquipValRegistnr_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodlendi = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Lendi/Comod_SaveEdit
		[HttpPost]
		public ActionResult Comod_SaveEdit([FromBody]Comod_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Comod_SaveEdit",
				ViewName = "Comod",
				AreaName = "lendi",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT COMOD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT COMOD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
