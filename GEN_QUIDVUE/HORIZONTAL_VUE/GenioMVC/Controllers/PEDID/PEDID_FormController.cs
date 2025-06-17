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
using GenioMVC.ViewModels.Pedid;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PEDID]/

namespace GenioMVC.Controllers
{
	public partial class PedidController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PEDID_CANCEL = new("EQUIPMENT_REQUEST62893", "Pedid_Cancel", "Pedid") { vueRouteName = "form-PEDID", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PEDID_SHOW = new("EQUIPMENT_REQUEST62893", "Pedid_Show", "Pedid") { vueRouteName = "form-PEDID", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PEDID_NEW = new("EQUIPMENT_REQUEST62893", "Pedid_New", "Pedid") { vueRouteName = "form-PEDID", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PEDID_EDIT = new("EQUIPMENT_REQUEST62893", "Pedid_Edit", "Pedid") { vueRouteName = "form-PEDID", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PEDID_DUPLICATE = new("EQUIPMENT_REQUEST62893", "Pedid_Duplicate", "Pedid") { vueRouteName = "form-PEDID", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PEDID_DELETE = new("EQUIPMENT_REQUEST62893", "Pedid_Delete", "Pedid") { vueRouteName = "form-PEDID", mode = "DELETE" };

		#endregion

		#region Pedid private

		private void FormHistoryLimits_Pedid()
		{

		}

		#endregion

		#region Pedid_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PEDID]/

		[HttpPost]
		public ActionResult Pedid_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pedid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Show_GET",
				AreaName = "pedid",
				Location = ACTION_PEDID_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pedid();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PEDID]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pedid_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PEDID]/
		[HttpPost]
		public ActionResult Pedid_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pedid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_New_GET",
				AreaName = "pedid",
				FormName = "PEDID",
				Location = ACTION_PEDID_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pedid();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PEDID]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pedid/Pedid_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PEDID]/
		[HttpPost]
		public ActionResult Pedid_New([FromBody]Pedid_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_New",
				ViewName = "Pedid",
				AreaName = "pedid",
				Location = ACTION_PEDID_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PEDID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PEDID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PEDID]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pedid_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PEDID]/
		[HttpPost]
		public ActionResult Pedid_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pedid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Edit_GET",
				AreaName = "pedid",
				FormName = "PEDID",
				Location = ACTION_PEDID_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pedid();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PEDID]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pedid/Pedid_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PEDID]/
		[HttpPost]
		public ActionResult Pedid_Edit([FromBody]Pedid_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Edit",
				ViewName = "Pedid",
				AreaName = "pedid",
				Location = ACTION_PEDID_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PEDID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PEDID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PEDID]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pedid_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PEDID]/
		[HttpPost]
		public ActionResult Pedid_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pedid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Delete_GET",
				AreaName = "pedid",
				FormName = "PEDID",
				Location = ACTION_PEDID_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pedid();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PEDID]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pedid/Pedid_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PEDID]/
		[HttpPost]
		public ActionResult Pedid_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pedid_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Delete",
				ViewName = "Pedid",
				AreaName = "pedid",
				Location = ACTION_PEDID_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PEDID]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pedid_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PEDID");
		}

		#endregion

		#region Pedid_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PEDID]/

		[HttpPost]
		public ActionResult Pedid_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pedid_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Duplicate_GET",
				AreaName = "pedid",
				FormName = "PEDID",
				Location = ACTION_PEDID_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PEDID]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pedid/Pedid_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PEDID]/
		[HttpPost]
		public ActionResult Pedid_Duplicate([FromBody]Pedid_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_Duplicate",
				ViewName = "Pedid",
				AreaName = "pedid",
				Location = ACTION_PEDID_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PEDID]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PEDID]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PEDID]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pedid_Cancel

		//
		// GET: /Pedid/Pedid_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PEDID]/
		public ActionResult Pedid_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pedid(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pedid");

// USE /[MANUAL GQT BEFORE_CANCEL PEDID]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PEDID]/

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

				Navigation.SetValue("ForcePrimaryRead_pedid", "true", true);
			}

			Navigation.ClearValue("pedid");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pedid_ValLinhasModel : RequestLookupModel
		{
			public Pedid_ViewModel Model { get; set; }
		}

		//
		// GET: /Pedid/Pedid_ValLinhas
		// POST: /Pedid/Pedid_ValLinhas
		[ActionName("Pedid_ValLinhas")]
		public ActionResult Pedid_ValLinhas([FromBody] Pedid_ValLinhasModel requestModel)
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

			Models.Pedid parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pedid_ValLinhas_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pedid_ValDesagregModel : RequestLookupModel
		{
			public Pedid_ViewModel Model { get; set; }
		}

		//
		// GET: /Pedid/Pedid_ValDesagreg
		// POST: /Pedid/Pedid_ValDesagreg
		[ActionName("Pedid_ValDesagreg")]
		public ActionResult Pedid_ValDesagreg([FromBody] Pedid_ValDesagregModel requestModel)
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

			Models.Pedid parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pedid_ValDesagreg_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pedid_ValAgrupameModel : RequestLookupModel
		{
			public Pedid_ViewModel Model { get; set; }
		}

		//
		// GET: /Pedid/Pedid_ValAgrupame
		// POST: /Pedid/Pedid_ValAgrupame
		[ActionName("Pedid_ValAgrupame")]
		public ActionResult Pedid_ValAgrupame([FromBody] Pedid_ValAgrupameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lnhag")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lnhag");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pedid parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pedid_ValAgrupame_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Pedid/Pedid_SaveEdit
		[HttpPost]
		public ActionResult Pedid_SaveEdit([FromBody] Pedid_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pedid_SaveEdit",
				ViewName = "Pedid",
				AreaName = "pedid",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PEDID]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PEDID]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PedidDocumValidateTickets : RequestDocumValidateTickets
		{
			public Pedid_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPedid([FromBody] PedidDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
