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
using GenioMVC.ViewModels.Tpeq1;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL GQT INCLUDE_CONTROLLER TPEQ1]/

namespace GenioMVC.Controllers
{
	public partial class Tpeq1Controller : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TPEQ1_CANCEL = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_Cancel", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TPEQ1_SHOW = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_Show", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TPEQ1_NEW = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_New", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TPEQ1_EDIT = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_Edit", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TPEQ1_DUPLICATE = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_Duplicate", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TPEQ1_DELETE = new("TYPE_OF_EQUIPMENT18080", "Tpeq1_Delete", "Tpeq1") { vueRouteName = "form-TPEQ1", mode = "DELETE" };

		#endregion

		#region Tpeq1 private

		private void FormHistoryLimits_Tpeq1()
		{

		}

		#endregion

		#region Tpeq1_Show

// USE /[MANUAL GQT CONTROLLER_SHOW TPEQ1]/

		[HttpPost]
		public ActionResult Tpeq1_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpeq1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Show_GET",
				AreaName = "tpeq1",
				Location = ACTION_TPEQ1_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpeq1();
// USE /[MANUAL GQT BEFORE_LOAD_SHOW TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_SHOW TPEQ1]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Tpeq1_New

// USE /[MANUAL GQT CONTROLLER_NEW_GET TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Tpeq1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_New_GET",
				AreaName = "tpeq1",
				FormName = "TPEQ1",
				Location = ACTION_TPEQ1_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Tpeq1();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW TPEQ1]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Tpeq1/Tpeq1_New
// USE /[MANUAL GQT CONTROLLER_NEW_POST TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_New([FromBody]Tpeq1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_New",
				ViewName = "Tpeq1",
				AreaName = "tpeq1",
				Location = ACTION_TPEQ1_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_NEW TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_NEW TPEQ1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_NEW_EX TPEQ1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_NEW_EX TPEQ1]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Tpeq1_Edit

// USE /[MANUAL GQT CONTROLLER_EDIT_GET TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpeq1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Edit_GET",
				AreaName = "tpeq1",
				FormName = "TPEQ1",
				Location = ACTION_TPEQ1_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpeq1();
// USE /[MANUAL GQT BEFORE_LOAD_EDIT TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT TPEQ1]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Tpeq1/Tpeq1_Edit
// USE /[MANUAL GQT CONTROLLER_EDIT_POST TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_Edit([FromBody]Tpeq1_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Edit",
				ViewName = "Tpeq1",
				AreaName = "tpeq1",
				Location = ACTION_TPEQ1_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_EDIT TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_EDIT TPEQ1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_EDIT_EX TPEQ1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_EDIT_EX TPEQ1]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Tpeq1_Delete

// USE /[MANUAL GQT CONTROLLER_DELETE_GET TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpeq1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Delete_GET",
				AreaName = "tpeq1",
				FormName = "TPEQ1",
				Location = ACTION_TPEQ1_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Tpeq1();
// USE /[MANUAL GQT BEFORE_LOAD_DELETE TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DELETE TPEQ1]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Tpeq1/Tpeq1_Delete
// USE /[MANUAL GQT CONTROLLER_DELETE_POST TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Tpeq1_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Delete",
				ViewName = "Tpeq1",
				AreaName = "tpeq1",
				Location = ACTION_TPEQ1_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_DESTROY_DELETE TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_DESTROY_DELETE TPEQ1]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Tpeq1_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TPEQ1");
		}

		#endregion

		#region Tpeq1_Duplicate

// USE /[MANUAL GQT CONTROLLER_DUPLICATE_GET TPEQ1]/

		[HttpPost]
		public ActionResult Tpeq1_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Tpeq1_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Duplicate_GET",
				AreaName = "tpeq1",
				FormName = "TPEQ1",
				Location = ACTION_TPEQ1_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE TPEQ1]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Tpeq1/Tpeq1_Duplicate
// USE /[MANUAL GQT CONTROLLER_DUPLICATE_POST TPEQ1]/
		[HttpPost]
		public ActionResult Tpeq1_Duplicate([FromBody]Tpeq1_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_Duplicate",
				ViewName = "Tpeq1",
				AreaName = "tpeq1",
				Location = ACTION_TPEQ1_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_SAVE_DUPLICATE TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_SAVE_DUPLICATE TPEQ1]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_LOAD_DUPLICATE_EX TPEQ1]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_LOAD_DUPLICATE_EX TPEQ1]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Tpeq1_Cancel

		//
		// GET: /Tpeq1/Tpeq1_Cancel
// USE /[MANUAL GQT CONTROLLER_CANCEL_GET TPEQ1]/
		public ActionResult Tpeq1_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var recordKey = Navigation.GetStrValue("tpeq1");
					var model = GenioMVC.Models.Tpeq1.Find(recordKey, UserContext.Current);
					if (model.ValZzstate == 0)
					{
						Navigation.ClearValue("tpeq1");
						string errorMessage = Resources.Resources.ESTE_REGISTO_JA_FOI_02595;
						Log.Error($"${errorMessage} ID: ${recordKey}");
						return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level, Warning = errorMessage });
					}

// USE /[MANUAL GQT BEFORE_CANCEL TPEQ1]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL GQT AFTER_CANCEL TPEQ1]/

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

				Navigation.SetValue("ForcePrimaryRead_tpeq1", "true", true);
			}

			Navigation.ClearValue("tpeq1");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Tpeq1_Fami1ValFamilyModel : RequestLookupModel
		{
			public Tpeq1_ViewModel Model { get; set; }
		}

		//
		// GET: /Tpeq1/Tpeq1_Fami1ValFamily
		// POST: /Tpeq1/Tpeq1_Fami1ValFamily
		[ActionName("Tpeq1_Fami1ValFamily")]
		public ActionResult Tpeq1_Fami1ValFamily([FromBody] Tpeq1_Fami1ValFamilyModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_fami1")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_fami1");
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

			Models.Tpeq1 parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Tpeq1_Fami1ValFamily_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Tpeq1/Tpeq1_SaveEdit
		[HttpPost]
		public ActionResult Tpeq1_SaveEdit([FromBody] Tpeq1_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Tpeq1_SaveEdit",
				ViewName = "Tpeq1",
				AreaName = "tpeq1",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL GQT BEFORE_APPLY_EDIT TPEQ1]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL GQT AFTER_APPLY_EDIT TPEQ1]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class Tpeq1DocumValidateTickets : RequestDocumValidateTickets
		{
			public Tpeq1_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTpeq1([FromBody] Tpeq1DocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
