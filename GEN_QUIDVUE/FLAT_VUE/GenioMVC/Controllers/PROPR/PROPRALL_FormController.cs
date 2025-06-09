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
using GenioMVC.ViewModels.Propr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROPR]/

namespace GenioMVC.Controllers
{
	public partial class ProprController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROPRALL_CANCEL = new("PROPERTY43977", "Proprall_Cancel", "Propr") { vueRouteName = "form-PROPRALL", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPRALL_SHOW = new("PROPERTY43977", "Proprall_Show", "Propr") { vueRouteName = "form-PROPRALL", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPRALL_NEW = new("PROPERTY43977", "Proprall_New", "Propr") { vueRouteName = "form-PROPRALL", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPRALL_EDIT = new("PROPERTY43977", "Proprall_Edit", "Propr") { vueRouteName = "form-PROPRALL", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPRALL_DUPLICATE = new("PROPERTY43977", "Proprall_Duplicate", "Propr") { vueRouteName = "form-PROPRALL", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPRALL_DELETE = new("PROPERTY43977", "Proprall_Delete", "Propr") { vueRouteName = "form-PROPRALL", mode = "DELETE" };

		#endregion

		#region Proprall private

		private void FormHistoryLimits_Proprall()
		{

		}

		#endregion

		#region Proprall_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPRALL]/

		[HttpPost]
		public ActionResult Proprall_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proprall_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Show_GET",
				AreaName = "propr",
				Location = ACTION_PROPRALL_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proprall();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPRALL]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Proprall_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Proprall_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_New_GET",
				AreaName = "propr",
				FormName = "PROPRALL",
				Location = ACTION_PROPRALL_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Proprall();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPRALL]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Propr/Proprall_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_New([FromBody]Proprall_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_New",
				ViewName = "Proprall",
				AreaName = "propr",
				Location = ACTION_PROPRALL_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPRALL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPRALL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPRALL]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Proprall_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proprall_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Edit_GET",
				AreaName = "propr",
				FormName = "PROPRALL",
				Location = ACTION_PROPRALL_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proprall();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPRALL]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Propr/Proprall_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_Edit([FromBody]Proprall_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Edit",
				ViewName = "Proprall",
				AreaName = "propr",
				Location = ACTION_PROPRALL_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPRALL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPRALL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPRALL]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Proprall_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proprall_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Delete_GET",
				AreaName = "propr",
				FormName = "PROPRALL",
				Location = ACTION_PROPRALL_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proprall();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPRALL]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Propr/Proprall_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proprall_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Delete",
				ViewName = "Proprall",
				AreaName = "propr",
				Location = ACTION_PROPRALL_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPRALL]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Proprall_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPRALL");
		}

		#endregion

		#region Proprall_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPRALL]/

		[HttpPost]
		public ActionResult Proprall_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Proprall_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Duplicate_GET",
				AreaName = "propr",
				FormName = "PROPRALL",
				Location = ACTION_PROPRALL_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPRALL]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Propr/Proprall_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPRALL]/
		[HttpPost]
		public ActionResult Proprall_Duplicate([FromBody]Proprall_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proprall_Duplicate",
				ViewName = "Proprall",
				AreaName = "propr",
				Location = ACTION_PROPRALL_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPRALL]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPRALL]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPRALL]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Proprall_Cancel

		//
		// GET: /Propr/Proprall_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPRALL]/
		public ActionResult Proprall_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Propr(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("propr");

// USE /[MANUAL GQT BEFORE_CANCEL PROPRALL]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPRALL]/

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

				Navigation.SetValue("ForcePrimaryRead_propr", "true", true);
			}

			Navigation.ClearValue("propr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Proprall_TpproValTppropriModel : RequestLookupModel
		{
			public Proprall_ViewModel Model { get; set; }
		}

		//
		// GET: /Propr/Proprall_TpproValTppropri
		// POST: /Propr/Proprall_TpproValTppropri
		[ActionName("Proprall_TpproValTppropri")]
		public ActionResult Proprall_TpproValTppropri([FromBody] Proprall_TpproValTppropriModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_tppro")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_tppro");
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

			Models.Propr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Proprall_TpproValTppropri_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Proprall_CntryValCountryModel : RequestLookupModel
		{
			public Proprall_ViewModel Model { get; set; }
		}

		//
		// GET: /Propr/Proprall_CntryValCountry
		// POST: /Propr/Proprall_CntryValCountry
		[ActionName("Proprall_CntryValCountry")]
		public ActionResult Proprall_CntryValCountry([FromBody] Proprall_CntryValCountryModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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

			Models.Propr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Proprall_CntryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Proprall_RegioValRegiaoModel : RequestLookupModel
		{
			public Proprall_ViewModel Model { get; set; }
		}

		//
		// GET: /Propr/Proprall_RegioValRegiao
		// POST: /Propr/Proprall_RegioValRegiao
		[ActionName("Proprall_RegioValRegiao")]
		public ActionResult Proprall_RegioValRegiao([FromBody] Proprall_RegioValRegiaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regio");
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

			Models.Propr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Proprall_RegioValRegiao_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Proprall_PessoValNameModel : RequestLookupModel
		{
			public Proprall_ViewModel Model { get; set; }
		}

		//
		// GET: /Propr/Proprall_PessoValName
		// POST: /Propr/Proprall_PessoValName
		[ActionName("Proprall_PessoValName")]
		public ActionResult Proprall_PessoValName([FromBody] Proprall_PessoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_pesso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_pesso");
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

			Models.Propr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Proprall_PessoValName_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Propr/Proprall_SaveEdit
		[HttpPost]
		public ActionResult Proprall_SaveEdit([FromBody] Proprall_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Proprall_SaveEdit",
				ViewName = "Proprall",
				AreaName = "propr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPRALL]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPRALL]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ProprallDocumValidateTickets : RequestDocumValidateTickets
		{
			public Proprall_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsProprall([FromBody] ProprallDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
