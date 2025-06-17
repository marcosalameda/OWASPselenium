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
using GenioMVC.ViewModels.Cntry;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER CNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CntryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PROPPAIS_CANCEL = new("COUNTRY64133", "Proppais_Cancel", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PROPPAIS_SHOW = new("COUNTRY64133", "Proppais_Show", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PROPPAIS_NEW = new("COUNTRY64133", "Proppais_New", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PROPPAIS_EDIT = new("COUNTRY64133", "Proppais_Edit", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PROPPAIS_DUPLICATE = new("COUNTRY64133", "Proppais_Duplicate", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PROPPAIS_DELETE = new("COUNTRY64133", "Proppais_Delete", "Cntry") { vueRouteName = "form-PROPPAIS", mode = "DELETE" };

		#endregion

		#region Proppais private

		private void FormHistoryLimits_Proppais()
		{

		}

		#endregion

		#region Proppais_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PROPPAIS]/

		[HttpPost]
		public ActionResult Proppais_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proppais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Show_GET",
				AreaName = "cntry",
				Location = ACTION_PROPPAIS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proppais();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PROPPAIS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Proppais_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Proppais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_New_GET",
				AreaName = "cntry",
				FormName = "PROPPAIS",
				Location = ACTION_PROPPAIS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Proppais();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PROPPAIS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cntry/Proppais_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_New([FromBody]Proppais_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_New",
				ViewName = "Proppais",
				AreaName = "cntry",
				Location = ACTION_PROPPAIS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PROPPAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PROPPAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PROPPAIS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Proppais_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proppais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Edit_GET",
				AreaName = "cntry",
				FormName = "PROPPAIS",
				Location = ACTION_PROPPAIS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proppais();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PROPPAIS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cntry/Proppais_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_Edit([FromBody]Proppais_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Edit",
				ViewName = "Proppais",
				AreaName = "cntry",
				Location = ACTION_PROPPAIS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PROPPAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PROPPAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PROPPAIS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Proppais_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proppais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Delete_GET",
				AreaName = "cntry",
				FormName = "PROPPAIS",
				Location = ACTION_PROPPAIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Proppais();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PROPPAIS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cntry/Proppais_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Proppais_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Delete",
				ViewName = "Proppais",
				AreaName = "cntry",
				Location = ACTION_PROPPAIS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PROPPAIS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Proppais_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PROPPAIS");
		}

		#endregion

		#region Proppais_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PROPPAIS]/

		[HttpPost]
		public ActionResult Proppais_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Proppais_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Duplicate_GET",
				AreaName = "cntry",
				FormName = "PROPPAIS",
				Location = ACTION_PROPPAIS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PROPPAIS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cntry/Proppais_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PROPPAIS]/
		[HttpPost]
		public ActionResult Proppais_Duplicate([FromBody]Proppais_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_Duplicate",
				ViewName = "Proppais",
				AreaName = "cntry",
				Location = ACTION_PROPPAIS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PROPPAIS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PROPPAIS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PROPPAIS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Proppais_Cancel

		//
		// GET: /Cntry/Proppais_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PROPPAIS]/
		public ActionResult Proppais_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cntry(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");

// USE /[MANUAL GQT BEFORE_CANCEL PROPPAIS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PROPPAIS]/

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

				Navigation.SetValue("ForcePrimaryRead_cntry", "true", true);
			}

			Navigation.ClearValue("cntry");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Proppais_ValPropriedModel : RequestLookupModel
		{
			public Proppais_ViewModel Model { get; set; }
		}

		//
		// GET: /Cntry/Proppais_ValPropried
		// POST: /Cntry/Proppais_ValPropried
		[ActionName("Proppais_ValPropried")]
		public ActionResult Proppais_ValPropried([FromBody] Proppais_ValPropriedModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_propr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_propr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Cntry parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Proppais_ValPropried_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Cntry/Proppais_SaveEdit
		[HttpPost]
		public ActionResult Proppais_SaveEdit([FromBody] Proppais_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Proppais_SaveEdit",
				ViewName = "Proppais",
				AreaName = "cntry",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PROPPAIS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PROPPAIS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ProppaisDocumValidateTickets : RequestDocumValidateTickets
		{
			public Proppais_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsProppais([FromBody] ProppaisDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
