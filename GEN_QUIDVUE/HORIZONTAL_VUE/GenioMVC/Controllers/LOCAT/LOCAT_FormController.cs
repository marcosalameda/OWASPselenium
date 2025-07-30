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
using GenioMVC.ViewModels.Locat;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LOCAT]/

namespace GenioMVC.Controllers
{
	public partial class LocatController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LOCAT_CANCEL = new("LOCATION54790", "Locat_Cancel", "Locat") { vueRouteName = "form-LOCAT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LOCAT_SHOW = new("LOCATION54790", "Locat_Show", "Locat") { vueRouteName = "form-LOCAT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LOCAT_NEW = new("LOCATION54790", "Locat_New", "Locat") { vueRouteName = "form-LOCAT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LOCAT_EDIT = new("LOCATION54790", "Locat_Edit", "Locat") { vueRouteName = "form-LOCAT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LOCAT_DUPLICATE = new("LOCATION54790", "Locat_Duplicate", "Locat") { vueRouteName = "form-LOCAT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LOCAT_DELETE = new("LOCATION54790", "Locat_Delete", "Locat") { vueRouteName = "form-LOCAT", mode = "DELETE" };

		#endregion

		#region Locat private

		private void FormHistoryLimits_Locat()
		{

		}

		#endregion

		#region Locat_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LOCAT]/

		[HttpPost]
		public ActionResult Locat_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Locat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Show_GET",
				AreaName = "locat",
				Location = ACTION_LOCAT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Locat();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LOCAT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Locat_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LOCAT]/
		[HttpPost]
		public ActionResult Locat_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Locat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Locat_New_GET",
				AreaName = "locat",
				FormName = "LOCAT",
				Location = ACTION_LOCAT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Locat();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LOCAT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Locat/Locat_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LOCAT]/
		[HttpPost]
		public ActionResult Locat_New([FromBody]Locat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Locat_New",
				ViewName = "Locat",
				AreaName = "locat",
				Location = ACTION_LOCAT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LOCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LOCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LOCAT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Locat_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LOCAT]/
		[HttpPost]
		public ActionResult Locat_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Locat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Edit_GET",
				AreaName = "locat",
				FormName = "LOCAT",
				Location = ACTION_LOCAT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Locat();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LOCAT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Locat/Locat_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LOCAT]/
		[HttpPost]
		public ActionResult Locat_Edit([FromBody]Locat_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Edit",
				ViewName = "Locat",
				AreaName = "locat",
				Location = ACTION_LOCAT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LOCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LOCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LOCAT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Locat_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LOCAT]/
		[HttpPost]
		public ActionResult Locat_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Locat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Delete_GET",
				AreaName = "locat",
				FormName = "LOCAT",
				Location = ACTION_LOCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Locat();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LOCAT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Locat/Locat_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LOCAT]/
		[HttpPost]
		public ActionResult Locat_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Locat_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Locat_Delete",
				ViewName = "Locat",
				AreaName = "locat",
				Location = ACTION_LOCAT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LOCAT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Locat_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LOCAT");
		}

		#endregion

		#region Locat_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LOCAT]/

		[HttpPost]
		public ActionResult Locat_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Locat_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Duplicate_GET",
				AreaName = "locat",
				FormName = "LOCAT",
				Location = ACTION_LOCAT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LOCAT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Locat/Locat_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LOCAT]/
		[HttpPost]
		public ActionResult Locat_Duplicate([FromBody]Locat_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Locat_Duplicate",
				ViewName = "Locat",
				AreaName = "locat",
				Location = ACTION_LOCAT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LOCAT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LOCAT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LOCAT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Locat_Cancel

		//
		// GET: /Locat/Locat_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LOCAT]/
		public ActionResult Locat_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Locat(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("locat");

// USE /[MANUAL GQT BEFORE_CANCEL LOCAT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LOCAT]/

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

				Navigation.SetValue("ForcePrimaryRead_locat", "true", true);
			}

			Navigation.ClearValue("locat");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Locat_EntitValNameModel : RequestLookupModel
		{
			public Locat_ViewModel Model { get; set; }
		}

		//
		// GET: /Locat/Locat_EntitValName
		// POST: /Locat/Locat_EntitValName
		[ActionName("Locat_EntitValName")]
		public ActionResult Locat_EntitValName([FromBody] Locat_EntitValNameModel requestModel)
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

			Models.Locat parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Locat_EntitValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Locat_FacilValNameModel : RequestLookupModel
		{
			public Locat_ViewModel Model { get; set; }
		}

		//
		// GET: /Locat/Locat_FacilValName
		// POST: /Locat/Locat_FacilValName
		[ActionName("Locat_FacilValName")]
		public ActionResult Locat_FacilValName([FromBody] Locat_FacilValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_facil")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_facil");
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

			Models.Locat parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Locat_FacilValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Locat_ValLocalextModel : RequestLookupModel
		{
			public Locat_ViewModel Model { get; set; }
		}

		//
		// GET: /Locat/Locat_ValLocalext
		// POST: /Locat/Locat_ValLocalext
		[ActionName("Locat_ValLocalext")]
		public ActionResult Locat_ValLocalext([FromBody] Locat_ValLocalextModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lcext")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lcext");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Locat parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Locat_ValLocalext_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Locat/Locat_SaveEdit
		[HttpPost]
		public ActionResult Locat_SaveEdit([FromBody] Locat_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Locat_SaveEdit",
				ViewName = "Locat",
				AreaName = "locat",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LOCAT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LOCAT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class LocatDocumValidateTickets : RequestDocumValidateTickets
		{
			public Locat_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsLocat([FromBody] LocatDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
