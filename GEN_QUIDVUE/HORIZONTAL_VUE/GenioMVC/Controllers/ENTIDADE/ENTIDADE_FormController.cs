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
using GenioMVC.ViewModels.Entidade;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ENTIDADE]/

namespace GenioMVC.Controllers
{
	public partial class EntidadeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ENTIDADE_CANCEL = new("ENTIDADE36471", "Entidade_Cancel", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ENTIDADE_SHOW = new("ENTIDADE36471", "Entidade_Show", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ENTIDADE_NEW = new("ENTIDADE36471", "Entidade_New", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ENTIDADE_EDIT = new("ENTIDADE36471", "Entidade_Edit", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ENTIDADE_DUPLICATE = new("ENTIDADE36471", "Entidade_Duplicate", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ENTIDADE_DELETE = new("ENTIDADE36471", "Entidade_Delete", "Entidade") { vueRouteName = "form-ENTIDADE", mode = "DELETE" };

		#endregion

		#region Entidade private

		private void FormHistoryLimits_Entidade()
		{

		}

		#endregion

		#region Entidade_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ENTIDADE]/

		[HttpPost]
		public ActionResult Entidade_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Entidade_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Show_GET",
				AreaName = "entidade",
				Location = ACTION_ENTIDADE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entidade();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ENTIDADE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Entidade_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Entidade_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Entidade_New_GET",
				AreaName = "entidade",
				FormName = "ENTIDADE",
				Location = ACTION_ENTIDADE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Entidade();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ENTIDADE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Entidade/Entidade_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_New([FromBody]Entidade_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Entidade_New",
				ViewName = "Entidade",
				AreaName = "entidade",
				Location = ACTION_ENTIDADE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ENTIDADE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ENTIDADE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ENTIDADE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Entidade_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Entidade_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Edit_GET",
				AreaName = "entidade",
				FormName = "ENTIDADE",
				Location = ACTION_ENTIDADE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entidade();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ENTIDADE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Entidade/Entidade_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_Edit([FromBody]Entidade_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Edit",
				ViewName = "Entidade",
				AreaName = "entidade",
				Location = ACTION_ENTIDADE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ENTIDADE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ENTIDADE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ENTIDADE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Entidade_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Entidade_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Delete_GET",
				AreaName = "entidade",
				FormName = "ENTIDADE",
				Location = ACTION_ENTIDADE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Entidade();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ENTIDADE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Entidade/Entidade_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Entidade_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Entidade_Delete",
				ViewName = "Entidade",
				AreaName = "entidade",
				Location = ACTION_ENTIDADE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ENTIDADE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Entidade_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ENTIDADE");
		}

		#endregion

		#region Entidade_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ENTIDADE]/

		[HttpPost]
		public ActionResult Entidade_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Entidade_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Duplicate_GET",
				AreaName = "entidade",
				FormName = "ENTIDADE",
				Location = ACTION_ENTIDADE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ENTIDADE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Entidade/Entidade_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ENTIDADE]/
		[HttpPost]
		public ActionResult Entidade_Duplicate([FromBody]Entidade_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Entidade_Duplicate",
				ViewName = "Entidade",
				AreaName = "entidade",
				Location = ACTION_ENTIDADE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ENTIDADE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ENTIDADE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ENTIDADE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Entidade_Cancel

		//
		// GET: /Entidade/Entidade_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ENTIDADE]/
		public ActionResult Entidade_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Entidade model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("entidade");

// USE /[MANUAL GQT BEFORE_CANCEL ENTIDADE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ENTIDADE]/

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

				Navigation.SetValue("ForcePrimaryRead_entidade", "true", true);
			}

			Navigation.ClearValue("entidade");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Entidade_ConcelhoValNomeModel : RequestLookupModel
		{
			public Entidade_ViewModel Model { get; set; }
		}

		//
		// GET: /Entidade/Entidade_ConcelhoValNome
		// POST: /Entidade/Entidade_ConcelhoValNome
		[ActionName("Entidade_ConcelhoValNome")]
		public ActionResult Entidade_ConcelhoValNome([FromBody] Entidade_ConcelhoValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_concelho")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_concelho");
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

			Models.Entidade parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Entidade_ConcelhoValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Entidade_ValOperacoesModel : RequestLookupModel
		{
			public Entidade_ViewModel Model { get; set; }
		}

		//
		// GET: /Entidade/Entidade_ValOperacoes
		// POST: /Entidade/Entidade_ValOperacoes
		[ActionName("Entidade_ValOperacoes")]
		public ActionResult Entidade_ValOperacoes([FromBody] Entidade_ValOperacoesModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_operacoes")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_operacoes");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Entidade parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Entidade_ValOperacoes_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Entidade/Entidade_SaveEdit
		[HttpPost]
		public ActionResult Entidade_SaveEdit([FromBody] Entidade_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Entidade_SaveEdit",
				ViewName = "Entidade",
				AreaName = "entidade",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ENTIDADE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ENTIDADE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class EntidadeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Entidade_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsEntidade([FromBody] EntidadeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
