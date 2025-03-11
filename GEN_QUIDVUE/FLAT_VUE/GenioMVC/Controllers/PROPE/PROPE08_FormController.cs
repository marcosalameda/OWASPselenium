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

		private static readonly NavigationLocation ACTION_PROPE08_CANCEL = new("PROPERTY43977", "Prope08_Cancel", "Prope") { vueRouteName = "form-PROPE08", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPE08_SHOW = new("PROPERTY43977", "Prope08_Show", "Prope") { vueRouteName = "form-PROPE08", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPE08_NEW = new("PROPERTY43977", "Prope08_New", "Prope") { vueRouteName = "form-PROPE08", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPE08_EDIT = new("PROPERTY43977", "Prope08_Edit", "Prope") { vueRouteName = "form-PROPE08", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPE08_DUPLICATE = new("PROPERTY43977", "Prope08_Duplicate", "Prope") { vueRouteName = "form-PROPE08", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPE08_DELETE = new("PROPERTY43977", "Prope08_Delete", "Prope") { vueRouteName = "form-PROPE08", mode = "DELETE" };

		#endregion

		#region Prope08 private

		private void FormHistoryLimits_Prope08()
		{

		}

		#endregion

		#region Prope08_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPE08]/

		[HttpPost]
		public ActionResult Prope08_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope08_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Show_GET",
				AreaName = "prope",
				Location = ACTION_PROPE08_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope08();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPE08]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Prope08_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPE08]/
		[HttpPost]
		public ActionResult Prope08_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Prope08_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_New_GET",
				AreaName = "prope",
				FormName = "PROPE08",
				Location = ACTION_PROPE08_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Prope08();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPE08]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Prope/Prope08_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPE08]/
		[HttpPost]
		public ActionResult Prope08_New([FromBody]Prope08_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_New",
				ViewName = "Prope08",
				AreaName = "prope",
				Location = ACTION_PROPE08_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPE08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPE08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPE08]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Prope08_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPE08]/
		[HttpPost]
		public ActionResult Prope08_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope08_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Edit_GET",
				AreaName = "prope",
				FormName = "PROPE08",
				Location = ACTION_PROPE08_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope08();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPE08]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope08_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPE08]/
		[HttpPost]
		public ActionResult Prope08_Edit([FromBody]Prope08_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Edit",
				ViewName = "Prope08",
				AreaName = "prope",
				Location = ACTION_PROPE08_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPE08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPE08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPE08]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Prope08_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPE08]/
		[HttpPost]
		public ActionResult Prope08_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope08_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Delete_GET",
				AreaName = "prope",
				FormName = "PROPE08",
				Location = ACTION_PROPE08_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Prope08();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPE08]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Prope/Prope08_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPE08]/
		[HttpPost]
		public ActionResult Prope08_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Prope08_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Delete",
				ViewName = "Prope08",
				AreaName = "prope",
				Location = ACTION_PROPE08_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPE08]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Prope08_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPE08");
		}

		#endregion

		#region Prope08_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPE08]/

		[HttpPost]
		public ActionResult Prope08_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Prope08_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Duplicate_GET",
				AreaName = "prope",
				FormName = "PROPE08",
				Location = ACTION_PROPE08_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPE08]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Prope/Prope08_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPE08]/
		[HttpPost]
		public ActionResult Prope08_Duplicate([FromBody]Prope08_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_Duplicate",
				ViewName = "Prope08",
				AreaName = "prope",
				Location = ACTION_PROPE08_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPE08]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPE08]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPE08]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Prope08_Cancel

		//
		// GET: /Prope/Prope08_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPE08]/
		public ActionResult Prope08_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Prope(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("prope");

// USE /[MANUAL GQT BEFORE_CANCEL PROPE08]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPE08]/

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


		public class Prope08_CityValCityModel : RequestLookupModel
		{
			public Prope08_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope08_CityValCity
		// POST: /Prope/Prope08_CityValCity
		[ActionName("Prope08_CityValCity")]
		public ActionResult Prope08_CityValCity([FromBody] Prope08_CityValCityModel requestModel)
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

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope08_CityValCity_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Prope08_AgentValNameModel : RequestLookupModel
		{
			public Prope08_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope08_AgentValName
		// POST: /Prope/Prope08_AgentValName
		[ActionName("Prope08_AgentValName")]
		public ActionResult Prope08_AgentValName([FromBody] Prope08_AgentValNameModel requestModel)
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

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope08_AgentValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Prope08_ValPropcontModel : RequestLookupModel
		{
			public Prope08_ViewModel Model { get; set; }
		}

		//
		// GET: /Prope/Prope08_ValPropcont
		// POST: /Prope/Prope08_ValPropcont
		[ActionName("Prope08_ValPropcont")]
		public ActionResult Prope08_ValPropcont([FromBody] Prope08_ValPropcontModel requestModel)
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

			Models.Prope parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Prope08_ValPropcont_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Prope/Prope08_SaveEdit
		[HttpPost]
		public ActionResult Prope08_SaveEdit([FromBody]Prope08_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Prope08_SaveEdit",
				ViewName = "Prope08",
				AreaName = "prope",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPE08]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPE08]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
