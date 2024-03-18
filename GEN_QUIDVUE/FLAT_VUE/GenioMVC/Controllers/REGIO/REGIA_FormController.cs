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

		private static readonly NavigationLocation ACTION_REGIA_CANCEL = new NavigationLocation("REGION12723", "Regia_Cancel", "Regio") { vueRouteName = "form-REGIA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIA_SHOW = new NavigationLocation("REGION12723", "Regia_Show", "Regio") { vueRouteName = "form-REGIA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIA_NEW = new NavigationLocation("REGION12723", "Regia_New", "Regio") { vueRouteName = "form-REGIA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIA_EDIT = new NavigationLocation("REGION12723", "Regia_Edit", "Regio") { vueRouteName = "form-REGIA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIA_DUPLICATE = new NavigationLocation("REGION12723", "Regia_Duplicate", "Regio") { vueRouteName = "form-REGIA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIA_DELETE = new NavigationLocation("REGION12723", "Regia_Delete", "Regio") { vueRouteName = "form-REGIA", mode = "DELETE" };

		#endregion

		#region Regia private

		private void FormHistoryLimits_Regia()
		{

		}

		#endregion

		public ActionResult Regia_ModalDBEdit()
		{
			Regia_ViewModel model = new Regia_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Regia_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGIA]/

		[HttpPost]
		public ActionResult Regia_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Show_GET",
				AreaName = "regio",
				Location = ACTION_REGIA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGIA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regia_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGIA]/
		[HttpPost]
		public ActionResult Regia_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regia_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_New_GET",
				AreaName = "regio",
				FormName = "REGIA",
				Location = ACTION_REGIA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regia();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGIA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Regio/Regia_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGIA]/
		[HttpPost]
		public ActionResult Regia_New([FromBody]Regia_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_New",
				ViewName = "Regia",
				AreaName = "regio",
				Location = ACTION_REGIA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGIA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regia_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGIA]/
		[HttpPost]
		public ActionResult Regia_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Edit_GET",
				AreaName = "regio",
				FormName = "REGIA",
				Location = ACTION_REGIA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGIA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGIA]/
		[HttpPost]
		public ActionResult Regia_Edit([FromBody]Regia_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Edit",
				ViewName = "Regia",
				AreaName = "regio",
				Location = ACTION_REGIA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGIA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regia_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGIA]/
		[HttpPost]
		public ActionResult Regia_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Delete_GET",
				AreaName = "regio",
				FormName = "REGIA",
				Location = ACTION_REGIA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGIA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGIA]/
		[HttpPost]
		public ActionResult Regia_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regia_Delete",
				ViewName = "Regia",
				AreaName = "regio",
				Location = ACTION_REGIA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGIA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regia_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGIA");
		}

		#endregion

		#region Regia_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGIA]/

		[HttpPost]
		public ActionResult Regia_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regia_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Duplicate_GET",
				AreaName = "regio",
				FormName = "REGIA",
				Location = ACTION_REGIA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGIA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Regio/Regia_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGIA]/
		[HttpPost]
		public ActionResult Regia_Duplicate([FromBody]Regia_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_Duplicate",
				ViewName = "Regia",
				AreaName = "regio",
				Location = ACTION_REGIA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGIA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regia_Cancel

		//
		// GET: /Regio/Regia_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGIA]/
		public ActionResult Regia_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Regio(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("regio");

// USE /[MANUAL GQT BEFORE_CANCEL REGIA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGIA]/

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

		#region Regia Multiform actions

		//
		// GET /Regio/MFRegia_New
		[HttpGet]
		[ActionName("MFRegia_New")]
		public ActionResult MFRegia_New()
		{
			var model = new Regia_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_REGIA_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

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
		public ActionResult MFRegia_New_GET()
		{
			return MFRegia_New();
		}

		//
		// GET /Regio/MFRegia_Edit
		[HttpGet]
		[ActionName("MFRegia_Edit")]
		public ActionResult MFRegia_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("REGIA", "EDIT", new { id = id, partialView = "MFRegia", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFRegia_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFRegia_Edit(requestModel);
		}

		//
		// GET /Regio/MFRegia_Cancel
		[ActionName("MFRegia_Cancel")]
		public ActionResult MFRegia_Cancel([FromBody]RequestIdModel requestModel)
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
		// POST /Regio/MFRegia_Save
		[HttpPost]
		[ActionName("MFRegia_Save")]
		public JsonResult MFRegia_Save(Regia_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFRegia_Save",
				ViewName = "MFRegia",
				AreaName = "regio"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Regio/MFRegia_Delete
		[HttpPost]
		[ActionName("MFRegia_Delete")]
		public JsonResult MFRegia_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFRegia_Delete",
				ViewName = "MFRegia",
				AreaName = "regio",
				Location = ACTION_REGIA_EDIT
			};

			var model = new Regia_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Regio/Regia_CntryValCountry
		// POST: /Regio/Regia_CntryValCountry
		[ActionName("Regia_CntryValCountry")]
		public ActionResult Regia_CntryValCountry([FromBody]RequestLookupModel requestModel)
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
			Regia_CntryValCountry_ViewModel model = new Regia_CntryValCountry_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodregia = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Regio/Regia_SaveEdit
		[HttpPost]
		public ActionResult Regia_SaveEdit([FromBody]Regia_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_SaveEdit",
				ViewName = "Regia",
				AreaName = "regio",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGIA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
