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
using GenioMVC.ViewModels.Compo;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER COMPO]/

namespace GenioMVC.Controllers
{
	public partial class CompoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_COMPTYPE_CANCEL = new("_COMPO__COMPTYPE_37230", "Comptype_Cancel", "Compo") { vueRouteName = "form-COMPTYPE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_COMPTYPE_SHOW = new("_COMPO__COMPTYPE_37230", "Comptype_Show", "Compo") { vueRouteName = "form-COMPTYPE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_COMPTYPE_NEW = new("_COMPO__COMPTYPE_37230", "Comptype_New", "Compo") { vueRouteName = "form-COMPTYPE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_COMPTYPE_EDIT = new("_COMPO__COMPTYPE_37230", "Comptype_Edit", "Compo") { vueRouteName = "form-COMPTYPE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_COMPTYPE_DUPLICATE = new("_COMPO__COMPTYPE_37230", "Comptype_Duplicate", "Compo") { vueRouteName = "form-COMPTYPE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_COMPTYPE_DELETE = new("_COMPO__COMPTYPE_37230", "Comptype_Delete", "Compo") { vueRouteName = "form-COMPTYPE", mode = "DELETE" };

		#endregion

		#region Comptype private

		private void FormHistoryLimits_Comptype()
		{

		}

		#endregion

		#region Comptype_Show

// USE /[MANUAL GQT CONTROLLER_SHOW COMPTYPE]/

		[HttpPost]
		public ActionResult Comptype_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comptype_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Show_GET",
				AreaName = "compo",
				Location = ACTION_COMPTYPE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comptype();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW COMPTYPE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Comptype_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Comptype_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comptype_New_GET",
				AreaName = "compo",
				FormName = "COMPTYPE",
				Location = ACTION_COMPTYPE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Comptype();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW COMPTYPE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Compo/Comptype_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_New([FromBody]Comptype_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comptype_New",
				ViewName = "Comptype",
				AreaName = "compo",
				Location = ACTION_COMPTYPE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW COMPTYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX COMPTYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX COMPTYPE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Comptype_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comptype_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Edit_GET",
				AreaName = "compo",
				FormName = "COMPTYPE",
				Location = ACTION_COMPTYPE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comptype();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT COMPTYPE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Compo/Comptype_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_Edit([FromBody]Comptype_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Edit",
				ViewName = "Comptype",
				AreaName = "compo",
				Location = ACTION_COMPTYPE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT COMPTYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX COMPTYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX COMPTYPE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Comptype_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comptype_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Delete_GET",
				AreaName = "compo",
				FormName = "COMPTYPE",
				Location = ACTION_COMPTYPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Comptype();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE COMPTYPE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Compo/Comptype_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Comptype_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Comptype_Delete",
				ViewName = "Comptype",
				AreaName = "compo",
				Location = ACTION_COMPTYPE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE COMPTYPE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Comptype_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("COMPTYPE");
		}

		#endregion

		#region Comptype_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET COMPTYPE]/

		[HttpPost]
		public ActionResult Comptype_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Comptype_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Duplicate_GET",
				AreaName = "compo",
				FormName = "COMPTYPE",
				Location = ACTION_COMPTYPE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE COMPTYPE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Compo/Comptype_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST COMPTYPE]/
		[HttpPost]
		public ActionResult Comptype_Duplicate([FromBody]Comptype_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comptype_Duplicate",
				ViewName = "Comptype",
				AreaName = "compo",
				Location = ACTION_COMPTYPE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE COMPTYPE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX COMPTYPE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX COMPTYPE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Comptype_Cancel

		//
		// GET: /Compo/Comptype_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET COMPTYPE]/
		public ActionResult Comptype_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Compo model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("compo");

// USE /[MANUAL GQT BEFORE_CANCEL COMPTYPE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL COMPTYPE]/

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

				Navigation.SetValue("ForcePrimaryRead_compo", "true", true);
			}

			Navigation.ClearValue("compo");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Comptab_CompcValCompclasModel : RequestLookupModel
		{
			public Comptype_ViewModel Model { get; set; }
		}

		//
		// GET: /Compo/Comptab_CompcValCompclas
		// POST: /Compo/Comptab_CompcValCompclas
		[ActionName("Comptab_CompcValCompclas")]
		public ActionResult Comptab_CompcValCompclas([FromBody] Comptab_CompcValCompclasModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_compc")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_compc");
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

			Models.Compo parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Comptab_CompcValCompclas_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Comptab_ValBehaviorModel : RequestLookupModel
		{
			public Comptype_ViewModel Model { get; set; }
		}

		//
		// GET: /Compo/Comptab_ValBehavior
		// POST: /Compo/Comptab_ValBehavior
		[ActionName("Comptab_ValBehavior")]
		public ActionResult Comptab_ValBehavior([FromBody] Comptab_ValBehaviorModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_compb")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_compb");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Compo parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Comptab_ValBehavior_ViewModel model = new(m_userContext, parentCtx);

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

		public class Tab_ValVariantsModel : RequestLookupModel
		{
			public Comptype_ViewModel Model { get; set; }
		}

		//
		// GET: /Compo/Tab_ValVariants
		// POST: /Compo/Tab_ValVariants
		[ActionName("Tab_ValVariants")]
		public ActionResult Tab_ValVariants([FromBody] Tab_ValVariantsModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_compv")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_compv");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Compo parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tab_ValVariants_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Compo/Comptype_SaveEdit
		[HttpPost]
		public ActionResult Comptype_SaveEdit([FromBody] Comptype_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Comptype_SaveEdit",
				ViewName = "Comptype",
				AreaName = "compo",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT COMPTYPE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT COMPTYPE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ComptypeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Comptype_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsComptype([FromBody] ComptypeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
