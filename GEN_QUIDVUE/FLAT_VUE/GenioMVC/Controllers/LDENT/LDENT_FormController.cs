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
using GenioMVC.ViewModels.Ldent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LDENT]/

namespace GenioMVC.Controllers
{
	public partial class LdentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LDENT_CANCEL = new("ENTRY29068", "Ldent_Cancel", "Ldent") { vueRouteName = "form-LDENT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LDENT_SHOW = new("ENTRY29068", "Ldent_Show", "Ldent") { vueRouteName = "form-LDENT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LDENT_NEW = new("ENTRY29068", "Ldent_New", "Ldent") { vueRouteName = "form-LDENT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LDENT_EDIT = new("ENTRY29068", "Ldent_Edit", "Ldent") { vueRouteName = "form-LDENT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LDENT_DUPLICATE = new("ENTRY29068", "Ldent_Duplicate", "Ldent") { vueRouteName = "form-LDENT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LDENT_DELETE = new("ENTRY29068", "Ldent_Delete", "Ldent") { vueRouteName = "form-LDENT", mode = "DELETE" };

		#endregion

		#region Ldent private

		private void FormHistoryLimits_Ldent()
		{

		}

		#endregion

		#region Ldent_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LDENT]/

		[HttpPost]
		public ActionResult Ldent_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Show_GET",
				AreaName = "ldent",
				Location = ACTION_LDENT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldent();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LDENT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ldent_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LDENT]/
		[HttpPost]
		public ActionResult Ldent_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ldent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_New_GET",
				AreaName = "ldent",
				FormName = "LDENT",
				Location = ACTION_LDENT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ldent();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LDENT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Ldent/Ldent_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LDENT]/
		[HttpPost]
		public ActionResult Ldent_New([FromBody]Ldent_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_New",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LDENT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ldent_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LDENT]/
		[HttpPost]
		public ActionResult Ldent_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Edit_GET",
				AreaName = "ldent",
				FormName = "LDENT",
				Location = ACTION_LDENT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldent();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LDENT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldent_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LDENT]/
		[HttpPost]
		public ActionResult Ldent_Edit([FromBody]Ldent_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Edit",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LDENT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ldent_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LDENT]/
		[HttpPost]
		public ActionResult Ldent_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Delete_GET",
				AreaName = "ldent",
				FormName = "LDENT",
				Location = ACTION_LDENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldent();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LDENT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldent_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LDENT]/
		[HttpPost]
		public ActionResult Ldent_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldent_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Delete",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LDENT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ldent_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LDENT");
		}

		#endregion

		#region Ldent_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LDENT]/

		[HttpPost]
		public ActionResult Ldent_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ldent_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Duplicate_GET",
				AreaName = "ldent",
				FormName = "LDENT",
				Location = ACTION_LDENT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LDENT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Ldent/Ldent_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LDENT]/
		[HttpPost]
		public ActionResult Ldent_Duplicate([FromBody]Ldent_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_Duplicate",
				ViewName = "Ldent",
				AreaName = "ldent",
				Location = ACTION_LDENT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LDENT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LDENT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LDENT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ldent_Cancel

		//
		// GET: /Ldent/Ldent_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LDENT]/
		public ActionResult Ldent_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ldent(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");

// USE /[MANUAL GQT BEFORE_CANCEL LDENT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LDENT]/

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

				Navigation.SetValue("ForcePrimaryRead_ldent", "true", true);
			}

			Navigation.ClearValue("ldent");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Ldent/Ldent_IndocValDocumenr
		// POST: /Ldent/Ldent_IndocValDocumenr
		[ActionName("Ldent_IndocValDocumenr")]
		public ActionResult Ldent_IndocValDocumenr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_indoc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_indoc");
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
			Ldent_IndocValDocumenr_ViewModel model = new Ldent_IndocValDocumenr_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Ldent/Ldent_WarehValWarehdes
		// POST: /Ldent/Ldent_WarehValWarehdes
		[ActionName("Ldent_WarehValWarehdes")]
		public ActionResult Ldent_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Ldent_WarehValWarehdes_ViewModel model = new Ldent_WarehValWarehdes_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Ldent/Ldent_ItemValItemdes
		// POST: /Ldent/Ldent_ItemValItemdes
		[ActionName("Ldent_ItemValItemdes")]
		public ActionResult Ldent_ItemValItemdes([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Ldent_ItemValItemdes_ViewModel model = new Ldent_ItemValItemdes_ViewModel(UserContext.Current);
			
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


		// POST: /Ldent/Ldent_SaveEdit
		[HttpPost]
		public ActionResult Ldent_SaveEdit([FromBody]Ldent_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldent_SaveEdit",
				ViewName = "Ldent",
				AreaName = "ldent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LDENT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LDENT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
