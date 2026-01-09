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
using System.Dynamic;

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
using GenioMVC.ViewModels.Wareh;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER WAREH]/

namespace GenioMVC.Controllers
{
	public partial class WarehController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ARMAZ_CANCEL = new("TABLE_LIST35818", "Armaz_Cancel", "Wareh") { vueRouteName = "form-ARMAZ", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ARMAZ_SHOW = new("TABLE_LIST35818", "Armaz_Show", "Wareh") { vueRouteName = "form-ARMAZ", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ARMAZ_NEW = new("TABLE_LIST35818", "Armaz_New", "Wareh") { vueRouteName = "form-ARMAZ", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ARMAZ_EDIT = new("TABLE_LIST35818", "Armaz_Edit", "Wareh") { vueRouteName = "form-ARMAZ", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ARMAZ_DUPLICATE = new("TABLE_LIST35818", "Armaz_Duplicate", "Wareh") { vueRouteName = "form-ARMAZ", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ARMAZ_DELETE = new("TABLE_LIST35818", "Armaz_Delete", "Wareh") { vueRouteName = "form-ARMAZ", mode = "DELETE" };

		#endregion

		#region Armaz private

		private void FormHistoryLimits_Armaz()
		{

		}

		#endregion

		#region Armaz_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ARMAZ]/

		[HttpPost]
		public ActionResult Armaz_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Show_GET",
				AreaName = "wareh",
				Location = ACTION_ARMAZ_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ARMAZ]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Armaz_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Armaz_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz_New_GET",
				AreaName = "wareh",
				FormName = "ARMAZ",
				Location = ACTION_ARMAZ_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Armaz();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ARMAZ]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Wareh/Armaz_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_New([FromBody]Armaz_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz_New",
				ViewName = "Armaz",
				AreaName = "wareh",
				Location = ACTION_ARMAZ_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ARMAZ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ARMAZ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ARMAZ]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Armaz_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Edit_GET",
				AreaName = "wareh",
				FormName = "ARMAZ",
				Location = ACTION_ARMAZ_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ARMAZ]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armaz_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_Edit([FromBody]Armaz_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Edit",
				ViewName = "Armaz",
				AreaName = "wareh",
				Location = ACTION_ARMAZ_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ARMAZ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ARMAZ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ARMAZ]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Armaz_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Delete_GET",
				AreaName = "wareh",
				FormName = "ARMAZ",
				Location = ACTION_ARMAZ_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Armaz();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ARMAZ]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Wareh/Armaz_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Armaz_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Armaz_Delete",
				ViewName = "Armaz",
				AreaName = "wareh",
				Location = ACTION_ARMAZ_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ARMAZ]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Armaz_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ARMAZ");
		}

		#endregion

		#region Armaz_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ARMAZ]/

		[HttpPost]
		public ActionResult Armaz_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Armaz_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Duplicate_GET",
				AreaName = "wareh",
				FormName = "ARMAZ",
				Location = ACTION_ARMAZ_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ARMAZ]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Wareh/Armaz_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ARMAZ]/
		[HttpPost]
		public ActionResult Armaz_Duplicate([FromBody]Armaz_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz_Duplicate",
				ViewName = "Armaz",
				AreaName = "wareh",
				Location = ACTION_ARMAZ_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ARMAZ]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ARMAZ]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ARMAZ]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Armaz_Cancel

		//
		// GET: /Wareh/Armaz_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ARMAZ]/
		public ActionResult Armaz_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Wareh model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("wareh");

// USE /[MANUAL GQT BEFORE_CANCEL ARMAZ]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ARMAZ]/

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

				Navigation.SetValue("ForcePrimaryRead_wareh", "true", true);
			}

			Navigation.ClearValue("wareh");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Armaz_ValPessarmaModel : RequestLookupModel
		{
			public Armaz_ViewModel Model { get; set; }
		}

		//
		// GET: /Wareh/Armaz_ValPessarma
		// POST: /Wareh/Armaz_ValPessarma
		[ActionName("Armaz_ValPessarma")]
		public ActionResult Armaz_ValPessarma([FromBody] Armaz_ValPessarmaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_wpess")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_wpess");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Wareh parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Armaz_ValPessarma_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			// Add form field filters to the table configuration
			tableConfig.FieldFilters = requestModel.RelatedFilterValues;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Wareh/Armaz_SaveEdit
		[HttpPost]
		public ActionResult Armaz_SaveEdit([FromBody] Armaz_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Armaz_SaveEdit",
				ViewName = "Armaz",
				AreaName = "wareh",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ARMAZ]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ARMAZ]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ArmazDocumValidateTickets : RequestDocumValidateTickets
		{
			public Armaz_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsArmaz([FromBody] ArmazDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
