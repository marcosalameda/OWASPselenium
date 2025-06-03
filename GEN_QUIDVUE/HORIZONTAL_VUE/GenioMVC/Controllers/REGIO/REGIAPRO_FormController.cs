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

		private static readonly NavigationLocation ACTION_REGIAPRO_CANCEL = new("IMOVEIS_NA_REGIAO56821", "Regiapro_Cancel", "Regio") { vueRouteName = "form-REGIAPRO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_REGIAPRO_SHOW = new("IMOVEIS_NA_REGIAO56821", "Regiapro_Show", "Regio") { vueRouteName = "form-REGIAPRO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_REGIAPRO_NEW = new("IMOVEIS_NA_REGIAO56821", "Regiapro_New", "Regio") { vueRouteName = "form-REGIAPRO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_REGIAPRO_EDIT = new("IMOVEIS_NA_REGIAO56821", "Regiapro_Edit", "Regio") { vueRouteName = "form-REGIAPRO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_REGIAPRO_DUPLICATE = new("IMOVEIS_NA_REGIAO56821", "Regiapro_Duplicate", "Regio") { vueRouteName = "form-REGIAPRO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_REGIAPRO_DELETE = new("IMOVEIS_NA_REGIAO56821", "Regiapro_Delete", "Regio") { vueRouteName = "form-REGIAPRO", mode = "DELETE" };

		#endregion

		#region Regiapro private

		private void FormHistoryLimits_Regiapro()
		{

		}

		#endregion

		#region Regiapro_Show

// USE /[MANUAL GQT CONTROLLER_SHOW REGIAPRO]/

		[HttpPost]
		public ActionResult Regiapro_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regiapro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Show_GET",
				AreaName = "regio",
				Location = ACTION_REGIAPRO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regiapro();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW REGIAPRO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Regiapro_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Regiapro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_New_GET",
				AreaName = "regio",
				FormName = "REGIAPRO",
				Location = ACTION_REGIAPRO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Regiapro();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW REGIAPRO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Regio/Regiapro_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_New([FromBody]Regiapro_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_New",
				ViewName = "Regiapro",
				AreaName = "regio",
				Location = ACTION_REGIAPRO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW REGIAPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX REGIAPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX REGIAPRO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Regiapro_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regiapro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Edit_GET",
				AreaName = "regio",
				FormName = "REGIAPRO",
				Location = ACTION_REGIAPRO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regiapro();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT REGIAPRO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Regio/Regiapro_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_Edit([FromBody]Regiapro_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Edit",
				ViewName = "Regiapro",
				AreaName = "regio",
				Location = ACTION_REGIAPRO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT REGIAPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX REGIAPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX REGIAPRO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Regiapro_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regiapro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Delete_GET",
				AreaName = "regio",
				FormName = "REGIAPRO",
				Location = ACTION_REGIAPRO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Regiapro();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE REGIAPRO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Regio/Regiapro_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Regiapro_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Delete",
				ViewName = "Regiapro",
				AreaName = "regio",
				Location = ACTION_REGIAPRO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE REGIAPRO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Regiapro_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("REGIAPRO");
		}

		#endregion

		#region Regiapro_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET REGIAPRO]/

		[HttpPost]
		public ActionResult Regiapro_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Regiapro_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Duplicate_GET",
				AreaName = "regio",
				FormName = "REGIAPRO",
				Location = ACTION_REGIAPRO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE REGIAPRO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Regio/Regiapro_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST REGIAPRO]/
		[HttpPost]
		public ActionResult Regiapro_Duplicate([FromBody]Regiapro_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_Duplicate",
				ViewName = "Regiapro",
				AreaName = "regio",
				Location = ACTION_REGIAPRO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE REGIAPRO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX REGIAPRO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX REGIAPRO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Regiapro_Cancel

		//
		// GET: /Regio/Regiapro_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET REGIAPRO]/
		public ActionResult Regiapro_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Regio(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("regio");

// USE /[MANUAL GQT BEFORE_CANCEL REGIAPRO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL REGIAPRO]/

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


		public class Regiapro_CntryValCountryModel : RequestLookupModel
		{
			public Regiapro_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regiapro_CntryValCountry
		// POST: /Regio/Regiapro_CntryValCountry
		[ActionName("Regiapro_CntryValCountry")]
		public ActionResult Regiapro_CntryValCountry([FromBody] Regiapro_CntryValCountryModel requestModel)
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
			Regiapro_CntryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regiapro_Pais1ValCountryModel : RequestLookupModel
		{
			public Regiapro_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regiapro_Pais1ValCountry
		// POST: /Regio/Regiapro_Pais1ValCountry
		[ActionName("Regiapro_Pais1ValCountry")]
		public ActionResult Regiapro_Pais1ValCountry([FromBody] Regiapro_Pais1ValCountryModel requestModel)
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
			Regiapro_Pais1ValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regiapro_ValImoveissModel : RequestLookupModel
		{
			public Regiapro_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regiapro_ValImoveiss
		// POST: /Regio/Regiapro_ValImoveiss
		[ActionName("Regiapro_ValImoveiss")]
		public ActionResult Regiapro_ValImoveiss([FromBody] Regiapro_ValImoveissModel requestModel)
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
			Regiapro_ValImoveiss_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regiapro_ValImoveislModel : RequestLookupModel
		{
			public Regiapro_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regiapro_ValImoveisl
		// POST: /Regio/Regiapro_ValImoveisl
		[ActionName("Regiapro_ValImoveisl")]
		public ActionResult Regiapro_ValImoveisl([FromBody] Regiapro_ValImoveislModel requestModel)
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
			Regiapro_ValImoveisl_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Regiapro_ValImoveisgModel : RequestLookupModel
		{
			public Regiapro_ViewModel Model { get; set; }
		}

		//
		// GET: /Regio/Regiapro_ValImoveisg
		// POST: /Regio/Regiapro_ValImoveisg
		[ActionName("Regiapro_ValImoveisg")]
		public ActionResult Regiapro_ValImoveisg([FromBody] Regiapro_ValImoveisgModel requestModel)
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
			Regiapro_ValImoveisg_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Regio/Regiapro_SaveEdit
		[HttpPost]
		public ActionResult Regiapro_SaveEdit([FromBody]Regiapro_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Regiapro_SaveEdit",
				ViewName = "Regiapro",
				AreaName = "regio",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT REGIAPRO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT REGIAPRO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
