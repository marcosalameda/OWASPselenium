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
using GenioMVC.ViewModels.Regio;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REGIO]/

namespace GenioMVC.Controllers
{
	public partial class RegioController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGIA_ML_CANCEL = new NavigationLocation("REGION12723", "Regia_ml_Cancel", "Regio") { vueRouteName = "form-REGIA_ML", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIA_ML_SHOW = new NavigationLocation("REGION12723", "Regia_ml_Show", "Regio") { vueRouteName = "form-REGIA_ML", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIA_ML_NEW = new NavigationLocation("REGION12723", "Regia_ml_New", "Regio") { vueRouteName = "form-REGIA_ML", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIA_ML_EDIT = new NavigationLocation("REGION12723", "Regia_ml_Edit", "Regio") { vueRouteName = "form-REGIA_ML", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIA_ML_DUPLICATE = new NavigationLocation("REGION12723", "Regia_ml_Duplicate", "Regio") { vueRouteName = "form-REGIA_ML", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIA_ML_DELETE = new NavigationLocation("REGION12723", "Regia_ml_Delete", "Regio") { vueRouteName = "form-REGIA_ML", mode = "DELETE" };

		#endregion

		#region Regia_ml private

		private void FormHistoryLimits_Regia_ml()
		{

		}

		#endregion

		public ActionResult Regia_ml_ModalDBEdit()
		{
			Regia_ml_ViewModel model = new Regia_ml_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Regia_ml_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGIA_ML]/

		[HttpPost]
		public ActionResult Regia_ml_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ml_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Show_GET",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_ml();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGIA_ML]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regia_ml_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regia_ml_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_New_GET",
				AreaName = "regio",
				FormName = "REGIA_ML",
				Location = ACTION_REGIA_ML_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regia_ml();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGIA_ML]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Regio/Regia_ml_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_New([FromBody]Regia_ml_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_New",
				ViewName = "Regia_ml",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGIA_ML]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGIA_ML]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGIA_ML]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regia_ml_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ml_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Edit_GET",
				AreaName = "regio",
				FormName = "REGIA_ML",
				Location = ACTION_REGIA_ML_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_ml();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGIA_ML]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_ml_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_Edit([FromBody]Regia_ml_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Edit",
				ViewName = "Regia_ml",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGIA_ML]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGIA_ML]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGIA_ML]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regia_ml_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ml_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Delete_GET",
				AreaName = "regio",
				FormName = "REGIA_ML",
				Location = ACTION_REGIA_ML_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_ml();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGIA_ML]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_ml_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ml_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Delete",
				ViewName = "Regia_ml",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGIA_ML]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regia_ml_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGIA_ML");
		}

		#endregion

		#region Regia_ml_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGIA_ML]/

		[HttpPost]
		public ActionResult Regia_ml_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regia_ml_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Duplicate_GET",
				AreaName = "regio",
				FormName = "REGIA_ML",
				Location = ACTION_REGIA_ML_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGIA_ML]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Regio/Regia_ml_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGIA_ML]/
		[HttpPost]
		public ActionResult Regia_ml_Duplicate([FromBody]Regia_ml_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_Duplicate",
				ViewName = "Regia_ml",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGIA_ML]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGIA_ML]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGIA_ML]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regia_ml_Cancel

		//
		// GET: /Regio/Regia_ml_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGIA_ML]/
		public ActionResult Regia_ml_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Regio(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("regio");

// USE /[MANUAL GQT BEFORE_CANCEL REGIA_ML]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGIA_ML]/

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

				Navigation.SetValue("ForcePrimaryRead_regio", "true", true);
			}

			Navigation.ClearValue("regio");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Regia_ml Multiform actions

		//
		// GET /Regio/MFRegia_ml_New
		[HttpGet]
		[ActionName("MFRegia_ml_New")]
		public ActionResult MFRegia_ml_New()
		{
			var model = new Regia_ml_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_REGIA_ML_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("regio", model.ValCodregia);

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
		public ActionResult MFRegia_ml_New_GET()
		{
			return MFRegia_ml_New();
		}

		//
		// GET /Regio/MFRegia_ml_Edit
		[HttpGet]
		[ActionName("MFRegia_ml_Edit")]
		public ActionResult MFRegia_ml_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("REGIA_ML", "EDIT", new { id = id, partialView = "MFRegia_ml", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFRegia_ml_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFRegia_ml_Edit(requestModel);
		}

		//
		// GET /Regio/MFRegia_ml_Cancel
		[ActionName("MFRegia_ml_Cancel")]
		public ActionResult MFRegia_ml_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Regio(UserContext.Current);
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
		// POST /Regio/MFRegia_ml_Save
		[HttpPost]
		[ActionName("MFRegia_ml_Save")]
		public JsonResult MFRegia_ml_Save(Regia_ml_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRegia_ml_Save",
				ViewName = "MFRegia_ml",
				AreaName = "regio"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Regio/MFRegia_ml_Delete
		[HttpPost]
		[ActionName("MFRegia_ml_Delete")]
		public JsonResult MFRegia_ml_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFRegia_ml_Delete",
				ViewName = "MFRegia_ml",
				AreaName = "regio",
				Location = ACTION_REGIA_ML_EDIT
			};

			var model = new Regia_ml_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Regio/Regia_ml_CntryValCountry
		// POST: /Regio/Regia_ml_CntryValCountry
		[ActionName("Regia_ml_CntryValCountry")]
		public ActionResult Regia_ml_CntryValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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
			Regia_ml_CntryValCountry_ViewModel model = new Regia_ml_CntryValCountry_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodregia = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Regio/Regia_ml_Pais1ValCountry
		// POST: /Regio/Regia_ml_Pais1ValCountry
		[ActionName("Regia_ml_Pais1ValCountry")]
		public ActionResult Regia_ml_Pais1ValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pais1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pais1");
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
			Regia_ml_Pais1ValCountry_ViewModel model = new Regia_ml_Pais1ValCountry_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodregia = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Regio/Regia_ml_ValImoveisl
		// POST: /Regio/Regia_ml_ValImoveisl
		[ActionName("Regia_ml_ValImoveisl")]
		public ActionResult Regia_ml_ValImoveisl([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
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

			Regia_ml_ValImoveisl_ViewModel model = new Regia_ml_ValImoveisl_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodregia = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Regio/Regia_ml_SaveEdit
		[HttpPost]
		public ActionResult Regia_ml_SaveEdit([FromBody]Regia_ml_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_ml_SaveEdit",
				ViewName = "Regia_ml",
				AreaName = "regio",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGIA_ML]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGIA_ML]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
