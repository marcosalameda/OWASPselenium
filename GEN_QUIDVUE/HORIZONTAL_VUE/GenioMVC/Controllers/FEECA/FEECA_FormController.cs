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
using GenioMVC.ViewModels.Feeca;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER FEECA]/

namespace GenioMVC.Controllers
{
	public partial class FeecaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_FEECA_CANCEL = new("FEEDBACK_CAMPO42437", "Feeca_Cancel", "Feeca") { vueRouteName = "form-FEECA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_FEECA_SHOW = new("FEEDBACK_CAMPO42437", "Feeca_Show", "Feeca") { vueRouteName = "form-FEECA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_FEECA_NEW = new("FEEDBACK_CAMPO42437", "Feeca_New", "Feeca") { vueRouteName = "form-FEECA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_FEECA_EDIT = new("FEEDBACK_CAMPO42437", "Feeca_Edit", "Feeca") { vueRouteName = "form-FEECA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_FEECA_DUPLICATE = new("FEEDBACK_CAMPO42437", "Feeca_Duplicate", "Feeca") { vueRouteName = "form-FEECA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_FEECA_DELETE = new("FEEDBACK_CAMPO42437", "Feeca_Delete", "Feeca") { vueRouteName = "form-FEECA", mode = "DELETE" };

		#endregion

		#region Feeca private

		private void FormHistoryLimits_Feeca()
		{

		}

		#endregion

		#region Feeca_Show

// USE /[MANUAL GQT CONTROLLER_SHOW FEECA]/

		[HttpPost]
		public ActionResult Feeca_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Feeca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Show_GET",
				AreaName = "feeca",
				Location = ACTION_FEECA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Feeca();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW FEECA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Feeca_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET FEECA]/
		[HttpPost]
		public ActionResult Feeca_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Feeca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Feeca_New_GET",
				AreaName = "feeca",
				FormName = "FEECA",
				Location = ACTION_FEECA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Feeca();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW FEECA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Feeca/Feeca_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST FEECA]/
		[HttpPost]
		public ActionResult Feeca_New([FromBody]Feeca_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Feeca_New",
				ViewName = "Feeca",
				AreaName = "feeca",
				Location = ACTION_FEECA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW FEECA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX FEECA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX FEECA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Feeca_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET FEECA]/
		[HttpPost]
		public ActionResult Feeca_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Feeca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Edit_GET",
				AreaName = "feeca",
				FormName = "FEECA",
				Location = ACTION_FEECA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Feeca();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT FEECA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Feeca/Feeca_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST FEECA]/
		[HttpPost]
		public ActionResult Feeca_Edit([FromBody]Feeca_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Edit",
				ViewName = "Feeca",
				AreaName = "feeca",
				Location = ACTION_FEECA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT FEECA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX FEECA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX FEECA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Feeca_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET FEECA]/
		[HttpPost]
		public ActionResult Feeca_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Feeca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Delete_GET",
				AreaName = "feeca",
				FormName = "FEECA",
				Location = ACTION_FEECA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Feeca();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE FEECA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Feeca/Feeca_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST FEECA]/
		[HttpPost]
		public ActionResult Feeca_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Feeca_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Feeca_Delete",
				ViewName = "Feeca",
				AreaName = "feeca",
				Location = ACTION_FEECA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE FEECA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Feeca_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("FEECA");
		}

		#endregion

		#region Feeca_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET FEECA]/

		[HttpPost]
		public ActionResult Feeca_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Feeca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Duplicate_GET",
				AreaName = "feeca",
				FormName = "FEECA",
				Location = ACTION_FEECA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE FEECA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Feeca/Feeca_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST FEECA]/
		[HttpPost]
		public ActionResult Feeca_Duplicate([FromBody]Feeca_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Feeca_Duplicate",
				ViewName = "Feeca",
				AreaName = "feeca",
				Location = ACTION_FEECA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE FEECA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX FEECA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX FEECA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Feeca_Cancel

		//
		// GET: /Feeca/Feeca_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET FEECA]/
		public ActionResult Feeca_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("feeca");
					var model = GenioMVC.Models.Feeca.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("feeca");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL FEECA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL FEECA]/

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

				Navigation.SetValue("ForcePrimaryRead_feeca", "true", true);
			}

			Navigation.ClearValue("feeca");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Feeca_FldsValDescripModel : RequestLookupModel
		{
			public Feeca_ViewModel Model { get; set; }
		}

		//
		// GET: /Feeca/Feeca_FldsValDescrip
		// POST: /Feeca/Feeca_FldsValDescrip
		[ActionName("Feeca_FldsValDescrip")]
		public ActionResult Feeca_FldsValDescrip([FromBody] Feeca_FldsValDescripModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_flds")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_flds");
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

			Models.Feeca parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Feeca_FldsValDescrip_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Feeca/Feeca_SaveEdit
		[HttpPost]
		public ActionResult Feeca_SaveEdit([FromBody] Feeca_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Feeca_SaveEdit",
				ViewName = "Feeca",
				AreaName = "feeca",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT FEECA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT FEECA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class FeecaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Feeca_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsFeeca([FromBody] FeecaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
