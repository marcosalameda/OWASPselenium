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
using GenioMVC.ViewModels.Dispa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISPA]/

namespace GenioMVC.Controllers
{
	public partial class DispaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DISPA_CANCEL = new("DISPATCH46310", "Dispa_Cancel", "Dispa") { vueRouteName = "form-DISPA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DISPA_SHOW = new("DISPATCH46310", "Dispa_Show", "Dispa") { vueRouteName = "form-DISPA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DISPA_NEW = new("DISPATCH46310", "Dispa_New", "Dispa") { vueRouteName = "form-DISPA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DISPA_EDIT = new("DISPATCH46310", "Dispa_Edit", "Dispa") { vueRouteName = "form-DISPA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DISPA_DUPLICATE = new("DISPATCH46310", "Dispa_Duplicate", "Dispa") { vueRouteName = "form-DISPA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DISPA_DELETE = new("DISPATCH46310", "Dispa_Delete", "Dispa") { vueRouteName = "form-DISPA", mode = "DELETE" };

		#endregion

		#region Dispa private

		private void FormHistoryLimits_Dispa()
		{

		}

		#endregion

		#region Dispa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DISPA]/

		[HttpPost]
		public ActionResult Dispa_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Show_GET",
				AreaName = "dispa",
				Location = ACTION_DISPA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DISPA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dispa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_New_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DISPA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Dispa/Dispa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_New([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_New",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DISPA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dispa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Edit_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DISPA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Edit",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DISPA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dispa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Delete_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DISPA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Dispa_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Delete",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DISPA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dispa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DISPA");
		}

		#endregion

		#region Dispa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DISPA]/

		[HttpPost]
		public ActionResult Dispa_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Dispa_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Duplicate_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DISPA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Dispa/Dispa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Duplicate([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_Duplicate",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DISPA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dispa_Cancel

		//
		// GET: /Dispa/Dispa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DISPA]/
		public ActionResult Dispa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Dispa(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("dispa");

// USE /[MANUAL GQT BEFORE_CANCEL DISPA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DISPA]/

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

				Navigation.SetValue("ForcePrimaryRead_dispa", "true", true);
			}

			Navigation.ClearValue("dispa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Dispa/Dispa_DisstValStatus
		// POST: /Dispa/Dispa_DisstValStatus
		[ActionName("Dispa_DisstValStatus")]
		public ActionResult Dispa_DisstValStatus([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_disst")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_disst");
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
			Dispa_DisstValStatus_ViewModel model = new Dispa_DisstValStatus_ViewModel(UserContext.Current);
			
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
		// GET: /Dispa/Dispa_EntitValName
		// POST: /Dispa/Dispa_EntitValName
		[ActionName("Dispa_EntitValName")]
		public ActionResult Dispa_EntitValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entit");
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
			Dispa_EntitValName_ViewModel model = new Dispa_EntitValName_ViewModel(UserContext.Current);
			
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
		// GET: /Dispa/Dispa_PersoValName
		// POST: /Dispa/Dispa_PersoValName
		[ActionName("Dispa_PersoValName")]
		public ActionResult Dispa_PersoValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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
			Dispa_PersoValName_ViewModel model = new Dispa_PersoValName_ViewModel(UserContext.Current);
			
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
		// GET: /Dispa/Dispa_ValDispatch
		// POST: /Dispa/Dispa_ValDispatch
		[ActionName("Dispa_ValDispatch")]
		public ActionResult Dispa_ValDispatch([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dilin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dilin");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Dispa_ValDispatch_ViewModel model = new Dispa_ValDispatch_ViewModel(UserContext.Current);
			
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


		// POST: /Dispa/Dispa_SaveEdit
		[HttpPost]
		public ActionResult Dispa_SaveEdit([FromBody]Dispa_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Dispa_SaveEdit",
				ViewName = "Dispa",
				AreaName = "dispa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DISPA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
