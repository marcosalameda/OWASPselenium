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
using GenioMVC.ViewModels.Pesso;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER PESSO]/

namespace GenioMVC.Controllers
{
	public partial class PessoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PESSO1_CANCEL = new("PERSON10446", "Pesso1_Cancel", "Pesso") { vueRouteName = "form-PESSO1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PESSO1_SHOW = new("PERSON10446", "Pesso1_Show", "Pesso") { vueRouteName = "form-PESSO1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PESSO1_NEW = new("PERSON10446", "Pesso1_New", "Pesso") { vueRouteName = "form-PESSO1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PESSO1_EDIT = new("PERSON10446", "Pesso1_Edit", "Pesso") { vueRouteName = "form-PESSO1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PESSO1_DUPLICATE = new("PERSON10446", "Pesso1_Duplicate", "Pesso") { vueRouteName = "form-PESSO1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PESSO1_DELETE = new("PERSON10446", "Pesso1_Delete", "Pesso") { vueRouteName = "form-PESSO1", mode = "DELETE" };

		#endregion

		#region Pesso1 private

		private void FormHistoryLimits_Pesso1()
		{

		}

		#endregion

		#region Pesso1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW PESSO1]/

		[HttpPost]
		public ActionResult Pesso1_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pesso1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Show_GET",
				AreaName = "pesso",
				Location = ACTION_PESSO1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW PESSO1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Pesso1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Pesso1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_New_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW PESSO1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Pesso/Pesso1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_New([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_New",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX PESSO1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Pesso1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pesso1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Edit_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT PESSO1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Edit([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Edit",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX PESSO1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Pesso1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pesso1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Delete_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Pesso1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE PESSO1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Pesso/Pesso1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Pesso1_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Delete",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE PESSO1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Pesso1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PESSO1");
		}

		#endregion

		#region Pesso1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET PESSO1]/

		[HttpPost]
		public ActionResult Pesso1_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Pesso1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Duplicate_GET",
				AreaName = "pesso",
				FormName = "PESSO1",
				Location = ACTION_PESSO1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE PESSO1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Pesso/Pesso1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST PESSO1]/
		[HttpPost]
		public ActionResult Pesso1_Duplicate([FromBody]Pesso1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_Duplicate",
				ViewName = "Pesso1",
				AreaName = "pesso",
				Location = ACTION_PESSO1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE PESSO1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX PESSO1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX PESSO1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Pesso1_Cancel

		//
		// GET: /Pesso/Pesso1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET PESSO1]/
		public ActionResult Pesso1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("pesso");
					var model = GenioMVC.Models.Pesso.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("pesso");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL PESSO1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL PESSO1]/

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

				Navigation.SetValue("ForcePrimaryRead_pesso", "true", true);
			}

			Navigation.ClearValue("pesso");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Pesso1_CategValCategoriaModel : RequestLookupModel
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pesso1_CategValCategoria
		// POST: /Pesso/Pesso1_CategValCategoria
		[ActionName("Pesso1_CategValCategoria")]
		public ActionResult Pesso1_CategValCategoria([FromBody] Pesso1_CategValCategoriaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_categ")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_categ");
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

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pesso1_CategValCategoria_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Pesso1_ValContactoModel : RequestLookupModel
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pesso1_ValContacto
		// POST: /Pesso/Pesso1_ValContacto
		[ActionName("Pesso1_ValContacto")]
		public ActionResult Pesso1_ValContacto([FromBody] Pesso1_ValContactoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_conta")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_conta");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pesso1_ValContacto_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Pesso1_CmpnyValDesignatModel : RequestLookupModel
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pesso1_CmpnyValDesignat
		// POST: /Pesso/Pesso1_CmpnyValDesignat
		[ActionName("Pesso1_CmpnyValDesignat")]
		public ActionResult Pesso1_CmpnyValDesignat([FromBody] Pesso1_CmpnyValDesignatModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_cmpny")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_cmpny");
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

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pesso1_CmpnyValDesignat_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Pesso1_ValEvolucaoModel : RequestLookupModel
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pesso1_ValEvolucao
		// POST: /Pesso/Pesso1_ValEvolucao
		[ActionName("Pesso1_ValEvolucao")]
		public ActionResult Pesso1_ValEvolucao([FromBody] Pesso1_ValEvolucaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_evcat")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_evcat");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pesso1_ValEvolucao_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Pesso1_Regi1ValRegiaoModel : RequestLookupModel
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		//
		// GET: /Pesso/Pesso1_Regi1ValRegiao
		// POST: /Pesso/Pesso1_Regi1ValRegiao
		[ActionName("Pesso1_Regi1ValRegiao")]
		public ActionResult Pesso1_Regi1ValRegiao([FromBody] Pesso1_Regi1ValRegiaoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_regi1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_regi1");
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

			Models.Pesso parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Pesso1_Regi1ValRegiao_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Pesso/Pesso1_SaveEdit
		[HttpPost]
		public ActionResult Pesso1_SaveEdit([FromBody] Pesso1_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Pesso1_SaveEdit",
				ViewName = "Pesso1",
				AreaName = "pesso",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT PESSO1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT PESSO1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Pesso1DocumValidateTickets : RequestDocumValidateTickets
		{
			public Pesso1_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPesso1([FromBody] Pesso1DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
