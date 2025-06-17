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
using GenioMVC.ViewModels.Procn;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PROCN]/

namespace GenioMVC.Controllers
{
	public partial class ProcnController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONTAC03_CANCEL = new("CONTACT59247", "Contac03_Cancel", "Procn") { vueRouteName = "form-CONTAC03", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONTAC03_SHOW = new("CONTACT59247", "Contac03_Show", "Procn") { vueRouteName = "form-CONTAC03", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONTAC03_NEW = new("CONTACT59247", "Contac03_New", "Procn") { vueRouteName = "form-CONTAC03", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONTAC03_EDIT = new("CONTACT59247", "Contac03_Edit", "Procn") { vueRouteName = "form-CONTAC03", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONTAC03_DUPLICATE = new("CONTACT59247", "Contac03_Duplicate", "Procn") { vueRouteName = "form-CONTAC03", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONTAC03_DELETE = new("CONTACT59247", "Contac03_Delete", "Procn") { vueRouteName = "form-CONTAC03", mode = "DELETE" };

		#endregion

		#region Contac03 private

		private void FormHistoryLimits_Contac03()
		{

		}

		#endregion

		#region Contac03_Show

// USE /[MANUAL GQT CONTROLLER_SHOW CONTAC03]/

		[HttpPost]
		public ActionResult Contac03_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Show_GET",
				AreaName = "procn",
				Location = ACTION_CONTAC03_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac03();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW CONTAC03]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Contac03_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Contac03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_New_GET",
				AreaName = "procn",
				FormName = "CONTAC03",
				Location = ACTION_CONTAC03_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Contac03();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW CONTAC03]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Procn/Contac03_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_New([FromBody]Contac03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_New",
				ViewName = "Contac03",
				AreaName = "procn",
				Location = ACTION_CONTAC03_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW CONTAC03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX CONTAC03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX CONTAC03]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Contac03_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Edit_GET",
				AreaName = "procn",
				FormName = "CONTAC03",
				Location = ACTION_CONTAC03_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac03();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT CONTAC03]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Procn/Contac03_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_Edit([FromBody]Contac03_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Edit",
				ViewName = "Contac03",
				AreaName = "procn",
				Location = ACTION_CONTAC03_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT CONTAC03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX CONTAC03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX CONTAC03]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Contac03_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Delete_GET",
				AreaName = "procn",
				FormName = "CONTAC03",
				Location = ACTION_CONTAC03_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Contac03();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE CONTAC03]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Procn/Contac03_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Contac03_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Delete",
				ViewName = "Contac03",
				AreaName = "procn",
				Location = ACTION_CONTAC03_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE CONTAC03]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Contac03_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONTAC03");
		}

		#endregion

		#region Contac03_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET CONTAC03]/

		[HttpPost]
		public ActionResult Contac03_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Contac03_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Duplicate_GET",
				AreaName = "procn",
				FormName = "CONTAC03",
				Location = ACTION_CONTAC03_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE CONTAC03]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Procn/Contac03_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST CONTAC03]/
		[HttpPost]
		public ActionResult Contac03_Duplicate([FromBody]Contac03_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_Duplicate",
				ViewName = "Contac03",
				AreaName = "procn",
				Location = ACTION_CONTAC03_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE CONTAC03]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX CONTAC03]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX CONTAC03]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Contac03_Cancel

		//
		// GET: /Procn/Contac03_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET CONTAC03]/
		public ActionResult Contac03_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Procn(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("procn");

// USE /[MANUAL GQT BEFORE_CANCEL CONTAC03]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL CONTAC03]/

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

				Navigation.SetValue("ForcePrimaryRead_procn", "true", true);
			}

			Navigation.ClearValue("procn");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Contac03_PropeValTitleModel : RequestLookupModel
		{
			public Contac03_ViewModel Model { get; set; }
		}

		//
		// GET: /Procn/Contac03_PropeValTitle
		// POST: /Procn/Contac03_PropeValTitle
		[ActionName("Contac03_PropeValTitle")]
		public ActionResult Contac03_PropeValTitle([FromBody] Contac03_PropeValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_prope")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_prope");
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

			Models.Procn parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Contac03_PropeValTitle_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Procn/Contac03_SaveEdit
		[HttpPost]
		public ActionResult Contac03_SaveEdit([FromBody] Contac03_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Contac03_SaveEdit",
				ViewName = "Contac03",
				AreaName = "procn",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT CONTAC03]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT CONTAC03]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Contac03DocumValidateTickets : RequestDocumValidateTickets
		{
			public Contac03_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsContac03([FromBody] Contac03DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
