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
using GenioMVC.ViewModels.Regio;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER REGIO]/

namespace GenioMVC.Controllers
{
	public partial class RegioController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_REGIA_ON_CANCEL = new("REGION12723", "Regia_on_Cancel", "Regio") { vueRouteName = "form-REGIA_ON", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIA_ON_SHOW = new("REGION12723", "Regia_on_Show", "Regio") { vueRouteName = "form-REGIA_ON", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIA_ON_NEW = new("REGION12723", "Regia_on_New", "Regio") { vueRouteName = "form-REGIA_ON", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIA_ON_EDIT = new("REGION12723", "Regia_on_Edit", "Regio") { vueRouteName = "form-REGIA_ON", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIA_ON_DUPLICATE = new("REGION12723", "Regia_on_Duplicate", "Regio") { vueRouteName = "form-REGIA_ON", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIA_ON_DELETE = new("REGION12723", "Regia_on_Delete", "Regio") { vueRouteName = "form-REGIA_ON", mode = "DELETE" };

		#endregion

		#region Regia_on private

		private void FormHistoryLimits_Regia_on()
		{

		}

		#endregion

		#region Regia_on_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGIA_ON]/

		[HttpPost]
		public ActionResult Regia_on_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_on_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Show_GET",
				AreaName = "regio",
				Location = ACTION_REGIA_ON_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_on();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGIA_ON]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regia_on_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regia_on_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_New_GET",
				AreaName = "regio",
				FormName = "REGIA_ON",
				Location = ACTION_REGIA_ON_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regia_on();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGIA_ON]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Regio/Regia_on_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_New([FromBody]Regia_on_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_New",
				ViewName = "Regia_on",
				AreaName = "regio",
				Location = ACTION_REGIA_ON_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGIA_ON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGIA_ON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGIA_ON]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regia_on_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_on_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Edit_GET",
				AreaName = "regio",
				FormName = "REGIA_ON",
				Location = ACTION_REGIA_ON_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_on();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGIA_ON]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_on_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_Edit([FromBody]Regia_on_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Edit",
				ViewName = "Regia_on",
				AreaName = "regio",
				Location = ACTION_REGIA_ON_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGIA_ON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGIA_ON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGIA_ON]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regia_on_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_on_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Delete_GET",
				AreaName = "regio",
				FormName = "REGIA_ON",
				Location = ACTION_REGIA_ON_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regia_on();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGIA_ON]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Regio/Regia_on_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regia_on_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Delete",
				ViewName = "Regia_on",
				AreaName = "regio",
				Location = ACTION_REGIA_ON_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGIA_ON]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regia_on_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGIA_ON");
		}

		#endregion

		#region Regia_on_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGIA_ON]/

		[HttpPost]
		public ActionResult Regia_on_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regia_on_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Duplicate_GET",
				AreaName = "regio",
				FormName = "REGIA_ON",
				Location = ACTION_REGIA_ON_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGIA_ON]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Regio/Regia_on_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGIA_ON]/
		[HttpPost]
		public ActionResult Regia_on_Duplicate([FromBody]Regia_on_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_Duplicate",
				ViewName = "Regia_on",
				AreaName = "regio",
				Location = ACTION_REGIA_ON_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGIA_ON]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGIA_ON]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGIA_ON]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regia_on_Cancel

		//
		// GET: /Regio/Regia_on_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGIA_ON]/
		public ActionResult Regia_on_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Regio(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("regio");

// USE /[MANUAL GQT BEFORE_CANCEL REGIA_ON]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGIA_ON]/

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


		//
		// GET: /Regio/Regia_on_CntryValCountry
		// POST: /Regio/Regia_on_CntryValCountry
		[ActionName("Regia_on_CntryValCountry")]
		public ActionResult Regia_on_CntryValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Regia_on_CntryValCountry_ViewModel model = new Regia_on_CntryValCountry_ViewModel(UserContext.Current);
			
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
		// GET: /Regio/Regia_on_Pais1ValCountry
		// POST: /Regio/Regia_on_Pais1ValCountry
		[ActionName("Regia_on_Pais1ValCountry")]
		public ActionResult Regia_on_Pais1ValCountry([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;
			Regia_on_Pais1ValCountry_ViewModel model = new Regia_on_Pais1ValCountry_ViewModel(UserContext.Current);
			
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
		// GET: /Regio/Regia_on_ValImoveisl
		// POST: /Regio/Regia_on_ValImoveisl
		[ActionName("Regia_on_ValImoveisl")]
		public ActionResult Regia_on_ValImoveisl([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

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
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Regia_on_ValImoveisl_ViewModel model = new Regia_on_ValImoveisl_ViewModel(UserContext.Current);
			
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


		// POST: /Regio/Regia_on_SaveEdit
		[HttpPost]
		public ActionResult Regia_on_SaveEdit([FromBody]Regia_on_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regia_on_SaveEdit",
				ViewName = "Regia_on",
				AreaName = "regio",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGIA_ON]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGIA_ON]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
