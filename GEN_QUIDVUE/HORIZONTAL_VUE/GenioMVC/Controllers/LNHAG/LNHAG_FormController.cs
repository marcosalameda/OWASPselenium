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
using GenioMVC.ViewModels.Lnhag;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHAG]/

namespace GenioMVC.Controllers
{
	public partial class LnhagController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHAG_CANCEL = new("EQUIPMENT_GROUPING44771", "Lnhag_Cancel", "Lnhag") { vueRouteName = "form-LNHAG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHAG_SHOW = new("EQUIPMENT_GROUPING44771", "Lnhag_Show", "Lnhag") { vueRouteName = "form-LNHAG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHAG_NEW = new("EQUIPMENT_GROUPING44771", "Lnhag_New", "Lnhag") { vueRouteName = "form-LNHAG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHAG_EDIT = new("EQUIPMENT_GROUPING44771", "Lnhag_Edit", "Lnhag") { vueRouteName = "form-LNHAG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHAG_DUPLICATE = new("EQUIPMENT_GROUPING44771", "Lnhag_Duplicate", "Lnhag") { vueRouteName = "form-LNHAG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHAG_DELETE = new("EQUIPMENT_GROUPING44771", "Lnhag_Delete", "Lnhag") { vueRouteName = "form-LNHAG", mode = "DELETE" };

		#endregion

		#region Lnhag private

		private void FormHistoryLimits_Lnhag()
		{

		}

		#endregion

		#region Lnhag_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHAG]/

		[HttpPost]
		public ActionResult Lnhag_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhag_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Show_GET",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhag();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHAG]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lnhag_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lnhag_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_New_GET",
				AreaName = "lnhag",
				FormName = "LNHAG",
				Location = ACTION_LNHAG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lnhag();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHAG]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lnhag/Lnhag_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_New([FromBody]Lnhag_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_New",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHAG]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lnhag_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhag_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Edit_GET",
				AreaName = "lnhag",
				FormName = "LNHAG",
				Location = ACTION_LNHAG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhag();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHAG]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lnhag/Lnhag_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_Edit([FromBody]Lnhag_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Edit",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHAG]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lnhag_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhag_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Delete_GET",
				AreaName = "lnhag",
				FormName = "LNHAG",
				Location = ACTION_LNHAG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhag();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHAG]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lnhag/Lnhag_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhag_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Delete",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHAG]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lnhag_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHAG");
		}

		#endregion

		#region Lnhag_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHAG]/

		[HttpPost]
		public ActionResult Lnhag_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lnhag_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Duplicate_GET",
				AreaName = "lnhag",
				FormName = "LNHAG",
				Location = ACTION_LNHAG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHAG]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lnhag/Lnhag_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHAG]/
		[HttpPost]
		public ActionResult Lnhag_Duplicate([FromBody]Lnhag_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_Duplicate",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				Location = ACTION_LNHAG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHAG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHAG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHAG]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lnhag_Cancel

		//
		// GET: /Lnhag/Lnhag_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHAG]/
		public ActionResult Lnhag_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhag(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhag");

// USE /[MANUAL GQT BEFORE_CANCEL LNHAG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHAG]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhag", "true", true);
			}

			Navigation.ClearValue("lnhag");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Lnhag/Lnhag_PedidValNrpedido
		// POST: /Lnhag/Lnhag_PedidValNrpedido
		[ActionName("Lnhag_PedidValNrpedido")]
		public ActionResult Lnhag_PedidValNrpedido([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pedid")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pedid");
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
			Lnhag_PedidValNrpedido_ViewModel model = new Lnhag_PedidValNrpedido_ViewModel(UserContext.Current);
			
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

		//
		// GET: /Lnhag/Lnhag_Tpeq1ValTipoequi
		// POST: /Lnhag/Lnhag_Tpeq1ValTipoequi
		[ActionName("Lnhag_Tpeq1ValTipoequi")]
		public ActionResult Lnhag_Tpeq1ValTipoequi([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpeq1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpeq1");
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
			Lnhag_Tpeq1ValTipoequi_ViewModel model = new Lnhag_Tpeq1ValTipoequi_ViewModel(UserContext.Current);
			
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


		// POST: /Lnhag/Lnhag_SaveEdit
		[HttpPost]
		public ActionResult Lnhag_SaveEdit([FromBody]Lnhag_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhag_SaveEdit",
				ViewName = "Lnhag",
				AreaName = "lnhag",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHAG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHAG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
