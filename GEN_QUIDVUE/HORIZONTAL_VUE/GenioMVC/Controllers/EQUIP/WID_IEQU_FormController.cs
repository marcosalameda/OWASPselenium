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

		private static readonly NavigationLocation ACTION_WID_IEQU_CANCEL = new("EQUIPMENT03632", "Wid_iequ_Cancel", "Equip") { vueRouteName = "form-WID_IEQU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_WID_IEQU_SHOW = new("EQUIPMENT03632", "Wid_iequ_Show", "Equip") { vueRouteName = "form-WID_IEQU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_WID_IEQU_NEW = new("EQUIPMENT03632", "Wid_iequ_New", "Equip") { vueRouteName = "form-WID_IEQU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_WID_IEQU_EDIT = new("EQUIPMENT03632", "Wid_iequ_Edit", "Equip") { vueRouteName = "form-WID_IEQU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_WID_IEQU_DUPLICATE = new("EQUIPMENT03632", "Wid_iequ_Duplicate", "Equip") { vueRouteName = "form-WID_IEQU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_WID_IEQU_DELETE = new("EQUIPMENT03632", "Wid_iequ_Delete", "Equip") { vueRouteName = "form-WID_IEQU", mode = "DELETE" };

		#endregion

		#region Wid_iequ private

		private void FormHistoryLimits_Wid_iequ()
		{

		}

		#endregion

		#region Wid_iequ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW WID_IEQU]/

		[HttpPost]
		public ActionResult Wid_iequ_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_iequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Show_GET",
				AreaName = "equip",
				Location = ACTION_WID_IEQU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_iequ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW WID_IEQU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Wid_iequ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Wid_iequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_New_GET",
				AreaName = "equip",
				FormName = "WID_IEQU",
				Location = ACTION_WID_IEQU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Wid_iequ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW WID_IEQU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Wid_iequ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_New([FromBody]Wid_iequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_New",
				ViewName = "Wid_iequ",
				AreaName = "equip",
				Location = ACTION_WID_IEQU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW WID_IEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX WID_IEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX WID_IEQU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Wid_iequ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_iequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Edit_GET",
				AreaName = "equip",
				FormName = "WID_IEQU",
				Location = ACTION_WID_IEQU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_iequ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT WID_IEQU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Wid_iequ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_Edit([FromBody]Wid_iequ_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Edit",
				ViewName = "Wid_iequ",
				AreaName = "equip",
				Location = ACTION_WID_IEQU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT WID_IEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX WID_IEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX WID_IEQU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Wid_iequ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_iequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Delete_GET",
				AreaName = "equip",
				FormName = "WID_IEQU",
				Location = ACTION_WID_IEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Wid_iequ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE WID_IEQU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Wid_iequ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Wid_iequ_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Delete",
				ViewName = "Wid_iequ",
				AreaName = "equip",
				Location = ACTION_WID_IEQU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE WID_IEQU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Wid_iequ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("WID_IEQU");
		}

		#endregion

		#region Wid_iequ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET WID_IEQU]/

		[HttpPost]
		public ActionResult Wid_iequ_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Wid_iequ_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Duplicate_GET",
				AreaName = "equip",
				FormName = "WID_IEQU",
				Location = ACTION_WID_IEQU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE WID_IEQU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Wid_iequ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST WID_IEQU]/
		[HttpPost]
		public ActionResult Wid_iequ_Duplicate([FromBody]Wid_iequ_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_Duplicate",
				ViewName = "Wid_iequ",
				AreaName = "equip",
				Location = ACTION_WID_IEQU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE WID_IEQU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX WID_IEQU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX WID_IEQU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Wid_iequ_Cancel

		//
		// GET: /Equip/Wid_iequ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET WID_IEQU]/
		public ActionResult Wid_iequ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL WID_IEQU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL WID_IEQU]/

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


		public class Wid_iequ_TpequValTipoequiModel : RequestLookupModel
		{
			public Wid_iequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Wid_iequ_TpequValTipoequi
		// POST: /Equip/Wid_iequ_TpequValTipoequi
		[ActionName("Wid_iequ_TpequValTipoequi")]
		public ActionResult Wid_iequ_TpequValTipoequi([FromBody] Wid_iequ_TpequValTipoequiModel requestModel)
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
			Wid_iequ_TpequValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Wid_iequ_WarehValWarehdesModel : RequestLookupModel
		{
			public Wid_iequ_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Wid_iequ_WarehValWarehdes
		// POST: /Equip/Wid_iequ_WarehValWarehdes
		[ActionName("Wid_iequ_WarehValWarehdes")]
		public ActionResult Wid_iequ_WarehValWarehdes([FromBody] Wid_iequ_WarehValWarehdesModel requestModel)
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
			Wid_iequ_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Equip/Wid_iequ_SaveEdit
		[HttpPost]
		public ActionResult Wid_iequ_SaveEdit([FromBody] Wid_iequ_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Wid_iequ_SaveEdit",
				ViewName = "Wid_iequ",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT WID_IEQU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT WID_IEQU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Wid_iequDocumValidateTickets : RequestDocumValidateTickets
		{
			public Wid_iequ_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsWid_iequ([FromBody] Wid_iequDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
