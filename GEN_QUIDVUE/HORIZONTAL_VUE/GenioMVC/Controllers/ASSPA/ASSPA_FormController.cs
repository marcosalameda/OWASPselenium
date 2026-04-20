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
using GenioMVC.ViewModels.Asspa;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ASSPA]/

namespace GenioMVC.Controllers
{
	public partial class AsspaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ASSPA_CANCEL = new("ASSET_PARAMETER22072", "Asspa_Cancel", "Asspa") { vueRouteName = "form-ASSPA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ASSPA_SHOW = new("ASSET_PARAMETER22072", "Asspa_Show", "Asspa") { vueRouteName = "form-ASSPA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ASSPA_NEW = new("ASSET_PARAMETER22072", "Asspa_New", "Asspa") { vueRouteName = "form-ASSPA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ASSPA_EDIT = new("ASSET_PARAMETER22072", "Asspa_Edit", "Asspa") { vueRouteName = "form-ASSPA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ASSPA_DUPLICATE = new("ASSET_PARAMETER22072", "Asspa_Duplicate", "Asspa") { vueRouteName = "form-ASSPA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ASSPA_DELETE = new("ASSET_PARAMETER22072", "Asspa_Delete", "Asspa") { vueRouteName = "form-ASSPA", mode = "DELETE" };

		#endregion

		#region Asspa private

		private void FormHistoryLimits_Asspa()
		{

		}

		#endregion

		#region Asspa_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ASSPA]/

		[HttpPost]
		public ActionResult Asspa_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asspa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Show_GET",
				AreaName = "asspa",
				Location = ACTION_ASSPA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ASSPA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Asspa_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Asspa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asspa_New_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ASSPA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Asspa/Asspa_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_New([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asspa_New",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ASSPA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Asspa_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asspa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Edit_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ASSPA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Asspa/Asspa_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Edit([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Edit",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ASSPA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Asspa_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asspa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Delete_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Asspa();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ASSPA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Asspa/Asspa_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Asspa_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Asspa_Delete",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ASSPA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Asspa_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ASSPA");
		}

		#endregion

		#region Asspa_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ASSPA]/

		[HttpPost]
		public ActionResult Asspa_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Asspa_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Duplicate_GET",
				AreaName = "asspa",
				FormName = "ASSPA",
				Location = ACTION_ASSPA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ASSPA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Asspa/Asspa_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ASSPA]/
		[HttpPost]
		public ActionResult Asspa_Duplicate([FromBody]Asspa_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asspa_Duplicate",
				ViewName = "Asspa",
				AreaName = "asspa",
				Location = ACTION_ASSPA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ASSPA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ASSPA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ASSPA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Asspa_Cancel

		//
		// GET: /Asspa/Asspa_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ASSPA]/
		public ActionResult Asspa_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("asspa");
					var model = GenioMVC.Models.Asspa.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("asspa");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL ASSPA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ASSPA]/

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

				Navigation.SetValue("ForcePrimaryRead_asspa", "true", true);
			}

			Navigation.ClearValue("asspa");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Asspa_AssetValNameModel : RequestLookupModel
		{
			public Asspa_ViewModel Model { get; set; }
		}

		//
		// GET: /Asspa/Asspa_AssetValName
		// POST: /Asspa/Asspa_AssetValName
		[ActionName("Asspa_AssetValName")]
		public ActionResult Asspa_AssetValName([FromBody] Asspa_AssetValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_asset")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_asset");
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

			Models.Asspa parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Asspa_AssetValName_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Asspa_ParamValParameterModel : RequestLookupModel
		{
			public Asspa_ViewModel Model { get; set; }
		}

		//
		// GET: /Asspa/Asspa_ParamValParameter
		// POST: /Asspa/Asspa_ParamValParameter
		[ActionName("Asspa_ParamValParameter")]
		public ActionResult Asspa_ParamValParameter([FromBody] Asspa_ParamValParameterModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_param")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_param");
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

			Models.Asspa parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Asspa_ParamValParameter_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Asspa/Asspa_SaveEdit
		[HttpPost]
		public ActionResult Asspa_SaveEdit([FromBody] Asspa_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Asspa_SaveEdit",
				ViewName = "Asspa",
				AreaName = "asspa",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ASSPA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ASSPA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class AsspaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Asspa_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsAsspa([FromBody] AsspaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
