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
using GenioMVC.ViewModels.Outpu;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER OUTPU]/

namespace GenioMVC.Controllers
{
	public partial class OutpuController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LDSAI_CANCEL = new("OUTPUT44370", "Ldsai_Cancel", "Outpu") { vueRouteName = "form-LDSAI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LDSAI_SHOW = new("OUTPUT44370", "Ldsai_Show", "Outpu") { vueRouteName = "form-LDSAI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LDSAI_NEW = new("OUTPUT44370", "Ldsai_New", "Outpu") { vueRouteName = "form-LDSAI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LDSAI_EDIT = new("OUTPUT44370", "Ldsai_Edit", "Outpu") { vueRouteName = "form-LDSAI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LDSAI_DUPLICATE = new("OUTPUT44370", "Ldsai_Duplicate", "Outpu") { vueRouteName = "form-LDSAI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LDSAI_DELETE = new("OUTPUT44370", "Ldsai_Delete", "Outpu") { vueRouteName = "form-LDSAI", mode = "DELETE" };

		#endregion

		#region Ldsai private

		private void FormHistoryLimits_Ldsai()
		{

		}

		#endregion

		#region Ldsai_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LDSAI]/

		[HttpPost]
		public ActionResult Ldsai_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldsai_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Show_GET",
				AreaName = "outpu",
				Location = ACTION_LDSAI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldsai();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LDSAI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ldsai_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ldsai_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_New_GET",
				AreaName = "outpu",
				FormName = "LDSAI",
				Location = ACTION_LDSAI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ldsai();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LDSAI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Outpu/Ldsai_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_New([FromBody]Ldsai_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_New",
				ViewName = "Ldsai",
				AreaName = "outpu",
				Location = ACTION_LDSAI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LDSAI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LDSAI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LDSAI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ldsai_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldsai_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Edit_GET",
				AreaName = "outpu",
				FormName = "LDSAI",
				Location = ACTION_LDSAI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldsai();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LDSAI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Outpu/Ldsai_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_Edit([FromBody]Ldsai_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Edit",
				ViewName = "Ldsai",
				AreaName = "outpu",
				Location = ACTION_LDSAI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LDSAI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LDSAI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LDSAI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ldsai_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldsai_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Delete_GET",
				AreaName = "outpu",
				FormName = "LDSAI",
				Location = ACTION_LDSAI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldsai();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LDSAI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Outpu/Ldsai_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldsai_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Delete",
				ViewName = "Ldsai",
				AreaName = "outpu",
				Location = ACTION_LDSAI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LDSAI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ldsai_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LDSAI");
		}

		#endregion

		#region Ldsai_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LDSAI]/

		[HttpPost]
		public ActionResult Ldsai_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ldsai_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Duplicate_GET",
				AreaName = "outpu",
				FormName = "LDSAI",
				Location = ACTION_LDSAI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LDSAI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Outpu/Ldsai_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LDSAI]/
		[HttpPost]
		public ActionResult Ldsai_Duplicate([FromBody]Ldsai_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_Duplicate",
				ViewName = "Ldsai",
				AreaName = "outpu",
				Location = ACTION_LDSAI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LDSAI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LDSAI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LDSAI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ldsai_Cancel

		//
		// GET: /Outpu/Ldsai_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LDSAI]/
		public ActionResult Ldsai_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Outpu(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("outpu");

// USE /[MANUAL GQT BEFORE_CANCEL LDSAI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LDSAI]/

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

				Navigation.SetValue("ForcePrimaryRead_outpu", "true", true);
			}

			Navigation.ClearValue("outpu");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Outpu/Ldsai_OutptValDocumenr
		// POST: /Outpu/Ldsai_OutptValDocumenr
		[ActionName("Ldsai_OutptValDocumenr")]
		public ActionResult Ldsai_OutptValDocumenr([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_outpt")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_outpt");
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
			Ldsai_OutptValDocumenr_ViewModel model = new Ldsai_OutptValDocumenr_ViewModel(UserContext.Current);
			
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
		// GET: /Outpu/Ldsai_WarehValWarehdes
		// POST: /Outpu/Ldsai_WarehValWarehdes
		[ActionName("Ldsai_WarehValWarehdes")]
		public ActionResult Ldsai_WarehValWarehdes([FromBody]RequestLookupModel requestModel)
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
			Ldsai_WarehValWarehdes_ViewModel model = new Ldsai_WarehValWarehdes_ViewModel(UserContext.Current);
			
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
		// GET: /Outpu/Ldsai_ItemValItemdes
		// POST: /Outpu/Ldsai_ItemValItemdes
		[ActionName("Ldsai_ItemValItemdes")]
		public ActionResult Ldsai_ItemValItemdes([FromBody]RequestLookupModel requestModel)
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
			Ldsai_ItemValItemdes_ViewModel model = new Ldsai_ItemValItemdes_ViewModel(UserContext.Current);
			
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
		// GET: /Outpu/Ldsai_OudocValNrdocsda
		// POST: /Outpu/Ldsai_OudocValNrdocsda
		[ActionName("Ldsai_OudocValNrdocsda")]
		public ActionResult Ldsai_OudocValNrdocsda([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_oudoc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_oudoc");
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
			Ldsai_OudocValNrdocsda_ViewModel model = new Ldsai_OudocValNrdocsda_ViewModel(UserContext.Current);
			
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


		// POST: /Outpu/Ldsai_SaveEdit
		[HttpPost]
		public ActionResult Ldsai_SaveEdit([FromBody]Ldsai_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldsai_SaveEdit",
				ViewName = "Ldsai",
				AreaName = "outpu",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LDSAI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LDSAI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
