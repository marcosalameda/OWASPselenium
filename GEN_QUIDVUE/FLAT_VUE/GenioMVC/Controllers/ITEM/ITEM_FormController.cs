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
using GenioMVC.ViewModels.Item;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ITEM]/

namespace GenioMVC.Controllers
{
	public partial class ItemController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ITEM_CANCEL = new("ARTICLES59822", "Item_Cancel", "Item") { vueRouteName = "form-ITEM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ITEM_SHOW = new("ARTICLES59822", "Item_Show", "Item") { vueRouteName = "form-ITEM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ITEM_NEW = new("ARTICLES59822", "Item_New", "Item") { vueRouteName = "form-ITEM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ITEM_EDIT = new("ARTICLES59822", "Item_Edit", "Item") { vueRouteName = "form-ITEM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ITEM_DUPLICATE = new("ARTICLES59822", "Item_Duplicate", "Item") { vueRouteName = "form-ITEM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ITEM_DELETE = new("ARTICLES59822", "Item_Delete", "Item") { vueRouteName = "form-ITEM", mode = "DELETE" };

		#endregion

		#region Item private

		private void FormHistoryLimits_Item()
		{

		}

		#endregion

		#region Item_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ITEM]/

		[HttpPost]
		public ActionResult Item_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Item_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Item_Show_GET",
				AreaName = "item",
				Location = ACTION_ITEM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Item();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ITEM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Item_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ITEM]/
		[HttpPost]
		public ActionResult Item_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Item_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Item_New_GET",
				AreaName = "item",
				FormName = "ITEM",
				Location = ACTION_ITEM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Item();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ITEM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Item_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ITEM]/
		[HttpPost]
		public ActionResult Item_New([FromBody]Item_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Item_New",
				ViewName = "Item",
				AreaName = "item",
				Location = ACTION_ITEM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ITEM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Item_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ITEM]/
		[HttpPost]
		public ActionResult Item_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Item_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Item_Edit_GET",
				AreaName = "item",
				FormName = "ITEM",
				Location = ACTION_ITEM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Item();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ITEM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Item_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ITEM]/
		[HttpPost]
		public ActionResult Item_Edit([FromBody]Item_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Item_Edit",
				ViewName = "Item",
				AreaName = "item",
				Location = ACTION_ITEM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ITEM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Item_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ITEM]/
		[HttpPost]
		public ActionResult Item_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Item_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Item_Delete_GET",
				AreaName = "item",
				FormName = "ITEM",
				Location = ACTION_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Item();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ITEM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Item_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ITEM]/
		[HttpPost]
		public ActionResult Item_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Item_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Item_Delete",
				ViewName = "Item",
				AreaName = "item",
				Location = ACTION_ITEM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ITEM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Item_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ITEM");
		}

		#endregion

		#region Item_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ITEM]/

		[HttpPost]
		public ActionResult Item_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Item_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Item_Duplicate_GET",
				AreaName = "item",
				FormName = "ITEM",
				Location = ACTION_ITEM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ITEM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Item_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ITEM]/
		[HttpPost]
		public ActionResult Item_Duplicate([FromBody]Item_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Item_Duplicate",
				ViewName = "Item",
				AreaName = "item",
				Location = ACTION_ITEM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ITEM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ITEM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ITEM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Item_Cancel

		//
		// GET: /Item/Item_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ITEM]/
		public ActionResult Item_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ITEM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ITEM]/

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


		public class Item_GitemValItemdesModel : RequestLookupModel
		{
			public Item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Item_GitemValItemdes
		// POST: /Item/Item_GitemValItemdes
		[ActionName("Item_GitemValItemdes")]
		public ActionResult Item_GitemValItemdes([FromBody] Item_GitemValItemdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_gitem")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_gitem");
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Item_GitemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Item_WarehValWarehdesModel : RequestLookupModel
		{
			public Item_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Item_WarehValWarehdes
		// POST: /Item/Item_WarehValWarehdes
		[ActionName("Item_WarehValWarehdes")]
		public ActionResult Item_WarehValWarehdes([FromBody] Item_WarehValWarehdesModel requestModel)
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

			Models.Item parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Item_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Item/Item_SaveEdit
		[HttpPost]
		public ActionResult Item_SaveEdit([FromBody] Item_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Item_SaveEdit",
				ViewName = "Item",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ITEM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ITEM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ItemDocumValidateTickets : RequestDocumValidateTickets
		{
			public Item_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsItem([FromBody] ItemDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}

		/// <summary>
		/// Stores a new document, in the Docums table, associated to field TECHSPEC
		/// </summary>
		/// <param name="requestModel">The request model with the document and ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFileItemTechspec([FromForm] RequestDocumsCreateModel requestModel)
		{
			List<string> extensions = [];
			return base.SetFile(requestModel.Ticket, requestModel.Mode, requestModel.Version, extensions);
		}
	}
}
