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
using GenioMVC.ViewModels.Operacoes;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER OPERACOES]/

namespace GenioMVC.Controllers
{
	public partial class OperacoesController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_OPERACOES_CANCEL = new("OPERACOES07850", "Operacoes_Cancel", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_OPERACOES_SHOW = new("OPERACOES07850", "Operacoes_Show", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_OPERACOES_NEW = new("OPERACOES07850", "Operacoes_New", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "NEW" };
		private static readonly NavigationLocation ACTION_OPERACOES_EDIT = new("OPERACOES07850", "Operacoes_Edit", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_OPERACOES_DUPLICATE = new("OPERACOES07850", "Operacoes_Duplicate", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_OPERACOES_DELETE = new("OPERACOES07850", "Operacoes_Delete", "Operacoes") { vueRouteName = "form-OPERACOES", mode = "DELETE" };

		#endregion

		#region Operacoes private

		private void FormHistoryLimits_Operacoes()
		{

		}

		#endregion

		#region Operacoes_Show

// USE /[MANUAL GQT CONTROLLER_SHOW OPERACOES]/

		[HttpPost]
		public ActionResult Operacoes_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Operacoes_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Show_GET",
				AreaName = "operacoes",
				Location = ACTION_OPERACOES_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Operacoes();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW OPERACOES]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Operacoes_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Operacoes_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_New_GET",
				AreaName = "operacoes",
				FormName = "OPERACOES",
				Location = ACTION_OPERACOES_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Operacoes();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW OPERACOES]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Operacoes/Operacoes_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_New([FromBody]Operacoes_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_New",
				ViewName = "Operacoes",
				AreaName = "operacoes",
				Location = ACTION_OPERACOES_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW OPERACOES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX OPERACOES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX OPERACOES]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Operacoes_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Operacoes_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Edit_GET",
				AreaName = "operacoes",
				FormName = "OPERACOES",
				Location = ACTION_OPERACOES_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Operacoes();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT OPERACOES]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Operacoes/Operacoes_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_Edit([FromBody]Operacoes_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Edit",
				ViewName = "Operacoes",
				AreaName = "operacoes",
				Location = ACTION_OPERACOES_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT OPERACOES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX OPERACOES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX OPERACOES]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Operacoes_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Operacoes_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Delete_GET",
				AreaName = "operacoes",
				FormName = "OPERACOES",
				Location = ACTION_OPERACOES_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Operacoes();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE OPERACOES]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Operacoes/Operacoes_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Operacoes_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Delete",
				ViewName = "Operacoes",
				AreaName = "operacoes",
				Location = ACTION_OPERACOES_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE OPERACOES]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Operacoes_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("OPERACOES");
		}

		#endregion

		#region Operacoes_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET OPERACOES]/

		[HttpPost]
		public ActionResult Operacoes_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Operacoes_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Duplicate_GET",
				AreaName = "operacoes",
				FormName = "OPERACOES",
				Location = ACTION_OPERACOES_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE OPERACOES]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Operacoes/Operacoes_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST OPERACOES]/
		[HttpPost]
		public ActionResult Operacoes_Duplicate([FromBody]Operacoes_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_Duplicate",
				ViewName = "Operacoes",
				AreaName = "operacoes",
				Location = ACTION_OPERACOES_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE OPERACOES]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX OPERACOES]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX OPERACOES]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Operacoes_Cancel

		//
		// GET: /Operacoes/Operacoes_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET OPERACOES]/
		public ActionResult Operacoes_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Operacoes model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("operacoes");

// USE /[MANUAL GQT BEFORE_CANCEL OPERACOES]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL OPERACOES]/

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

				Navigation.SetValue("ForcePrimaryRead_operacoes", "true", true);
			}

			Navigation.ClearValue("operacoes");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Operacoes_EntidadeValEntidadeModel : RequestLookupModel
		{
			public Operacoes_ViewModel Model { get; set; }
		}

		//
		// GET: /Operacoes/Operacoes_EntidadeValEntidade
		// POST: /Operacoes/Operacoes_EntidadeValEntidade
		[ActionName("Operacoes_EntidadeValEntidade")]
		public ActionResult Operacoes_EntidadeValEntidade([FromBody] Operacoes_EntidadeValEntidadeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entidade")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entidade");
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

			Models.Operacoes parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Operacoes_EntidadeValEntidade_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Operacoes/Operacoes_SaveEdit
		[HttpPost]
		public ActionResult Operacoes_SaveEdit([FromBody] Operacoes_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Operacoes_SaveEdit",
				ViewName = "Operacoes",
				AreaName = "operacoes",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT OPERACOES]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT OPERACOES]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class OperacoesDocumValidateTickets : RequestDocumValidateTickets
		{
			public Operacoes_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsOperacoes([FromBody] OperacoesDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
