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
using GenioMVC.ViewModels.Produ;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PRODU]/

namespace GenioMVC.Controllers
{
	public partial class ProduController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PRODU_CANCEL = new("PRODUCT12880", "Produ_Cancel", "Produ") { vueRouteName = "form-PRODU", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PRODU_SHOW = new("PRODUCT12880", "Produ_Show", "Produ") { vueRouteName = "form-PRODU", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PRODU_NEW = new("PRODUCT12880", "Produ_New", "Produ") { vueRouteName = "form-PRODU", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PRODU_EDIT = new("PRODUCT12880", "Produ_Edit", "Produ") { vueRouteName = "form-PRODU", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PRODU_DUPLICATE = new("PRODUCT12880", "Produ_Duplicate", "Produ") { vueRouteName = "form-PRODU", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PRODU_DELETE = new("PRODUCT12880", "Produ_Delete", "Produ") { vueRouteName = "form-PRODU", mode = "DELETE" };

		#endregion

		#region Produ private

		private void FormHistoryLimits_Produ()
		{

		}

		#endregion

		#region Produ_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PRODU]/

		[HttpPost]
		public ActionResult Produ_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Produ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Produ_Show_GET",
				AreaName = "produ",
				Location = ACTION_PRODU_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PRODU]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Produ_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Produ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Produ_New_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PRODU]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Produ/Produ_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_New([FromBody]Produ_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Produ_New",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PRODU]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Produ_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Produ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Produ_Edit_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PRODU]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Produ/Produ_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Edit([FromBody]Produ_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Produ_Edit",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PRODU]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Produ_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PRODU]/
		[HttpPost]
		public ActionResult Produ_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Produ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Produ_Delete_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Produ();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PRODU]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Produ/Produ_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Produ_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Produ_Delete",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PRODU]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Produ_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PRODU");
		}

		#endregion

		#region Produ_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PRODU]/

		[HttpPost]
		public ActionResult Produ_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Produ_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Produ_Duplicate_GET",
				AreaName = "produ",
				FormName = "PRODU",
				Location = ACTION_PRODU_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PRODU]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Produ/Produ_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PRODU]/
		[HttpPost]
		public ActionResult Produ_Duplicate([FromBody]Produ_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Produ_Duplicate",
				ViewName = "Produ",
				AreaName = "produ",
				Location = ACTION_PRODU_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PRODU]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PRODU]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PRODU]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Produ_Cancel

		//
		// GET: /Produ/Produ_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PRODU]/
		public ActionResult Produ_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Produ model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("produ");

// USE /[MANUAL GQT BEFORE_CANCEL PRODU]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PRODU]/

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

				Navigation.SetValue("ForcePrimaryRead_produ", "true", true);
			}

			Navigation.ClearValue("produ");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Produ_LocatValGlnModel : RequestLookupModel
		{
			public Produ_ViewModel Model { get; set; }
		}

		//
		// GET: /Produ/Produ_LocatValGln
		// POST: /Produ/Produ_LocatValGln
		[ActionName("Produ_LocatValGln")]
		public ActionResult Produ_LocatValGln([FromBody] Produ_LocatValGlnModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_locat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_locat");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Produ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Produ_LocatValGln_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Produ_LcextValGlnextModel : RequestLookupModel
		{
			public Produ_ViewModel Model { get; set; }
		}

		//
		// GET: /Produ/Produ_LcextValGlnext
		// POST: /Produ/Produ_LcextValGlnext
		[ActionName("Produ_LcextValGlnext")]
		public ActionResult Produ_LcextValGlnext([FromBody] Produ_LcextValGlnextModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_lcext")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_lcext");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Produ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Produ_LcextValGlnext_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Produ_ValStockevoModel : RequestLookupModel
		{
			public Produ_ViewModel Model { get; set; }
		}

		//
		// GET: /Produ/Produ_ValStockevo
		// POST: /Produ/Produ_ValStockevo
		[ActionName("Produ_ValStockevo")]
		public ActionResult Produ_ValStockevo([FromBody] Produ_ValStockevoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_stock")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_stock");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Produ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Produ_ValStockevo_ViewModel model = new(m_userContext, parentCtx);

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

		public class Produ_ValInputsreModel : RequestLookupModel
		{
			public Produ_ViewModel Model { get; set; }
		}

		//
		// GET: /Produ/Produ_ValInputsre
		// POST: /Produ/Produ_ValInputsre
		[ActionName("Produ_ValInputsre")]
		public ActionResult Produ_ValInputsre([FromBody] Produ_ValInputsreModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_relin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_relin");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Produ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Produ_ValInputsre_ViewModel model = new(m_userContext, parentCtx);

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

		public class Produ_ValOutputsdModel : RequestLookupModel
		{
			public Produ_ViewModel Model { get; set; }
		}

		//
		// GET: /Produ/Produ_ValOutputsd
		// POST: /Produ/Produ_ValOutputsd
		[ActionName("Produ_ValOutputsd")]
		public ActionResult Produ_ValOutputsd([FromBody] Produ_ValOutputsdModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_dilin")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_dilin");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Produ parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Produ_ValOutputsd_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Produ/Produ_SaveEdit
		[HttpPost]
		public ActionResult Produ_SaveEdit([FromBody] Produ_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Produ_SaveEdit",
				ViewName = "Produ",
				AreaName = "produ",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PRODU]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PRODU]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ProduDocumValidateTickets : RequestDocumValidateTickets
		{
			public Produ_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsProdu([FromBody] ProduDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
