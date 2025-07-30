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
using GenioMVC.ViewModels.Indoc;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER INDOC]/

namespace GenioMVC.Controllers
{
	public partial class IndocController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DENTR_CANCEL = new("INPUT_DOCUMENT28194", "Dentr_Cancel", "Indoc") { vueRouteName = "form-DENTR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DENTR_SHOW = new("INPUT_DOCUMENT28194", "Dentr_Show", "Indoc") { vueRouteName = "form-DENTR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DENTR_NEW = new("INPUT_DOCUMENT28194", "Dentr_New", "Indoc") { vueRouteName = "form-DENTR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DENTR_EDIT = new("INPUT_DOCUMENT28194", "Dentr_Edit", "Indoc") { vueRouteName = "form-DENTR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DENTR_DUPLICATE = new("INPUT_DOCUMENT28194", "Dentr_Duplicate", "Indoc") { vueRouteName = "form-DENTR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DENTR_DELETE = new("INPUT_DOCUMENT28194", "Dentr_Delete", "Indoc") { vueRouteName = "form-DENTR", mode = "DELETE" };

		#endregion

		#region Dentr private

		private void FormHistoryLimits_Dentr()
		{

		}

		#endregion

		#region Dentr_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DENTR]/

		[HttpPost]
		public ActionResult Dentr_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dentr_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Show_GET",
				AreaName = "indoc",
				Location = ACTION_DENTR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dentr();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DENTR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dentr_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DENTR]/
		[HttpPost]
		public ActionResult Dentr_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Dentr_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_New_GET",
				AreaName = "indoc",
				FormName = "DENTR",
				Location = ACTION_DENTR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dentr();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DENTR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Indoc/Dentr_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DENTR]/
		[HttpPost]
		public ActionResult Dentr_New([FromBody]Dentr_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_New",
				ViewName = "Dentr",
				AreaName = "indoc",
				Location = ACTION_DENTR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DENTR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DENTR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DENTR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dentr_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DENTR]/
		[HttpPost]
		public ActionResult Dentr_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dentr_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Edit_GET",
				AreaName = "indoc",
				FormName = "DENTR",
				Location = ACTION_DENTR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dentr();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DENTR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Indoc/Dentr_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DENTR]/
		[HttpPost]
		public ActionResult Dentr_Edit([FromBody]Dentr_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Edit",
				ViewName = "Dentr",
				AreaName = "indoc",
				Location = ACTION_DENTR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DENTR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DENTR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DENTR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dentr_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DENTR]/
		[HttpPost]
		public ActionResult Dentr_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dentr_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Delete_GET",
				AreaName = "indoc",
				FormName = "DENTR",
				Location = ACTION_DENTR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dentr();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DENTR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Indoc/Dentr_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DENTR]/
		[HttpPost]
		public ActionResult Dentr_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dentr_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Delete",
				ViewName = "Dentr",
				AreaName = "indoc",
				Location = ACTION_DENTR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DENTR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dentr_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DENTR");
		}

		#endregion

		#region Dentr_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DENTR]/

		[HttpPost]
		public ActionResult Dentr_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Dentr_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Duplicate_GET",
				AreaName = "indoc",
				FormName = "DENTR",
				Location = ACTION_DENTR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DENTR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Indoc/Dentr_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DENTR]/
		[HttpPost]
		public ActionResult Dentr_Duplicate([FromBody]Dentr_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dentr_Duplicate",
				ViewName = "Dentr",
				AreaName = "indoc",
				Location = ACTION_DENTR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DENTR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DENTR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DENTR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dentr_Cancel

		//
		// GET: /Indoc/Dentr_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DENTR]/
		public ActionResult Dentr_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Indoc(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("indoc");

// USE /[MANUAL GQT BEFORE_CANCEL DENTR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DENTR]/

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

				Navigation.SetValue("ForcePrimaryRead_indoc", "true", true);
			}

			Navigation.ClearValue("indoc");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Dentr_CntryValCountryModel : RequestLookupModel
		{
			public Dentr_ViewModel Model { get; set; }
		}

		//
		// GET: /Indoc/Dentr_CntryValCountry
		// POST: /Indoc/Dentr_CntryValCountry
		[ActionName("Dentr_CntryValCountry")]
		public ActionResult Dentr_CntryValCountry([FromBody] Dentr_CntryValCountryModel requestModel)
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

			Models.Indoc parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Dentr_CntryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Dentr_CmpnyValDesignatModel : RequestLookupModel
		{
			public Dentr_ViewModel Model { get; set; }
		}

		//
		// GET: /Indoc/Dentr_CmpnyValDesignat
		// POST: /Indoc/Dentr_CmpnyValDesignat
		[ActionName("Dentr_CmpnyValDesignat")]
		public ActionResult Dentr_CmpnyValDesignat([FromBody] Dentr_CmpnyValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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

			Models.Indoc parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Dentr_CmpnyValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Dentr_PessoValNameModel : RequestLookupModel
		{
			public Dentr_ViewModel Model { get; set; }
		}

		//
		// GET: /Indoc/Dentr_PessoValName
		// POST: /Indoc/Dentr_PessoValName
		[ActionName("Dentr_PessoValName")]
		public ActionResult Dentr_PessoValName([FromBody] Dentr_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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

			Models.Indoc parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Dentr_PessoValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Dentr_Ware1ValWarehdesModel : RequestLookupModel
		{
			public Dentr_ViewModel Model { get; set; }
		}

		//
		// GET: /Indoc/Dentr_Ware1ValWarehdes
		// POST: /Indoc/Dentr_Ware1ValWarehdes
		[ActionName("Dentr_Ware1ValWarehdes")]
		public ActionResult Dentr_Ware1ValWarehdes([FromBody] Dentr_Ware1ValWarehdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ware1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ware1");
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

			Models.Indoc parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Dentr_Ware1ValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Dentr_ValEntradasModel : RequestLookupModel
		{
			public Dentr_ViewModel Model { get; set; }
		}

		//
		// GET: /Indoc/Dentr_ValEntradas
		// POST: /Indoc/Dentr_ValEntradas
		[ActionName("Dentr_ValEntradas")]
		public ActionResult Dentr_ValEntradas([FromBody] Dentr_ValEntradasModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = -1;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_ldent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_ldent");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Indoc parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Dentr_ValEntradas_ViewModel model = new(UserContext.Current, parentCtx);

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
			// Verificar se o user clicou to exportar os dados da Qlisting
			if (requestValues["ExportList"] != null && Convert.ToBoolean(requestValues["ExportList"]) && requestValues["ExportType"] != null)
			{
				string file = "Dentr_ValEntradas_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + requestValues["ExportType"];
				ListingMVC<CSGenioAldent> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, Request.IsAjaxRequest());
				byte[] fileBytes = null;

// USE /[MANUAL GQT OVERRQEXPORT DENTR_PSEUDENTRADAS]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, requestValues["ExportType"], Resources.Resources.ENTRIES32319);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, requestValues["ExportType"]));
			}

			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		[ActionName("ReorderDentr_ValEntradas")]
		public ActionResult ReorderDentr_ValEntradas([FromBody] RequestReorderModel requestModel)
		{
			var id = requestModel.Id;
			var position = requestModel.Position.ToString();

			Dentr_ValEntradas_ViewModel model = new(UserContext.Current);
			model.setModes(Request.Query["m"].ToString());
			model.IndocValCoddentr = Navigation.GetStrValue("indoc");
			model.Reorder(id, position);
			model.Load(-1);

			return JsonOK(model);
		}

		// POST: /Indoc/Dentr_SaveEdit
		[HttpPost]
		public ActionResult Dentr_SaveEdit([FromBody] Dentr_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dentr_SaveEdit",
				ViewName = "Dentr",
				AreaName = "indoc",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DENTR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DENTR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DentrDocumValidateTickets : RequestDocumValidateTickets
		{
			public Dentr_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDentr([FromBody] DentrDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
