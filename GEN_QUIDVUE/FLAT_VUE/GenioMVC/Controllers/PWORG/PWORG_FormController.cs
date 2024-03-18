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
using GenioMVC.ViewModels.Pworg;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWORG]/

namespace GenioMVC.Controllers
{
	public partial class PworgController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PWORG_CANCEL = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_Cancel", "Pworg") { vueRouteName = "form-PWORG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PWORG_SHOW = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_Show", "Pworg") { vueRouteName = "form-PWORG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PWORG_NEW = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_New", "Pworg") { vueRouteName = "form-PWORG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PWORG_EDIT = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_Edit", "Pworg") { vueRouteName = "form-PWORG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PWORG_DUPLICATE = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_Duplicate", "Pworg") { vueRouteName = "form-PWORG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PWORG_DELETE = new NavigationLocation("ACESSO_A_ORGANIZACAO01976", "Pworg_Delete", "Pworg") { vueRouteName = "form-PWORG", mode = "DELETE" };

		#endregion

		#region Pworg private

		private void FormHistoryLimits_Pworg()
		{

		}

		#endregion

		public ActionResult Pworg_ModalDBEdit()
		{
			Pworg_ViewModel model = new Pworg_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Pworg_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PWORG]/

		[HttpPost]
		public ActionResult Pworg_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pworg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Show_GET",
				AreaName = "pworg",
				Location = ACTION_PWORG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pworg();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PWORG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pworg_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PWORG]/
		[HttpPost]
		public ActionResult Pworg_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pworg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_New_GET",
				AreaName = "pworg",
				FormName = "PWORG",
				Location = ACTION_PWORG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pworg();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PWORG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pworg/Pworg_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PWORG]/
		[HttpPost]
		public ActionResult Pworg_New([FromBody]Pworg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_New",
				ViewName = "Pworg",
				AreaName = "pworg",
				Location = ACTION_PWORG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PWORG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PWORG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PWORG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pworg_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PWORG]/
		[HttpPost]
		public ActionResult Pworg_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pworg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Edit_GET",
				AreaName = "pworg",
				FormName = "PWORG",
				Location = ACTION_PWORG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pworg();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PWORG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pworg/Pworg_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PWORG]/
		[HttpPost]
		public ActionResult Pworg_Edit([FromBody]Pworg_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Edit",
				ViewName = "Pworg",
				AreaName = "pworg",
				Location = ACTION_PWORG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PWORG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PWORG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PWORG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pworg_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PWORG]/
		[HttpPost]
		public ActionResult Pworg_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pworg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Delete_GET",
				AreaName = "pworg",
				FormName = "PWORG",
				Location = ACTION_PWORG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pworg();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PWORG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pworg/Pworg_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PWORG]/
		[HttpPost]
		public ActionResult Pworg_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pworg_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Delete",
				ViewName = "Pworg",
				AreaName = "pworg",
				Location = ACTION_PWORG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PWORG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pworg_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PWORG");
		}

		#endregion

		#region Pworg_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PWORG]/

		[HttpPost]
		public ActionResult Pworg_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pworg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Duplicate_GET",
				AreaName = "pworg",
				FormName = "PWORG",
				Location = ACTION_PWORG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PWORG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pworg/Pworg_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PWORG]/
		[HttpPost]
		public ActionResult Pworg_Duplicate([FromBody]Pworg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_Duplicate",
				ViewName = "Pworg",
				AreaName = "pworg",
				Location = ACTION_PWORG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PWORG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PWORG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PWORG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pworg_Cancel

		//
		// GET: /Pworg/Pworg_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PWORG]/
		public ActionResult Pworg_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pworg(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pworg");

// USE /[MANUAL GQT BEFORE_CANCEL PWORG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PWORG]/

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

				Navigation.SetValue("ForcePrimaryRead_pworg", "true", true);
			}

			Navigation.ClearValue("pworg");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Pworg Multiform actions

		//
		// GET /Pworg/MFPworg_New
		[HttpGet]
		[ActionName("MFPworg_New")]
		public ActionResult MFPworg_New()
		{
			var model = new Pworg_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_PWORG_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("pworg", model.ValCodpworg);

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
		public ActionResult MFPworg_New_GET()
		{
			return MFPworg_New();
		}

		//
		// GET /Pworg/MFPworg_Edit
		[HttpGet]
		[ActionName("MFPworg_Edit")]
		public ActionResult MFPworg_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("PWORG", "EDIT", new { id = id, partialView = "MFPworg", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFPworg_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFPworg_Edit(requestModel);
		}

		//
		// GET /Pworg/MFPworg_Cancel
		[ActionName("MFPworg_Cancel")]
		public ActionResult MFPworg_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Pworg(UserContext.Current);
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
		// POST /Pworg/MFPworg_Save
		[HttpPost]
		[ActionName("MFPworg_Save")]
		public JsonResult MFPworg_Save(Pworg_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFPworg_Save",
				ViewName = "MFPworg",
				AreaName = "pworg"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Pworg/MFPworg_Delete
		[HttpPost]
		[ActionName("MFPworg_Delete")]
		public JsonResult MFPworg_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFPworg_Delete",
				ViewName = "MFPworg",
				AreaName = "pworg",
				Location = ACTION_PWORG_EDIT
			};

			var model = new Pworg_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Pworg/Pworg_PswValNome
		// POST: /Pworg/Pworg_PswValNome
		[ActionName("Pworg_PswValNome")]
		public ActionResult Pworg_PswValNome([FromBody]RequestLookupModel requestModel)
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
			Pworg_PswValNome_ViewModel model = new Pworg_PswValNome_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpworg = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Pworg/Pworg_OrganValOrganiza
		// POST: /Pworg/Pworg_OrganValOrganiza
		[ActionName("Pworg_OrganValOrganiza")]
		public ActionResult Pworg_OrganValOrganiza([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_organ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_organ");
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
			Pworg_OrganValOrganiza_ViewModel model = new Pworg_OrganValOrganiza_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodpworg = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pworg/Pworg_SaveEdit
		[HttpPost]
		public ActionResult Pworg_SaveEdit([FromBody]Pworg_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pworg_SaveEdit",
				ViewName = "Pworg",
				AreaName = "pworg",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PWORG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PWORG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
