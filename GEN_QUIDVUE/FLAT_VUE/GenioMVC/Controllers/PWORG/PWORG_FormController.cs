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
using GenioMVC.ViewModels.Pworg;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWORG]/

namespace GenioMVC.Controllers
{
	public partial class PworgController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PWORG_CANCEL = new("ACESSO_A_ORGANIZACAO01976", "Pworg_Cancel", "Pworg") { vueRouteName = "form-PWORG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PWORG_SHOW = new("ACESSO_A_ORGANIZACAO01976", "Pworg_Show", "Pworg") { vueRouteName = "form-PWORG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PWORG_NEW = new("ACESSO_A_ORGANIZACAO01976", "Pworg_New", "Pworg") { vueRouteName = "form-PWORG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PWORG_EDIT = new("ACESSO_A_ORGANIZACAO01976", "Pworg_Edit", "Pworg") { vueRouteName = "form-PWORG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PWORG_DUPLICATE = new("ACESSO_A_ORGANIZACAO01976", "Pworg_Duplicate", "Pworg") { vueRouteName = "form-PWORG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PWORG_DELETE = new("ACESSO_A_ORGANIZACAO01976", "Pworg_Delete", "Pworg") { vueRouteName = "form-PWORG", mode = "DELETE" };

		#endregion

		#region Pworg private

		private void FormHistoryLimits_Pworg()
		{

		}

		#endregion

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


		public class Pworg_PswValNomeModel : RequestLookupModel
		{
			public Pworg_ViewModel Model { get; set; }
		}

		//
		// GET: /Pworg/Pworg_PswValNome
		// POST: /Pworg/Pworg_PswValNome
		[ActionName("Pworg_PswValNome")]
		public ActionResult Pworg_PswValNome([FromBody] Pworg_PswValNomeModel requestModel)
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

			Models.Pworg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pworg_PswValNome_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pworg_OrganValOrganizaModel : RequestLookupModel
		{
			public Pworg_ViewModel Model { get; set; }
		}

		//
		// GET: /Pworg/Pworg_OrganValOrganiza
		// POST: /Pworg/Pworg_OrganValOrganiza
		[ActionName("Pworg_OrganValOrganiza")]
		public ActionResult Pworg_OrganValOrganiza([FromBody] Pworg_OrganValOrganizaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Pworg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pworg_OrganValOrganiza_ViewModel model = new(UserContext.Current, parentCtx);

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
