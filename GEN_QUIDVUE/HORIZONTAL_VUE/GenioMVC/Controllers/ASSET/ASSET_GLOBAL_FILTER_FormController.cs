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
using System.Dynamic;

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
using GenioMVC.ViewModels.Asset;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSET]/

namespace GenioMVC.Controllers
{
	public partial class AssetController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_CANCEL = new("ASSET37028", "Asset_global_filter_Cancel", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_SHOW = new("ASSET37028", "Asset_global_filter_Show", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_NEW = new("ASSET37028", "Asset_global_filter_New", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_EDIT = new("ASSET37028", "Asset_global_filter_Edit", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_DUPLICATE = new("ASSET37028", "Asset_global_filter_Duplicate", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ASSET_GLOBAL_FILTER_DELETE = new("ASSET37028", "Asset_global_filter_Delete", "Asset") { vueRouteName = "form-ASSET_GLOBAL_FILTER", mode = "DELETE" };

		#endregion

		#region Asset_global_filter private

		private void FormHistoryLimits_Asset_global_filter()
		{

		}

		#endregion

		#region Asset_global_filter_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ASSET_GLOBAL_FILTER]/

		[HttpPost]
		public ActionResult Asset_global_filter_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_global_filter_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Show_GET",
				AreaName = "asset",
				Location = ACTION_ASSET_GLOBAL_FILTER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset_global_filter();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Asset_global_filter_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Asset_global_filter_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_New_GET",
				AreaName = "asset",
				FormName = "ASSET_GLOBAL_FILTER",
				Location = ACTION_ASSET_GLOBAL_FILTER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Asset_global_filter();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Asset/Asset_global_filter_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_New([FromBody]Asset_global_filter_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_New",
				ViewName = "Asset_global_filter",
				AreaName = "asset",
				Location = ACTION_ASSET_GLOBAL_FILTER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ASSET_GLOBAL_FILTER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ASSET_GLOBAL_FILTER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Asset_global_filter_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_global_filter_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Edit_GET",
				AreaName = "asset",
				FormName = "ASSET_GLOBAL_FILTER",
				Location = ACTION_ASSET_GLOBAL_FILTER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset_global_filter();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Asset/Asset_global_filter_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_Edit([FromBody]Asset_global_filter_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Edit",
				ViewName = "Asset_global_filter",
				AreaName = "asset",
				Location = ACTION_ASSET_GLOBAL_FILTER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ASSET_GLOBAL_FILTER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ASSET_GLOBAL_FILTER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Asset_global_filter_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_global_filter_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Delete_GET",
				AreaName = "asset",
				FormName = "ASSET_GLOBAL_FILTER",
				Location = ACTION_ASSET_GLOBAL_FILTER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset_global_filter();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Asset/Asset_global_filter_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_global_filter_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Delete",
				ViewName = "Asset_global_filter",
				AreaName = "asset",
				Location = ACTION_ASSET_GLOBAL_FILTER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Asset_global_filter_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ASSET_GLOBAL_FILTER");
		}

		#endregion

		#region Asset_global_filter_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ASSET_GLOBAL_FILTER]/

		[HttpPost]
		public ActionResult Asset_global_filter_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Asset_global_filter_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Duplicate_GET",
				AreaName = "asset",
				FormName = "ASSET_GLOBAL_FILTER",
				Location = ACTION_ASSET_GLOBAL_FILTER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Asset/Asset_global_filter_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ASSET_GLOBAL_FILTER]/
		[HttpPost]
		public ActionResult Asset_global_filter_Duplicate([FromBody]Asset_global_filter_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_Duplicate",
				ViewName = "Asset_global_filter",
				AreaName = "asset",
				Location = ACTION_ASSET_GLOBAL_FILTER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ASSET_GLOBAL_FILTER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ASSET_GLOBAL_FILTER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Asset_global_filter_Cancel

		//
		// GET: /Asset/Asset_global_filter_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ASSET_GLOBAL_FILTER]/
		public ActionResult Asset_global_filter_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Asset model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("asset");

// USE /[MANUAL GQT BEFORE_CANCEL ASSET_GLOBAL_FILTER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ASSET_GLOBAL_FILTER]/

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

				Navigation.SetValue("ForcePrimaryRead_asset", "true", true);
			}

			Navigation.ClearValue("asset");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Asset_global_filter_KindeValDesignatModel : RequestLookupModel
		{
			public Asset_global_filter_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset_global_filter_KindeValDesignat
		// POST: /Asset/Asset_global_filter_KindeValDesignat
		[ActionName("Asset_global_filter_KindeValDesignat")]
		public ActionResult Asset_global_filter_KindeValDesignat([FromBody] Asset_global_filter_KindeValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_kinde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_kinde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Asset parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Asset_global_filter_KindeValDesignat_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset_global_filter_ValParameterModel : RequestLookupModel
		{
			public Asset_global_filter_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset_global_filter_ValParameter
		// POST: /Asset/Asset_global_filter_ValParameter
		[ActionName("Asset_global_filter_ValParameter")]
		public ActionResult Asset_global_filter_ValParameter([FromBody] Asset_global_filter_ValParameterModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_param")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_param");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Asset parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Asset_global_filter_ValParameter_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset_global_filter_ValAsspa_filtred_by_paramModel : RequestLookupModel
		{
			public Asset_global_filter_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset_global_filter_ValAsspa_filtred_by_param
		// POST: /Asset/Asset_global_filter_ValAsspa_filtred_by_param
		[ActionName("Asset_global_filter_ValAsspa_filtred_by_param")]
		public ActionResult Asset_global_filter_ValAsspa_filtred_by_param([FromBody] Asset_global_filter_ValAsspa_filtred_by_paramModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asspa")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asspa");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Asset parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Asset_global_filter_ValAsspa_filtred_by_param_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.legacy.v1.TableConfigurationUpdate.SetFilterShiftValue(model.Uuid, "filter_ValAsspa_filtred_by_param_PARAM_TYPE", 0);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			// Verificar se o user clicou to exportar os dados da Qlisting
			if (requestValues["ExportList"] != null && Convert.ToBoolean(requestValues["ExportList"]) && requestValues["ExportType"] != null)
			{
				string file = "Asset_global_filter_ValAsspa_filtred_by_param_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + requestValues["ExportType"];
				ListingMVC<CSGenioAasspa> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, Request.IsAjaxRequest());
				byte[] fileBytes = null;

// USE /[MANUAL GQT OVERRQEXPORT ASSET_GLOBAL_FILTER_PSEUDASSPA_FILTRED_BY_PARAM]/
				// Protected against cases where it receive zero columns. Otherwise, it will select all columns in the area.
				if (listing.RequestFields.Length == 0)
					return JsonERROR(Resources.Resources.A_EXPORTACAO_NAO_POD03671);
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, requestValues["ExportType"], Resources.Resources.ASSET_PARAMETERS20615);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, requestValues["ExportType"]));
			}

			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Asset/Asset_global_filter_SaveEdit
		[HttpPost]
		public ActionResult Asset_global_filter_SaveEdit([FromBody] Asset_global_filter_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_global_filter_SaveEdit",
				ViewName = "Asset_global_filter",
				AreaName = "asset",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ASSET_GLOBAL_FILTER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ASSET_GLOBAL_FILTER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Asset_global_filterDocumValidateTickets : RequestDocumValidateTickets
		{
			public Asset_global_filter_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAsset_global_filter([FromBody] Asset_global_filterDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
