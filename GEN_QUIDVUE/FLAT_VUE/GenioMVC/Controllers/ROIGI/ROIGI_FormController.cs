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
using GenioMVC.ViewModels.Roigi;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER ROIGI]/

namespace GenioMVC.Controllers
{
	public partial class RoigiController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_ROIGI_CANCEL = new("ORDER_IN_GROUP__INTE56416", "Roigi_Cancel", "Roigi") { vueRouteName = "form-ROIGI", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_ROIGI_SHOW = new("ORDER_IN_GROUP__INTE56416", "Roigi_Show", "Roigi") { vueRouteName = "form-ROIGI", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_ROIGI_NEW = new("ORDER_IN_GROUP__INTE56416", "Roigi_New", "Roigi") { vueRouteName = "form-ROIGI", mode = "NEW" };
		private static readonly NavigationLocation ACTION_ROIGI_EDIT = new("ORDER_IN_GROUP__INTE56416", "Roigi_Edit", "Roigi") { vueRouteName = "form-ROIGI", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_ROIGI_DUPLICATE = new("ORDER_IN_GROUP__INTE56416", "Roigi_Duplicate", "Roigi") { vueRouteName = "form-ROIGI", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_ROIGI_DELETE = new("ORDER_IN_GROUP__INTE56416", "Roigi_Delete", "Roigi") { vueRouteName = "form-ROIGI", mode = "DELETE" };

		#endregion

		#region Roigi private

		private void FormHistoryLimits_Roigi()
		{

		}

		#endregion

		#region Roigi_Show

// USE /[MANUAL GQT CONTROLLER_SHOW ROIGI]/

		[HttpPost]
		public ActionResult Roigi_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigi_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Show_GET",
				AreaName = "roigi",
				Location = ACTION_ROIGI_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW ROIGI]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Roigi_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Roigi_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigi_New_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW ROIGI]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Roigi/Roigi_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_New([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigi_New",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX ROIGI]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Roigi_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigi_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Edit_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT ROIGI]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Roigi/Roigi_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Edit([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Edit",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX ROIGI]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Roigi_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigi_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Delete_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Roigi();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE ROIGI]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Roigi/Roigi_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Roigi_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Roigi_Delete",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE ROIGI]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Roigi_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("ROIGI");
		}

		#endregion

		#region Roigi_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET ROIGI]/

		[HttpPost]
		public ActionResult Roigi_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Roigi_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Duplicate_GET",
				AreaName = "roigi",
				FormName = "ROIGI",
				Location = ACTION_ROIGI_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE ROIGI]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Roigi/Roigi_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST ROIGI]/
		[HttpPost]
		public ActionResult Roigi_Duplicate([FromBody]Roigi_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigi_Duplicate",
				ViewName = "Roigi",
				AreaName = "roigi",
				Location = ACTION_ROIGI_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE ROIGI]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX ROIGI]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX ROIGI]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Roigi_Cancel

		//
		// GET: /Roigi/Roigi_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET ROIGI]/
		public ActionResult Roigi_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("roigi");
					var model = GenioMVC.Models.Roigi.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("roigi");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL ROIGI]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL ROIGI]/

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

				Navigation.SetValue("ForcePrimaryRead_roigi", "true", true);
			}

			Navigation.ClearValue("roigi");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Roigi_Rogl1ValTitleModel : RequestLookupModel
		{
			public Roigi_ViewModel Model { get; set; }
		}

		//
		// GET: /Roigi/Roigi_Rogl1ValTitle
		// POST: /Roigi/Roigi_Rogl1ValTitle
		[ActionName("Roigi_Rogl1ValTitle")]
		public ActionResult Roigi_Rogl1ValTitle([FromBody] Roigi_Rogl1ValTitleModel requestModel)
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

			Models.Roigi parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Roigi_Rogl1ValTitle_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Roigi/Roigi_SaveEdit
		[HttpPost]
		public ActionResult Roigi_SaveEdit([FromBody] Roigi_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Roigi_SaveEdit",
				ViewName = "Roigi",
				AreaName = "roigi",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT ROIGI]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT ROIGI]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class RoigiDocumValidateTickets : RequestDocumValidateTickets
		{
			public Roigi_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsRoigi([FromBody] RoigiDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
