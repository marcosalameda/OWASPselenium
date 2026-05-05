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
using GenioMVC.ViewModels.Pwreg;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PWREG]/

namespace GenioMVC.Controllers
{
	public partial class PwregController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PWREG_CANCEL = new("ACESSO_REGIAO41894", "Pwreg_Cancel", "Pwreg") { vueRouteName = "form-PWREG", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PWREG_SHOW = new("ACESSO_REGIAO41894", "Pwreg_Show", "Pwreg") { vueRouteName = "form-PWREG", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PWREG_NEW = new("ACESSO_REGIAO41894", "Pwreg_New", "Pwreg") { vueRouteName = "form-PWREG", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PWREG_EDIT = new("ACESSO_REGIAO41894", "Pwreg_Edit", "Pwreg") { vueRouteName = "form-PWREG", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PWREG_DUPLICATE = new("ACESSO_REGIAO41894", "Pwreg_Duplicate", "Pwreg") { vueRouteName = "form-PWREG", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PWREG_DELETE = new("ACESSO_REGIAO41894", "Pwreg_Delete", "Pwreg") { vueRouteName = "form-PWREG", mode = "DELETE" };

		#endregion

		#region Pwreg private

		private void FormHistoryLimits_Pwreg()
		{

		}

		#endregion

		#region Pwreg_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PWREG]/

		[HttpPost]
		public ActionResult Pwreg_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Show_GET",
				AreaName = "pwreg",
				Location = ACTION_PWREG_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwreg();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormShow(eventSink, model, id);
			}
		}

		#endregion

		#region Pwreg_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PWREG]/
		[HttpPost]
		public ActionResult Pwreg_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Pwreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_New_GET",
				AreaName = "pwreg",
				FormName = "PWREG",
				Location = ACTION_PWREG_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pwreg();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
			}
		}

		//
		// POST: /Pwreg/Pwreg_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PWREG]/
		[HttpPost]
		public ActionResult Pwreg_New([FromBody]Pwreg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_New",
				ViewName = "Pwreg",
				AreaName = "pwreg",
				Location = ACTION_PWREG_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PWREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PWREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.NEW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormNew(eventSink, model);
			}
		}

		#endregion

		#region Pwreg_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PWREG]/
		[HttpPost]
		public ActionResult Pwreg_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Edit_GET",
				AreaName = "pwreg",
				FormName = "PWREG",
				Location = ACTION_PWREG_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwreg();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormEdit(eventSink, model, id);
			}
		}

		//
		// POST: /Pwreg/Pwreg_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PWREG]/
		[HttpPost]
		public ActionResult Pwreg_Edit([FromBody]Pwreg_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Edit",
				ViewName = "Pwreg",
				AreaName = "pwreg",
				Location = ACTION_PWREG_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PWREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PWREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.EDIT"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormEdit(eventSink, model);
			}
		}

		#endregion

		#region Pwreg_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PWREG]/
		[HttpPost]
		public ActionResult Pwreg_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Delete_GET",
				AreaName = "pwreg",
				FormName = "PWREG",
				Location = ACTION_PWREG_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pwreg();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDelete(eventSink, model, id);
			}
		}

		//
		// POST: /Pwreg/Pwreg_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PWREG]/
		[HttpPost]
		public ActionResult Pwreg_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Pwreg_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Delete",
				ViewName = "Pwreg",
				AreaName = "pwreg",
				Location = ACTION_PWREG_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.DELETE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDelete(eventSink, model);
			}
		}

		public ActionResult Pwreg_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PWREG");
		}

		#endregion

		#region Pwreg_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PWREG]/

		[HttpPost]
		public ActionResult Pwreg_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Pwreg_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Duplicate_GET",
				AreaName = "pwreg",
				FormName = "PWREG",
				Location = ACTION_PWREG_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.SHOW"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
			}
		}

		//
		// POST: /Pwreg/Pwreg_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PWREG]/
		[HttpPost]
		public ActionResult Pwreg_Duplicate([FromBody]Pwreg_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Pwreg_Duplicate",
				ViewName = "Pwreg",
				AreaName = "pwreg",
				Location = ACTION_PWREG_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PWREG]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PWREG]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PWREG]/
				}
			};

			using (CSGenio.core.di.GenioDI.MetricsOtlp.RecordTime("page_load_time", new System.Diagnostics.TagList([
				new("PageId", "PWREG.DUPLICATE"),
				new("PageType", "form")
			]), "ms", "Time to load the page."))
			{
				return GenericHandlePostFormDuplicate(eventSink, model);
			}
		}

		#endregion

		#region Pwreg_Cancel

		//
		// GET: /Pwreg/Pwreg_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PWREG]/
		public ActionResult Pwreg_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Pwreg(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("pwreg");

// USE /[MANUAL GQT BEFORE_CANCEL PWREG]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PWREG]/

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

				Navigation.SetValue("ForcePrimaryRead_pwreg", "true", true);
			}

			Navigation.ClearValue("pwreg");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pwreg_PswValNomeModel : RequestLookupModel
		{
			public Pwreg_ViewModel Model { get; set; }
		}

		//
		// GET: /Pwreg/Pwreg_PswValNome
		// POST: /Pwreg/Pwreg_PswValNome
		[ActionName("Pwreg_PswValNome")]
		public ActionResult Pwreg_PswValNome([FromBody] Pwreg_PswValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_psw")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_psw");
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

			Models.Pwreg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pwreg_PswValNome_ViewModel model = new(UserContext.Current, parentCtx);

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

		public class Pwreg_RegioValRegiaoModel : RequestLookupModel
		{
			public Pwreg_ViewModel Model { get; set; }
		}

		//
		// GET: /Pwreg/Pwreg_RegioValRegiao
		// POST: /Pwreg/Pwreg_RegioValRegiao
		[ActionName("Pwreg_RegioValRegiao")]
		public ActionResult Pwreg_RegioValRegiao([FromBody] Pwreg_RegioValRegiaoModel requestModel)
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

			Models.Pwreg parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Pwreg_RegioValRegiao_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Pwreg/Pwreg_SaveEdit
		[HttpPost]
		public ActionResult Pwreg_SaveEdit([FromBody] Pwreg_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pwreg_SaveEdit",
				ViewName = "Pwreg",
				AreaName = "pwreg",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PWREG]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PWREG]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PwregDocumValidateTickets : RequestDocumValidateTickets
		{
			public Pwreg_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPwreg([FromBody] PwregDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
