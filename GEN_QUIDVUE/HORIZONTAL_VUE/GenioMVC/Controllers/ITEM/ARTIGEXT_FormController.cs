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

		private static readonly NavigationLocation ACTION_ARTIGEXT_CANCEL = new("ITEM40802", "Artigext_Cancel", "Item") { vueRouteName = "form-ARTIGEXT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARTIGEXT_SHOW = new("ITEM40802", "Artigext_Show", "Item") { vueRouteName = "form-ARTIGEXT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARTIGEXT_NEW = new("ITEM40802", "Artigext_New", "Item") { vueRouteName = "form-ARTIGEXT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARTIGEXT_EDIT = new("ITEM40802", "Artigext_Edit", "Item") { vueRouteName = "form-ARTIGEXT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARTIGEXT_DUPLICATE = new("ITEM40802", "Artigext_Duplicate", "Item") { vueRouteName = "form-ARTIGEXT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARTIGEXT_DELETE = new("ITEM40802", "Artigext_Delete", "Item") { vueRouteName = "form-ARTIGEXT", mode = "DELETE" };

		#endregion

		#region Artigext private

		private void FormHistoryLimits_Artigext()
		{

		}

		#endregion

		#region Artigext_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARTIGEXT]/

		[HttpPost]
		public ActionResult Artigext_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Show_GET",
				AreaName = "item",
				Location = ACTION_ARTIGEXT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigext();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARTIGEXT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Artigext_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Artigext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_New_GET",
				AreaName = "item",
				FormName = "ARTIGEXT",
				Location = ACTION_ARTIGEXT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Artigext();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARTIGEXT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Item/Artigext_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_New([FromBody]Artigext_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_New",
				ViewName = "Artigext",
				AreaName = "item",
				Location = ACTION_ARTIGEXT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARTIGEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARTIGEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARTIGEXT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Artigext_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Edit_GET",
				AreaName = "item",
				FormName = "ARTIGEXT",
				Location = ACTION_ARTIGEXT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigext();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARTIGEXT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Item/Artigext_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_Edit([FromBody]Artigext_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Edit",
				ViewName = "Artigext",
				AreaName = "item",
				Location = ACTION_ARTIGEXT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARTIGEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARTIGEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARTIGEXT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Artigext_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Delete_GET",
				AreaName = "item",
				FormName = "ARTIGEXT",
				Location = ACTION_ARTIGEXT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Artigext();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARTIGEXT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Item/Artigext_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Artigext_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Delete",
				ViewName = "Artigext",
				AreaName = "item",
				Location = ACTION_ARTIGEXT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARTIGEXT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Artigext_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARTIGEXT");
		}

		#endregion

		#region Artigext_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARTIGEXT]/

		[HttpPost]
		public ActionResult Artigext_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Artigext_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Duplicate_GET",
				AreaName = "item",
				FormName = "ARTIGEXT",
				Location = ACTION_ARTIGEXT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARTIGEXT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Item/Artigext_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARTIGEXT]/
		[HttpPost]
		public ActionResult Artigext_Duplicate([FromBody]Artigext_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_Duplicate",
				ViewName = "Artigext",
				AreaName = "item",
				Location = ACTION_ARTIGEXT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARTIGEXT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARTIGEXT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARTIGEXT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Artigext_Cancel

		//
		// GET: /Item/Artigext_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARTIGEXT]/
		public ActionResult Artigext_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Item(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("item");

// USE /[MANUAL GQT BEFORE_CANCEL ARTIGEXT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARTIGEXT]/

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


		public class Artigext_WarehValWarehdesModel : RequestLookupModel
		{
			public Artigext_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artigext_WarehValWarehdes
		// POST: /Item/Artigext_WarehValWarehdes
		[ActionName("Artigext_WarehValWarehdes")]
		public ActionResult Artigext_WarehValWarehdes([FromBody] Artigext_WarehValWarehdesModel requestModel)
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
			Artigext_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Artigext_GitemValItemdesModel : RequestLookupModel
		{
			public Artigext_ViewModel Model { get; set; }
		}

		//
		// GET: /Item/Artigext_GitemValItemdes
		// POST: /Item/Artigext_GitemValItemdes
		[ActionName("Artigext_GitemValItemdes")]
		public ActionResult Artigext_GitemValItemdes([FromBody] Artigext_GitemValItemdesModel requestModel)
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
			Artigext_GitemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Item/Artigext_SaveEdit
		[HttpPost]
		public ActionResult Artigext_SaveEdit([FromBody]Artigext_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Artigext_SaveEdit",
				ViewName = "Artigext",
				AreaName = "item",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARTIGEXT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARTIGEXT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
