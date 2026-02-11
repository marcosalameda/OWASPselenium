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

		private static readonly NavigationLocation ACTION_ASSET_CANCEL = new("ASSET37028", "Asset_Cancel", "Asset") { vueRouteName = "form-ASSET", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ASSET_SHOW = new("ASSET37028", "Asset_Show", "Asset") { vueRouteName = "form-ASSET", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ASSET_NEW = new("ASSET37028", "Asset_New", "Asset") { vueRouteName = "form-ASSET", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ASSET_EDIT = new("ASSET37028", "Asset_Edit", "Asset") { vueRouteName = "form-ASSET", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ASSET_DUPLICATE = new("ASSET37028", "Asset_Duplicate", "Asset") { vueRouteName = "form-ASSET", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ASSET_DELETE = new("ASSET37028", "Asset_Delete", "Asset") { vueRouteName = "form-ASSET", mode = "DELETE" };

		#endregion

		#region Asset private

		private void FormHistoryLimits_Asset()
		{

		}

		#endregion

		#region Asset_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ASSET]/

		[HttpPost]
		public ActionResult Asset_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_Show_GET",
				AreaName = "asset",
				Location = ACTION_ASSET_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ASSET]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Asset_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ASSET]/
		[HttpPost]
		public ActionResult Asset_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Asset_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_New_GET",
				AreaName = "asset",
				FormName = "ASSET",
				Location = ACTION_ASSET_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Asset();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ASSET]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Asset/Asset_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ASSET]/
		[HttpPost]
		public ActionResult Asset_New([FromBody]Asset_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_New",
				ViewName = "Asset",
				AreaName = "asset",
				Location = ACTION_ASSET_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ASSET]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ASSET]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ASSET]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Asset_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ASSET]/
		[HttpPost]
		public ActionResult Asset_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_Edit_GET",
				AreaName = "asset",
				FormName = "ASSET",
				Location = ACTION_ASSET_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ASSET]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Asset/Asset_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ASSET]/
		[HttpPost]
		public ActionResult Asset_Edit([FromBody]Asset_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_Edit",
				ViewName = "Asset",
				AreaName = "asset",
				Location = ACTION_ASSET_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ASSET]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ASSET]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ASSET]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Asset_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ASSET]/
		[HttpPost]
		public ActionResult Asset_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_Delete_GET",
				AreaName = "asset",
				FormName = "ASSET",
				Location = ACTION_ASSET_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asset();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ASSET]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Asset/Asset_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ASSET]/
		[HttpPost]
		public ActionResult Asset_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asset_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Asset_Delete",
				ViewName = "Asset",
				AreaName = "asset",
				Location = ACTION_ASSET_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ASSET]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Asset_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ASSET");
		}

		#endregion

		#region Asset_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ASSET]/

		[HttpPost]
		public ActionResult Asset_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Asset_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asset_Duplicate_GET",
				AreaName = "asset",
				FormName = "ASSET",
				Location = ACTION_ASSET_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ASSET]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Asset/Asset_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ASSET]/
		[HttpPost]
		public ActionResult Asset_Duplicate([FromBody]Asset_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_Duplicate",
				ViewName = "Asset",
				AreaName = "asset",
				Location = ACTION_ASSET_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ASSET]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ASSET]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ASSET]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Asset_Cancel

		//
		// GET: /Asset/Asset_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ASSET]/
		public ActionResult Asset_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Asset model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("asset");

// USE /[MANUAL GQT BEFORE_CANCEL ASSET]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ASSET]/

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


		public class Asset_ManufValNameModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset_ManufValName
		// POST: /Asset/Asset_ManufValName
		[ActionName("Asset_ManufValName")]
		public ActionResult Asset_ManufValName([FromBody] Asset_ManufValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_manuf")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_manuf");
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
			Asset_ManufValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset_KindeValDesignatModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset_KindeValDesignat
		// POST: /Asset/Asset_KindeValDesignat
		[ActionName("Asset_KindeValDesignat")]
		public ActionResult Asset_KindeValDesignat([FromBody] Asset_KindeValDesignatModel requestModel)
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
			Asset_KindeValDesignat_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset02_ValAttachmeModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset02_ValAttachme
		// POST: /Asset/Asset02_ValAttachme
		[ActionName("Asset02_ValAttachme")]
		public ActionResult Asset02_ValAttachme([FromBody] Asset02_ValAttachmeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_attac")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_attac");
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
			Asset02_ValAttachme_ViewModel model = new(m_userContext, parentCtx);

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
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset03_ValDocumentModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset03_ValDocument
		// POST: /Asset/Asset03_ValDocument
		[ActionName("Asset03_ValDocument")]
		public ActionResult Asset03_ValDocument([FromBody] Asset03_ValDocumentModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_assma")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_assma");
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
			Asset03_ValDocument_ViewModel model = new(m_userContext, parentCtx);

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
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_Parameters([FromBody] RequestCargaModel requestModel)
		{
			string idsrc = requestModel.Idsrc;
			string iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Asset.Find(iddst, UserContext.Current).carga_Parameters(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 });
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return JsonERROR();
			}
		}

		#endregion

		public class Asset04_ValParamloaModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset04_ValParamloa
		// POST: /Asset/Asset04_ValParamloa
		[ActionName("Asset04_ValParamloa")]
		public ActionResult Asset04_ValParamloa([FromBody] Asset04_ValParamloaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_assma")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_assma");
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
			Asset04_ValParamloa_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_Manuals([FromBody] RequestCargaModel requestModel)
		{
			string idsrc = requestModel.Idsrc;
			string iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Asset.Find(iddst, UserContext.Current).carga_Manuals(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 });
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return JsonERROR();
			}
		}

		#endregion

		public class Asset04_ValManualsModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset04_ValManuals
		// POST: /Asset/Asset04_ValManuals
		[ActionName("Asset04_ValManuals")]
		public ActionResult Asset04_ValManuals([FromBody] Asset04_ValManualsModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_assma")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_assma");
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
			Asset04_ValManuals_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = requestModel.TableConfiguration ?? new();

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asset04_ValParameteModel : RequestLookupModel
		{
			public Asset_ViewModel Model { get; set; }
		}

		//
		// GET: /Asset/Asset04_ValParamete
		// POST: /Asset/Asset04_ValParamete
		[ActionName("Asset04_ValParamete")]
		public ActionResult Asset04_ValParamete([FromBody] Asset04_ValParameteModel requestModel)
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
			Asset04_ValParamete_ViewModel model = new(m_userContext, parentCtx);

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
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Asset/Asset_SaveEdit
		[HttpPost]
		public ActionResult Asset_SaveEdit([FromBody] Asset_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asset_SaveEdit",
				ViewName = "Asset",
				AreaName = "asset",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ASSET]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ASSET]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AssetDocumValidateTickets : RequestDocumValidateTickets
		{
			public Asset_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAsset([FromBody] AssetDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
