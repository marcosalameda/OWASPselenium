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

		private static readonly NavigationLocation ACTION_REGIA_ML_CANCEL = new("REGION12723", "Regia_ml_Cancel", "Regio") { vueRouteName = "form-REGIA_ML", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIA_ML_SHOW = new("REGION12723", "Regia_ml_Show", "Regio") { vueRouteName = "form-REGIA_ML", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIA_ML_NEW = new("REGION12723", "Regia_ml_New", "Regio") { vueRouteName = "form-REGIA_ML", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIA_ML_EDIT = new("REGION12723", "Regia_ml_Edit", "Regio") { vueRouteName = "form-REGIA_ML", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIA_ML_DUPLICATE = new("REGION12723", "Regia_ml_Duplicate", "Regio") { vueRouteName = "form-REGIA_ML", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIA_ML_DELETE = new("REGION12723", "Regia_ml_Delete", "Regio") { vueRouteName = "form-REGIA_ML", mode = "DELETE" };

		#endregion

		#region Regia_ml private

		private void FormHistoryLimits_Regia_ml()
		{

		}

		#endregion

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


		public class Regia_ml_CntryValCountryModel : RequestLookupModel
		{
			public Regia_ml_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regia_ml_CntryValCountry
		// POST: /Regio/Regia_ml_CntryValCountry
		[ActionName("Regia_ml_CntryValCountry")]
		public ActionResult Regia_ml_CntryValCountry([FromBody] Regia_ml_CntryValCountryModel requestModel)
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

			Models.Regio parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Regia_ml_CntryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regia_ml_Pais1ValCountryModel : RequestLookupModel
		{
			public Regia_ml_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regia_ml_Pais1ValCountry
		// POST: /Regio/Regia_ml_Pais1ValCountry
		[ActionName("Regia_ml_Pais1ValCountry")]
		public ActionResult Regia_ml_Pais1ValCountry([FromBody] Regia_ml_Pais1ValCountryModel requestModel)
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

			Models.Regio parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Regia_ml_Pais1ValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regia_ml_ValImoveislModel : RequestLookupModel
		{
			public Regia_ml_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regia_ml_ValImoveisl
		// POST: /Regio/Regia_ml_ValImoveisl
		[ActionName("Regia_ml_ValImoveisl")]
		public ActionResult Regia_ml_ValImoveisl([FromBody] Regia_ml_ValImoveislModel requestModel)
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

			Models.Regio parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Regia_ml_ValImoveisl_ViewModel model = new(UserContext.Current, parentCtx);

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
