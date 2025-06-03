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
using GenioMVC.ViewModels.Lnhde;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHDE]/

namespace GenioMVC.Controllers
{
	public partial class LnhdeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHDE_CANCEL = new("DISAGGREGATION_LINE06730", "Lnhde_Cancel", "Lnhde") { vueRouteName = "form-LNHDE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHDE_SHOW = new("DISAGGREGATION_LINE06730", "Lnhde_Show", "Lnhde") { vueRouteName = "form-LNHDE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHDE_NEW = new("DISAGGREGATION_LINE06730", "Lnhde_New", "Lnhde") { vueRouteName = "form-LNHDE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHDE_EDIT = new("DISAGGREGATION_LINE06730", "Lnhde_Edit", "Lnhde") { vueRouteName = "form-LNHDE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHDE_DUPLICATE = new("DISAGGREGATION_LINE06730", "Lnhde_Duplicate", "Lnhde") { vueRouteName = "form-LNHDE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHDE_DELETE = new("DISAGGREGATION_LINE06730", "Lnhde_Delete", "Lnhde") { vueRouteName = "form-LNHDE", mode = "DELETE" };

		#endregion

		#region Lnhde private

		private void FormHistoryLimits_Lnhde()
		{

		}

		#endregion

		#region Lnhde_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHDE]/

		[HttpPost]
		public ActionResult Lnhde_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Show_GET",
				AreaName = "lnhde",
				Location = ACTION_LNHDE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhde();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHDE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lnhde_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lnhde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_New_GET",
				AreaName = "lnhde",
				FormName = "LNHDE",
				Location = ACTION_LNHDE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lnhde();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHDE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lnhde/Lnhde_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_New([FromBody]Lnhde_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_New",
				ViewName = "Lnhde",
				AreaName = "lnhde",
				Location = ACTION_LNHDE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHDE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lnhde_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Edit_GET",
				AreaName = "lnhde",
				FormName = "LNHDE",
				Location = ACTION_LNHDE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhde();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHDE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lnhde/Lnhde_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_Edit([FromBody]Lnhde_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Edit",
				ViewName = "Lnhde",
				AreaName = "lnhde",
				Location = ACTION_LNHDE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHDE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lnhde_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Delete_GET",
				AreaName = "lnhde",
				FormName = "LNHDE",
				Location = ACTION_LNHDE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhde();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHDE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lnhde/Lnhde_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhde_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Delete",
				ViewName = "Lnhde",
				AreaName = "lnhde",
				Location = ACTION_LNHDE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHDE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lnhde_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHDE");
		}

		#endregion

		#region Lnhde_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHDE]/

		[HttpPost]
		public ActionResult Lnhde_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lnhde_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Duplicate_GET",
				AreaName = "lnhde",
				FormName = "LNHDE",
				Location = ACTION_LNHDE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHDE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lnhde/Lnhde_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHDE]/
		[HttpPost]
		public ActionResult Lnhde_Duplicate([FromBody]Lnhde_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_Duplicate",
				ViewName = "Lnhde",
				AreaName = "lnhde",
				Location = ACTION_LNHDE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHDE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHDE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHDE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lnhde_Cancel

		//
		// GET: /Lnhde/Lnhde_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHDE]/
		public ActionResult Lnhde_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhde(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhde");

// USE /[MANUAL GQT BEFORE_CANCEL LNHDE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHDE]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhde", "true", true);
			}

			Navigation.ClearValue("lnhde");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Lnhde_PedidValNrpedidoModel : RequestLookupModel
		{
			public Lnhde_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhde/Lnhde_PedidValNrpedido
		// POST: /Lnhde/Lnhde_PedidValNrpedido
		[ActionName("Lnhde_PedidValNrpedido")]
		public ActionResult Lnhde_PedidValNrpedido([FromBody] Lnhde_PedidValNrpedidoModel requestModel)
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

			Models.Lnhde parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhde_PedidValNrpedido_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Lnhde_LnhpdValLineModel : RequestLookupModel
		{
			public Lnhde_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhde/Lnhde_LnhpdValLine
		// POST: /Lnhde/Lnhde_LnhpdValLine
		[ActionName("Lnhde_LnhpdValLine")]
		public ActionResult Lnhde_LnhpdValLine([FromBody] Lnhde_LnhpdValLineModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhpd")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhpd");
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

			Models.Lnhde parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhde_LnhpdValLine_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Lnhde_Tpeq1ValTipoequiModel : RequestLookupModel
		{
			public Lnhde_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhde/Lnhde_Tpeq1ValTipoequi
		// POST: /Lnhde/Lnhde_Tpeq1ValTipoequi
		[ActionName("Lnhde_Tpeq1ValTipoequi")]
		public ActionResult Lnhde_Tpeq1ValTipoequi([FromBody] Lnhde_Tpeq1ValTipoequiModel requestModel)
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

			Models.Lnhde parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhde_Tpeq1ValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Lnhde_ValLnpropsModel : RequestLookupModel
		{
			public Lnhde_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhde/Lnhde_ValLnprops
		// POST: /Lnhde/Lnhde_ValLnprops
		[ActionName("Lnhde_ValLnprops")]
		public ActionResult Lnhde_ValLnprops([FromBody] Lnhde_ValLnpropsModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhdf")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhdf");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Lnhde parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhde_ValLnprops_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Lnhde/Lnhde_SaveEdit
		[HttpPost]
		public ActionResult Lnhde_SaveEdit([FromBody]Lnhde_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhde_SaveEdit",
				ViewName = "Lnhde",
				AreaName = "lnhde",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHDE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHDE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}
	}
}
