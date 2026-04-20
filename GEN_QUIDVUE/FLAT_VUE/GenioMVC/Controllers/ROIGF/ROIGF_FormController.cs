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
using GenioMVC.ViewModels.Roigf;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGF]/

namespace GenioMVC.Controllers
{
	public partial class RoigfController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROIGF_CANCEL = new("ORDER_IN_GROUP__FLOA51083", "Roigf_Cancel", "Roigf") { vueRouteName = "form-ROIGF", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROIGF_SHOW = new("ORDER_IN_GROUP__FLOA51083", "Roigf_Show", "Roigf") { vueRouteName = "form-ROIGF", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROIGF_NEW = new("ORDER_IN_GROUP__FLOA51083", "Roigf_New", "Roigf") { vueRouteName = "form-ROIGF", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROIGF_EDIT = new("ORDER_IN_GROUP__FLOA51083", "Roigf_Edit", "Roigf") { vueRouteName = "form-ROIGF", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROIGF_DUPLICATE = new("ORDER_IN_GROUP__FLOA51083", "Roigf_Duplicate", "Roigf") { vueRouteName = "form-ROIGF", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROIGF_DELETE = new("ORDER_IN_GROUP__FLOA51083", "Roigf_Delete", "Roigf") { vueRouteName = "form-ROIGF", mode = "DELETE" };

		#endregion

		#region Roigf private

		private void FormHistoryLimits_Roigf()
		{

		}

		#endregion

		#region Roigf_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ROIGF]/

		[HttpPost]
		public ActionResult Roigf_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigf_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Show_GET",
				AreaName = "roigf",
				Location = ACTION_ROIGF_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ROIGF]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Roigf_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Roigf_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigf_New_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ROIGF]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Roigf/Roigf_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_New([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigf_New",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ROIGF]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Roigf_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigf_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Edit_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ROIGF]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Roigf/Roigf_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Edit([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Edit",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ROIGF]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Roigf_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigf_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Delete_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigf();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ROIGF]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Roigf/Roigf_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigf_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Roigf_Delete",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ROIGF]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Roigf_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROIGF");
		}

		#endregion

		#region Roigf_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ROIGF]/

		[HttpPost]
		public ActionResult Roigf_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Roigf_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Duplicate_GET",
				AreaName = "roigf",
				FormName = "ROIGF",
				Location = ACTION_ROIGF_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ROIGF]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Roigf/Roigf_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ROIGF]/
		[HttpPost]
		public ActionResult Roigf_Duplicate([FromBody]Roigf_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigf_Duplicate",
				ViewName = "Roigf",
				AreaName = "roigf",
				Location = ACTION_ROIGF_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ROIGF]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ROIGF]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ROIGF]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Roigf_Cancel

		//
		// GET: /Roigf/Roigf_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ROIGF]/
		public ActionResult Roigf_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("roigf");
					var model = GenioMVC.Models.Roigf.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("roigf");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL ROIGF]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ROIGF]/

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

				Navigation.SetValue("ForcePrimaryRead_roigf", "true", true);
			}

			Navigation.ClearValue("roigf");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Roigf_Rogl1ValTitleModel : RequestLookupModel
		{
			public Roigf_ViewModel Model { get; set; }
		}

		//
		// GET: /Roigf/Roigf_Rogl1ValTitle
		// POST: /Roigf/Roigf_Rogl1ValTitle
		[ActionName("Roigf_Rogl1ValTitle")]
		public ActionResult Roigf_Rogl1ValTitle([FromBody] Roigf_Rogl1ValTitleModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_rogl1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_rogl1");
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

			Models.Roigf parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Roigf_Rogl1ValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Roigf/Roigf_SaveEdit
		[HttpPost]
		public ActionResult Roigf_SaveEdit([FromBody] Roigf_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigf_SaveEdit",
				ViewName = "Roigf",
				AreaName = "roigf",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ROIGF]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ROIGF]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RoigfDocumValidateTickets : RequestDocumValidateTickets
		{
			public Roigf_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRoigf([FromBody] RoigfDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
