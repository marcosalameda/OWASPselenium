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
using GenioMVC.ViewModels.Lnhpd;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER LNHPD]/

namespace GenioMVC.Controllers
{
	public partial class LnhpdController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_LNHPD_CANCEL = new("ORDER_LINE50035", "Lnhpd_Cancel", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_LNHPD_SHOW = new("ORDER_LINE50035", "Lnhpd_Show", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_LNHPD_NEW = new("ORDER_LINE50035", "Lnhpd_New", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "NEW" };
		private static readonly NavigationLocation ACTION_LNHPD_EDIT = new("ORDER_LINE50035", "Lnhpd_Edit", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_LNHPD_DUPLICATE = new("ORDER_LINE50035", "Lnhpd_Duplicate", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_LNHPD_DELETE = new("ORDER_LINE50035", "Lnhpd_Delete", "Lnhpd") { vueRouteName = "form-LNHPD", mode = "DELETE" };

		#endregion

		#region Lnhpd private

		private void FormHistoryLimits_Lnhpd()
		{

		}

		#endregion

		#region Lnhpd_Show

// USE /[MANUAL GQT CONTROLLER_SHOW LNHPD]/

		[HttpPost]
		public ActionResult Lnhpd_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Show_GET",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW LNHPD]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Lnhpd_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_New_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW LNHPD]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Lnhpd/Lnhpd_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_New([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_New",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX LNHPD]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Lnhpd_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Edit_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT LNHPD]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Lnhpd/Lnhpd_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Edit([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Edit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX LNHPD]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Lnhpd_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Delete_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Lnhpd();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE LNHPD]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Lnhpd/Lnhpd_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Lnhpd_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Delete",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE LNHPD]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Lnhpd_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("LNHPD");
		}

		#endregion

		#region Lnhpd_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET LNHPD]/

		[HttpPost]
		public ActionResult Lnhpd_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Lnhpd_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Duplicate_GET",
				AreaName = "lnhpd",
				FormName = "LNHPD",
				Location = ACTION_LNHPD_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE LNHPD]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Lnhpd/Lnhpd_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST LNHPD]/
		[HttpPost]
		public ActionResult Lnhpd_Duplicate([FromBody]Lnhpd_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_Duplicate",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				Location = ACTION_LNHPD_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE LNHPD]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX LNHPD]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX LNHPD]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Lnhpd_Cancel

		//
		// GET: /Lnhpd/Lnhpd_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET LNHPD]/
		public ActionResult Lnhpd_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Lnhpd(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("lnhpd");

// USE /[MANUAL GQT BEFORE_CANCEL LNHPD]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL LNHPD]/

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

				Navigation.SetValue("ForcePrimaryRead_lnhpd", "true", true);
			}

			Navigation.ClearValue("lnhpd");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Lnhpd_PedidValNrpedidoModel : RequestLookupModel
		{
			public Lnhpd_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhpd/Lnhpd_PedidValNrpedido
		// POST: /Lnhpd/Lnhpd_PedidValNrpedido
		[ActionName("Lnhpd_PedidValNrpedido")]
		public ActionResult Lnhpd_PedidValNrpedido([FromBody] Lnhpd_PedidValNrpedidoModel requestModel)
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

			Models.Lnhpd parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhpd_PedidValNrpedido_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Lnhpd_TpequValTipoequiModel : RequestLookupModel
		{
			public Lnhpd_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhpd/Lnhpd_TpequValTipoequi
		// POST: /Lnhpd/Lnhpd_TpequValTipoequi
		[ActionName("Lnhpd_TpequValTipoequi")]
		public ActionResult Lnhpd_TpequValTipoequi([FromBody] Lnhpd_TpequValTipoequiModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
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

			Models.Lnhpd parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhpd_TpequValTipoequi_ViewModel model = new(UserContext.Current, parentCtx);

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

		#region Cargas

		/// <summary>
		/// Carga
		/// </summary>
		/// <param name="id">source id</param>
		/// <param name="modelname">destination id</param>
		/// <returns>Success message</returns>
		public ActionResult GetCarga_CONJUNTO([FromBody] RequestCargaModel requestModel)
		{
			var idsrc = requestModel.Idsrc;
			var iddst = requestModel.Iddst;

			PersistentSupport sp = UserContext.Current.PersistentSupport;
			try
			{
				sp.openTransaction();
				GenioMVC.Models.Lnhpd.Find(iddst, UserContext.Current).carga_CONJUNTO(idsrc);
				sp.closeTransaction();
				return Json(new { Success = true, data = Resources.Resources.A_OPERACAO_FOI_CONCL36721 });
			}
			catch (Exception)
			{
				sp.rollbackTransaction();
				sp.closeConnection();
				return JsonERROR();
			}
		}

		#endregion

		public class Lnhpd_ValDesconjuModel : RequestLookupModel
		{
			public Lnhpd_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhpd/Lnhpd_ValDesconju
		// POST: /Lnhpd/Lnhpd_ValDesconju
		[ActionName("Lnhpd_ValDesconju")]
		public ActionResult Lnhpd_ValDesconju([FromBody] Lnhpd_ValDesconjuModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tpequ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tpequ");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Lnhpd parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhpd_ValDesconju_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Lnhpd_ValDesagregModel : RequestLookupModel
		{
			public Lnhpd_ViewModel Model { get; set; }
		}

		//
		// GET: /Lnhpd/Lnhpd_ValDesagreg
		// POST: /Lnhpd/Lnhpd_ValDesagreg
		[ActionName("Lnhpd_ValDesagreg")]
		public ActionResult Lnhpd_ValDesagreg([FromBody] Lnhpd_ValDesagregModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhde")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhde");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Lnhpd parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Lnhpd_ValDesagreg_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Lnhpd/Lnhpd_SaveEdit
		[HttpPost]
		public ActionResult Lnhpd_SaveEdit([FromBody] Lnhpd_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Lnhpd_SaveEdit",
				ViewName = "Lnhpd",
				AreaName = "lnhpd",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT LNHPD]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT LNHPD]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class LnhpdDocumValidateTickets : RequestDocumValidateTickets
		{
			public Lnhpd_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsLnhpd([FromBody] LnhpdDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
