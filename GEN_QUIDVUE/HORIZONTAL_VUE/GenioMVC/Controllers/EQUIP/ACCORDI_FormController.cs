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

		private static readonly NavigationLocation ACTION_ACCORDI_CANCEL = new("ACCORDIONS05516", "Accordi_Cancel", "Equip") { vueRouteName = "form-ACCORDI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ACCORDI_SHOW = new("ACCORDIONS05516", "Accordi_Show", "Equip") { vueRouteName = "form-ACCORDI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ACCORDI_NEW = new("ACCORDIONS05516", "Accordi_New", "Equip") { vueRouteName = "form-ACCORDI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ACCORDI_EDIT = new("ACCORDIONS05516", "Accordi_Edit", "Equip") { vueRouteName = "form-ACCORDI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ACCORDI_DUPLICATE = new("ACCORDIONS05516", "Accordi_Duplicate", "Equip") { vueRouteName = "form-ACCORDI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ACCORDI_DELETE = new("ACCORDIONS05516", "Accordi_Delete", "Equip") { vueRouteName = "form-ACCORDI", mode = "DELETE" };

		#endregion

		#region Accordi private

		private void FormHistoryLimits_Accordi()
		{

		}

		#endregion

		#region Accordi_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ACCORDI]/

		[HttpPost]
		public ActionResult Accordi_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Accordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Show_GET",
				AreaName = "equip",
				Location = ACTION_ACCORDI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Accordi();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ACCORDI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Accordi_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Accordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_New_GET",
				AreaName = "equip",
				FormName = "ACCORDI",
				Location = ACTION_ACCORDI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Accordi();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ACCORDI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Equip/Accordi_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_New([FromBody]Accordi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_New",
				ViewName = "Accordi",
				AreaName = "equip",
				Location = ACTION_ACCORDI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ACCORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ACCORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ACCORDI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Accordi_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Accordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Edit_GET",
				AreaName = "equip",
				FormName = "ACCORDI",
				Location = ACTION_ACCORDI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Accordi();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ACCORDI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Equip/Accordi_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_Edit([FromBody]Accordi_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Edit",
				ViewName = "Accordi",
				AreaName = "equip",
				Location = ACTION_ACCORDI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ACCORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ACCORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ACCORDI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Accordi_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Accordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Delete_GET",
				AreaName = "equip",
				FormName = "ACCORDI",
				Location = ACTION_ACCORDI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Accordi();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ACCORDI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Equip/Accordi_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Accordi_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Delete",
				ViewName = "Accordi",
				AreaName = "equip",
				Location = ACTION_ACCORDI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ACCORDI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Accordi_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ACCORDI");
		}

		#endregion

		#region Accordi_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ACCORDI]/

		[HttpPost]
		public ActionResult Accordi_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Accordi_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Duplicate_GET",
				AreaName = "equip",
				FormName = "ACCORDI",
				Location = ACTION_ACCORDI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ACCORDI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Equip/Accordi_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ACCORDI]/
		[HttpPost]
		public ActionResult Accordi_Duplicate([FromBody]Accordi_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_Duplicate",
				ViewName = "Accordi",
				AreaName = "equip",
				Location = ACTION_ACCORDI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ACCORDI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ACCORDI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ACCORDI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Accordi_Cancel

		//
		// GET: /Equip/Accordi_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ACCORDI]/
		public ActionResult Accordi_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Equip(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("equip");

// USE /[MANUAL GQT BEFORE_CANCEL ACCORDI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ACCORDI]/

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


		public class Accordi_CmpnyValDesignatModel : RequestLookupModel
		{
			public Accordi_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Accordi_CmpnyValDesignat
		// POST: /Equip/Accordi_CmpnyValDesignat
		[ActionName("Accordi_CmpnyValDesignat")]
		public ActionResult Accordi_CmpnyValDesignat([FromBody] Accordi_CmpnyValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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
			Accordi_CmpnyValDesignat_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Accordi_Pess1ValNameModel : RequestLookupModel
		{
			public Accordi_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Accordi_Pess1ValName
		// POST: /Equip/Accordi_Pess1ValName
		[ActionName("Accordi_Pess1ValName")]
		public ActionResult Accordi_Pess1ValName([FromBody] Accordi_Pess1ValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pess1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pess1");
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
			Accordi_Pess1ValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Static filter "order" fields that have changed
			tableConfigOptions.StaticFiltersKeyShiftValues = new Dictionary<string, int>
			{
				{ "filter_Pess1ValName_FILTER1", 0 },
				{ "filter_Pess1ValName_FILTER2", -1 }
			};

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

		public class Accordi_ValInstalagModel : RequestLookupModel
		{
			public Accordi_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Accordi_ValInstalag
		// POST: /Equip/Accordi_ValInstalag
		[ActionName("Accordi_ValInstalag")]
		public ActionResult Accordi_ValInstalag([FromBody] Accordi_ValInstalagModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Accordi_ValInstalag_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Accordi_ValInstalacModel : RequestLookupModel
		{
			public Accordi_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Accordi_ValInstalac
		// POST: /Equip/Accordi_ValInstalac
		[ActionName("Accordi_ValInstalac")]
		public ActionResult Accordi_ValInstalac([FromBody] Accordi_ValInstalacModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_insta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_insta");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Accordi_ValInstalac_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Accordi_ValReparacoModel : RequestLookupModel
		{
			public Accordi_ViewModel Model { get; set; }
		}

		//
		// GET: /Equip/Accordi_ValReparaco
		// POST: /Equip/Accordi_ValReparaco
		[ActionName("Accordi_ValReparaco")]
		public ActionResult Accordi_ValReparaco([FromBody] Accordi_ValReparacoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_repar")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_repar");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Equip parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Accordi_ValReparaco_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Equip/Accordi_SaveEdit
		[HttpPost]
		public ActionResult Accordi_SaveEdit([FromBody] Accordi_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Accordi_SaveEdit",
				ViewName = "Accordi",
				AreaName = "equip",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ACCORDI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ACCORDI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AccordiDocumValidateTickets : RequestDocumValidateTickets
		{
			public Accordi_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAccordi([FromBody] AccordiDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
