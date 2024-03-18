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
using GenioMVC.ViewModels.Pwcom;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWCOM]/

namespace GenioMVC.Controllers
{
	public partial class PwcomController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PWCOM_CANCEL = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_Cancel", "Pwcom") { vueRouteName = "form-PWCOM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PWCOM_SHOW = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_Show", "Pwcom") { vueRouteName = "form-PWCOM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PWCOM_NEW = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_New", "Pwcom") { vueRouteName = "form-PWCOM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PWCOM_EDIT = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_Edit", "Pwcom") { vueRouteName = "form-PWCOM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PWCOM_DUPLICATE = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_Duplicate", "Pwcom") { vueRouteName = "form-PWCOM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PWCOM_DELETE = new NavigationLocation("MOVING_ACCESS62712", "Pwcom_Delete", "Pwcom") { vueRouteName = "form-PWCOM", mode = "DELETE" };

		#endregion

		#region Pwcom private

		private void FormHistoryLimits_Pwcom()
		{

		}

		#endregion

		public ActionResult Pwcom_ModalDBEdit()
		{
			Pwcom_ViewModel model = new Pwcom_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Pwcom_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PWCOM]/

		[HttpPost]
		public ActionResult Pwcom_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwcom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Show_GET",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PWCOM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pwcom_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pwcom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_New_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PWCOM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pwcom/Pwcom_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_New([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_New",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PWCOM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pwcom_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwcom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Edit_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PWCOM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pwcom/Pwcom_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Edit([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Edit",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PWCOM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pwcom_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwcom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Delete_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwcom();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PWCOM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pwcom/Pwcom_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwcom_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Delete",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PWCOM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pwcom_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PWCOM");
		}

		#endregion

		#region Pwcom_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PWCOM]/

		[HttpPost]
		public ActionResult Pwcom_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pwcom_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Duplicate_GET",
				AreaName = "pwcom",
				FormName = "PWCOM",
				Location = ACTION_PWCOM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PWCOM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pwcom/Pwcom_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PWCOM]/
		[HttpPost]
		public ActionResult Pwcom_Duplicate([FromBody]Pwcom_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_Duplicate",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PWCOM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PWCOM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PWCOM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pwcom_Cancel

		//
		// GET: /Pwcom/Pwcom_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PWCOM]/
		public ActionResult Pwcom_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pwcom(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pwcom");

// USE /[MANUAL GQT BEFORE_CANCEL PWCOM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PWCOM]/

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

				Navigation.SetValue("ForcePrimaryRead_pwcom", "true", true);
			}

			Navigation.ClearValue("pwcom");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Pwcom Multiform actions

		//
		// GET /Pwcom/MFPwcom_New
		[HttpGet]
		[ActionName("MFPwcom_New")]
		public ActionResult MFPwcom_New()
		{
			var model = new Pwcom_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PWCOM_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("pwcom", model.ValCodpwcom);

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
		public ActionResult MFPwcom_New_GET()
		{
			return MFPwcom_New();
		}

		//
		// GET /Pwcom/MFPwcom_Edit
		[HttpGet]
		[ActionName("MFPwcom_Edit")]
		public ActionResult MFPwcom_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PWCOM", "EDIT", new { id = id, partialView = "MFPwcom", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPwcom_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPwcom_Edit(requestModel);
		}

		//
		// GET /Pwcom/MFPwcom_Cancel
		[ActionName("MFPwcom_Cancel")]
		public ActionResult MFPwcom_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Pwcom(UserContext.Current);
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
		// POST /Pwcom/MFPwcom_Save
		[HttpPost]
		[ActionName("MFPwcom_Save")]
		public JsonResult MFPwcom_Save(Pwcom_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPwcom_Save",
				ViewName = "MFPwcom",
				AreaName = "pwcom"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Pwcom/MFPwcom_Delete
		[HttpPost]
		[ActionName("MFPwcom_Delete")]
		public JsonResult MFPwcom_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPwcom_Delete",
				ViewName = "MFPwcom",
				AreaName = "pwcom",
				Location = ACTION_PWCOM_EDIT
			};

			var model = new Pwcom_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Pwcom/Pwcom_PswValNome
		// POST: /Pwcom/Pwcom_PswValNome
		[ActionName("Pwcom_PswValNome")]
		public ActionResult Pwcom_PswValNome([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
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
			Pwcom_PswValNome_ViewModel model = new Pwcom_PswValNome_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpwcom = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pwcom/Pwcom_Pess1ValName
		// POST: /Pwcom/Pwcom_Pess1ValName
		[ActionName("Pwcom_Pess1ValName")]
		public ActionResult Pwcom_Pess1ValName([FromBody]RequestLookupModel requestModel)
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
			Pwcom_Pess1ValName_ViewModel model = new Pwcom_Pess1ValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpwcom = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pwcom/Pwcom_SaveEdit
		[HttpPost]
		public ActionResult Pwcom_SaveEdit([FromBody]Pwcom_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwcom_SaveEdit",
				ViewName = "Pwcom",
				AreaName = "pwcom",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PWCOM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PWCOM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
