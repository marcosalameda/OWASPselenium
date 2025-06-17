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
using GenioMVC.ViewModels.Ldent;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LDENT]/

namespace GenioMVC.Controllers
{
	public partial class LdentController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LDENTNOR_CANCEL = new("ENTRY29068", "Ldentnor_Cancel", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LDENTNOR_SHOW = new("ENTRY29068", "Ldentnor_Show", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LDENTNOR_NEW = new("ENTRY29068", "Ldentnor_New", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LDENTNOR_EDIT = new("ENTRY29068", "Ldentnor_Edit", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LDENTNOR_DUPLICATE = new("ENTRY29068", "Ldentnor_Duplicate", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LDENTNOR_DELETE = new("ENTRY29068", "Ldentnor_Delete", "Ldent") { vueRouteName = "form-LDENTNOR", mode = "DELETE" };

		#endregion

		#region Ldentnor private

		private void FormHistoryLimits_Ldentnor()
		{

		}

		#endregion

		#region Ldentnor_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LDENTNOR]/

		[HttpPost]
		public ActionResult Ldentnor_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Show_GET",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LDENTNOR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Ldentnor_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_New_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LDENTNOR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Ldent/Ldentnor_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_New([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_New",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Ldentnor_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Edit_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LDENTNOR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldentnor_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Edit([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Edit",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Ldentnor_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Delete_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Ldentnor();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LDENTNOR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Ldent/Ldentnor_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Ldentnor_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Delete",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LDENTNOR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Ldentnor_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LDENTNOR");
		}

		#endregion

		#region Ldentnor_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LDENTNOR]/

		[HttpPost]
		public ActionResult Ldentnor_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Ldentnor_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Duplicate_GET",
				AreaName = "ldent",
				FormName = "LDENTNOR",
				Location = ACTION_LDENTNOR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LDENTNOR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Ldent/Ldentnor_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LDENTNOR]/
		[HttpPost]
		public ActionResult Ldentnor_Duplicate([FromBody]Ldentnor_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_Duplicate",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				Location = ACTION_LDENTNOR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LDENTNOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LDENTNOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LDENTNOR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Ldentnor_Cancel

		//
		// GET: /Ldent/Ldentnor_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LDENTNOR]/
		public ActionResult Ldentnor_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Ldent(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("ldent");

// USE /[MANUAL GQT BEFORE_CANCEL LDENTNOR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LDENTNOR]/

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

				Navigation.SetValue("ForcePrimaryRead_ldent", "true", true);
			}

			Navigation.ClearValue("ldent");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Ldentnor_IndocValDocumenrModel : RequestLookupModel
		{
			public Ldentnor_ViewModel Model { get; set; }
		}

		//
		// GET: /Ldent/Ldentnor_IndocValDocumenr
		// POST: /Ldent/Ldentnor_IndocValDocumenr
		[ActionName("Ldentnor_IndocValDocumenr")]
		public ActionResult Ldentnor_IndocValDocumenr([FromBody] Ldentnor_IndocValDocumenrModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_indoc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_indoc");
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

			Models.Ldent parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Ldentnor_IndocValDocumenr_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Ldentnor_WarehValWarehdesModel : RequestLookupModel
		{
			public Ldentnor_ViewModel Model { get; set; }
		}

		//
		// GET: /Ldent/Ldentnor_WarehValWarehdes
		// POST: /Ldent/Ldentnor_WarehValWarehdes
		[ActionName("Ldentnor_WarehValWarehdes")]
		public ActionResult Ldentnor_WarehValWarehdes([FromBody] Ldentnor_WarehValWarehdesModel requestModel)
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

			Models.Ldent parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Ldentnor_WarehValWarehdes_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Ldentnor_ItemValItemdesModel : RequestLookupModel
		{
			public Ldentnor_ViewModel Model { get; set; }
		}

		//
		// GET: /Ldent/Ldentnor_ItemValItemdes
		// POST: /Ldent/Ldentnor_ItemValItemdes
		[ActionName("Ldentnor_ItemValItemdes")]
		public ActionResult Ldentnor_ItemValItemdes([FromBody] Ldentnor_ItemValItemdesModel requestModel)
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

			Models.Ldent parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Ldentnor_ItemValItemdes_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Ldent/Ldentnor_SaveEdit
		[HttpPost]
		public ActionResult Ldentnor_SaveEdit([FromBody] Ldentnor_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Ldentnor_SaveEdit",
				ViewName = "Ldentnor",
				AreaName = "ldent",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LDENTNOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LDENTNOR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class LdentnorDocumValidateTickets : RequestDocumValidateTickets
		{
			public Ldentnor_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsLdentnor([FromBody] LdentnorDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
