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
using GenioMVC.ViewModels.Equip;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER EQUIP]/

namespace GenioMVC.Controllers
{
	public partial class EquipController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GROUPBX_CANCEL = new("GROUPBOX00384", "Groupbx_Cancel", "Equip") { vueRouteName = "form-GROUPBX", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GROUPBX_SHOW = new("GROUPBOX00384", "Groupbx_Show", "Equip") { vueRouteName = "form-GROUPBX", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GROUPBX_NEW = new("GROUPBOX00384", "Groupbx_New", "Equip") { vueRouteName = "form-GROUPBX", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GROUPBX_EDIT = new("GROUPBOX00384", "Groupbx_Edit", "Equip") { vueRouteName = "form-GROUPBX", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GROUPBX_DUPLICATE = new("GROUPBOX00384", "Groupbx_Duplicate", "Equip") { vueRouteName = "form-GROUPBX", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GROUPBX_DELETE = new("GROUPBOX00384", "Groupbx_Delete", "Equip") { vueRouteName = "form-GROUPBX", mode = "DELETE" };

		#endregion

		#region Groupbx private

		private void FormHistoryLimits_Groupbx()
		{

		}

		#endregion

		#region Groupbx_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GROUPBX]/

		[HttpPost]
		public ActionResult Groupbx_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Show_GET",
				AreaName = "equip",
				Location = ACTION_GROUPBX_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GROUPBX]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Groupbx_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_New_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GROUPBX]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Groupbx_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_New([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_New",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Groupbx_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Edit_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GROUPBX]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Groupbx_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Edit([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Edit",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Groupbx_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Delete_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Groupbx();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GROUPBX]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Groupbx_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Groupbx_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Delete",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GROUPBX]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Groupbx_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GROUPBX");
		}

		#endregion

		#region Groupbx_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GROUPBX]/

		[HttpPost]
		public ActionResult Groupbx_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Groupbx_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Duplicate_GET",
				AreaName = "equip",
				FormName = "GROUPBX",
				Location = ACTION_GROUPBX_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GROUPBX]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Groupbx_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GROUPBX]/
		[HttpPost]
		public ActionResult Groupbx_Duplicate([FromBody]Groupbx_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_Duplicate",
				ViewName = "Groupbx",
				AreaName = "equip",
				Location = ACTION_GROUPBX_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GROUPBX]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GROUPBX]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GROUPBX]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Groupbx_Cancel

		//
		// GET: /Equip/Groupbx_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GROUPBX]/
		public ActionResult Groupbx_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL GROUPBX]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GROUPBX]/

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

				Navigation.SetValue("ForcePrimaryRead_equip", "true", true);
			}

			Navigation.ClearValue("equip");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Groupbx_TpequValTipoequiModel : RequestLookupModel
		{
			public Groupbx_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Groupbx_TpequValTipoequi
		// POST: /Equip/Groupbx_TpequValTipoequi
		[ActionName("Groupbx_TpequValTipoequi")]
		public ActionResult Groupbx_TpequValTipoequi([FromBody] Groupbx_TpequValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Groupbx_TpequValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Groupbx_WarehValWarehdesModel : RequestLookupModel
		{
			public Groupbx_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Groupbx_WarehValWarehdes
		// POST: /Equip/Groupbx_WarehValWarehdes
		[ActionName("Groupbx_WarehValWarehdes")]
		public ActionResult Groupbx_WarehValWarehdes([FromBody] Groupbx_WarehValWarehdesModel requestModel)
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Groupbx_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Groupbx_ItemValItemdesModel : RequestLookupModel
		{
			public Groupbx_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Groupbx_ItemValItemdes
		// POST: /Equip/Groupbx_ItemValItemdes
		[ActionName("Groupbx_ItemValItemdes")]
		public ActionResult Groupbx_ItemValItemdes([FromBody] Groupbx_ItemValItemdesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_item")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_item");
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

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Groupbx_ItemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Equip/Groupbx_SaveEdit
		[HttpPost]
		public ActionResult Groupbx_SaveEdit([FromBody] Groupbx_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Groupbx_SaveEdit",
				ViewName = "Groupbx",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GROUPBX]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GROUPBX]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class GroupbxDocumValidateTickets : RequestDocumValidateTickets
		{
			public Groupbx_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGroupbx([FromBody] GroupbxDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
