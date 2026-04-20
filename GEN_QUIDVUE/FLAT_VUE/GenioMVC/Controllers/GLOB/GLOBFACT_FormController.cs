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
using GenioMVC.ViewModels.Glob;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER GLOB]/

namespace GenioMVC.Controllers
{
	public partial class GlobController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_GLOBFACT_CANCEL = new("GLOBAL_PARAMETER43021", "Globfact_Cancel", "Glob") { vueRouteName = "form-GLOBFACT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_GLOBFACT_SHOW = new("GLOBAL_PARAMETER43021", "Globfact_Show", "Glob") { vueRouteName = "form-GLOBFACT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_GLOBFACT_NEW = new("GLOBAL_PARAMETER43021", "Globfact_New", "Glob") { vueRouteName = "form-GLOBFACT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_GLOBFACT_EDIT = new("GLOBAL_PARAMETER43021", "Globfact_Edit", "Glob") { vueRouteName = "form-GLOBFACT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_GLOBFACT_DUPLICATE = new("GLOBAL_PARAMETER43021", "Globfact_Duplicate", "Glob") { vueRouteName = "form-GLOBFACT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_GLOBFACT_DELETE = new("GLOBAL_PARAMETER43021", "Globfact_Delete", "Glob") { vueRouteName = "form-GLOBFACT", mode = "DELETE" };

		#endregion

		#region Globfact private

		private void FormHistoryLimits_Globfact()
		{

		}

		#endregion

		#region Globfact_Show

// USE /[MANUAL GQT CONTROLLER_SHOW GLOBFACT]/

		[HttpPost]
		public ActionResult Globfact_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Globfact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Show_GET",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW GLOBFACT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Globfact_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Globfact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Globfact_New_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW GLOBFACT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Glob/Globfact_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_New([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Globfact_New",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Globfact_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Globfact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Edit_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT GLOBFACT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Glob/Globfact_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Edit([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Edit",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Globfact_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Globfact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Delete_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Globfact();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE GLOBFACT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Glob/Globfact_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Globfact_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Globfact_Delete",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE GLOBFACT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Globfact_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("GLOBFACT");
		}

		#endregion

		#region Globfact_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET GLOBFACT]/

		[HttpPost]
		public ActionResult Globfact_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Globfact_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Duplicate_GET",
				AreaName = "glob",
				FormName = "GLOBFACT",
				Location = ACTION_GLOBFACT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE GLOBFACT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Glob/Globfact_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST GLOBFACT]/
		[HttpPost]
		public ActionResult Globfact_Duplicate([FromBody]Globfact_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Globfact_Duplicate",
				ViewName = "Globfact",
				AreaName = "glob",
				Location = ACTION_GLOBFACT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE GLOBFACT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX GLOBFACT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX GLOBFACT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Globfact_Cancel

		//
		// GET: /Glob/Globfact_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET GLOBFACT]/
		public ActionResult Globfact_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("glob");
					var model = GenioMVC.Models.Glob.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("glob");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL GLOBFACT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL GLOBFACT]/

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

				Navigation.SetValue("ForcePrimaryRead_glob", "true", true);
			}

			Navigation.ClearValue("glob");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Globfact_FactyValTypeModel : RequestLookupModel
		{
			public Globfact_ViewModel Model { get; set; }
		}

		//
		// GET: /Glob/Globfact_FactyValType
		// POST: /Glob/Globfact_FactyValType
		[ActionName("Globfact_FactyValType")]
		public ActionResult Globfact_FactyValType([FromBody] Globfact_FactyValTypeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_facty")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_facty");
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

			Models.Glob parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Globfact_FactyValType_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Glob/Globfact_SaveEdit
		[HttpPost]
		public ActionResult Globfact_SaveEdit([FromBody] Globfact_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Globfact_SaveEdit",
				ViewName = "Globfact",
				AreaName = "glob",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT GLOBFACT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT GLOBFACT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class GlobfactDocumValidateTickets : RequestDocumValidateTickets
		{
			public Globfact_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsGlobfact([FromBody] GlobfactDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
