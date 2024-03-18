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
using GenioMVC.ViewModels.Users;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER USERS]/

namespace GenioMVC.Controllers
{
	public partial class UsersController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_USERS_CANCEL = new NavigationLocation("USER57012", "Users_Cancel", "Users") { vueRouteName = "form-USERS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_USERS_SHOW = new NavigationLocation("USER57012", "Users_Show", "Users") { vueRouteName = "form-USERS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_USERS_NEW = new NavigationLocation("USER57012", "Users_New", "Users") { vueRouteName = "form-USERS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_USERS_EDIT = new NavigationLocation("USER57012", "Users_Edit", "Users") { vueRouteName = "form-USERS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_USERS_DUPLICATE = new NavigationLocation("USER57012", "Users_Duplicate", "Users") { vueRouteName = "form-USERS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_USERS_DELETE = new NavigationLocation("USER57012", "Users_Delete", "Users") { vueRouteName = "form-USERS", mode = "DELETE" };

		#endregion

		#region Users private

		private void FormHistoryLimits_Users()
		{

		}

		#endregion

		public ActionResult Users_ModalDBEdit()
		{
			Users_ViewModel model = new Users_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			var values = new NameValueCollection();
			values.AddRange(Request.Form);
			model.Load(values, true, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Users_Show

// USE /[MANUAL GQT CONTROLLER_SHOW USERS]/

		[HttpPost]
		public ActionResult Users_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Users_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Users_Show_GET",
				AreaName = "users",
				Location = ACTION_USERS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Users();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW USERS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Users_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET USERS]/
		[HttpPost]
		public ActionResult Users_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Users_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Users_New_GET",
				AreaName = "users",
				FormName = "USERS",
				Location = ACTION_USERS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Users();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW USERS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Users/Users_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST USERS]/
		[HttpPost]
		public ActionResult Users_New([FromBody]Users_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Users_New",
				ViewName = "Users",
				AreaName = "users",
				Location = ACTION_USERS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW USERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX USERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX USERS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Users_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET USERS]/
		[HttpPost]
		public ActionResult Users_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Users_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Users_Edit_GET",
				AreaName = "users",
				FormName = "USERS",
				Location = ACTION_USERS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Users();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT USERS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Users/Users_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST USERS]/
		[HttpPost]
		public ActionResult Users_Edit([FromBody]Users_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Users_Edit",
				ViewName = "Users",
				AreaName = "users",
				Location = ACTION_USERS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT USERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX USERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX USERS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Users_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET USERS]/
		[HttpPost]
		public ActionResult Users_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Users_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Users_Delete_GET",
				AreaName = "users",
				FormName = "USERS",
				Location = ACTION_USERS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Users();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE USERS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Users/Users_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST USERS]/
		[HttpPost]
		public ActionResult Users_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Users_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Users_Delete",
				ViewName = "Users",
				AreaName = "users",
				Location = ACTION_USERS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE USERS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Users_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("USERS");
		}

		#endregion

		#region Users_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET USERS]/

		[HttpPost]
		public ActionResult Users_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Users_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Users_Duplicate_GET",
				AreaName = "users",
				FormName = "USERS",
				Location = ACTION_USERS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE USERS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Users/Users_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST USERS]/
		[HttpPost]
		public ActionResult Users_Duplicate([FromBody]Users_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Users_Duplicate",
				ViewName = "Users",
				AreaName = "users",
				Location = ACTION_USERS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE USERS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX USERS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX USERS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Users_Cancel

		//
		// GET: /Users/Users_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET USERS]/
		public ActionResult Users_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Users(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("users");

// USE /[MANUAL GQT BEFORE_CANCEL USERS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL USERS]/

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

				Navigation.SetValue("ForcePrimaryRead_users", "true", true);
			}

			Navigation.ClearValue("users");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion

		#region Users Multiform actions

		//
		// GET /Users/MFUsers_New
		[HttpGet]
		[ActionName("MFUsers_New")]
		public ActionResult MFUsers_New()
		{
			var model = new Users_ViewModel(UserContext.Current, true);
			model.setModes(Request.Query["m"].ToString());
			PersistentSupport sp = UserContext.Current.PersistentSupport;
			var navigationLocationAction = ACTION_USERS_NEW.SetRoutedValues(new { m = Request.Query["m"].ToString() });

			try
			{
				sp.openTransaction();
				model.New();
				sp.closeTransaction();

				Navigation.SetValue("users", model.ValCodusers);

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
		public ActionResult MFUsers_New_GET()
		{
			return MFUsers_New();
		}

		//
		// GET /Users/MFUsers_Edit
		[HttpGet]
		[ActionName("MFUsers_Edit")]
		public ActionResult MFUsers_Edit([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			return RedirectToFormAction("USERS", "EDIT", new { id = id, partialView = "MFUsers", nestedForm = "true", multiForm = "true" });
		}

		[HttpPost]
		public ActionResult MFUsers_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			return MFUsers_Edit(requestModel);
		}

		//
		// GET /Users/MFUsers_Cancel
		[ActionName("MFUsers_Cancel")]
		public ActionResult MFUsers_Cancel([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			if (string.IsNullOrEmpty(id))
				return JsonOK(new { Success = false });

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				var model = new GenioMVC.Models.Users(UserContext.Current);
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
		// POST /Users/MFUsers_Save
		[HttpPost]
		[ActionName("MFUsers_Save")]
		public JsonResult MFUsers_Save(Users_ViewModel model, string mode)
		{
			var eventSink = new EventSink()
			{
				MethodName = "MFUsers_Save",
				ViewName = "MFUsers",
				AreaName = "users"
			};

			return GenericHandleMultiFormSave(eventSink, model, mode);
		}

		//
		// POST /Users/MFUsers_Delete
		[HttpPost]
		[ActionName("MFUsers_Delete")]
		public JsonResult MFUsers_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var eventSink = new EventSink()
			{
				MethodName = "MFUsers_Delete",
				ViewName = "MFUsers",
				AreaName = "users",
				Location = ACTION_USERS_EDIT
			};

			var model = new Users_ViewModel(UserContext.Current, id);
			model.MapFromModel();

			return GenericHandlePostMultiFormDelete(eventSink, model);
		}

		#endregion

		//
		// GET: /Users/Users_PswValNome
		// POST: /Users/Users_PswValNome
		[ActionName("Users_PswValNome")]
		public ActionResult Users_PswValNome([FromBody]RequestLookupModel requestModel)
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
			Users_PswValNome_ViewModel model = new Users_PswValNome_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodusers = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		//
		// GET: /Users/Users_PersoValName
		// POST: /Users/Users_PersoValName
		[ActionName("Users_PersoValName")]
		public ActionResult Users_PersoValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
			Users_PersoValName_ViewModel model = new Users_PersoValName_ViewModel(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.ValCodusers = requestModel.Id;
			model.Load(perPage, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Users/Users_SaveEdit
		[HttpPost]
		public ActionResult Users_SaveEdit([FromBody]Users_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Users_SaveEdit",
				ViewName = "Users",
				AreaName = "users",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT USERS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT USERS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
