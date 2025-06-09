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
using GenioMVC.ViewModels.Cmpny;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CMPNY]/

namespace GenioMVC.Controllers
{
	public partial class CmpnyController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EMPRE_CANCEL = new("COMPANY52963", "Empre_Cancel", "Cmpny") { vueRouteName = "form-EMPRE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EMPRE_SHOW = new("COMPANY52963", "Empre_Show", "Cmpny") { vueRouteName = "form-EMPRE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EMPRE_NEW = new("COMPANY52963", "Empre_New", "Cmpny") { vueRouteName = "form-EMPRE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EMPRE_EDIT = new("COMPANY52963", "Empre_Edit", "Cmpny") { vueRouteName = "form-EMPRE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EMPRE_DUPLICATE = new("COMPANY52963", "Empre_Duplicate", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EMPRE_DELETE = new("COMPANY52963", "Empre_Delete", "Cmpny") { vueRouteName = "form-EMPRE", mode = "DELETE" };

		#endregion

		#region Empre private

		private void FormHistoryLimits_Empre()
		{

		}

		#endregion

		#region Empre_Show

// USE /[MANUAL GQT CONTROLLER_SHOW EMPRE]/

		[HttpPost]
		public ActionResult Empre_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Show_GET",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW EMPRE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Empre_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_New_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW EMPRE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cmpny/Empre_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_New([FromBody]Empre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_New",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX EMPRE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Empre_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Edit_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT EMPRE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Empre_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Edit([FromBody]Empre_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Edit",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX EMPRE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Empre_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET EMPRE]/
		[HttpPost]
		public ActionResult Empre_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Delete_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Empre();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE EMPRE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cmpny/Empre_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Empre_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Empre_Delete",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE EMPRE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Empre_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EMPRE");
		}

		#endregion

		#region Empre_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET EMPRE]/

		[HttpPost]
		public ActionResult Empre_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Empre_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Duplicate_GET",
				AreaName = "cmpny",
				FormName = "EMPRE",
				Location = ACTION_EMPRE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE EMPRE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cmpny/Empre_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST EMPRE]/
		[HttpPost]
		public ActionResult Empre_Duplicate([FromBody]Empre_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Empre_Duplicate",
				ViewName = "Empre",
				AreaName = "cmpny",
				Location = ACTION_EMPRE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE EMPRE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX EMPRE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX EMPRE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Empre_Cancel

		//
		// GET: /Cmpny/Empre_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET EMPRE]/
		public ActionResult Empre_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cmpny(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cmpny");

// USE /[MANUAL GQT BEFORE_CANCEL EMPRE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL EMPRE]/

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

				Navigation.SetValue("ForcePrimaryRead_cmpny", "true", true);
			}

			Navigation.ClearValue("cmpny");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Empre_CntryValCountryModel : RequestLookupModel
		{
			public Empre_ViewModel Model { get; set; }
		}

		//
		// GET: /Cmpny/Empre_CntryValCountry
		// POST: /Cmpny/Empre_CntryValCountry
		[ActionName("Empre_CntryValCountry")]
		public ActionResult Empre_CntryValCountry([FromBody] Empre_CntryValCountryModel requestModel)
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

			Models.Cmpny parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Empre_CntryValCountry_ViewModel model = new(UserContext.Current, parentCtx);

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

		// POST: /Cmpny/Empre_SaveEdit
		[HttpPost]
		public ActionResult Empre_SaveEdit([FromBody] Empre_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Empre_SaveEdit",
				ViewName = "Empre",
				AreaName = "cmpny",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT EMPRE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT EMPRE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class EmpreDocumValidateTickets : RequestDocumValidateTickets
		{
			public Empre_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEmpre([FromBody] EmpreDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
