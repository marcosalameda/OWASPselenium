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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EQUIP_ITEM_CANCEL = new("ARTICLES59822", "Equip_item_Cancel", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EQUIP_ITEM_SHOW = new("ARTICLES59822", "Equip_item_Show", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EQUIP_ITEM_NEW = new("ARTICLES59822", "Equip_item_New", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EQUIP_ITEM_EDIT = new("ARTICLES59822", "Equip_item_Edit", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EQUIP_ITEM_DUPLICATE = new("ARTICLES59822", "Equip_item_Duplicate", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EQUIP_ITEM_DELETE = new("ARTICLES59822", "Equip_item_Delete", "Item") { vueRouteName = "form-EQUIP_ITEM", mode = "DELETE" };

		#endregion

		#region Equip_item private

		private void FormHistoryLimits_Equip_item()
		{

		}

		#endregion

		#region Equip_item_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EQUIP_ITEM]/

		[HttpPost]
		public ActionResult Equip_item_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equip_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Show_GET",
				AreaName = "item",
				Location = ACTION_EQUIP_ITEM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equip_item();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EQUIP_ITEM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Equip_item_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Equip_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_New_GET",
				AreaName = "item",
				FormName = "EQUIP_ITEM",
				Location = ACTION_EQUIP_ITEM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Equip_item();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EQUIP_ITEM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Equip_item_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_New([FromBody]Equip_item_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_New",
				ViewName = "Equip_item",
				AreaName = "item",
				Location = ACTION_EQUIP_ITEM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EQUIP_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EQUIP_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EQUIP_ITEM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Equip_item_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equip_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Edit_GET",
				AreaName = "item",
				FormName = "EQUIP_ITEM",
				Location = ACTION_EQUIP_ITEM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equip_item();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EQUIP_ITEM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Equip_item_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_Edit([FromBody]Equip_item_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Edit",
				ViewName = "Equip_item",
				AreaName = "item",
				Location = ACTION_EQUIP_ITEM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EQUIP_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EQUIP_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EQUIP_ITEM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Equip_item_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equip_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Delete_GET",
				AreaName = "item",
				FormName = "EQUIP_ITEM",
				Location = ACTION_EQUIP_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Equip_item();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EQUIP_ITEM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Equip_item_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Equip_item_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Delete",
				ViewName = "Equip_item",
				AreaName = "item",
				Location = ACTION_EQUIP_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EQUIP_ITEM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Equip_item_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EQUIP_ITEM");
		}

		#endregion

		#region Equip_item_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EQUIP_ITEM]/

		[HttpPost]
		public ActionResult Equip_item_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Equip_item_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Duplicate_GET",
				AreaName = "item",
				FormName = "EQUIP_ITEM",
				Location = ACTION_EQUIP_ITEM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EQUIP_ITEM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Equip_item_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EQUIP_ITEM]/
		[HttpPost]
		public ActionResult Equip_item_Duplicate([FromBody]Equip_item_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_Duplicate",
				ViewName = "Equip_item",
				AreaName = "item",
				Location = ACTION_EQUIP_ITEM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EQUIP_ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EQUIP_ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EQUIP_ITEM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Equip_item_Cancel

		//
		// GET: /Item/Equip_item_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EQUIP_ITEM]/
		public ActionResult Equip_item_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Item model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL EQUIP_ITEM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EQUIP_ITEM]/

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

				Navigation.SetValue("ForcePrimaryRead_item", "true", true);
			}

			Navigation.ClearValue("item");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Equip_item_GitemValItemdesModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_GitemValItemdes
		// POST: /Item/Equip_item_GitemValItemdes
		[ActionName("Equip_item_GitemValItemdes")]
		public ActionResult Equip_item_GitemValItemdes([FromBody] Equip_item_GitemValItemdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_gitem")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_gitem");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_GitemValItemdes_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equip_item_WarehValWarehdesModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_WarehValWarehdes
		// POST: /Item/Equip_item_WarehValWarehdes
		[ActionName("Equip_item_WarehValWarehdes")]
		public ActionResult Equip_item_WarehValWarehdes([FromBody] Equip_item_WarehValWarehdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wareh")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wareh");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_WarehValWarehdes_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equip_item_ValCountryModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_ValCountry
		// POST: /Item/Equip_item_ValCountry
		[ActionName("Equip_item_ValCountry")]
		public ActionResult Equip_item_ValCountry([FromBody] Equip_item_ValCountryModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_ValCountry_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equip_item_ValDesignatModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_ValDesignat
		// POST: /Item/Equip_item_ValDesignat
		[ActionName("Equip_item_ValDesignat")]
		public ActionResult Equip_item_ValDesignat([FromBody] Equip_item_ValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_ValDesignat_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equip_item_ValNameModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_ValName
		// POST: /Item/Equip_item_ValName
		[ActionName("Equip_item_ValName")]
		public ActionResult Equip_item_ValName([FromBody] Equip_item_ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess1");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_ValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Equip_item_ValEquip_filtradoModel : RequestLookupModel
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Equip_item_ValEquip_filtrado
		// POST: /Item/Equip_item_ValEquip_filtrado
		[ActionName("Equip_item_ValEquip_filtrado")]
		public ActionResult Equip_item_ValEquip_filtrado([FromBody] Equip_item_ValEquip_filtradoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Item parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Equip_item_ValEquip_filtrado_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Item/Equip_item_SaveEdit
		[HttpPost]
		public ActionResult Equip_item_SaveEdit([FromBody] Equip_item_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Equip_item_SaveEdit",
				ViewName = "Equip_item",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EQUIP_ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EQUIP_ITEM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Equip_itemDocumValidateTickets : RequestDocumValidateTickets
		{
			public Equip_item_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEquip_item([FromBody] Equip_itemDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field TECHSPEC
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileEquip_itemTechspec([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
