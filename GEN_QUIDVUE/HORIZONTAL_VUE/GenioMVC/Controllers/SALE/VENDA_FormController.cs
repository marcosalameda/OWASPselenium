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
using GenioMVC.ViewModels.Sale;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SALE]/

namespace GenioMVC.Controllers
{
	public partial class SaleController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_VENDA_CANCEL = new("SALE02786", "Venda_Cancel", "Sale") { vueRouteName = "form-VENDA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_VENDA_SHOW = new("SALE02786", "Venda_Show", "Sale") { vueRouteName = "form-VENDA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_VENDA_NEW = new("SALE02786", "Venda_New", "Sale") { vueRouteName = "form-VENDA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_VENDA_EDIT = new("SALE02786", "Venda_Edit", "Sale") { vueRouteName = "form-VENDA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_VENDA_DUPLICATE = new("SALE02786", "Venda_Duplicate", "Sale") { vueRouteName = "form-VENDA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_VENDA_DELETE = new("SALE02786", "Venda_Delete", "Sale") { vueRouteName = "form-VENDA", mode = "DELETE" };

		#endregion

		#region Venda private

		private void FormHistoryLimits_Venda()
		{

		}

		#endregion

		#region Venda_Show

// USE /[MANUAL GQT CONTROLLER_SHOW VENDA]/

		[HttpPost]
		public ActionResult Venda_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Show_GET",
				AreaName = "sale",
				Location = ACTION_VENDA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW VENDA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Venda_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_New_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW VENDA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Sale/Venda_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_New([FromBody]Venda_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_New",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX VENDA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Venda_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Edit_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT VENDA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Sale/Venda_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Edit([FromBody]Venda_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Edit",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX VENDA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Venda_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET VENDA]/
		[HttpPost]
		public ActionResult Venda_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Delete_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Venda();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE VENDA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Sale/Venda_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new Venda_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "Venda_Delete",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE VENDA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Venda_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("VENDA");
		}

		#endregion

		#region Venda_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET VENDA]/

		[HttpPost]
		public ActionResult Venda_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new Venda_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Duplicate_GET",
				AreaName = "sale",
				FormName = "VENDA",
				Location = ACTION_VENDA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE VENDA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Sale/Venda_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST VENDA]/
		[HttpPost]
		public ActionResult Venda_Duplicate([FromBody]Venda_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_Duplicate",
				ViewName = "Venda",
				AreaName = "sale",
				Location = ACTION_VENDA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE VENDA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX VENDA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX VENDA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Venda_Cancel

		//
		// GET: /Sale/Venda_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET VENDA]/
		public ActionResult Venda_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Sale(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("sale");

// USE /[MANUAL GQT BEFORE_CANCEL VENDA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL VENDA]/

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

				Navigation.SetValue("ForcePrimaryRead_sale", "true", true);
			}

			Navigation.ClearValue("sale");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Venda_OrganValOrganizaModel : RequestLookupModel
		{
			public Venda_ViewModel Model { get; set; }
		}

		//
		// GET: /Sale/Venda_OrganValOrganiza
		// POST: /Sale/Venda_OrganValOrganiza
		[ActionName("Venda_OrganValOrganiza")]
		public ActionResult Venda_OrganValOrganiza([FromBody] Venda_OrganValOrganizaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_organ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_organ");
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

			Models.Sale parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			Venda_OrganValOrganiza_ViewModel model = new(UserContext.Current, parentCtx);

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


		// POST: /Sale/Venda_SaveEdit
		[HttpPost]
		public ActionResult Venda_SaveEdit([FromBody] Venda_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "Venda_SaveEdit",
				ViewName = "Venda",
				AreaName = "sale",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT VENDA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT VENDA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class VendaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Venda_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsVenda([FromBody] VendaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
