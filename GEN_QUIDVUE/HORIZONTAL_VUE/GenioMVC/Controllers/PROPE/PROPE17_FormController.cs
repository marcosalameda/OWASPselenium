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
using GenioMVC.ViewModels.Prope;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPE]/

namespace GenioMVC.Controllers
{
	public partial class PropeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROPE17_CANCEL = new("PROPERTY43977", "Prope17_Cancel", "Prope") { vueRouteName = "form-PROPE17", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE17_SHOW = new("PROPERTY43977", "Prope17_Show", "Prope") { vueRouteName = "form-PROPE17", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE17_NEW = new("PROPERTY43977", "Prope17_New", "Prope") { vueRouteName = "form-PROPE17", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE17_EDIT = new("PROPERTY43977", "Prope17_Edit", "Prope") { vueRouteName = "form-PROPE17", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE17_DUPLICATE = new("PROPERTY43977", "Prope17_Duplicate", "Prope") { vueRouteName = "form-PROPE17", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE17_DELETE = new("PROPERTY43977", "Prope17_Delete", "Prope") { vueRouteName = "form-PROPE17", mode = "DELETE" };

		#endregion

		#region Prope17 private

		private void FormHistoryLimits_Prope17()
		{

		}

		#endregion

		#region Prope17_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE17]/

		[HttpPost]
		public ActionResult Prope17_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope17_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE17_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope17();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE17]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope17_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE17]/
		[HttpPost]
		public ActionResult Prope17_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Prope17_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_New_GET",
				AreaName = "prope",
				FormName = "PROPE17",
				Location = ACTION_PROPE17_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope17();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE17]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope17_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE17]/
		[HttpPost]
		public ActionResult Prope17_New([FromBody]Prope17_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_New",
				ViewName = "Prope17",
				AreaName = "prope",
				Location = ACTION_PROPE17_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE17]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE17]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE17]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope17_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE17]/
		[HttpPost]
		public ActionResult Prope17_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope17_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE17",
				Location = ACTION_PROPE17_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope17();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE17]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope17_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE17]/
		[HttpPost]
		public ActionResult Prope17_Edit([FromBody]Prope17_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Edit",
				ViewName = "Prope17",
				AreaName = "prope",
				Location = ACTION_PROPE17_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE17]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE17]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE17]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope17_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE17]/
		[HttpPost]
		public ActionResult Prope17_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope17_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE17",
				Location = ACTION_PROPE17_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope17();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE17]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope17_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE17]/
		[HttpPost]
		public ActionResult Prope17_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope17_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Delete",
				ViewName = "Prope17",
				AreaName = "prope",
				Location = ACTION_PROPE17_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE17]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope17_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE17");
		}

		#endregion

		#region Prope17_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE17]/

		[HttpPost]
		public ActionResult Prope17_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Prope17_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE17",
				Location = ACTION_PROPE17_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE17]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope17_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE17]/
		[HttpPost]
		public ActionResult Prope17_Duplicate([FromBody]Prope17_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_Duplicate",
				ViewName = "Prope17",
				AreaName = "prope",
				Location = ACTION_PROPE17_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE17]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE17]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE17]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope17_Cancel

		//
		// GET: /Prope/Prope17_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE17]/
		public ActionResult Prope17_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Prope(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE17]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE17]/

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

				Navigation.SetValue("ForcePrimaryRead_prope", "true", true);
			}

			Navigation.ClearValue("prope");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		//
		// GET: /Prope/Prope17_CityValCity
		// POST: /Prope/Prope17_CityValCity
		[ActionName("Prope17_CityValCity")]
		public ActionResult Prope17_CityValCity([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_city")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_city");
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
			Prope17_CityValCity_ViewModel model = new Prope17_CityValCity_ViewModel(UserContext.Current);
			
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
		// GET: /Prope/Prope17_AgentValName
		// POST: /Prope/Prope17_AgentValName
		[ActionName("Prope17_AgentValName")]
		public ActionResult Prope17_AgentValName([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agent");
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
			Prope17_AgentValName_ViewModel model = new Prope17_AgentValName_ViewModel(UserContext.Current);
			
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
		// GET: /Prope/Prope17_ValProphoto
		// POST: /Prope/Prope17_ValProphoto
		[ActionName("Prope17_ValProphoto")]
		public ActionResult Prope17_ValProphoto([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_proph")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_proph");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Prope17_ValProphoto_ViewModel model = new Prope17_ValProphoto_ViewModel(UserContext.Current);
			
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
		// GET: /Prope/Prope17_ValPropcont
		// POST: /Prope/Prope17_ValPropcont
		[ActionName("Prope17_ValPropcont")]
		public ActionResult Prope17_ValPropcont([FromBody]RequestLookupModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_procn")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_procn");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Prope17_ValPropcont_ViewModel model = new Prope17_ValPropcont_ViewModel(UserContext.Current);
			
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


		// POST: /Prope/Prope17_SaveEdit
		[HttpPost]
		public ActionResult Prope17_SaveEdit([FromBody]Prope17_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope17_SaveEdit",
				ViewName = "Prope17",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE17]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE17]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
