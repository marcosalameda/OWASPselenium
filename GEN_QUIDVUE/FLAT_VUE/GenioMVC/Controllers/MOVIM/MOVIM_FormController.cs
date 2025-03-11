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
using GenioMVC.ViewModels.Movim;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER MOVIM]/

namespace GenioMVC.Controllers
{
	public partial class MovimController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_MOVIM_CANCEL = new("DRIVE03517", "Movim_Cancel", "Movim") { vueRouteName = "form-MOVIM", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_MOVIM_SHOW = new("DRIVE03517", "Movim_Show", "Movim") { vueRouteName = "form-MOVIM", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_MOVIM_NEW = new("DRIVE03517", "Movim_New", "Movim") { vueRouteName = "form-MOVIM", mode = "NEW" };
		private static readonly NavigationLocation ACTION_MOVIM_EDIT = new("DRIVE03517", "Movim_Edit", "Movim") { vueRouteName = "form-MOVIM", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_MOVIM_DUPLICATE = new("DRIVE03517", "Movim_Duplicate", "Movim") { vueRouteName = "form-MOVIM", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_MOVIM_DELETE = new("DRIVE03517", "Movim_Delete", "Movim") { vueRouteName = "form-MOVIM", mode = "DELETE" };

		#endregion

		#region Movim private

		private void FormHistoryLimits_Movim()
		{

		}

		#endregion

		#region Movim_Show

// USE /[MANUAL GQT CONTROLLER_SHOW MOVIM]/

		[HttpPost]
		public ActionResult Movim_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Show_GET",
				AreaName = "movim",
				Location = ACTION_MOVIM_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW MOVIM]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Movim_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_New_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW MOVIM]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Movim/Movim_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_New([FromBody]Movim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_New",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX MOVIM]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Movim_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Edit_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT MOVIM]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Movim/Movim_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Edit([FromBody]Movim_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Edit",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX MOVIM]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Movim_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET MOVIM]/
		[HttpPost]
		public ActionResult Movim_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Delete_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Movim();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE MOVIM]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Movim/Movim_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Movim_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Movim_Delete",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE MOVIM]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Movim_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("MOVIM");
		}

		#endregion

		#region Movim_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET MOVIM]/

		[HttpPost]
		public ActionResult Movim_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Movim_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Duplicate_GET",
				AreaName = "movim",
				FormName = "MOVIM",
				Location = ACTION_MOVIM_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE MOVIM]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Movim/Movim_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST MOVIM]/
		[HttpPost]
		public ActionResult Movim_Duplicate([FromBody]Movim_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_Duplicate",
				ViewName = "Movim",
				AreaName = "movim",
				Location = ACTION_MOVIM_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE MOVIM]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX MOVIM]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX MOVIM]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Movim_Cancel

		//
		// GET: /Movim/Movim_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET MOVIM]/
		public ActionResult Movim_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Movim(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("movim");

// USE /[MANUAL GQT BEFORE_CANCEL MOVIM]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL MOVIM]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();
					ClearMessages();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_movim", "true", true);
			}

			Navigation.ClearValue("movim");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Movim_EquipValRegistnrModel : RequestLookupModel
		{
			public Movim_ViewModel Model { get; set; }
		}

		//
		// GET: /Movim/Movim_EquipValRegistnr
		// POST: /Movim/Movim_EquipValRegistnr
		[ActionName("Movim_EquipValRegistnr")]
		public ActionResult Movim_EquipValRegistnr([FromBody] Movim_EquipValRegistnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_equip")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_equip");
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

			Models.Movim parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Movim_EquipValRegistnr_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Movim_RoomsValRoomnrModel : RequestLookupModel
		{
			public Movim_ViewModel Model { get; set; }
		}

		//
		// GET: /Movim/Movim_RoomsValRoomnr
		// POST: /Movim/Movim_RoomsValRoomnr
		[ActionName("Movim_RoomsValRoomnr")]
		public ActionResult Movim_RoomsValRoomnr([FromBody] Movim_RoomsValRoomnrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rooms")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rooms");
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

			Models.Movim parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Movim_RoomsValRoomnr_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Movim/Movim_SaveEdit
		[HttpPost]
		public ActionResult Movim_SaveEdit([FromBody]Movim_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Movim_SaveEdit",
				ViewName = "Movim",
				AreaName = "movim",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT MOVIM]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT MOVIM]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
