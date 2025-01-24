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

		private static readonly NavigationLocation ACTION_PROPE09_CANCEL = new("PROPERTY43977", "Prope09_Cancel", "Prope") { vueRouteName = "form-PROPE09", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE09_SHOW = new("PROPERTY43977", "Prope09_Show", "Prope") { vueRouteName = "form-PROPE09", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE09_NEW = new("PROPERTY43977", "Prope09_New", "Prope") { vueRouteName = "form-PROPE09", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE09_EDIT = new("PROPERTY43977", "Prope09_Edit", "Prope") { vueRouteName = "form-PROPE09", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE09_DUPLICATE = new("PROPERTY43977", "Prope09_Duplicate", "Prope") { vueRouteName = "form-PROPE09", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE09_DELETE = new("PROPERTY43977", "Prope09_Delete", "Prope") { vueRouteName = "form-PROPE09", mode = "DELETE" };

		#endregion

		#region Prope09 private

		private void FormHistoryLimits_Prope09()
		{

		}

		#endregion

		#region Prope09_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE09]/

		[HttpPost]
		public ActionResult Prope09_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope09_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE09_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope09();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE09]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope09_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE09]/
		[HttpPost]
		public ActionResult Prope09_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Prope09_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_New_GET",
				AreaName = "prope",
				FormName = "PROPE09",
				Location = ACTION_PROPE09_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope09();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE09]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope09_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE09]/
		[HttpPost]
		public ActionResult Prope09_New([FromBody]Prope09_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_New",
				ViewName = "Prope09",
				AreaName = "prope",
				Location = ACTION_PROPE09_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE09]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE09]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE09]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope09_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE09]/
		[HttpPost]
		public ActionResult Prope09_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope09_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE09",
				Location = ACTION_PROPE09_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope09();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE09]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope09_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE09]/
		[HttpPost]
		public ActionResult Prope09_Edit([FromBody]Prope09_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Edit",
				ViewName = "Prope09",
				AreaName = "prope",
				Location = ACTION_PROPE09_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE09]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE09]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE09]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope09_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE09]/
		[HttpPost]
		public ActionResult Prope09_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope09_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE09",
				Location = ACTION_PROPE09_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope09();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE09]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope09_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE09]/
		[HttpPost]
		public ActionResult Prope09_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope09_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Delete",
				ViewName = "Prope09",
				AreaName = "prope",
				Location = ACTION_PROPE09_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE09]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope09_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE09");
		}

		#endregion

		#region Prope09_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE09]/

		[HttpPost]
		public ActionResult Prope09_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Prope09_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE09",
				Location = ACTION_PROPE09_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE09]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope09_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE09]/
		[HttpPost]
		public ActionResult Prope09_Duplicate([FromBody]Prope09_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_Duplicate",
				ViewName = "Prope09",
				AreaName = "prope",
				Location = ACTION_PROPE09_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE09]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE09]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE09]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope09_Cancel

		//
		// GET: /Prope/Prope09_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE09]/
		public ActionResult Prope09_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Prope(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE09]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE09]/

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
		// GET: /Prope/Prope09_CityValCity
		// POST: /Prope/Prope09_CityValCity
		[ActionName("Prope09_CityValCity")]
		public ActionResult Prope09_CityValCity([FromBody]RequestLookupModel requestModel)
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
			Prope09_CityValCity_ViewModel model = new Prope09_CityValCity_ViewModel(UserContext.Current);
			
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
		// GET: /Prope/Prope09_AgentValName
		// POST: /Prope/Prope09_AgentValName
		[ActionName("Prope09_AgentValName")]
		public ActionResult Prope09_AgentValName([FromBody]RequestLookupModel requestModel)
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
			Prope09_AgentValName_ViewModel model = new Prope09_AgentValName_ViewModel(UserContext.Current);
			
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
		// GET: /Prope/Prope09_ValPropcont
		// POST: /Prope/Prope09_ValPropcont
		[ActionName("Prope09_ValPropcont")]
		public ActionResult Prope09_ValPropcont([FromBody]RequestLookupModel requestModel)
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

			Prope09_ValPropcont_ViewModel model = new Prope09_ValPropcont_ViewModel(UserContext.Current);
			
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


		// POST: /Prope/Prope09_SaveEdit
		[HttpPost]
		public ActionResult Prope09_SaveEdit([FromBody]Prope09_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope09_SaveEdit",
				ViewName = "Prope09",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE09]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE09]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
