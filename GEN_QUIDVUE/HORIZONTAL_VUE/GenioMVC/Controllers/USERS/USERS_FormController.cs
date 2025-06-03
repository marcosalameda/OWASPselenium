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
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Users;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER USERS]/

namespace GenioMVC.Controllers
{
	public partial class UsersController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_USERS_CANCEL = new("USER57012", "Users_Cancel", "Users") { vueRouteName = "form-USERS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_USERS_SHOW = new("USER57012", "Users_Show", "Users") { vueRouteName = "form-USERS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_USERS_NEW = new("USER57012", "Users_New", "Users") { vueRouteName = "form-USERS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_USERS_EDIT = new("USER57012", "Users_Edit", "Users") { vueRouteName = "form-USERS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_USERS_DUPLICATE = new("USER57012", "Users_Duplicate", "Users") { vueRouteName = "form-USERS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_USERS_DELETE = new("USER57012", "Users_Delete", "Users") { vueRouteName = "form-USERS", mode = "DELETE" };

		#endregion

		#region Users private

		private void FormHistoryLimits_Users()
		{

		}

		#endregion

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


		public class Users_PswValNomeModel : RequestLookupModel
		{
			public Users_ViewModel Model { get; set; }
		}

		//
		// GET: /Users/Users_PswValNome
		// POST: /Users/Users_PswValNome
		[ActionName("Users_PswValNome")]
		public ActionResult Users_PswValNome([FromBody] Users_PswValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Users parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Users_PswValNome_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Users_PersoValNameModel : RequestLookupModel
		{
			public Users_ViewModel Model { get; set; }
		}

		//
		// GET: /Users/Users_PersoValName
		// POST: /Users/Users_PersoValName
		[ActionName("Users_PersoValName")]
		public ActionResult Users_PersoValName([FromBody] Users_PersoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Users parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Users_PersoValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

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
