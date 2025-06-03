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

		private static readonly NavigationLocation ACTION_PLIST_CANCEL = new("PROPERTY_LIST14171", "Plist_Cancel", "Item") { vueRouteName = "form-PLIST", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PLIST_SHOW = new("PROPERTY_LIST14171", "Plist_Show", "Item") { vueRouteName = "form-PLIST", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PLIST_NEW = new("PROPERTY_LIST14171", "Plist_New", "Item") { vueRouteName = "form-PLIST", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PLIST_EDIT = new("PROPERTY_LIST14171", "Plist_Edit", "Item") { vueRouteName = "form-PLIST", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PLIST_DUPLICATE = new("PROPERTY_LIST14171", "Plist_Duplicate", "Item") { vueRouteName = "form-PLIST", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PLIST_DELETE = new("PROPERTY_LIST14171", "Plist_Delete", "Item") { vueRouteName = "form-PLIST", mode = "DELETE" };

		#endregion

		#region Plist private

		private void FormHistoryLimits_Plist()
		{

		}

		#endregion

		#region Plist_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PLIST]/

		[HttpPost]
		public ActionResult Plist_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Plist_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Show_GET",
				AreaName = "item",
				Location = ACTION_PLIST_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Plist();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PLIST]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Plist_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PLIST]/
		[HttpPost]
		public ActionResult Plist_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Plist_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Plist_New_GET",
				AreaName = "item",
				FormName = "PLIST",
				Location = ACTION_PLIST_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Plist();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PLIST]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Plist_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PLIST]/
		[HttpPost]
		public ActionResult Plist_New([FromBody]Plist_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Plist_New",
				ViewName = "Plist",
				AreaName = "item",
				Location = ACTION_PLIST_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PLIST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PLIST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PLIST]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Plist_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PLIST]/
		[HttpPost]
		public ActionResult Plist_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Plist_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Edit_GET",
				AreaName = "item",
				FormName = "PLIST",
				Location = ACTION_PLIST_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Plist();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PLIST]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Plist_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PLIST]/
		[HttpPost]
		public ActionResult Plist_Edit([FromBody]Plist_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Edit",
				ViewName = "Plist",
				AreaName = "item",
				Location = ACTION_PLIST_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PLIST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PLIST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PLIST]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Plist_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PLIST]/
		[HttpPost]
		public ActionResult Plist_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Plist_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Delete_GET",
				AreaName = "item",
				FormName = "PLIST",
				Location = ACTION_PLIST_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Plist();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PLIST]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Plist_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PLIST]/
		[HttpPost]
		public ActionResult Plist_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Plist_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Plist_Delete",
				ViewName = "Plist",
				AreaName = "item",
				Location = ACTION_PLIST_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PLIST]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Plist_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PLIST");
		}

		#endregion

		#region Plist_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PLIST]/

		[HttpPost]
		public ActionResult Plist_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Plist_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Duplicate_GET",
				AreaName = "item",
				FormName = "PLIST",
				Location = ACTION_PLIST_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PLIST]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Plist_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PLIST]/
		[HttpPost]
		public ActionResult Plist_Duplicate([FromBody]Plist_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Plist_Duplicate",
				ViewName = "Plist",
				AreaName = "item",
				Location = ACTION_PLIST_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PLIST]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PLIST]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PLIST]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Plist_Cancel

		//
		// GET: /Item/Plist_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PLIST]/
		public ActionResult Plist_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL PLIST]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PLIST]/

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


		public class Plist_WarehValWarehdesModel : RequestLookupModel
		{
			public Plist_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Plist_WarehValWarehdes
		// POST: /Item/Plist_WarehValWarehdes
		[ActionName("Plist_WarehValWarehdes")]
		public ActionResult Plist_WarehValWarehdes([FromBody] Plist_WarehValWarehdesModel requestModel)
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
			Plist_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Plist_ValPlistModel : RequestLookupModel
		{
			public Plist_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Plist_ValPlist
		// POST: /Item/Plist_ValPlist
		[ActionName("Plist_ValPlist")]
		public ActionResult Plist_ValPlist([FromBody] Plist_ValPlistModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_itemp")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_itemp");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Item parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Plist_ValPlist_ViewModel model = new(UserContext.Current, parentCtx);

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

			return JsonOK(model.Menu);
		}


		// POST: /Item/Plist_SaveEdit
		[HttpPost]
		public ActionResult Plist_SaveEdit([FromBody]Plist_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Plist_SaveEdit",
				ViewName = "Plist",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PLIST]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PLIST]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
