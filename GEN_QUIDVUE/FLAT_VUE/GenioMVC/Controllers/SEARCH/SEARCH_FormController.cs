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
using GenioMVC.ViewModels.Search;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER SEARCH]/

namespace GenioMVC.Controllers
{
	public partial class SearchController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_SEARCH_CANCEL = new("SEARCH25743", "Search_Cancel", "Search") { vueRouteName = "form-SEARCH", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_SEARCH_SHOW = new("SEARCH25743", "Search_Show", "Search") { vueRouteName = "form-SEARCH", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_SEARCH_NEW = new("SEARCH25743", "Search_New", "Search") { vueRouteName = "form-SEARCH", mode = "NEW" };
		private static readonly NavigationLocation ACTION_SEARCH_EDIT = new("SEARCH25743", "Search_Edit", "Search") { vueRouteName = "form-SEARCH", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_SEARCH_DUPLICATE = new("SEARCH25743", "Search_Duplicate", "Search") { vueRouteName = "form-SEARCH", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_SEARCH_DELETE = new("SEARCH25743", "Search_Delete", "Search") { vueRouteName = "form-SEARCH", mode = "DELETE" };

		#endregion

		#region Search private

		private void FormHistoryLimits_Search()
		{

		}

		#endregion

		#region Search_Show

// USE /[MANUAL GQT CONTROLLER_SHOW SEARCH]/

		[HttpPost]
		public ActionResult Search_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Search_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Search_Show_GET",
				AreaName = "search",
				Location = ACTION_SEARCH_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Search();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW SEARCH]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Search_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET SEARCH]/
		[HttpPost]
		public ActionResult Search_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Search_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Search_New_GET",
				AreaName = "search",
				FormName = "SEARCH",
				Location = ACTION_SEARCH_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Search();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW SEARCH]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Search/Search_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST SEARCH]/
		[HttpPost]
		public ActionResult Search_New([FromBody]Search_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Search_New",
				ViewName = "Search",
				AreaName = "search",
				Location = ACTION_SEARCH_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW SEARCH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX SEARCH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX SEARCH]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Search_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET SEARCH]/
		[HttpPost]
		public ActionResult Search_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Search_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Search_Edit_GET",
				AreaName = "search",
				FormName = "SEARCH",
				Location = ACTION_SEARCH_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Search();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT SEARCH]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Search/Search_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST SEARCH]/
		[HttpPost]
		public ActionResult Search_Edit([FromBody]Search_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Search_Edit",
				ViewName = "Search",
				AreaName = "search",
				Location = ACTION_SEARCH_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT SEARCH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX SEARCH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX SEARCH]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Search_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET SEARCH]/
		[HttpPost]
		public ActionResult Search_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Search_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Search_Delete_GET",
				AreaName = "search",
				FormName = "SEARCH",
				Location = ACTION_SEARCH_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Search();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE SEARCH]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Search/Search_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST SEARCH]/
		[HttpPost]
		public ActionResult Search_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Search_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Search_Delete",
				ViewName = "Search",
				AreaName = "search",
				Location = ACTION_SEARCH_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE SEARCH]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Search_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("SEARCH");
		}

		#endregion

		#region Search_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET SEARCH]/

		[HttpPost]
		public ActionResult Search_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Search_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Search_Duplicate_GET",
				AreaName = "search",
				FormName = "SEARCH",
				Location = ACTION_SEARCH_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE SEARCH]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Search/Search_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST SEARCH]/
		[HttpPost]
		public ActionResult Search_Duplicate([FromBody]Search_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Search_Duplicate",
				ViewName = "Search",
				AreaName = "search",
				Location = ACTION_SEARCH_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE SEARCH]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX SEARCH]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX SEARCH]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Search_Cancel

		//
		// GET: /Search/Search_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET SEARCH]/
		public ActionResult Search_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Search model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("search");

// USE /[MANUAL GQT BEFORE_CANCEL SEARCH]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL SEARCH]/

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

				Navigation.SetValue("ForcePrimaryRead_search", "true", true);
			}

			Navigation.ClearValue("search");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Search_CntryValCountryModel : RequestLookupModel
		{
			public Search_ViewModel Model { get; set; }
		}

		//
		// GET: /Search/Search_CntryValCountry
		// POST: /Search/Search_CntryValCountry
		[ActionName("Search_CntryValCountry")]
		public ActionResult Search_CntryValCountry([FromBody] Search_CntryValCountryModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cntry")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cntry");
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

			Models.Search parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Search_CntryValCountry_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Search_RegioValRegiaoModel : RequestLookupModel
		{
			public Search_ViewModel Model { get; set; }
		}

		//
		// GET: /Search/Search_RegioValRegiao
		// POST: /Search/Search_RegioValRegiao
		[ActionName("Search_RegioValRegiao")]
		public ActionResult Search_RegioValRegiao([FromBody] Search_RegioValRegiaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regio");
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

			Models.Search parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Search_RegioValRegiao_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Search_ValRegioesModel : RequestLookupModel
		{
			public Search_ViewModel Model { get; set; }
		}

		//
		// GET: /Search/Search_ValRegioes
		// POST: /Search/Search_ValRegioes
		[ActionName("Search_ValRegioes")]
		public ActionResult Search_ValRegioes([FromBody] Search_ValRegioesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regio")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regio");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Search parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Search_ValRegioes_ViewModel model = new(m_userContext, parentCtx);

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
			// Map received value to field - The 'field' type limit
			model.ValCodpais = Navigation.GetValue<string>("search.codpais");
			// Map received value to field - The 'field' type limit
			model.ValCodregia = Navigation.GetValue<string>("search.codregia");
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Search/Search_SaveEdit
		[HttpPost]
		public ActionResult Search_SaveEdit([FromBody] Search_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Search_SaveEdit",
				ViewName = "Search",
				AreaName = "search",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT SEARCH]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT SEARCH]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class SearchDocumValidateTickets : RequestDocumValidateTickets
		{
			public Search_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsSearch([FromBody] SearchDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
