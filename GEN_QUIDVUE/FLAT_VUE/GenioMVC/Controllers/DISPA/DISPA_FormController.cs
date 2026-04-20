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
using GenioMVC.ViewModels.Dispa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER DISPA]/

namespace GenioMVC.Controllers
{
	public partial class DispaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_DISPA_CANCEL = new("DISPATCH46310", "Dispa_Cancel", "Dispa") { vueRouteName = "form-DISPA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_DISPA_SHOW = new("DISPATCH46310", "Dispa_Show", "Dispa") { vueRouteName = "form-DISPA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_DISPA_NEW = new("DISPATCH46310", "Dispa_New", "Dispa") { vueRouteName = "form-DISPA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_DISPA_EDIT = new("DISPATCH46310", "Dispa_Edit", "Dispa") { vueRouteName = "form-DISPA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_DISPA_DUPLICATE = new("DISPATCH46310", "Dispa_Duplicate", "Dispa") { vueRouteName = "form-DISPA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_DISPA_DELETE = new("DISPATCH46310", "Dispa_Delete", "Dispa") { vueRouteName = "form-DISPA", mode = "DELETE" };

		#endregion

		#region Dispa private

		private void FormHistoryLimits_Dispa()
		{

		}

		#endregion

		#region Dispa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW DISPA]/

		[HttpPost]
		public ActionResult Dispa_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dispa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Show_GET",
				AreaName = "dispa",
				Location = ACTION_DISPA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW DISPA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Dispa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Dispa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dispa_New_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW DISPA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Dispa/Dispa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_New([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dispa_New",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX DISPA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Dispa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dispa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Edit_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT DISPA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Edit([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Edit",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX DISPA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Dispa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dispa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Delete_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Dispa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE DISPA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Dispa/Dispa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Dispa_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Dispa_Delete",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE DISPA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Dispa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("DISPA");
		}

		#endregion

		#region Dispa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET DISPA]/

		[HttpPost]
		public ActionResult Dispa_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Dispa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Duplicate_GET",
				AreaName = "dispa",
				FormName = "DISPA",
				Location = ACTION_DISPA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE DISPA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Dispa/Dispa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST DISPA]/
		[HttpPost]
		public ActionResult Dispa_Duplicate([FromBody]Dispa_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dispa_Duplicate",
				ViewName = "Dispa",
				AreaName = "dispa",
				Location = ACTION_DISPA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE DISPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX DISPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX DISPA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Dispa_Cancel

		//
		// GET: /Dispa/Dispa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET DISPA]/
		public ActionResult Dispa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("dispa");
					var model = GenioMVC.Models.Dispa.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("dispa");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL DISPA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL DISPA]/

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

				Navigation.SetValue("ForcePrimaryRead_dispa", "true", true);
			}

			Navigation.ClearValue("dispa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Dispa_EntitValNameModel : RequestLookupModel
		{
			public Dispa_ViewModel Model { get; set; }
		}

		//
		// GET: /Dispa/Dispa_EntitValName
		// POST: /Dispa/Dispa_EntitValName
		[ActionName("Dispa_EntitValName")]
		public ActionResult Dispa_EntitValName([FromBody] Dispa_EntitValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_entit")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_entit");
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

			Models.Dispa parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Dispa_EntitValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Dispa_PersoValNameModel : RequestLookupModel
		{
			public Dispa_ViewModel Model { get; set; }
		}

		//
		// GET: /Dispa/Dispa_PersoValName
		// POST: /Dispa/Dispa_PersoValName
		[ActionName("Dispa_PersoValName")]
		public ActionResult Dispa_PersoValName([FromBody] Dispa_PersoValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_perso")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_perso");
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

			Models.Dispa parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Dispa_PersoValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Dispa_ValDispatchModel : RequestLookupModel
		{
			public Dispa_ViewModel Model { get; set; }
		}

		//
		// GET: /Dispa/Dispa_ValDispatch
		// POST: /Dispa/Dispa_ValDispatch
		[ActionName("Dispa_ValDispatch")]
		public ActionResult Dispa_ValDispatch([FromBody] Dispa_ValDispatchModel requestModel)
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

			Models.Dispa parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Dispa_ValDispatch_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Dispa/Dispa_SaveEdit
		[HttpPost]
		public ActionResult Dispa_SaveEdit([FromBody] Dispa_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Dispa_SaveEdit",
				ViewName = "Dispa",
				AreaName = "dispa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT DISPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT DISPA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class DispaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Dispa_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsDispa([FromBody] DispaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
